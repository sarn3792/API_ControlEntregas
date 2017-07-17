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
    public class OrdenCompraController : ApiController
    {
        public async Task<HttpResponseMessage> Get()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
