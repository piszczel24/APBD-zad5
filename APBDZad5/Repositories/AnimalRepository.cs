using System.Data.SqlClient;
using APBDZad5.Models;

namespace APBDZad5.Repositories;

public class AnimalRepository : IAnimalsRepository
{
    private const string ConnectionString = "Server=db-mssql16;Database=s26479;Trusted_Connection=True;";

    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        using var con = new SqlConnection(ConnectionString);
        con.Open();

        var columns = new Dictionary<string, string>
        {
            ["name"] = "Name",
            ["description"] = "Description",
            ["category"] = "Category",
            ["area"] = "Area"
        };

        var query =
            "select IdAnimal, Name, Description, Category, Area " +
            "from Animal " +
            $"order by {columns[orderBy]} asc";

        using var cmd = new SqlCommand(query, con);
        var reader = cmd.ExecuteReader();

        var animals = new List<Animal>();
        while (reader.Read())
        {
            var animal = new Animal
            {
                IdAnimal = (int)reader["IdAnimal"],
                Name = reader["Name"].ToString() ?? string.Empty,
                Description = reader["Description"].ToString(),
                Category = reader["Category"].ToString() ?? string.Empty,
                Area = reader["Area"].ToString() ?? string.Empty
            };
            animals.Add(animal);
        }

        return animals;
    }
}