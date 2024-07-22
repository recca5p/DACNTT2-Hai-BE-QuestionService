namespace UserService.Models;

public class SubjectModel
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public string CreatedByName { get; set; }
    public long CreatedById { get; set; }
}