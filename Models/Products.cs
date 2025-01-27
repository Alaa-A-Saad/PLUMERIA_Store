using System.ComponentModel.DataAnnotations;

namespace P_L_U_M_E_R_I_A.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }  // primary key
        public int ProductsCate_id { get; set; } // forign key
        public string Name { get; set; }

        public string Description { get; set; }

        public string Images { get; set; }

        public decimal Price { get; set; }

    }
}


