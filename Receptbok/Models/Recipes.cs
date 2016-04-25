using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Receptbok.Models
{
    public partial class Recipes
    {
        [Key]
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeInstructions { get; set; }
        public Nullable<int> CategoryId { get; set; }

        public virtual Categories Categories { get; set; }
        public virtual ICollection<FilePath> FilePath { get; set; }
    }
}