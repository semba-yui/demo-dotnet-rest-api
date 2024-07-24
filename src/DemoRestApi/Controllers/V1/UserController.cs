using System.Net.Mime;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SembaYui.DemoRestApi.Exceptions;
using SembaYui.DemoRestApi.Models.Responses;
using SembaYui.DemoRestApi.Models.Responses.User;
using SembaYui.DemoRestApi.Repositories.Interfaces;
using Serilog;

namespace SembaYui.DemoRestApi.Controllers.V1;

/// <summary>
///     User Controller
/// </summary>
/// <param name="dateTimeRepository"></param>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UserController(IDateTimeRepository dateTimeRepository) : Controller
{
    /// <summary>
    ///     Get User
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "GetUser")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        Log.Information("calling GetUser.");
        var now = dateTimeRepository.Now;
        Log.Information(now.ToShortDateString());

        var user = new User(1, "Semba Yui");

        var response = new UserResponse(ResponseCodes.Success, now, user);

        return Ok(response);
    }

    /// <summary>
    ///     Get User By Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}", Name = "GetUserById")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    public IActionResult GetById(int id)
    {
        Log.Information("calling GetUserById.");
        var now = dateTimeRepository.Now;
        Log.Information(now.ToShortDateString());

        var user = new User(id, "Semba Yui By Id");

        var response = new UserResponse(ResponseCodes.Success, now, user);

        return Ok(response);
    }

    /// <summary>
    ///     Create User
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost(Name = "CreateUser")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] User user)
    {
        Log.Information("calling CreateUser.");
        var now = dateTimeRepository.Now;
        Log.Information(now.ToShortDateString());

        var response = new UserResponse(ResponseCodes.Success, now, user);

        return CreatedAtRoute("GetUserById", new { id = user.Id }, response);
    }

    /// <summary>
    ///     Update User
    /// </summary>
    /// <param name="id"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    /// <exception cref="OriginalApplicationException"></exception>
    [HttpPut("{id:int}", Name = "UpdateUser")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    public IActionResult Update(int id, [FromBody] User user)
    {
        Log.Information("calling UpdateUser.");
        var now = dateTimeRepository.Now;
        Log.Information(now.ToShortDateString());

        throw new OriginalApplicationException("UpdateUser Exception");
    }

    /// <summary>
    ///     Delete User
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="OriginalSystemException"></exception>
    [HttpDelete("{id:int}", Name = "DeleteUser")]
    [ProducesResponseType(typeof(SuccessResponse), StatusCodes.Status200OK)]
    public IActionResult Delete(int id)
    {
        Log.Information("calling DeleteUser.");
        var now = dateTimeRepository.Now;
        Log.Information(now.ToShortDateString());

        throw new OriginalSystemException("DeleteUser Exception");
    }
}
