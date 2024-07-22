namespace UserService.Models
{
    public class CreateOrUpdateChapterReq
    {
        public int? ChapterId { get; set; }
        public string ChapterName { get; set; }
        public int SubjectId { get; set; }
        public long CreatedBy { get; set; }
        public string CreatedByName { get; set; }
    }
}
