using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokLogg.Model
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfRegistry { get; set; } = DateTime.Now;
        
    }
}
