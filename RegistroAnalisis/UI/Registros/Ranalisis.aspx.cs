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
            analisis.PacienteID = Utils.ToInt(PacienteTextBox.Text);
            analisis.detalle = detalles;
            return analisis;

        }
        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            PacienteTextBox.Text = string.Empty;
            TipoDropDownList.SelectedIndex = 0;
            DatosGridView.DataSource = null;
            DatosGridView.DataBind();
        }

        private void LlenarCampo(Analisis analisis)
        {
            TipoDropDownList.DataSource = repositorio.GetList(x => true);
            TipoDropDownList.DataValueField = "ID";
            TipoDropDownList.DataTextField = "Descripcion";
            TipoDropDownList.AppendDataBoundItems = true;
            TipoDropDownList.DataBind();
            DatosGridView.DataSource = analisis.detalle;
            DatosGridView.DataBind();
        }
        private void llenarDrownList()
        {
            TipoDropDownList.DataSource = repositorio.GetList(x => true);
            TipoDropDownList.DataValueField = "ID";
            TipoDropDownList.DataTextField = "Descripcion";
            TipoDropDownList.AppendDataBoundItems = true;
            TipoDropDownList.DataBind();


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
    
