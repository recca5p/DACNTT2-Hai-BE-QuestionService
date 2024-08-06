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
using UserService.Models;
using System.Text.Json;

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
        var connect = _configuration.GetConnectionString("DefaultConnection");
        return new NpgsqlConnection(connect);
    }

    [HttpGet("get-question")]
    public async Task<IActionResult> GetQuestions([FromQuery] QuestionFilterParameters filterParameters)
    {
        using (var connection = CreateConnection())
        {
            connection.Open();

            var parameters = new
            {
                p_created_by = filterParameters.CreatedBy,
                p_subject_ids = filterParameters.SubjectIds,
                p_chapter_ids = filterParameters.ChapterIds,
                p_levels = filterParameters.Levels,
                p_question_type_id = filterParameters.QuestionTypeId,
                p_search = filterParameters.Search
            };

            var sql = "SELECT * FROM get_questions(@p_created_by, @p_subject_ids, @p_chapter_ids, @p_levels, @p_question_type_id, @p_search);";
            var result = await connection.QueryAsync<QuestionModel>(sql, parameters);
            return new JsonResult(result);
        }
    }

    [HttpGet("get-subjects")]
    public async Task<IActionResult> GetSubjects([FromQuery] long CreatedBy)
    {
        using (var connection = CreateConnection())
        {
            connection.Open();

            var parameters = new
            {
                p_created_by = CreatedBy
            };

            var sql = "SELECT * FROM get_subjects(@p_created_by);";
            var result = await connection.QueryAsync<SubjectModel>(sql, parameters);
            return new JsonResult(result);
        }
    }

    [HttpGet("get-chapter")]
    public async Task<IActionResult> GetChapters([FromQuery] int SubjectId, [FromQuery] long CreatedBy)
    {
        using (var connection = CreateConnection())
        {
            connection.Open();

            var parameters = new
            {
                p_subject_id = SubjectId,
                p_created_by = CreatedBy
            };

            var sql = "SELECT * FROM get_chapters(@p_subject_id,@p_created_by);";
            var result = await connection.QueryAsync<ChapterModel>(sql, parameters);
            return new JsonResult(result);
        }
    }
    [HttpGet("get-level")]
    public async Task<IActionResult> GetLevels()
    {
        using (var connection = CreateConnection())
        {
            connection.Open();
            var sql = "SELECT * FROM get_active_levels();";
            var result = await connection.QueryAsync<LevelModel>(sql);
            return new JsonResult(result);
        }
    }

    [HttpDelete("delete-chapter/{chapterId}")]
    public async Task<IActionResult> DeleteChapter(int chapterId)
    {
        using (var connection = CreateConnection())
        {
            connection.Open();

            var parameters = new { p_chapter_id = chapterId };
            var sql = "SELECT * FROM delete_chapter(@p_chapter_id);";
            var result = await connection.QueryFirstOrDefaultAsync<ReturnMessage>(sql, parameters);
            return new JsonResult(result);
        }
    }

    [HttpPost("upsert-chapter")]
    public async Task<IActionResult> UpsertChapter([FromBody] CreateOrUpdateChapterReq model)
    {
        using (var connection = CreateConnection())
        {
            connection.Open();

            var parameters = new
            {
                p_chapter_id = model.ChapterId,
                p_chapter_name = model.ChapterName,
                p_subject_id = model.SubjectId,
                p_created_by = model.CreatedBy,
                p_created_by_name = model.CreatedByName
            };

            var sql = "SELECT * FROM upsert_chapter(@p_chapter_id, @p_chapter_name, @p_subject_id, @p_created_by, @p_created_by_name);";
            var result = await connection.QueryFirstOrDefaultAsync<ReturnMessage>(sql, parameters);

            return new JsonResult(result);
        }
    }

    [HttpDelete("delete-subject/{subjectId}")]
    public async Task<IActionResult> DeleteSubject(int subjectId)
    {
        using (var connection = CreateConnection())
        {
            connection.Open();

            var parameters = new { p_subject_id = subjectId };
            var sql = "SELECT * FROM delete_subject(@p_subject_id);";
            var result = await connection.QueryFirstOrDefaultAsync<ReturnMessage>(sql, parameters);
            return new JsonResult(result);
        }
    }

    [HttpPost("upsert-subject")]
    public async Task<IActionResult> UpsertSubject([FromBody] CreateOrUpdateSubjectReq model)
    {
        using (var connection = CreateConnection())
        {
            connection.Open();

            var parameters = new
            {
                p_subject_id = model.SubjectId,
                p_subject_name = model.SubjectName,
                p_created_by = model.CreatedBy,
                p_created_by_name = model.CreatedByName
            };

            var sql = "SELECT * FROM upsert_subject(@p_subject_id, @p_subject_name, @p_created_by, @p_created_by_name);";
            var result = await connection.QueryFirstOrDefaultAsync<ReturnMessage>(sql, parameters);

            return new JsonResult(result);
        }
    }

    [HttpGet("get-exam-question")]
    public async Task<IActionResult> GetExamQuestions([FromQuery] ExamQuestionFilterParameters filterParameters)
    {
        using (var connection = CreateConnection())
        {
            connection.Open();

            var parameters = new
            {
                p_levels = filterParameters.Levels,
                p_subjects = filterParameters.SubjectIds,
                p_chapters = filterParameters.ChapterIds,
                p_create_by = filterParameters.CreatedBy
            };

            var sql = "SELECT * FROM get_exam_questions(@p_levels, @p_subjects, @p_chapters, @p_create_by);";
            var result = await connection.QueryAsync<ExamQuestionModel>(sql, parameters);
            return new JsonResult(result);
        }
    }

}