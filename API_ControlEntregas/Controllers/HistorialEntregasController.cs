using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using API_ControlEntregas.Models;
using System.Threading.Tasks;

namespace API_ControlEntregas.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    public class HistorialEntregasController : ApiController
    {
        [HttpPost]
        [Route("api/OrdenesEntrega/{idOrdenEntrega}/HistorialEntrega")]
        public async Task<HttpResponseMessage> Insert([FromBody] HistorialEntregas data, [FromUri] Int64? idOrdenEntrega)
        {
            try
            {
                if (data != null && idOrdenEntrega != null)
                {
                    HistorialEntregasModel model = new HistorialEntregasModel();
                    data.idOrdenEntrega = idOrdenEntrega;
                    Int64? idHistorialEntrega = await model.Insert(data);

                    if (data.fotos.Count > 0)
                    {
                        await model.GuardarFotos(new Images(idHistorialEntrega, data.fotos));
                    }

                    if (data.firmas.Count > 0)
                    {
                        await model.GuardarFirmas(new Images(idHistorialEntrega, data.firmas));
                    }
                    return Request.CreateResponse(HttpStatusCode.Created, data);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Parámetro nulo");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/OrdenesEntrega/{idOrdenEntrega}/HistorialEntrega/{idHistorialEntrega}")]
        public async Task<HttpResponseMessage> Get([FromUri] Int64? idHistorialEntrega)
        {
            try
            {
                if (idHistorialEntrega != null)
                {
                    HistorialEntregasModel model = new HistorialEntregasModel();
                    HistorialEntregas data = await model.GetSpecific(idHistorialEntrega);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Parámetro nulo");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
