//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebREST.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Habilidades
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Detalhes { get; set; }
        public int PersonagensId { get; set; }
    
        public virtual Personagens Personagens { get; set; }
    }
}
