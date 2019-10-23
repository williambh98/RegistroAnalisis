<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Canalisis.aspx.cs" Inherits="RegistroAnalisis.UI.Consultas.Canalisis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
       function ShowReporte(title) {
           $("#ModalReporte .modal-title").html(title);
           $("#ModalReporte").modal("show");
       }
    </script>
    <%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="panel panel-primary">
        <div class="panel-heading">Consulta de Analisis</div>
        <div class="panel-body">

            <div >
                <div class="col-md-2">
                    <asp:DropDownList ID="BuscarPorDropDownList" runat="server" CssClass="form-control input-sm" >
                        <asp:ListItem>Todos</asp:ListItem>
                        <asp:ListItem>AnalisisID</asp:ListItem>
                        <asp:ListItem>Nombres</asp:ListItem>
                         <asp:ListItem>Fecha</asp:ListItem>
                    </asp:DropDownList>
                </div>

                  <%--Criterio--%>
                <div class="col-md-6">
                    <asp:TextBox ID="FiltroTextBox" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <asp:Button ID="BuscarButton" runat="server" Class="btn btn-success input-sm" Text="Buscar" OnClick="BuscarButton_Click" />
                </div>
            </div>
                 <%--Selercionar solo por fecha--%>
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <asp:CheckBox AutoPostBack="true" Checked="true" OnCheckedChanged="FechaCheckBox_CheckedChanged" ID="fechaCheckBox" runat="server" Text="Filtrar solo por fecha" />
                        </div>
                    </div>

              <%--Rango fecha--%>
            <div class="form-row justify-content-center">
                <div class="form-group col-md-2">
                    <asp:Label Text="Desde" runat="server" />
                    <asp:TextBox ID="DesdeTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                </div>
                <div class="form-group col-md-2">
                    <asp:Label Text="Hasta" runat="server" />
                    <asp:TextBox ID="HastaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
                </div>
            </div>
            <%--GRID--%>
            <div class="col-md-12">
                <asp:GridView ID="DatosGridView"
                    runat="server"
                    class="table table-condensed table-bordered table-responsive"
                    CellPadding="4" ForeColor="#333333" GridLines="None">

                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:HyperLinkField ControlStyle-ForeColor="blue"
                            DataNavigateUrlFields="AnalisisID"
                            
                            DataNavigateUrlFormatString="~/UI/Registros/Ranalisis.aspx?Id={0}"
                            Text="Editar"></asp:HyperLinkField>
                    </Columns>
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                </asp:GridView>
            </div>
             <%--Imprimir--%>
            <div class="card-footer">
                <div class="justify-content-start">
                    <div class="form-group" style="display: inline-block">
                        <button type="button" class="btn btn-success mt-4" data-toggle="modal" data-target=".bd-example-modal-lg">Imprimir</button>
                    </div>
                </div>
            </div>

             <!-- Modal para mi Reporte.// -->
            <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
               <div class="modal-dialog" style="max-width: 600px!important; min-width: 300px!important">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">REPORTE ANALISIS</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <%--Viewer--%>
                            <rsweb:ReportViewer ID="MyAnalisisReportViewer" runat="server" ProcessingMode="Remote" Height="450px" Width="500px">
                                <ServerReport ReportPath="" ReportServerUrl="" />
                            </rsweb:ReportViewer>
                        </div>
                        <div class="modal-footer">
                        </div>
                    </div>
                </div>
          </div>

        </div>
    </div>
</asp:Content>
