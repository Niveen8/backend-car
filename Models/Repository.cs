using System.ComponentModel.DataAnnotations;

namespace CarShop.Models
{
    public class Repository
    {
        
            public int Id { get; set; } // Primary Key

            // Foreign Keys
            public int AdminId { get; set; }  // Which admin managed the car
            public Admin Admin { get; set; }  // Navigation property

            public int CarId { get; set; }    // Which car was managed
            public Car Car { get; set; }      // Navigation property
            public string Make { get; set; }
            public DateTime ActionDate { get; set; }  // Timestamp when the action was taken
        

    }
}
