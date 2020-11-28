using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebREST.Controllers.TransferObjects
{
    public class PersonagensSResponse : BaseResponse
    {
        public List<PersonagensTO> Personagens { get; set; }
    }
}