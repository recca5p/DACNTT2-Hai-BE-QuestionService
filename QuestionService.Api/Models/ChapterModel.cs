namespace UserService.Models;

public class ChapterModel
{
    public int ChapterId { get; set; }
    public string ChapterName { get; set; }
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public string CreatedByName { get; set; }
    public long CreatedById { get; set; }
}