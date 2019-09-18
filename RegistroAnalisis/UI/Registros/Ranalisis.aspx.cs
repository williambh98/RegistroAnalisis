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
    public partial class Ranalisis : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                //si llego in id
                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    RepositorioBase<Analisis> repositorio = new RepositorioBase<Analisis>();
                    Analisis user = repositorio.Buscar(id);
                    if (user == null)
                        Utils.ShowToastr(this, "Id no existe", "Error", "error");
                    else
                        LlenarCombo();
                    LlenarCampo(user);
                }
                LlenarCombo();
                ViewState["Analisis"] = new Analisis();
            }
        }
        protected void BindGrid()
        {
            DatosGridView.DataSource = ((Analisis)ViewState["Analisis"]).detalle;
            DatosGridView.DataBind();
        }
        private Analisis LlenaClase()
        {
            Analisis analisis = new Analisis();
            analisis = (Analisis)ViewState["Analisis"];
            analisis.AnalisisID = Utils.ToInt(IdTextBox.Text);
            analisis.PacienteID = PacientsDropdownList.SelectedValue.Length;
            analisis.fecha = DateTime.Now;
            analisis.Monto = 0;
            return analisis;
        }
        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            PacientsDropdownList.ClearSelection();
            ResultadoTextBox.Text = string.Empty;
            fechaTextBox.Text = DateTime.Now.ToString();
            MontoTextBox.Text = 0.ToString();
            BalanceTextBox.Text = 0.ToString();
            ViewState["Analisis"] = new Analisis();
            LlenarCombo();
            this.BindGrid();
        }

        private void LlenarCampo(Analisis analisis)
        {
            Limpiar();
            IdTextBox.Text = analisis.AnalisisID.ToString();
            PacientsDropdownList.SelectedValue = analisis.PacienteID.ToString();
            MontoTextBox.Text = analisis.Monto.ToString();
            BalanceTextBox.Text = analisis.Balance.ToString();
            fechaTextBox.Text = analisis.fecha.ToString();
            ViewState["Analisis"] = analisis;
            CalcularMonto();
            this.BindGrid();
        }
        private void LlenarCombo()
        {
            TipoADropdonwList.Items.Clear();
            PacientsDropdownList.Items.Clear();
            RepositorioBase<TipoAnalisis> repositorio = new RepositorioBase<TipoAnalisis>();
            TipoADropdonwList.DataSource = repositorio.GetList(x => true);
            TipoADropdonwList.DataValueField = "TipoID";
            TipoADropdonwList.DataTextField = "Descripcion";
            TipoADropdonwList.DataBind();

           
            RepositorioBase<Pacientes> repositorioPacientes = new RepositorioBase<Pacientes>();
            PacientsDropdownList.DataSource = repositorioPacientes.GetList(x => true);
            PacientsDropdownList.DataValueField = "PacienteID";
            PacientsDropdownList.DataTextField = "Nombre";
            PacientsDropdownList.DataBind();
        }
        protected void buscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Analisis> rep = new RepositorioBase<Analisis>();
            Analisis a = rep.Buscar(Utils.ToInt(IdTextBox.Text));
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
                Analisis analisis = new Analisis();
                analisis = (Analisis)ViewState["Analisis"];
                GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
                analisis.RemoverDetalle(row.RowIndex);
                ViewState["Analisis"] = analisis;
                this.BindGrid();
                CalcularMonto();
            }

        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Analisis analisis = new Analisis();
            analisis = (Analisis)ViewState["Analisis"];
            analisis.AgragarDetalle(0, Utils.ToInt(IdTextBox.Text),
                                    Utils.ToInt(TipoADropdonwList.SelectedValue), ResultadoTextBox.Text);
            ViewState["Analisis"] = analisis;
            this.BindGrid();

        }
        protected void AgregarAnalis_Click(object sender, EventArgs e)
        {
            RepositorioBase<TipoAnalisis> repositorio = new RepositorioBase<TipoAnalisis>();
            if (!string.IsNullOrEmpty(DescripcionTextBox.Text))
            {
                repositorio.Guardar(new TipoAnalisis(0, DescripcionTextBox.Text, Convert.ToDecimal(PrecioATexBox.Text), DateTime.Now));
            }
            LlenarCombo();
        }
        public void CalcularMonto()
        {
            //decimal Monto = 0;
            //Analisis analisis = new Analisis();
            //analisis = (Analisis)ViewState["Analisis"];
            //foreach (var item in analisis.
            //{
            //    TipoAnalisis tipo = new RepositorioBase<TipoAnalisis>().Buscar(item.TipoAnalisisID);
            //    Monto += tipo.EsNulo() ? 0 : tipo.Monto;
            //}
            //analisis.Monto = Monto;
            //ViewState[KeyViewState] = analisis;
            //this.BindGrid();
        }
        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioAnalisis repositorio = new RepositorioAnalisis();
            Analisis analisis = repositorio.Buscar(Utils.ToInt(IdTextBox.Text));


            if (analisis == null)
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
            RepositorioAnalisis repositorio = new RepositorioAnalisis();


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
    }
}

