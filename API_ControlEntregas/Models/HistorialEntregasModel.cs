using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API_ControlEntregas.Models
{
    public class HistorialEntregasModel
    {
        public async Task<Int64> Insert(HistorialEntregas data)
        {
            try
            {
                String query = String.Format(@"INSERT INTO HistorialEntregas
                                                (IDOrdenEntrega, IDUsuario, Latitud, Longitud)
                                                OUTPUT Inserted.IDHistorialEntrega
                                                VALUES
                                                ({0}, '{1}', '{2}', '{3}')");
                DataBaseSettings db = new DataBaseSettings();
                DataTable aux = await db.GetDataTable(query);

                if(aux.Rows.Count > 0)
                {
                    return Convert.ToInt64(aux.Rows[0]["IDHistorialEntrega"].ToString());
                }

                throw new Exception("Ha ocurrido un error al guardar la entrega");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task GuardarFotos(Images data)
        {
            try
            {
                foreach(byte[] singleObject in data.images)
                {
                    String query = String.Format(@"INSERT INTO Fotos
                                                   (IDHistorialEntrega, Foto)
                                                    VALUES
                                                    ({0}, {1})", data.idHistorialEntrega, singleObject);
                    DataBaseSettings db = new DataBaseSettings();
                    await db.ExecuteQuery(query);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task GuardarFirmas(Images data)
        {
            try
            {
                foreach (byte[] singleObject in data.images)
                {
                    String query = String.Format(@"INSERT INTO Firmas
                                                   (IDHistorialEntrega, Firma)
                                                    VALUES
                                                    ({0}, {1})", data.idHistorialEntrega, singleObject);
                    DataBaseSettings db = new DataBaseSettings();
                    await db.ExecuteQuery(query);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class HistorialEntregas
    {
        public Int64? idHistorialEntrega;
        public Int64? idOrdenEntrega;
        public String idUsuario;
        public String latitud;
        public String longitud;
        public DateTime fechaEntrega;
        public List<byte[]> firmas;
        public List<byte[]> fotos;

        public HistorialEntregas()
        {

        }
    }

    public class Images
    {
        public Int64? idHistorialEntrega;
        public List<byte[]> images;

        public Images()
        {

        }

        public Images(Int64? idHistorialEntrega, List<byte[]> images)
        {
            this.idHistorialEntrega = idHistorialEntrega;
            this.images = images;
        }
    }
}