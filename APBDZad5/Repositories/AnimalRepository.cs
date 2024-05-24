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

        if (!columns.TryGetValue(orderBy, out var value))
            throw new ArgumentException($"Niepoprawna warotość parametru orderBy: {orderBy}");

        var query =
            "select IdAnimal, Name, Description, Category, Area " +
            "from Animal " +
            $"order by {value} asc";

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

    public int CreateAnimal(Animal animal)
    {
        ArgumentNullException.ThrowIfNull(animal);

        if (string.IsNullOrEmpty(animal.Name) || string.IsNullOrEmpty(animal.Description) ||
            string.IsNullOrEmpty(animal.Category) || string.IsNullOrEmpty(animal.Area))
            throw new ArgumentException("Atrybuty Name, Category oraz Area nie mogą być ani puste, ani być nullem");

        using var con = new SqlConnection(ConnectionString);
        con.Open();

        const string query = "insert into Animal (IdAnimal, Name, Description, Category, Area) " +
                             "values (@IdAnimal, @Name, @Description, @Category, @Area)";
        using var cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);

        var affectedRowsCout = cmd.ExecuteNonQuery();
        return affectedRowsCout;
    }

    public int UpdateAnimal(int id, Animal animal)
    {
        ArgumentNullException.ThrowIfNull(animal);

        if (string.IsNullOrEmpty(animal.Name) || string.IsNullOrEmpty(animal.Description) ||
            string.IsNullOrEmpty(animal.Category) || string.IsNullOrEmpty(animal.Area))
            throw new ArgumentException("Atrybuty Name, Category oraz Area nie mogą być ani puste, ani być nullem");

        using var con = new SqlConnection(ConnectionString);
        con.Open();

        const string query =
            "update Animal " +
            "set Name = @Name, Description = @Description, Category = @Category, Area = @Area " +
            "where IdAnimal = @IdAnimal";

        using var cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        cmd.Parameters.AddWithValue("@IdAnimal", id);

        var affectedRowsCout = cmd.ExecuteNonQuery();
        return affectedRowsCout;
    }

    public int DeleteAnimal(int id)
    {
        using var con = new SqlConnection(ConnectionString);
        con.Open();

        const string query =
            "delete from Animal " +
            "where IdAnimal = @IdAnimal";

        using var cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@IdAnimal", id);

        var affectedRowsCount = cmd.ExecuteNonQuery();
        return affectedRowsCount;
    }
}