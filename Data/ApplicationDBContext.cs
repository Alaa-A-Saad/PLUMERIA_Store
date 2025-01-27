using Microsoft.EntityFrameworkCore;
using P_L_U_M_E_R_I_A.Models;

namespace P_L_U_M_E_R_I_A.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        public DbSet <Products> Products { get; set; }
        public DbSet <ProductsCate> ProductsCate { get; set; }


    }
}
