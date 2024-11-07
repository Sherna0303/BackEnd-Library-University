using LibrarySystemWeb.Context;
using LibrarySystemWeb.Interfaces;
using LibrarySystemWeb.Models;
using LibrarySystemWeb.Models.Enum;

namespace LibrarySystemWeb.Services;

public class UserService : IUserService {
    private readonly ApplicationDbContext _dbContext;

    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<User> GetAll() => _dbContext.Users.Where(u => u.Role==RoleEnum.STUDENT).ToList();

    public User? GetById(int id) => _dbContext.Users.FirstOrDefault(s => s.Id == id);

    public void Add(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public void Update(User user)
    {
        _dbContext.Users.Update(user);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var userToRemove = _dbContext.Users.FirstOrDefault(s => s.Id == id);
        if (userToRemove != null)
        {
            _dbContext.Users.Remove(userToRemove);
            _dbContext.SaveChanges();
        }
    }
}
