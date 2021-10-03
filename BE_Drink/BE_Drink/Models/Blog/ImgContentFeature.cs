using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BE_Drink.Models.Blog
{
    public class ImgContentFeature
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public long content_id { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string avatar_feature { get; set; }
    }
}
