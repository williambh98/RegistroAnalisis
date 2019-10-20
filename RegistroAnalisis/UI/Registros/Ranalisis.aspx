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
                            <asp:TextBox CssClass="form-control input-sm" TextMode="Number" ID="IdTextBox" Text="0" runat="server"></asp:TextBox>
                        </div>
                        <asp:Button CssClass="col-md-1 btn btn-info btn-sm" ID="BuscarButton" runat="server" Text="Buscar" OnClick="buscarButton_Click" />
                        <label for="fechaTextBox" class="col-md-2 control-label input-sm">Fecha: </label>
                        <div class="col-md-2">
                            <asp:TextBox CssClass="form-control" ID="fechaTextBox" TextMode="Date" runat="server"></asp:TextBox>
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
                        <button aria-describedby="TipoADropdonwList" type="button" class="btn btn-info" data-toggle="modal" data-target="#TipoAModal" runat="server">+</button>
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

                    <%--  Monto--%>
                    <div class="form-group">
                        <label for="MontoTextBox" class="col-md-3 control-label input-sm">Monto: </label>
                        <div class="col-md-3">
                            <asp:TextBox class="form-control input-sm" ReadOnly="True" ID="MontoTextBox" Text="0" runat="server"></asp:TextBox>
                        </div>
                        <%--Balance--%>
                        <label for="BalanceTextBox" class="col-md-1 control-label input-sm">Balance: </label>
                        <div class="col-md-3">
                            <asp:TextBox class="form-control input-sm" ReadOnly="true" ID="BalanceTextBox" Text="0" runat="server"></asp:TextBox>
                        </div>
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
                                            Text="---------- " class="btn btn-success btn-sm" OnClick="RemoveLinkButton_Click" />
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
                    <%--  <div class="col-md-6 col-md-offset-0">
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
    <div class="modal fade" id="TipoAModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog ml-sm-auto" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="AgregarAnalisisLB">Agregar Analisis</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text" id="DescripcionLb">Descripción </span>
                        </div>
                        <div aria-describedby="Descripcion">
                            <asp:TextBox ID="DescripcionTextBox" runat="server" class="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                    <div class="input-group mb-3">
                        <div class="input-group-append">
                            <span class="input-group-text" id="PrecioLB">Precio </span>
                        </div>
                        <div aria-describedby="DescripcionLb">
                            <asp:TextBox ID="PrecioATexBox" TextMode="Number" runat="server" class="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                    <asp:Button ID="AgregarAnaliss" class="btn btn-success" Text="Guardar" runat="server" data-dismiss="modal" UseSubmitBehavior="false" OnClick="AgregarAnalis_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
