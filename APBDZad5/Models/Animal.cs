namespace APBDZad5.Models;

public class Animal
{
    public int IdAnimal { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string Category { get; set; }
    public required string Area { get; set; }
}