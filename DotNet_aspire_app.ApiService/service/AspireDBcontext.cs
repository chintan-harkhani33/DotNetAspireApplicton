using DotNet_aspire_app.ApiService.model;
using Microsoft.EntityFrameworkCore;

namespace DotNet_aspire_app.ApiService.service
{
    public class AspireDBcontext : DbContext
    {
        public AspireDBcontext(DbContextOptions<AspireDBcontext> options) : base(options) { }

        public DbSet<EmployeeModel> Employees { get; set; }
    }
}
