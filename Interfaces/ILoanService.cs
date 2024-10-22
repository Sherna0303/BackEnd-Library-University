using LibrarySystemWeb.Models;

namespace LibrarySystemWeb.Interfaces;

public interface ILoanService
{
    IEnumerable<LoanResponse> GetAll();
    LoanResponse GetById(int id);
    void Add(Loan loan);
    void Update(Loan loan);
    void Delete(int id);
}