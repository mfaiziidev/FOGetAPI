using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOGetAPI
{
    public class clsFOEntries
    {
    }

    public class clsResponse
    {
        public int ResponseCode { get; set; }
        public string Status { get; set; }
    }

    public class clsEntries
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhnNo { get; set; }
        public string Email { get; set; }
    }
}