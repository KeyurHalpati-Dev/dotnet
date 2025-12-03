using System.Data;
using PMS.Model;

namespace PMS.Business.Interface
{
    public interface IPostsService
    {
        Task<bool> UpsertPost(UpsertPostsModel post);
        Task<DataTable> GetPostsList(PostsListModel post);
    }
}