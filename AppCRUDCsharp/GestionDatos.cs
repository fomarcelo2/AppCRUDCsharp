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
    public class GestionDatos
    {
        public MySqlConnection conexion;
        public string error;

        
        

        //constructor
        public GestionDatos()
        {
            this.conexion = ConexionMySql.getConexion();
        }



        public List<Empleado> LeerTodos()
        {
            List<Empleado> listaEmpleados = new List<Empleado>();
            string sql = "select * from empleados";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            MySqlDataReader resultado = cmd.ExecuteReader();

            while (resultado.Read())
            {
                Empleado myEmpleado = new Empleado();
                myEmpleado.Codigo = resultado.GetString(1);
                myEmpleado.Nombre = resultado.GetString(2);
                myEmpleado.Apellido = resultado.GetString(3);
                myEmpleado.Cargo = resultado.GetString(4);
                myEmpleado.Salario = resultado.GetString(5);
                myEmpleado.Area = resultado.GetString(6);
                myEmpleado.Ciudad = resultado.GetString(7);

                listaEmpleados.Add(myEmpleado);

            }
            resultado.Close();

            return listaEmpleados;
        }

        //insertar un objeto a la base de datos

            //
        public Boolean ExisteEmpleado(string codigo)
        {
            string sql = "Select * from empleados where codigo = @codigo";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            MySqlDataReader resultado = cmd.ExecuteReader();

            if (resultado.Read())
            {
                resultado.Close();
                return true;
            }
            else
            {
                resultado.Close();
                return false;
            }
        }
        public Boolean InsertarEmpleados(Empleado myEmpleado)
        {
            Boolean rta = false;//respuesta funcion

            try
            {
                string sql = "Insert Into Empleados (codigo,nombre,apellido,cargo,salario,area,ciudad) values (@codigo,@nombre,@apellido,@cargo,@salario,@area,@ciudad)";//consulta
                MySqlCommand cmd = new MySqlCommand(sql, conexion);//creo un objeto de la clase comando
                cmd.Parameters.AddWithValue("@codigo", myEmpleado.Codigo);//agrego parametros a consulta
                cmd.Parameters.AddWithValue("@nombre", myEmpleado.Nombre);
                cmd.Parameters.AddWithValue("@apellido", myEmpleado.Apellido);
                cmd.Parameters.AddWithValue("@cargo", myEmpleado.Cargo);
                cmd.Parameters.AddWithValue("@salario", myEmpleado.Salario);
                cmd.Parameters.AddWithValue("@area", myEmpleado.Area);
                cmd.Parameters.AddWithValue("@ciudad", myEmpleado.Ciudad);
                cmd.ExecuteNonQuery();
                rta = true;
            }
            catch (MySqlException ex)
            {

                this.error = ex.Message;
            }

            return rta;
        }
        
        //gestiones sql sobre la base de datos

        public Empleado consultaEmpleado(string codigo)
        {
            Empleado busqueda = new Empleado();
            string sql = "select * from empleados where codigo=@codigo";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@codigo", codigo);
            MySqlDataReader resultado = cmd.ExecuteReader();
            if (resultado.Read())
            {
                busqueda.Codigo = resultado.GetString(1);
                busqueda.Nombre = resultado.GetString(2);
                busqueda.Apellido = resultado.GetString(3);
                busqueda.Cargo = resultado.GetString(4);
                busqueda.Salario = resultado.GetString(5);
                busqueda.Area = resultado.GetString(6);
                busqueda.Ciudad = resultado.GetString(7);
                resultado.Close();
                return busqueda;
            }
            else
            {
                resultado.Close();
                return null;
            }
        }

        //editar datos empleado
        public Boolean EditarEmpleado(Empleado myEmpleado)
        {
            Boolean rta = false;//respuesta funcion

            try
            {
                string sql = "Update Empleados set nombre=@nombre, apellido=@apellido, cargo=@cargo, salario=@salario,area=@area,ciudad=@ciudad where codigo=@codigo";//consulta
                MySqlCommand cmd = new MySqlCommand(sql, conexion);//creo un objeto de la clase comando
                cmd.Parameters.AddWithValue("@codigo", myEmpleado.Codigo);//agrego parametros a consulta
                cmd.Parameters.AddWithValue("@nombre", myEmpleado.Nombre);
                cmd.Parameters.AddWithValue("@apellido", myEmpleado.Apellido);
                cmd.Parameters.AddWithValue("@cargo", myEmpleado.Cargo);
                cmd.Parameters.AddWithValue("@salario", myEmpleado.Salario);
                cmd.Parameters.AddWithValue("@area", myEmpleado.Area);
                cmd.Parameters.AddWithValue("@ciudad", myEmpleado.Ciudad);
                cmd.ExecuteNonQuery();
                rta = true;
            }
            catch (MySqlException ex)
            {

                this.error = ex.Message;
            }

            return rta;
        }

        //eliminar datos empleado
        public Boolean EliminarEmpleado(string codigo)
        {
            Boolean rta = false;//respuesta funcion
            try
            {
                string sql = "delete from empleados where codigo=@codigo";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.ExecuteNonQuery();
                rta = true;
            }
            catch (MySqlException ex)
            {

                this.error = ex.Message;
            }

            return rta;
        }


    }
}