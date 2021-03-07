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
            Children = new HashSet<Shelter>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public virtual Shelter Parent { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }
        public virtual ICollection<Shelter> Children { get; set; }
    }
}
