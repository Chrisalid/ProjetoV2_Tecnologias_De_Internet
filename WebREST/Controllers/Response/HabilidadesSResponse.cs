using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebREST.Controllers.TransferObjects
{
    public class HabilidadesSResponse : BaseResponse
    {
        public List<HabilidadesTO> Habilidades { get; set; }
    }
}