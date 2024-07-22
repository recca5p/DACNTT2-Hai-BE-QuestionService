namespace UserService.Models
{
    public class QuestionFilterParameters
    {
        public int[] CreatedBy { get; set; }
        public int[] SubjectIds { get; set; }
        public int[] ChapterIds { get; set; }
        public int[] Levels { get; set; }
        public int[] QuestionTypeId { get; set; }
        public string Search { get; set; }
    }
}
