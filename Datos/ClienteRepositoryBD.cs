using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Net;

namespace Datos
{
    public class ClienteRepositoryBD
    {
        SqlConnection sqlcon;
        public void Open()
        {
            string nombreservidor = Dns.GetHostName();       
            sqlcon = new SqlConnection("Data Source"+nombreservidor+"\\LOCAL;Initial Catalog=ValuableChainBD;Integrated Security=True");
            sqlcon.Open();
        }
        public void Close() 
        {
            sqlcon.Close();
        }

        public string Cadena()
        {
            return sqlcon.ConnectionString;
        }
    }
}
