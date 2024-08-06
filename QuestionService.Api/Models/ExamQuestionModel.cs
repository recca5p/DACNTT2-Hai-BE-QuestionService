using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class ExamQuestionModel
{
    public int QuestionTypeId { get; set; }
    public string QuestionTypeName { get; set; }
    public string QuestionTypeDisplayTitle { get; set; }
    [JsonIgnore]
    public string Questions { get; set; }

    public List<Question> QuestionsList
    {
        get
        {
            if (!string.IsNullOrEmpty(Questions))
            {
                try
                {
                    return JsonSerializer.Deserialize<List<Question>>(Questions);
                }
                catch (JsonException)
                {
                    // Handle or log the exception as needed
                    return new List<Question>();
                }
            }
            return new List<Question>();
        }
    }
}


public class Question
{
    public int QuestionId { get; set; }
    public string QuestionTitle { get; set; }
    public List<AnswerChoice> AnswerChoice { get; set; }
    public string RightAnswer { get; set; }
}

public class AnswerChoice
{
    public string Choice { get; set; }
}
