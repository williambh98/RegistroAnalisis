using BLL;
using Entidades;
using RegistroAnalisis.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroAnalisis.UI.Registros
{
    public partial class Rpago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<Pago> repositorio = new RepositorioBase<Pago>();
                    Pago user = repositorio.Buscar(id);
                    if (user == null)
                        Utils.ShowToastr(this, "Id no existe", "Error", "error");
                    else
                     LlenarCombo();
                    LlenarCampo(user);
                }
                LlenarCombo();
                ViewState["Pago"] = new Pago();
            }

        }
            protected void BindGrid()
            {
                DatosGridView.DataSource = ((Pago)ViewState["Pago"]).PagoDetalles;
                DatosGridView.DataBind();
            }

        private Pago LlenaClase()
        {
            Pago pago = new Pago();
            pago = (Pago)ViewState["Pago"];
            pago.IDpago = Utils.ToInt(IdTextBox.Text);
            pago.Fecha = DateTime.Now;
            return pago;
        }
        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
           AnalisisDropdownList.ClearSelection();
            fechaTextBox.Text = DateTime.Now.ToString();
            MontoTextBox.Text = 0.ToString();
            BalanceTextBox.Text = 0.ToString();
            ViewState["Pago"] = new Pago();
            LlenarCombo();
            this.BindGrid();
        }
        private void LlenarCampo(Pago pago)
        {
            Limpiar();
            IdTextBox.Text = pago.IDpago.ToString();
            ViewState["Pago"] = pago;
            this.BindGrid();
        }
        private void LlenarCombo()
        {
            AnalisisDropdownList.Items.Clear();
            RepositorioBase<Analisis> repositorio = new RepositorioBase<Analisis>();
            AnalisisDropdownList.DataSource = repositorio.GetList(x => true);
            AnalisisDropdownList.DataValueField = "AnalisisID";
            AnalisisDropdownList.DataTextField = "AnalisisID";
            AnalisisDropdownList.DataBind();
          
        }
        protected void buscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Pago> rep = new RepositorioBase<Pago>();
            Pago a = rep.Buscar(Utils.ToInt(IdTextBox.Text));
            if (a != null)
                LlenarCampo(a);
            else
            {
                Limpiar();
                Utils.ShowToastr(this.Page, "Id no exite", "Error", "error");
            }
        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void RemoveLinkButton_Click(object sender, EventArgs e)
        {
            if (DatosGridView.Rows.Count > 0 && DatosGridView.SelectedIndex >= 0)
            {
                Pago pago = new Pago();
                pago = (Pago)ViewState["Pago"];
                GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
                pago.RemoverPAgoDetalle(row.RowIndex);
                ViewState["Analisis"] = pago;
                this.BindGrid();
        
            }

        }
        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Pago pago = new Pago();
            pago = (Pago)ViewState["Pago"];
            pago.AgregarDetalle(0,Utils.ToInt(IdTextBox.Text),
                                    Utils.ToInt(AnalisisDropdownList.SelectedValue),Convert.ToDecimal(MontoTextBox.Text),DateTime.Now);
            ViewState["Pago"] = pago;
            this.BindGrid();

        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioPago repositorio = new RepositorioPago();
            Pago pago = repositorio.Buscar(Utils.ToInt(IdTextBox.Text));


            if (pago == null)
            {
                if (repositorio.Guardar(LlenaClase()))
                {

                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    Limpiar();
                }
                else
                {
                    Utils.ShowToastr(this, "No existe", "Error", "error");
                    Limpiar();
                }

            }
            else
            {
                if (repositorio.Modificar(LlenaClase()))
                {
                    Utils.ShowToastr(this.Page, "Modificado con exito!!", "Guardado", "success");
                    Limpiar();
                }
                else
                {
                    Utils.ShowToastr(this.Page, "No se puede modificar", "Error", "error");
                    Limpiar();
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            GridViewRow grid = DatosGridView.SelectedRow;
            RepositorioPago repositorio = new RepositorioPago();


            if (IdTextBox.Text == 0.ToString())
            {
                Utils.ShowToastr(this.Page, "Id no exite", "success");
                return;
            }
            if (repositorio.Eliminar(Utils.ToInt(IdTextBox.Text)))
            {
                Utils.ShowToastr(this.Page, "Exito Eliminado", "success");
                Limpiar();
            }
            else
                EliminarRequiredFieldValidator.IsValid = false;

        }

        protected void AnalisisDropdownList_SelectedIndexChanged(object sender, EventArgs e)
        {
         if (AnalisisDropdownList.Items.Count > 0)
            {
                int AnalisisID = AnalisisDropdownList.SelectedValue.Length;

            }
        }
    }
}