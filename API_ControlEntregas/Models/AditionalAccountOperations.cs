using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API_ControlEntregas.Models
{
    public class AditionalAccountOperations
    {
        public bool IsEnable(String userName)
        {
            try
            {
                DataBaseSettings db = new DataBaseSettings();
                String query = String.Format(@"SELECT * FROM AspNetUsers WHERE UserName = '{0}' and Enabled = 1", userName);
                DataTable aux = db.GetDataTable(query);

                return aux.Rows.Count > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DisableUser(String id)
        {
            try
            {
                String query = String.Format("UPDATE AspNetUsers SET Enabled = 0 WHERE ID = '{0}'", id);
                DataBaseSettings db = new DataBaseSettings();
                db.ExecuteQuery(query);
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public void EnableUser(String id)
        {
            try
            {
                String query = String.Format("UPDATE AspNetUsers SET Enabled = 1 WHERE ID = '{0}'", id);
                DataBaseSettings db = new DataBaseSettings();
                db.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}