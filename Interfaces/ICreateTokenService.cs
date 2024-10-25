using LibrarySystemWeb.Models;

namespace LibrarySystemWeb.Interfaces
{
    public interface ICreateTokenService
    {
        Task<string> GenerateToken( Users user );
    }
}
