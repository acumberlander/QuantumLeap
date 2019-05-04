using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuantumLeap.cs.Models
{
    public class CreateLeapeeRequest
    {
        public int LeaperId { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public int Age { get; set; }
    }
}
