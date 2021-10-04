using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_Drink.Models.BlogF
{
    public class Metarial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        [StringLength(250, ErrorMessage = "Max length is  250 char")]
        [Required(ErrorMessage = "Name is required")]
        public string title { get; set; }

        [Column(TypeName = "int")]
        public int mass { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string unit { get; set; }

        public int order { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int blog_id { get; set; }

    }
}
