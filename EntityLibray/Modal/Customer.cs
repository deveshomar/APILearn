using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityLibray.Modal
{
    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string Address { get; set; }

        [JsonIgnore]
        public string DepartMent { get; set; }
    }
}
