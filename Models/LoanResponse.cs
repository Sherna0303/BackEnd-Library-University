namespace LibrarySystemWeb.Models;

public class LoanResponse : Loan
{
    public string BookName { get; set; } = default!;
    public string StudentName { get; set; } = default!;
}