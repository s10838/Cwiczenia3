using System.Reflection;
using Cwiczenia3.Model;

namespace Cwiczenia3.Repositories;

public interface IAnimalsRepository
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    int CreateAnimal(Animal animal);
   
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idAnimal);

}