using APBDZad5.Models;

namespace APBDZad5.Repositories;

public interface IAnimalsRepository
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    int CreateAnimal(Animal animal);
    int UpdateAnimal(int id, Animal animal);
    int DeleteAnimal(int id);
}