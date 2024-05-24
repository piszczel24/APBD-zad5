using APBDZad5.Models;

namespace APBDZad5.Repositories;

public interface IAnimalsRepository
{
    IEnumerable<Animal> GetAnimals(string orderBy);
}