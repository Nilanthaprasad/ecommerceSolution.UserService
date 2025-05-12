using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DBContext;


namespace eCommerce.Infrastructure.Repositories;

internal class UsersRepository : IUsersRepository
{
    public readonly DapperDbContext _dbcontext;

    public UsersRepository(DapperDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        //Generate a new unique user ID for the user
        user.UserID = Guid.NewGuid();
        string query = "INSERT INTO public.\"Users\"(\"UserID\", \"Email\", \"PersonName\", \"Gender\", \"Password\" ) " +
                                            "VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";
        int rowCountAffected = await _dbcontext.DbConnection.ExecuteAsync(query, user);
        if(rowCountAffected > 0)
        {
            return user;
        }
        else
        {
            return null;
        }
         
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        string query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";
        var parameters = new { Email = email, Password = password };
        ApplicationUser? user = await _dbcontext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);

        return user;
        /*
        return new ApplicationUser()
        {
            UserID = Guid.NewGuid(),
            Email = email,
            Password = password,
            PersonName = "Person name",
            Gender = GenderOptions.Male.ToString()
        };
        */

    }
}
