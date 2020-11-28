using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebREST.Models
{
    public partial class Habilidades
    {
        public static Habilidades Consultar(int id)
        {
            Habilidades habilidades = null;

            using (BDRpgEntities context = new BDRpgEntities())
            {
                var habilidades_ = from Habilidades h in context.HabilidadesS
                                   where h.Id == id
                                   select h;
                if (habilidades_.Count() > 0)
                {
                    habilidades = habilidades_.First();
                }
                else
                    throw new RpgException(RpgExceptionCode.HABILIDADESIDINEXISTENTE, id.ToString());
            }
            return habilidades;
        }

        public static List<Habilidades> Listar()
        {
            List<Habilidades> habilidades = new List<Habilidades>();
            using (BDRpgEntities context = new BDRpgEntities())
            {
                habilidades.AddRange(context.HabilidadesS);
            }
            return habilidades;
        }

        public static int Inserir(string nome)
        {
            int idNovo = -1;
            if (nome == null || nome.Length == 0)
                throw new RpgException(RpgExceptionCode.HABILIDADESNOMEVAZIO, "");

            using (BDRpgEntities context = new BDRpgEntities())
            {
                Habilidades c = new Habilidades();
                c.Nome = nome;
                context.HabilidadesS.Add(c);
                context.SaveChanges();
                idNovo = c.Id;
            }
            return idNovo;
        }

        public static void Atualizar(int id, string nome)
        {
            if (nome == null || nome.Length == 0)
                throw new RpgException(RpgExceptionCode.HABILIDADESNOMEVAZIO, "");

            using (BDRpgEntities context = new BDRpgEntities())
            {
                var habilidades_ = from Habilidades c in context.HabilidadesS
                                   where c.Id == id
                                   select c;
                if (habilidades_.Count() > 0)
                {
                    Habilidades c = habilidades_.First();
                    c.Nome = nome;
                    context.SaveChanges();
                }
                else
                    throw new RpgException(RpgExceptionCode.HABILIDADESIDINEXISTENTE, id.ToString());
            }
        }

        public static void Remover(int id)
        {
            using (BDRpgEntities context = new BDRpgEntities())
            {
                var habilidades_ = from Habilidades p in context.HabilidadesS
                                   where p.Personagens.Id == id
                                   select p;
                if (habilidades_.Count() > 0)
                {
                    throw new RpgException(RpgExceptionCode.HABILIDADESCOMHABILIDADES, id.ToString());
                }
                var personagem_ = from Habilidades c in context.HabilidadesS
                                  where c.Id == id
                                  select c;
                if (personagem_.Count() > 0)
                {
                    context.HabilidadesS.Remove(personagem_.First());
                    context.SaveChanges();
                }
                else
                    throw new RpgException(RpgExceptionCode.HABILIDADESIDINEXISTENTE, id.ToString());
            }
        }
    }
}