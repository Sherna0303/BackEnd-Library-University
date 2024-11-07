using LibrarySystemWeb.Interfaces;
using LibrarySystemWeb.Models;
using LibrarySystemWeb.Models.Enum;

namespace LibrarySystemWeb.Services;

public class StudentService : IStudentService {
    private readonly ApplicationDbContext _dbContext;

    public StudentService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Users> GetAll() => _dbContext.Users.Where(u => u.Role==RoleEnum.STUDENT).ToList();

    public Student GetById(int id) => _dbContext.Students.FirstOrDefault(s => s.Id == id);

    public void Add(Student student)
    {
        _dbContext.Students.Add(student);
        _dbContext.SaveChanges();
    }

    public void Update(Student student)
    {
        _dbContext.Students.Update(student);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var studentToRemove = _dbContext.Students.FirstOrDefault(s => s.Id == id);
        if (studentToRemove != null)
        {
            _dbContext.Students.Remove(studentToRemove);
            _dbContext.SaveChanges();
        }
    }
}
