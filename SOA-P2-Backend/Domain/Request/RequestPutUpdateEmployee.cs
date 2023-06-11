using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Request
{
    public class RequestPutUpdateEmployee 
    {
        [Required]
        public int num_employee { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public bool status { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string last_name { get; set; }
        [DataType(DataType.Date)]
        public DateTime birth_date { get; set; }
    }
}
