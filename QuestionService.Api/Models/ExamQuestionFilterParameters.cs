namespace UserService.Models
{
    public class ExamQuestionFilterParameters
    {
        public int[] Levels { get; set; }
        public int[] SubjectIds { get; set; }
        public int[] ChapterIds { get; set; }
        public int[] CreatedBy { get; set; }
    }
}
