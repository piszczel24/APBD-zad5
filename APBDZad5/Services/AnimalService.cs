using APBDZad5.Models;
using APBDZad5.Repositories;

namespace APBDZad5.Services;

public class AnimalService(IAnimalsRepository animalsRepository) : IAnimalsService
{
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        var data = animalsRepository.GetAnimals(orderBy);
        return data;
    }
}