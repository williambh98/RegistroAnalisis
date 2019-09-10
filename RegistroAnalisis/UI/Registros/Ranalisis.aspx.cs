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
                    //else
                        //LlenaCampos(user);

                }
                else
                {
                    detalles = (List<DetalleAnalisis>)ViewState["Detalle"];
                }
            }
        }
    }
}