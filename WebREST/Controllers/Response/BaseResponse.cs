using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebREST.Controllers.TransferObjects
{
    public class BaseResponse
    {
        public int Status { get; set; }
        public string Detalhes { get; set; }
    }
}