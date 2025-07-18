using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPatrolDesktop.Models
{
    public class UserRequestDto
    {
        public string UserId { get; set; }
        public int RequestCode { get; set; }
        public string Description { get; set; }
    }

}
