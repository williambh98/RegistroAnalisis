<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ranalisis.aspx.cs" Inherits="RegistroAnalisis.UI.Registros.Ranalisis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .modal-lg {
            max-width: 80% !important;
        }
    </style>
     <script></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">Registro de Analisis</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <%--AnalisisId--%>
                    <div class="form-group">
                        <label for="IdTextBox" class="col-md-3 control-label input-sm">ID: </label>
                        <div class="col-md-4">
                            <asp:TextBox class="form-control input-sm" TextMode="Number" ID="IdTextBox" Text="0" runat="server"></asp:TextBox>
                        </div>
                        <asp:Button class="btn btn-info btn-sm" ID="BuscarButton" runat="server" Text="Buscar" OnClick="buscarButton_Click" />
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="IdTextBox" ErrorMessage="*" ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="IdRegularExpressionValidator" runat="server" ControlToValidate="IdTextBox" ErrorMessage="Porfavor ingrese un numero" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Buscar"></asp:RegularExpressionValidator>
                    </div>
                    <%--    Fecha--%>
                    <div class="form-group">
                        <label for="fechaTextBox" class="col-md-3 control-label input-sm">Fecha: </label>
                        <div class="col-md-8">
                            <asp:TextBox class="form-control" ID="fechaTextBox" TextMode="Date" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <%--  Pacienetes--%>
                    <div class="form-group">
                        <label for="PacienteTextBox" class="col-md-3 control-label input-sm">Paciente: </label>
                        <div class="col-md-8">
                            <div>
                                <asp:DropDownList ID="PacientsDropdownList" CssClass=" form-control dropdown-item" AppendDataBoundItems="true" runat="server" Height="2.8em">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <%--TipoAnalisis--%>
                    <div class="form-group">
                        <label for="TipoADropdonwList" class="col-md-3 control-label input-sm">Tipo Analisis: </label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="TipoADropdonwList" CssClass=" form-control dropdown-toggle-split" AppendDataBoundItems="true" runat="server" Height="2.5em">
                            </asp:DropDownList>
                        </div> 
                      <%-- <asp:Button Text="Agregar" class="btn btn-info" runat="server" ID="Button1" data-toggle="modal" data-target="#TipoanalisisModal" />--%>
                       <button aria-describedby="TipoADropdonwList" type="button" class="btn btn-info" data-toggle="modal" data-target="#TipoanalisisModal" runat="server">+</button>
                    </div>
                    <%--Resultados--%>
                    <div class="form-group">
                        <label for="IdResultado" class="col-md-3 control-label input-sm">Resultados: </label>
                        <div class="col-md-6">
                            <asp:TextBox class="form-control input-sm" ID="ResultadoTextBox" runat="server"></asp:TextBox>
                     <%--Agregar--%>
                        </div>
                        <asp:Button class="btn btn-info btn-sm" ID="ResultadoButton" runat="server" Text="Agregar" OnClick="AgregarButton_Click" />
                    </div>
                    <%--GRID--%>
                    <div class="row">
                        <asp:GridView ID="DatosGridView"
                            runat="server"
                            class="table table-condensed table-bordered table-responsive"
                            CellPadding="4" ForeColor="#333333" GridLines="None">

                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                 <asp:TemplateField ShowHeader="False" HeaderText="Remover">
                                    <ItemTemplate>
                                        <asp:Button ID="RemoveLinkButton" runat="server" CausesValidation="false" CommandName="Select"
                                            Text="--- " class="btn btn-danger btn-sm" OnClick="RemoveLinkButton_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:HyperLinkField ControlStyle-ForeColor="blue"
                                    DataNavigateUrlFields="AnalisisID"
                                    Text="Editar"></asp:HyperLinkField>--%>
                            </Columns>
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" />
                        </asp:GridView>
                    </div>
                    <%--Remover--%>
                   <%-- <div class="col-md-6 col-md-offset-0">
                        <asp:Button ID="RemoverClick" runat="server" CausesValidation="false" CommandName="Select" Text="Remover" class="btn btn-danger btn-sm" OnClick="RemoveLinkButton_Click" />

                    </div>--%>
                </div>


            </div>
            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
            <div class="panel-footer">
                <div class="text-center">
                    <div class="form-group" style="display: inline-block">

                        <asp:Button Text="Nuevo" class="btn btn-warning btn-sm" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                        <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="GuadarButton" OnClick="GuardarButton_Click" />
                        <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />
                         <asp:RequiredFieldValidator ID="EliminarRequiredFieldValidator" CssClass="col-md-1 col-sm-1" runat="server" ControlToValidate="IdTextBox" ErrorMessage="Es necesario elegir ID valido para eliminar" ValidationGroup="Eliminar">Porfavor elige un ID valido.</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="EliminarRegularExpressionValidator" CssClass="col-md-1 col-sm-1 col-md-offset-1 col-sm-offset-1" runat="server" ControlToValidate="PresupuestoTextBox" ErrorMessage="RegularExpressionValidator" ValidationExpression="\d+ " ValidationGroup="Eliminar" Visible="False"></asp:RegularExpressionValidator>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal agregar analisis -->

    <div class="modal fade" id="TipoanalisisModal" tabindex="-1" role="dialog" aria-labelledby="ModalLabel" aria-hidden="true">
<%--        <div class="modal" tabindex="-1" role="dialog">--%>
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Agragar analsiis</h5>
                        <button type="button" class="Cerrar" data-dismiss="modal" aria-label="Cerrar">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="DescripcionLb">Descripcion: </span>
                    </div>
                    <div aria-describedby="Descripcion">
                        <asp:TextBox ID="DescripcionTextBox" runat="server" class="form-control input-sm"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="AgregarAnaliss" class="btn btn-success" Text="Guardar" runat="server" data-dismiss="modal" UseSubmitBehavior="false" OnClick="AgregarAnalis_Click"/>
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            </div>
        </div>
<%--    </div>--%>
</asp:Content>
