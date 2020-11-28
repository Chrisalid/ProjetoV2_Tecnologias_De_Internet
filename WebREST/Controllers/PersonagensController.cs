using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebREST.Controllers.TransferObjects;
using WebREST.Models;

namespace WebREST.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonagensController : ApiController
    {
        // GET: api/Personagens
        public IHttpActionResult Get()
        {
            PersonagensSResponse pResponse = new PersonagensSResponse();

            try
            {
                List<Personagens> lista = Personagens.Listar();
                pResponse.Personagens = new List<PersonagensTO>();
                foreach (Personagens p in lista)
                {
                    PersonagensTO pTO = new PersonagensTO();
                    pTO.Id = p.Id;
                    pTO.Nome = p.Nome;
                    pTO.Tipo = p.Tipo;
                    pTO.Genero = p.Genero;
                    pResponse.Personagens.Add(pTO);
                }
            }
            catch (Exception ex)
            {
                pResponse.Status = -1;
                pResponse.Detalhes = ex.Message;
            }

            return Ok(pResponse);
        }

        // GET: api/personagens/5
        public IHttpActionResult Get(int id)
        {
            PersonagensResponse pResponse = new PersonagensResponse();
            try
            {
                Personagens p = Personagens.Consultar(id);
                pResponse.Personagens = new PersonagensTO();
                pResponse.Personagens.Id = p.Id;
                pResponse.Personagens.Nome = p.Nome;
                pResponse.Personagens.Tipo = p.Tipo;
                pResponse.Personagens.Genero = p.Genero;
            }
            catch (RpgException nex)
            {
                pResponse.Status = (int)nex.Codigo;
            }
            catch (Exception ex)
            {
                pResponse.Status = -1;
                pResponse.Detalhes = ex.Message;
            }
            return Ok(pResponse);
        }

        // POST: api/personagens
        public IHttpActionResult Post([FromBody] PersonagensTO personagensTO)
        {
            PersonagensResponse pResponse = new PersonagensResponse();
            pResponse.Personagens.Nome = personagensTO.Nome;

            try
            {
                pResponse.Personagens.Id = Personagens.Inserir(personagensTO.Nome);
            }
            catch (RpgException nex)
            {
                pResponse.Status = (int)nex.Codigo;
            }
            catch (Exception ex)
            {
                pResponse.Status = -1;
                pResponse.Detalhes = ex.Message;
            }
            return Ok(pResponse);
        }

        // PUT: api/personagens/5
        public IHttpActionResult Put(int id, [FromBody] PersonagensTO personagensTO)
        {
            BaseResponse bResp = new BaseResponse();
            try
            {
                Personagens.Atualizar(id, personagensTO.Nome);
            }
            catch (RpgException nex)
            {
                bResp.Status = (int)nex.Codigo;
            }
            catch (Exception ex)
            {
                bResp.Status = -1;
                bResp.Detalhes = ex.Message;
            }
            return Ok(bResp);
        }

        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Update([FromBody] PersonagensTO personagensTO)
        {
            BaseResponse bResp = new BaseResponse();
            try
            {
                Personagens.Atualizar(personagensTO.Id, personagensTO.Nome);
            }
            catch (RpgException nex)
            {
                bResp.Status = (int)nex.Codigo;
            }
            catch (Exception ex)
            {
                bResp.Status = -1;
                bResp.Detalhes = ex.Message;
            }
            return Ok(bResp);
        }

        // DELETE: api/personagens/5
        public IHttpActionResult Delete(int id)
        {
            BaseResponse bResp = new BaseResponse();
            try
            {
                Personagens.Remover(id);
            }
            catch (RpgException nex)
            {
                bResp.Status = (int)nex.Codigo;
            }
            catch (Exception ex)
            {
                bResp.Status = -1;
                bResp.Detalhes = ex.Message;
            }
            return Ok(bResp);
        }

        [HttpPost]
        [Route("remover")]
        public IHttpActionResult Remover([FromBody] PersonagensTO personagensTO)
        {
            BaseResponse bResp = new BaseResponse();
            try
            {
                Personagens.Remover(personagensTO.Id);
            }
            catch (RpgException nex)
            {
                bResp.Status = (int)nex.Codigo;
            }
            catch (Exception ex)
            {
                bResp.Status = -1;
                bResp.Detalhes = ex.Message;
            }
            return Ok(bResp);
        }
    }
}
