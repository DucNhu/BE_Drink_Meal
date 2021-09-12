using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BE_Drink.Models
{
    public class Product
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

        [Column(TypeName = "money")]
        public decimal price { get; set; }

        [Column(TypeName = "money")]
        public decimal sale { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string desciption { get; set; }

        [Column(TypeName = "int")]
        public int availability { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string unit { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string storage_instructions { get; set; }

        [Column(TypeName = "int")]
        public int view { get; set; }

        [Column(TypeName = "money")]
        public decimal revenue { get; set; }

        [Column(TypeName = "int")]
        public int returned { get; set; }

        [Column(TypeName = "int")]
        public int status { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string seller_id { get; set; }

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
