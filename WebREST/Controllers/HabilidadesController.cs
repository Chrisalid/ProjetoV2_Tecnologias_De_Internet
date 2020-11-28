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
    public class HabilidadesController : ApiController
    {
        // GET: api/Habilidades
        public IHttpActionResult Get()
        {
            HabilidadesSResponse pResponse = new HabilidadesSResponse();

            try
            {
                List<Habilidades> lista = Habilidades.Listar();
                pResponse.Habilidades = new List<HabilidadesTO>();
                foreach (Habilidades p in lista)
                {
                    HabilidadesTO pTO = new HabilidadesTO();
                    pTO.Id = p.Id;
                    pTO.Nome = p.Nome;
                    pTO.Tipo = p.Tipo;
                    pTO.Detalhes = p.Detalhes;
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
            HabilidadesResponse pResponse = new HabilidadesResponse();
            try
            {
                Habilidades p = Habilidades.Consultar(id);
                pResponse.Habilidades = new HabilidadesTO();
                pResponse.Habilidades.Id = p.Id;
                pResponse.Habilidades.Nome = p.Nome;
                pResponse.Habilidades.Tipo = p.Tipo;
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
        public IHttpActionResult Post([FromBody] HabilidadesTO personagensTO)
        {
            HabilidadesResponse pResponse = new HabilidadesResponse();
            pResponse.Habilidades.Nome = personagensTO.Nome;

            try
            {
                pResponse.Habilidades.Id = Habilidades.Inserir(personagensTO.Nome);
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
        public IHttpActionResult Put(int id, [FromBody] HabilidadesTO personagensTO)
        {
            BaseResponse bResp = new BaseResponse();
            try
            {
                Habilidades.Atualizar(id, personagensTO.Nome);
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
        public IHttpActionResult Update([FromBody] HabilidadesTO habilidadesTO)
        {
            BaseResponse bResp = new BaseResponse();
            try
            {
                Habilidades.Atualizar(habilidadesTO.Id, habilidadesTO.Nome);
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
                Habilidades.Remover(id);
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
        public IHttpActionResult Remover([FromBody] HabilidadesTO personagensTO)
        {
            BaseResponse bResp = new BaseResponse();
            try
            {
                Habilidades.Remover(personagensTO.Id);
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
