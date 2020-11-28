using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebREST.Controllers.TransferObjects
{
    public class HabilidadesTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Detalhes { get; set; }
    }
}