using System.Data;
using System.Runtime.Intrinsics.Arm;
using CustomeAttributes;
using Microsoft.AspNetCore.Mvc;
using PMS.Business.Interface;
using PMS.Model;
using PMS.Models.ApiResponse;

namespace PMS.Controllers;

[ApiController]
[Route(CustomeAttr.AttName)]
public class PostController(IPostsService service) : ControllerBase
{
    private readonly IPostsService _postsService = service;

    [HttpPost("UpsertPost")]
    public async Task<IActionResult> UpsertPost([FromBody] UpsertPostsModel post)
    {
        var result = await _postsService.UpsertPost(post);

        if (result)
        {
            return Ok(new Response
            {
                statuscode = 201,
                message = "Post upserted successfully",
                error_status = false,
                data = null
            });
        }
        else
        {
            return Ok(new Response
            {
                statuscode = 404,
                message = "Invalid credentials or no data found",
                error_status = true,
                data = null
            });
        }
    }
    [HttpPost("GetPostsList")]
    public async Task<IActionResult> GetPostsList([FromBody] PostsListModel postsListModel)
    {
        DataTable dt = await _postsService.GetPostsList(postsListModel);

        if (dt == null || dt.Rows.Count == 0)
        {
            return Ok(new Response
            {
                statuscode = 404,
                message = "No posts found for the user",
                error_status = true,
                data = null
            });
        }
        else
        {
            return Ok(new Response
            {
                statuscode = 200,
                message = "Posts fetched successfully",
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


}