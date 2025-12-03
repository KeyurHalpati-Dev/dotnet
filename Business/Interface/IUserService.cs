using System.Data;
using PMS.Model;

namespace PMS.Business.Interface
{
    public interface IUserService 
    {
        Task<DataTable> UserLogin(UserLoginModel user);
        Task<bool> RegisterUser(UserRegisterModel user);
    }
}