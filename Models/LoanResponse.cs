namespace LibrarySystemWeb.Models;

public class LoanResponse : Loan
{
    public string BookName { get; set; }
    public string StudentName { get; set; }
}