namespace SecondExam.Entities;

public class EducationalMaterialType
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Definition { get; set; }
    public ICollection<EducationalMaterial>? EducationalMaterials { get; set; }
}
