namespace SecondExam.Entities;

public class Author
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ICollection<EducationalMaterial>? Materials { get; set; }
    public int? CreatedMaterials => Materials?.Count;
}
