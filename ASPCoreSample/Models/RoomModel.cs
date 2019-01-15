using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ASPCoreSample.Models
{
    public class RoomModel : BaseEntity
    {
        [Key]
        public long Id { get; set; }

        public string roomname { get; set; }

        public string floor { get; set; }
        public string block { get; set; }
        public int owner_id { get; set; }
        public string name { get; set; }
       

        [Required]
        public Boolean isactive { get; set; }

    }
}
