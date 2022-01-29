using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServicesDSM.Models.Request
{
    public class PelisRequest
    {
        public int Id { set; get; }
        public string titulo { set; get; }
        public string director { set; get; }
        public string genero { set; get; }
        public int rating { set; get; }
        public DateTime año { set; get; }

    }
}
