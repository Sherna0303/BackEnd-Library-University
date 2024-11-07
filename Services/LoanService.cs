using LibrarySystemWeb.Context;
using LibrarySystemWeb.Interfaces;
using LibrarySystemWeb.Models;

namespace LibrarySystemWeb.Services;

public class LoanService : ILoanService
{
    private readonly ApplicationDbContext _dbContext;

    public LoanService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<LoanResponse> GetAll()
    {
        var loans = _dbContext.Loans.ToList();
        var loanResponses = new List<LoanResponse>();

        foreach (var loan in loans)
        {
            var loanResponse = new LoanResponse
            {
                Id = loan.Id,
                Created = loan.Created,
                Student_Id = loan.Student_Id,
                Book_Id = loan.Book_Id,
                BookName = GetBookName(loan.Book_Id),
                StudentName = GetUserName(loan.Student_Id)
            };

            loanResponses.Add(loanResponse);
        }

        return loanResponses;
    }

    public LoanResponse GetById(int id)
    {
        var loan = _dbContext.Loans.FirstOrDefault(s => s.Id == id);
        if (loan == null) return null;

        var loanResponse = new LoanResponse
        {
            Id = loan.Id,
            Created = loan.Created,
            Student_Id = loan.Student_Id,
            Book_Id = loan.Book_Id,
            BookName = GetBookName(loan.Book_Id),
            StudentName = GetUserName(loan.Student_Id)
        };

        return loanResponse;
    }
    
    public List<LoanResponse> GetMain(int userId)
    {
        var loans = _dbContext.Loans.Where(l => l.Student_Id==userId).ToList();
        var loanResponses = new List<LoanResponse>();

        foreach (var loan in loans)
        {
            var loanResponse = new LoanResponse
            {
                Id = loan.Id,
                Created = loan.Created,
                Student_Id = loan.Student_Id,
                Book_Id = loan.Book_Id,
                BookName = GetBookName(loan.Book_Id),
                StudentName = GetUserName(loan.Student_Id)
            };

            loanResponses.Add(loanResponse);
        }

        return loanResponses;
    }

    public void Add(Loan loan)
    {
        _dbContext.Loans.Add(loan);
        _dbContext.SaveChanges();
    }

    public void Update(Loan loan)
    {
        _dbContext.Loans.Update(loan);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var loanToRemove = _dbContext.Loans.FirstOrDefault(s => s.Id == id);
        if (loanToRemove != null)
        {
            _dbContext.Loans.Remove(loanToRemove);
            _dbContext.SaveChanges();
        }
    }

    public string GetBookName(int bookId)
    {
        var book = _dbContext.Books.FirstOrDefault(b => b.Id == bookId);
        return
            book != null
                ? book.Name
                : "Book not found";
    }

    public string GetUserName(int userId)
    {
        var user = _dbContext.Users.FirstOrDefault(b => b.Id == userId);
        return
            user != null
                ? user.Name
                : "User not found";
    }
}