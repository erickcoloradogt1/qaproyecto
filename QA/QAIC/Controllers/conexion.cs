using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QAIC.Controllers
{
    public class Conexion
    {
        public static SqlConnection conectar()
        {
            string connetionString = "Data Source=desarrolloumg.database.windows.net,1433;Initial Catalog=lms;User ID=diego;Password=desarrolloumg1.";
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();
            return cnn;

        }

        public static SqlConnection cerrarConexion()
        {
            string connetionString = "Data Source=desarrolloumg.database.windows.net,1433;Initial Catalog=aseguradora;User ID=diego;Password=desarrolloumg1.";
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Close();
            return cnn;

        }
    }
}