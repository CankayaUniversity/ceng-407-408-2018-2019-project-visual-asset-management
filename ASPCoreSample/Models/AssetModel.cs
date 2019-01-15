using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ASPCoreSample.Models
{
    public class AssetModel : BaseEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public int numberofasset { get; set; }

        [Required]
        public int room_id { get; set; }
        
        public string room_name { get; set; }

        [Required]
        public int assettype_id { get; set; }
        
        public string type_name { get; set; }

        [Required]
        public int owner_id { get; set; }
        
        public string owner_name { get; set; }

        [Required]
        public int brand_id { get; set; }
        
        public string brand_name { get; set; }
        
        public DateTime acquisition_date { get; set; }
        
        public string serial_no { get; set; }

        [Required]
        public int depot_id { get; set; }
        
        public string depot_name { get; set; }
    }
}
