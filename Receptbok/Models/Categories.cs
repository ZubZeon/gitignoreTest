using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Receptbok.Models
{
    public partial class Categories
    {
        public Categories()
        {
            this.Recipes = new HashSet<Recipes>();
        }

        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Recipes> Recipes { get; set; }
    }
}