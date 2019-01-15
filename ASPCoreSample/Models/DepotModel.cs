using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ASPCoreSample.Models
{
    public class DepotModel : BaseEntity
    {
        [Key]
        public long Id { get; set; }

        public string name { get; set; }

        public int type_id { get; set; }
        public int brand_id { get; set; }
        public int inusecount { get; set; }
        public int totalcount { get; set; }
        public int notusecount { get; set; }
        public string brandName { get; set; }
        public string typeName { get; set; }

    }
}
