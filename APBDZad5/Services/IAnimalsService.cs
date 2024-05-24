using APBDZad5.Models;

namespace APBDZad5.Services;

public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimals(string orderBy);
}