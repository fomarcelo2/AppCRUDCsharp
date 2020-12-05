using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppCRUDCsharp.App
{
    public partial class Formulario : System.Web.UI.Page
    {
        ValidarCajas validar = new ValidarCajas();
        GestionDatos datos = new GestionDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            //cuando se carga el formulario
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    InCodigo.Text = Request.QueryString["id"];
                    Empleado myEmpleado = datos.consultaEmpleado(InCodigo.Text);

                    InNombre.Text = myEmpleado.Nombre;
                    InApellido.Text = myEmpleado.Apellido;
                    InCargo.Text = myEmpleado.Cargo;
                    InSalario.Text = myEmpleado.Salario;
                    InArea.Text = myEmpleado.Area;
                    InSalario.Text = myEmpleado.Salario;
                    InCiudad.Text = myEmpleado.Ciudad;
                    btnAgregarEmpleado.Visible = false;
                    btnEditarEmpleado.Visible = true;
                    btnBorrarEmpleado.Visible = true;
                    InCodigo.Enabled = false;
                }
                else
                {
                    InCodigo.Enabled = true;
                    btnAgregarEmpleado.Visible = true;
                    btnEditarEmpleado.Visible = false;
                    btnBorrarEmpleado.Visible = false;
                }
            }
        }

        protected void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            //enviar los datos
            if (!validar.Vacio(InCodigo, ErrorCodigo,"No puede ser vacío"))
                if (!validar.Vacio(InNombre, ErrorNombre,"No puede ser vacío"))
                    if (!validar.Vacio(InApellido, ErrorApellido,"No puede ser vacío"))
                        if (!validar.Vacio(InCargo, ErrorCargo,"No puede ser vacío"))
                            if (!validar.Vacio(InSalario, ErrorSalario,"No puede ser vacío"))
                                if (!validar.Vacio(InArea, ErrorArea,"No puede ser vacío"))
                                    if (!validar.Vacio(InCiudad, ErrorCiudad,"No puede ser vacío"))
            {
                                        InsertarDatosBD();
            }
        }


        private void InsertarDatosBD()
        {
            Empleado myEmpleado = new Empleado();
            myEmpleado.Codigo = InCodigo.Text;
            myEmpleado.Nombre = InNombre.Text;
            myEmpleado.Apellido = InApellido.Text;
            myEmpleado.Cargo = InCargo.Text;
            myEmpleado.Salario = InSalario.Text;
            myEmpleado.Area = InArea.Text;
            myEmpleado.Ciudad = InCiudad.Text;

            if (!datos.ExisteEmpleado(myEmpleado.Codigo))
            {
                if (datos.InsertarEmpleados(myEmpleado))
                {

                    labelRta.Text = "El registro fue insertado correctamente";
                    LimpiarCampos();
                }
                else
                {
                    labelRta.Text = "Error al insertar " + datos.error; 
                }
            }
            else
            {
                labelRta.Text = "El registro ya existe";
            }

            
        }

        private void LimpiarCampos()
        {
            InCodigo.Text = "";
            InNombre.Text = "";
            InApellido.Text = "";
            InCargo.Text = "";
            InSalario.Text = "";
            InArea.Text = "";
            InCiudad.Text = "";
        }

        protected void btnBorrarEmpleado_Click(object sender, EventArgs e)
        {
            //borrar empleado
            if (datos.EliminarEmpleado(InCodigo.Text))
            {
                labelRta.Text = "El registro fue eliminado correctamente.";
                LimpiarCampos();
            }
            else
            {
                labelRta.Text = "Error al eliminar " + datos.error;
            }
        }

        protected void btnEditarEmpleado_Click(object sender, EventArgs e)
        {
            //editar empleado
            Empleado myEmpleado = new Empleado();
            myEmpleado.Codigo = InCodigo.Text;
            myEmpleado.Nombre = InNombre.Text;
            myEmpleado.Apellido = InApellido.Text;
            myEmpleado.Cargo = InCargo.Text;
            myEmpleado.Salario = InSalario.Text;
            myEmpleado.Area = InArea.Text;
            myEmpleado.Ciudad = InCiudad.Text;

            if (datos.EditarEmpleado(myEmpleado))
            {
                labelRta.Text = "El registro fue actualizado correctamente.";
            }
            else
            {
                labelRta.Text = "Error al actualizar " + datos.error;
            }
        }
    }
}