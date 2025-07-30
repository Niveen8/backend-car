using System.ComponentModel.DataAnnotations.Schema;

namespace CarShop.Models
{
    public class Car
    {
       
            public int CarId { get; set; }
            public string Make { get; set; }
            //public string Color { get; set; }
            public string Model { get; set; } 
            public int Year { get; set; }

            
            [Column(TypeName = "decimal(18,2)")]
            public decimal Price { get; set; } 
        
    }

}
