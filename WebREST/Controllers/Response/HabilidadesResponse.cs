using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebREST.Controllers.TransferObjects
{
    public class HabilidadesResponse : BaseResponse
    {
        public HabilidadesTO Habilidades { get; set; }
    }
}