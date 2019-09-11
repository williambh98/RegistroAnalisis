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
        int a = 0;
        private Analisis analisis = new Analisis();
        private RepositorioBase<Analisis> repositorio = new RepositorioBase<Analisis>();
        private RepositorioBase<TipoAnalisis> repositorioBase = new RepositorioBase<TipoAnalisis>();
        private RepositorioAnalisis repositorioAnalisis = new RepositorioAnalisis();
        private List<DetalleAnalisis> detalles = new List<DetalleAnalisis>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //si llego in id
                EnableViewState = true;
                ViewState.Add("Detalle", detalles);
                ViewState.Add("Analisis", analisis);
                ViewState.Add("Index", a);
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
                else
                {
                    detalles = (List<DetalleAnalisis>)ViewState["Detalle"];
                }
            }
        }
        protected void BindGrid()
        {

            DatosGridView.DataSource = ((Analisis)ViewState["Analisis"]).detalle;
            DatosGridView.DataBind();
        }
        private List<DetalleAnalisis> ListaVacia()
        {
            List<DetalleAnalisis> detallesAnalisis = new List<DetalleAnalisis>();
            detallesAnalisis.Add(new DetalleAnalisis());
            return detallesAnalisis;
        }
        private Analisis LlenaClase()
        {
            analisis = (Analisis)ViewState["Analisis"];

            analisis.AnalisisID = Utils.ToInt(IdTextBox.Text);
            analisis.PacienteID = PacientsDropdownList.SelectedValue.Length;
            analisis.fecha = DateTime.Now;
            analisis.detalle = detalles;
            return analisis;

        }
        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            PacientsDropdownList.ClearSelection();
            TipoADropdonwList.SelectedIndex = 0;
            DatosGridView.DataSource = null;
            DatosGridView.DataBind();
        }

        private void LlenarCampo(Analisis analisis)
        {
            Limpiar();
            AnalisisID.Text = analisis.AnalisisID.ToString();
            PacientsDropdownList.SelectedValue = analisis.PacienteID.ToString();
            LabelFecha.Text = analisis.fecha.ToString();
            //ViewState[KeyViewState] = analisis;
            this.BindGrid();
        }
        private void LlenarCombo()
        {
            TipoADropdonwList.Items.Clear();
            TipoADropdonwList.Items.Clear();
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
        protected void AddLinkButton_Click(object sender, EventArgs e)
        {
            Analisis analisis = new Analisis();
            analisis = (Analisis)ViewState["Analisis"];
            //  analisis.detalle.Add(new DetalleAnalisis(TipoDropDownList.SelectedIndex = 0));
            ViewState["detalle"] = analisis.detalle;
            this.BindGrid();
            DatosGridView.Columns[1].Visible = false;

        }
        protected void buscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Analisis> rep = new RepositorioBase<Analisis>();
            Analisis a = rep.Buscar(Utils.ToInt(IdTextBox.Text));
            if (a != null)
            {
                LlenarCampo(a);
                ViewState["detalle"] = a.detalle;
            }
            else
            {
                Utils.ShowToastr(this.Page, "Id no exite", "Error", "error");
                Limpiar();
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
                int indice = int.Parse(ViewState["Index"].ToString());
                detalles.RemoveAt(indice);
                ViewState["detalle"] = detalles;
                DatosGridView.DataSource = detalles;
                DatosGridView.DataBind();

                RepositorioBase<Analisis> repositoriom = new RepositorioBase<Analisis>();
            }

        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ResultadoATextBox.Text))
                return;
            Analisis analisis = new Analisis();
           // analisis = ViewState[KeyViewState].ToAnalisis();
            analisis.AgragarDetalle(0, analisis.AnalisisID, tipoADropdonwList.SelectedValue.Length, ResultadoATextBox.Text);
           // ViewState[KeyViewState] = analisis;
            this.BindGrid();
            ResultadoATextBox.Text = string.Empty;
        }
        protected void AgregarAnaliss_Click(object sender, EventArgs e)
        {
            RepositorioBase<TipoAnalisis> repositorio = new RepositorioBase<TipoAnalisis>();
            if (!string.IsNullOrEmpty(DescripcionTextBox.Text))
            {
                repositorio.Guardar(new TipoAnalisis(0, DescripcionTextBox.Text, DateTime.Now));
            }
            LlenarCombo();
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
            List<DetalleAnalisis> lista = (List<DetalleAnalisis>)ViewState["Detalle"];
            RepositorioBase<Analisis> repositorio = new RepositorioBase<Analisis>();
            Analisis analisis = repositorio.Buscar(Utils.ToInt(IdTextBox.Text));

            if (IsValid)
            {
                if (analisis != null)
                {
                    repositorio.Eliminar(analisis.AnalisisID);
                    DatosGridView.DataSource = ViewState["Detalle"];
                    DatosGridView.DataBind();

                    Utils.ShowToastr(this.Page, "Exito Eliminado", "success");
                    Limpiar();
                }
                else
                {
                    Utils.ShowToastr(this.Page, "Revisar todos los campo", "Error", "error");
                    Limpiar();
                }
            }
        }
    }
  }
    
