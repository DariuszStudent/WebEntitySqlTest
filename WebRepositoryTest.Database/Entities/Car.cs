using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebRepositoryTest.Database
{
    public class Car
    {
        public int CarId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Color { get; set; }
        public string Engine { get; set; }
        
        [ForeignKey("CarBadNameId")]
        public string CarBadNameId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
