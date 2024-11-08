using LibrarySystemWeb.Interfaces;
using LibrarySystemWeb.Models;
using LibrarySystemWeb.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystemWeb.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")] 
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public List<User> GetAllUsers()
    {
        return _userService.GetAll();
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _userService.GetById(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public IActionResult AddUser(User user)
    {
        _userService.Add(user);
        return Created($"/students/{user.Id}", user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, UserUpdateDto user )
    {
        if (id != user.Id) return BadRequest();

        _userService.Update(user);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        _userService.Delete(id);
        return NoContent();
    }
}