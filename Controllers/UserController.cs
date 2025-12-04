using System.Data;
// using System.Runtime.Intrinsics.Arm;
using CustomeAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMS.Business.Interface;
using PMS.Model;
using PMS.Models.ApiResponse;

namespace PMS.Controllers;

[ApiController]
[Route(CustomeAttr.AttName)]
public class UserController(IUserService service) : ControllerBase
{
    private readonly IUserService _userService = service;

    [HttpPost("GetUserData")]
    public async Task<IActionResult> GetUserData([FromBody] UserLoginModel user)
    {
        DataTable dt = await _userService.UserLogin(user);

        if (dt == null || dt.Rows.Count == 0)
        {
            return Ok(new Response
            {
                statuscode = 404,
                message = "Invalid credentials or no data found",
                error_status = true,
                data = null
            });
        }
        else
        {
            return Ok(new Response
            {
                statuscode = 200,
                message = "User data fetched successfully",
                error_status = false,
                data = dt
            });
        }
        // Convert DataTable → List<Dictionary<string, object>>
        // var dataList = new List<Dictionary<string, object>>();
        // foreach (DataRow row in dt.Rows)
        // {
        //     var dict = new Dictionary<string, object>();
        //     foreach (DataColumn col in dt.Columns)
        //     {
        //         var value = row[col];
        //         dict[col.ColumnName] = value == DBNull.Value ? "" : value;
        //     }
        //     dataList.Add(dict);
        // }
    }
    
    [HttpGet("RegisterUser")]
    public async Task<IActionResult> RegisterUser(UserRegisterModel user)
    {      
        // var result = await _userService.RegisterUser(user);
        // if (result)
        // {
        //     return Ok(new Response
        //     {
        //         statuscode = 201,
        //         message = "User registered successfully",
        //         error_status = false,
        //         data = "Hello"
        //     });
        // }
        // else
        // {
        //     return Ok(new Response
        //     {
        //         statuscode = 400,
        //         message = "User registration failed",
        //         error_status = true,
        //         data ="Hello"
        //     });
        // }
        return Ok(new Response
            {
                statuscode = 400,
                message = "User registration failed",
                error_status = true,
                data ="Hello"
            });
    }
     [HttpGet("StaticUser")]
    public async Task<IActionResult> StaticUser()
    {
        var result =  new[]
            {
            new
            {
                id = 1,
                name = "John Doe Holla",
                email = "john.doe@example.com",
                age = 28,
                city = "New York"
            },
            new
            {
                id = 2,
                name = "Jane Smith",
                email = "jane.smith@example.com",
                age = 34,
                city = "Los Angeles"
            },
            new
            {
                id = 3,
                name = "Mike Johnson",
                email = "mike.johnson@example.com",
                age = 42,
                city = "Chicago"
            },
            new
            {
                id = 4,
                name = "Sarah Williams",
                email = "sarah.williams@example.com",
                age = 29,
                city = "Houston"
            },
            new
            {
                id = 5,
                name = "David Brown",
                email = "david.brown@example.com",
                age = 37,
                city = "Phoenix"
            }
        };

        return Ok(await Task.FromResult(result));
    }


}