using APBDZad5.Models;
using APBDZad5.Repositories;

namespace APBDZad5.Services;

public class AnimalService(IAnimalsRepository animalRepository) : IAnimalsService
{
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        return animalRepository.GetAnimals(orderBy);
    }

    public int CreateAnimal(Animal animal)
    {
        return animalRepository.CreateAnimal(animal);
    }

    public int UpdateAnimal(int id, Animal animal)
    {
        return animalRepository.UpdateAnimal(id, animal);
    }

    public int DeleteAnimal(int id)
    {
        return animalRepository.DeleteAnimal(id);
    }
}