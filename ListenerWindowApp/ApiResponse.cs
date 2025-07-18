using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListenerWindowApp
{
    public class ApiResponse
    {
        public DataWrapper Data { get; set; }
    }

    public class DataWrapper
    {
        public int Number { get; set; }
    }
}
