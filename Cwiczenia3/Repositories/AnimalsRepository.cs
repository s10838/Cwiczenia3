using System.Collections;
using System.Data.SqlClient;
using Cwiczenia3.Model;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace Cwiczenia3.Repositories;

public class AnimalsRepository : IAnimalsRepository 
{

private IConfiguration _configuration;


public AnimalsRepository(IConfiguration configuration)
{
    _configuration = configuration;
}

    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;

        switch (orderBy.ToLower())
        {
            case "name":
                cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY Name";
                break;
            case "description":
                cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY Description";
                break;
            case "category":
                cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY Category";
                break;
            case "area":
                cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY Area";

                break;
            default:
                cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY Name";

                break;
        }
        
      
      
        var dr = cmd.ExecuteReader();

        var animals = new List<Animal>();
        while (dr.Read())
        {
            var a = new Animal
            {
                IdAnimal = (int)dr["IdAnimal"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Category = dr["Category"].ToString(),
                Area = dr["Area"].ToString(),
              
            };
            animals.Add(a);
        }
     
        return animals;
    }
        
        
    


    public int CreateAnimal(Animal animal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
 
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        
      
        cmd.CommandText = "INSERT INTO Animal(IdAnimal, Name, Description, Category, Area) VALUES(@IdAnimal, @Name, @Description, @Category, @Area)";
        cmd.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        
        
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;  
        
    }
    
    public int UpdateAnimal(Animal animal)
    {
    
        
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
       
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE Animal SET IdAnimal=@IdAnimal, Name=@Name, Description=@Description, Category=@Category, Area=@Area WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
       
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
        
        
    }

    public int DeleteAnimal(int idAnimal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
 
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM Animal WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);
 
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
}