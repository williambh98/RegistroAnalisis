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
    public partial class Cpago : System.Web.UI.Page
    {
        static List<PagoDetalle> lista = new List<PagoDetalle>();
        protected void Page_Load(object sender, EventArgs e)
        {
            DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            if (!Page.IsPostBack)
            {
                LlenaReport();
            }
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<PagoDetalle, bool>> filtro = x => true;
            RepositorioBase<PagoDetalle> repositorio = new RepositorioBase<PagoDetalle>();

            // List<TipoAnalisis> TiposAnalisis = new RepositorioBase<TipoAnalisis>().GetList(x => true);
            int id;
            switch (BuscarPorDropDownList.SelectedIndex)
            {
                case 0://Todo
                    filtro = x => true;
                    break;
                case 1://ID
                    id = Utilitarios.Utils.ToInt(FiltroTextBox.Text);
                    filtro = c => c.IDpago == id;
                    break;
            }
            DateTime desdeTextBox = Utilitarios.Utils.ToFecha(DesdeTextBox.Text);
            DateTime FechaHasta = Utilitarios.Utils.ToFecha(HastaTextBox.Text);
            if (fechaCheckBox.Checked)
                lista = repositorio.GetList(filtro).Where(c => c.Fecha >= desdeTextBox && c.Fecha <= FechaHasta).ToList();
            else
                lista = repositorio.GetList(filtro);
            this.BindGrid(lista);
        }
        private void BindGrid(List<PagoDetalle> lista)
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
            MyPagoReportViewer.ProcessingMode = ProcessingMode.Local;
            MyPagoReportViewer.Reset();
            MyPagoReportViewer.LocalReport.ReportPath = Server.MapPath(@"\Reportes\ReportPago.rdlc");
            MyPagoReportViewer.LocalReport.DataSources.Clear();
            MyPagoReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Pago", Metodo.APago()));
            MyPagoReportViewer.LocalReport.Refresh();
        }


    }
}

