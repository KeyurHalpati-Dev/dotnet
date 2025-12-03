using Microsoft.EntityFrameworkCore;

namespace PMS.Repository.DBContext
{
    public partial class API_DbContext(DbContextOptions<API_DbContext> options)
                    : DbContext(options)
    {
    }
}