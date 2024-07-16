using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities;
using Npgsql;

[Route("api/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public QuestionController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }

    [HttpGet]
    public async Task<IActionResult> GetQuestions()
    {
        var createdBy = new int[] { 1, 2 }; // example data
        var subjectIds = new int[] { 3, 4 }; // example data
        var chapterIds = new int[] { 5, 6 }; // example data
        var levels = new int[] { 1, 2 }; // example data
        var questionTypeId = new int[] { 1, 2 }; // example data
        var search = "example search"; // example data

        using (var connection = CreateConnection())
        {
            connection.Open();

            var parameters = new
            {
                p_created_by = createdBy,
                p_subject_ids = subjectIds,
                p_chapter_ids = chapterIds,
                p_levels = levels,
                p_question_type_id = questionTypeId,
                p_search = search
            };

            var sql = "SELECT * FROM get_questions(@p_created_by, @p_subject_ids, @p_chapter_ids, @p_levels, @p_question_type_id, @p_search);";
            var result = await connection.QueryAsync<Question>(sql, parameters);
            return new JsonResult(result);
        }
    }
}