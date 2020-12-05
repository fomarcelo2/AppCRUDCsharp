using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppCRUDCsharp.App
{
    public partial class Datos : System.Web.UI.Page
    {
        //crear nuestro objeto para gestionar datos
        GestionDatos datos = new GestionDatos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //invocamos el objeto para listar todos los empleados
                List<Empleado> listaEmpleados = datos.LeerTodos();

                //mostramos los resultados
                gvEmpleados.DataSource = listaEmpleados;
                gvEmpleados.DataBind();//actualiza los datos de la grid
            }

        }

        protected void btnListarTodo_Click(object sender, EventArgs e)
        {
            
        }

        protected void gvEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmpleados.PageIndex = e.NewPageIndex;//recarga tabla de datos
            List<Empleado> listaEmpleados = datos.LeerTodos();
            gvEmpleados.DataSource = listaEmpleados;
            gvEmpleados.DataBind();//actualiza los datos de la grid
        }

        protected void gvEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                string valor = Convert.ToString(gvEmpleados.DataKeys[indice].Value);
                //Response.Write("Valor de fila " + indice);
                //Response.Write("Valor Celda " + valor);

                Response.Redirect("Formulario.aspx?id=" + valor);

            }
        }

        protected void BtnBuscarCodigo_Click(object sender, EventArgs e)
        {
            if (datos.ExisteEmpleado(InCodigoaBuscar.Text))
            {
                Response.Redirect("Formulario.aspx?id=" + InCodigoaBuscar.Text);
            }
            else
            {
                LabelBuscar.Text = "No existe el codigo ingresado.";
            }
        }
    }
}