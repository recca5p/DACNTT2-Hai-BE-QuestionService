namespace UserService.Models
{
    public class CreateOrUpdateSubjectReq
    {
        public int? SubjectId { get; set; }
        public string SubjectName { get; set; }
        public long CreatedBy { get; set; }
        public string CreatedByName { get; set; }
    }
}
