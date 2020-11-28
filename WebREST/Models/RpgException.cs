using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebREST.Models
{
    public enum RpgExceptionCode
    {
        ERRODESCONHECIDO = 1,
        PERSONAGEMNOMEVAZIO = 101,
        PERSONAGEMIDINEXISTENTE = 102,
        PERSONAGEMCOMHABILIDADES = 103,
        HABILIDADESNOMEVAZIO = 201,
        HABILIDADESIDINEXISTENTE = 202,
        HABILIDADESCOMHABILIDADES = 203
    }

    public class RpgException : Exception
    {
        private string Detalhe { get; }
        public RpgExceptionCode Codigo { get; }

        public RpgException(RpgExceptionCode codigo, string detalhe)
       : base(detalhe)
        {
            this.Codigo = codigo;
            this.Detalhe = detalhe;
        }

        public override string Message
        {
            get
            {
                switch (Codigo)
                {
                    case RpgExceptionCode.ERRODESCONHECIDO:
                        return "Erro desconhecido: " + Detalhe;
                    case RpgExceptionCode.PERSONAGEMNOMEVAZIO:
                        return "Categoria nao pode ter o nome vazio. ";
                    case RpgExceptionCode.PERSONAGEMIDINEXISTENTE:
                        return "ID de Categoria nao encontrado." + Detalhe;
                    case RpgExceptionCode.PERSONAGEMCOMHABILIDADES:
                        return "A categoria possui produtos cadastrados." + Detalhe;
                    case RpgExceptionCode.HABILIDADESNOMEVAZIO:
                        return "Produto nao pode ter o nome vazio. ";
                    case RpgExceptionCode.HABILIDADESIDINEXISTENTE:
                        return "ID de Produto nao encontrado." + Detalhe;
                    case RpgExceptionCode.HABILIDADESCOMHABILIDADES:
                        return "A Produto possui categoria cadastrada." + Detalhe;

                    default: return "Erro desconhecido";
                }
            }
        }
    }
}