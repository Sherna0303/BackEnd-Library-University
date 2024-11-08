using LibrarySystemWeb.Models;
using LibrarySystemWeb.Models.Dtos;

namespace LibrarySystemWeb.Interfaces;

public interface IUserService
{
    List<User> GetAll();
    User? GetById(int id);
    void Add(User user);
    void Update( UserUpdateDto user );
    void Delete(int id);
}