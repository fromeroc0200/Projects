using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runtime
{
    public class ProcessResult<T> where T : class
    {
        public T Objects { get; set; }
        public bool HasError { get; set; }
        public string Description { get; set; } 
    }
}
