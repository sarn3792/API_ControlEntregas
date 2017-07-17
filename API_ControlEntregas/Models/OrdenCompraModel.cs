using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API_ControlEntregas.Models
{
    public class OrdenCompraModel
    {
        public async Task<List<OrdenCompra>> Get()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrdenCompra> Get(Int64 idOrdenCompra)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Insert(OrdenCompra data)
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

    public class OrdenCompra
    {
        public Int64 idOrdenCompra;
        public Int64 idCliente;
        public String descripcion;
        public DateTime creadoEn;

        public OrdenCompra()
        {

        }
    }
}