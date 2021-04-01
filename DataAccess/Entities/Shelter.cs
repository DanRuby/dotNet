using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    
    public class Shelter
    {
        public Shelter()
        {
            Animals = new HashSet<Animal>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }  
  
        public virtual ICollection<Animal> Animals { get; set; }
  
    }
}
