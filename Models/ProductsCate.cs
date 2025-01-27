using System.ComponentModel.DataAnnotations;

namespace P_L_U_M_E_R_I_A.Models
{
    public class ProductsCate
    {
       [Key]
        public int Id { get; set; } // primary key

        public string Name { get; set; }
    }
}
