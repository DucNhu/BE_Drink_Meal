﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_Drink.Models.BlogF
{
    public class Content
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        [StringLength(250, ErrorMessage = "Max length is  250 char")]
        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string content { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string banner_img { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string unit { get; set; }
    }
}
