using LibrarySystemWeb.Interfaces;
using LibrarySystemWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystemWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class LoansController : ControllerBase
{
    private readonly ILoanService _loanService;

    public LoansController(ILoanService loanService)
    {
        _loanService = loanService;
    }

    [HttpGet]
    public IEnumerable<Loan> GetAllLoans()
    {
        return _loanService.GetAll();
    }

    [HttpGet("{id}")]
    public IActionResult GetLoanById(int id)
    {
        var loan = _loanService.GetById(id);
        if (loan == null) return NotFound();
        return Ok(loan);
    }

    [HttpPost]
    public IActionResult AddLoan(Loan loan)
    {
        _loanService.Add(loan);
        return Created($"/loans/{loan.Id}", loan);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateLoan(int id, Loan loan)
    {
        if (id != loan.Id) return BadRequest();

        _loanService.Update(loan);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteLoan(int id)
    {
        _loanService.Delete(id);
        return NoContent();
    }
}