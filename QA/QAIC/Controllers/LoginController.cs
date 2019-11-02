
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QAIC.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        
        }
        [HttpGet]
        public ActionResult Falla()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Consulta()
        {
            List<ModeloLibros.modeloLibros> lst = new List<ModeloLibros.modeloLibros>();
            try
            {
                string sentencia = "select * from dbo.books";
                SqlCommand sql = new SqlCommand(sentencia, Conexion.conectar());
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    lst.Add(new ModeloLibros.modeloLibros {  id= reader.GetInt32(0).ToString(), titulo= reader.GetString(1), autor= reader.GetString(5), isbn = reader.GetString(6) , cantidad= reader.GetString(7).ToString()});
                }
                ViewBag.Modelo = lst;

                reader.Close();
                sql.Dispose();
                Conexion.cerrarConexion();

            }
            catch (Exception ex)
            {
                ViewBag.Dato = null;

            }

            return View();
        }

        bool validacion = false;

        [HttpPost]
        public ActionResult Validacion(string usr, string pwd)
        {
            try
            {
                string sentencia = "select * from dbo.student_registration where username = '" + usr + "' and password = '" + pwd + "'";
                SqlCommand sql = new SqlCommand(sentencia, Conexion.conectar());
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    ViewBag.nombre = reader.GetString(2);
                    validacion = true;
                }
                reader.Close();
                sql.Dispose();
                Conexion.cerrarConexion();
                if (validacion == true)
                    return Redirect("Consulta");
                else
                    return View("Falla");
            }
            catch (Exception ex)
            {
                return View("Falla");
            }


        }
	}
}