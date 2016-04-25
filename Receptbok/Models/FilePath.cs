using System.ComponentModel.DataAnnotations;

namespace Receptbok.Models
{
    public class FilePath
    {
        public int FilePathId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        public FileType FileType { get; set; }

        public int RecipeId { get; set; }
        public virtual Recipes Recipes { get; set; }
    }
}