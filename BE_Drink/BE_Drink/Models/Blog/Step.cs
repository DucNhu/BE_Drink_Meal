using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BE_Drink.Models.Blog
{
    public class Step
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        [StringLength(250, ErrorMessage = "Max length is  250 char")]
        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string banner_img { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string description { get; set; }

        public int order { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int blog_id { get; set; }
    }
}
