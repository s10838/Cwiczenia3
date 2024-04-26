using Cwiczenia3.Model;

namespace Cwiczenia3.Services;

public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    int CreateAnimal(Animal animal);
 
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idAnimal);
}