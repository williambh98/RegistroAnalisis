using BLL;
using Entidades;
using Microsoft.Reporting.WebForms;
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
        static List<Analisis> lista = new List<Analisis>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenaReport();
            }
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Analisis, bool>> filtro = x => true;
            RepositorioBase<Analisis> repositorio = new RepositorioBase<Analisis>();
       
           // List<TipoAnalisis> TiposAnalisis = new RepositorioBase<TipoAnalisis>().GetList(x => true);
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
            DateTime desdeTextBox = Utilitarios.Utils.ToFecha(DesdeTextBox.Text);
            DateTime FechaHasta = Utilitarios.Utils.ToFecha(HastaTextBox.Text);
            if (fechaCheckBox.Checked)
                lista = repositorio.GetList(filtro).Where(c => c.fecha >= desdeTextBox && c.fecha <= FechaHasta).ToList();
            else
                lista = repositorio.GetList(filtro);
                this.BindGrid(lista);
        }
        private void BindGrid(List<Analisis> lista)
        {
            DatosGridView.DataSource = lista;
            DatosGridView.DataBind();
        }

        protected void FechaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (fechaCheckBox.Checked)
            {
                fechaCheckBox.Visible = true;
                fechaCheckBox.Visible = true;
            }
            else
            {
                fechaCheckBox.Visible = false;
                fechaCheckBox.Visible = false;
            }
        }

        public void LlenaReport()
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", $"ShowReporte('');", true);
            MyAnalisisReportViewer.ProcessingMode = ProcessingMode.Local;
            MyAnalisisReportViewer.Reset();
            MyAnalisisReportViewer.LocalReport.ReportPath = Server.MapPath(@"\Reportes\ReportAnalisis.rdlc");
            MyAnalisisReportViewer.LocalReport.DataSources.Clear();
            MyAnalisisReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Analisis", Metodo.Analisis()));
            MyAnalisisReportViewer.LocalReport.Refresh();
        }

    }
}