using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebREST.Controllers.TransferObjects
{
    public class PersonagensResponse : BaseResponse
    {
        public PersonagensTO Personagens { get; set; }
    }
}