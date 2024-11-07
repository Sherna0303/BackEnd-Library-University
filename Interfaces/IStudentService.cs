using LibrarySystemWeb.Models;

namespace LibrarySystemWeb.Interfaces;

public interface IStudentService
{
    List<Users> GetAll();
    Student GetById(int id);
    void Add(Student student);
    void Update(Student student);
    void Delete(int id);
}