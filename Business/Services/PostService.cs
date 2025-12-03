using System.Data;
using System.Text;
using PMS.Business.Interface;
using PMS.Const;
using PMS.Model;
using PMS.Repository;

namespace PMS.Business.Services
{
    public class PostService(IStoredProcedureRepository procedureRepository,
                                 IHttpContextAccessor accessor) : IPostsService
    {
        private readonly IStoredProcedureRepository _procedureRepository = procedureRepository;
        private readonly IHttpContextAccessor _accessor = accessor;
        public async Task<bool> UpsertPost(UpsertPostsModel post)
        {
            var result = await _procedureRepository.ExecuteNonQueryAsync<UpsertPostsModel>(PMSConst.USP_UPSERT_POST, post);
            return result;
        }
        public async Task<DataTable> GetPostsList(PostsListModel post)
        {
            return await  _procedureRepository.GetDataTableAsync<PostsListModel>(PMSConst.USP_GET_POSTS_LIST, post);

        }
    }
}