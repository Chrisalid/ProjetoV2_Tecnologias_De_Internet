using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebREST.Models;

namespace WebREST.Models
{
    public partial class Personagens
    {

        public static Personagens Consultar(int id)
        {
            Personagens categoria = null;

            using (BDRpgEntities context = new BDRpgEntities())
            {
                var categoria_ = from Personagens p in context.PersonagensS
                                 where p.Id == id
                                 select p;
                if (categoria_.Count() > 0)
                {
                    categoria = categoria_.First();
                }
                else
                    throw new RpgException(RpgExceptionCode.PERSONAGEMIDINEXISTENTE, id.ToString());
            }
            return categoria;
        }

        public static List<Personagens> Listar()
        {
            List<Personagens> categorias = new List<Personagens>();
            using (BDRpgEntities context = new BDRpgEntities())
            {
                categorias.AddRange(context.PersonagensS);
            }
            return categorias;
        }

        public static int Inserir(string nome)
        {
            int idNovo = -1;
            if (nome == null || nome.Length == 0)
                throw new RpgException(RpgExceptionCode.PERSONAGEMNOMEVAZIO, "");

            using (BDRpgEntities context = new BDRpgEntities())
            {
                Personagens c = new Personagens();
                c.Nome = nome;
                context.PersonagensS.Add(c);
                context.SaveChanges();
                idNovo = c.Id;
            }
            return idNovo;
        }

        public static void Atualizar(int id, string nome)
        {
            if (nome == null || nome.Length == 0)
                throw new RpgException(RpgExceptionCode.PERSONAGEMNOMEVAZIO, "");

            using (BDRpgEntities context = new BDRpgEntities())
            {
                var categoria_ = from Personagens c in context.PersonagensS
                                 where c.Id == id
                                 select c;
                if (categoria_.Count() > 0)
                {
                    Personagens c = categoria_.First();
                    c.Nome = nome;
                    context.SaveChanges();
                }
                else
                    throw new RpgException(RpgExceptionCode.PERSONAGEMIDINEXISTENTE, id.ToString());
            }
        }

        public static void Remover(int id)
        {
            using (BDRpgEntities context = new BDRpgEntities())
            {
                var produto_ = from Habilidades p in context.HabilidadesS
                               where p.Personagens.Id == id
                               select p;
                if (produto_.Count() > 0)
                {
                    throw new RpgException(RpgExceptionCode.PERSONAGEMCOMHABILIDADES, id.ToString());
                }
                var categoria_ = from Personagens c in context.PersonagensS
                                 where c.Id == id
                                 select c;
                if (categoria_.Count() > 0)
                {
                    context.PersonagensS.Remove(categoria_.First());
                    context.SaveChanges();
                }
                else
                    throw new RpgException(RpgExceptionCode.PERSONAGEMIDINEXISTENTE, id.ToString());
            }
        }

    }

}