using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BE_Drink.Models
{
    public class Bloger
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
        public string cover_img { get; set; }

        public string cooking_time { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string summary { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string description { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string url_video_utube { get; set; }

        [Column(TypeName = "int")]
        public int view { get; set; }

        [Column(TypeName = "int")]
        public int status { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string user_id { get; set; }

        [Column(TypeName = "int")]
        public int category_id { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime create_at { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime update_at { get; set; }
    }
}
