using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;//
using MySql.Data.Types;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace AppCRUDCsharp
{
    public class ConexionMySql
    {
        private static MySqlConnection ObjConexion;
        private static string error;

        //metodos

        //Genera objeto de conexion
        public static MySqlConnection getConexion()
        {
            //Validamos si existe la conexion
            if (ObjConexion != null)
            {
                return ObjConexion;
            }


            string strConnString = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;

            ObjConexion = new MySqlConnection(strConnString);
            //ObjConexion = new MySqlConnection("Server=localhost;Database=sena2020;Uid=usrPagina;Pwd=12345;");

            try
            {
                ObjConexion.Open();//abre conexion a bd
                return ObjConexion;
            }
            catch (Exception e)
            {
                error = e.Message;
                return null;
                
            }
        }

        public static void cerrarConexion()
        {
            if (ObjConexion != null)
            {
                ObjConexion.Close();
            }
        }
    }
}