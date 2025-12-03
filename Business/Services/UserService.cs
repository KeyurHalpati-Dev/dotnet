using System.Data;
using System.Text;
using PMS.Business.Interface;
using PMS.Const;
using PMS.Model;
using PMS.Repository;

namespace PMS.Business.Services
{
    public class UserService (IStoredProcedureRepository procedureRepository,
                                  IHttpContextAccessor accessor): IUserService
    {
        private readonly IStoredProcedureRepository _procedureRepository = procedureRepository;
        private readonly IHttpContextAccessor _accessor = accessor;
        // private readonly IStoredProcedure _storedProcedure;
        // public UserService(IStoredProcedure storedProcedure)
        // {
        //     _storedProcedure = storedProcedure;
        // }
        public async Task<DataTable> UserLogin(UserLoginModel user)
        {
            return await _procedureRepository.GetDataTableAsync<UserLoginModel>(PMSConst.USP_USER_LOGIN, user);
        }
        public async Task<bool> RegisterUser(UserRegisterModel user)
        {
            var result = await _procedureRepository.ExecuteNonQueryAsync<UserRegisterModel>(PMSConst.USP_USER_REGISTER, user);
            return result;
        }

    }
}