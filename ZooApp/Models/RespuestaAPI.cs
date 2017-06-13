using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZooApp
{
    public class RespuestaAPI<T>
    {
        public int totalElementos { get; set; }

        public string error { get; set; }

        public List<T> data { get; set; }
    }
}