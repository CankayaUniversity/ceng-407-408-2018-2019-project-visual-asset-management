using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ASPCoreSample.Models
{
    public class BrandModel : BaseEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string name { get; set; }
        
    }
}
