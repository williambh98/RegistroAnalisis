using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroAnalisis.UI.Consultas
{
    public partial class Canalisis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Analisis, bool>> filtro = x => true;
            RepositorioBase<Analisis> repositorio = new RepositorioBase<Analisis>();
            List<TipoAnalisis> TiposAnalisis = new RepositorioBase<TipoAnalisis>().GetList(x => true);
            int id;
            switch (BuscarPorDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = x => true;
                    break;
                case 1://ID
                    id = Utilitarios.Utils.ToInt(FiltroTextBox.Text);
                    filtro = c => c.AnalisisID == id;
                    break;
                case 2:// nombre
                    id = Utilitarios.Utils.ToInt(FiltroTextBox.Text);
                    filtro = c => c.PacienteID == id;
                    break;
            }
            //DateTime fechaDesde = DesdeTextBox.Text.ToDatetime();
            ////DateTime FechaHasta = HastaTextBox.Text.ToDatetime();
            //List<Analisis> lista = repositorio.GetList(filtro).Where(c => c.fecha >= Desde && c.fecha <= Hasta).ToList();
            //this.BindGrid(lista);
        }
        private void BindGrid(List<Analisis> lista)
        {
            DatosGridView.DataSource = lista;
            DatosGridView.DataBind();
        }

    }
}