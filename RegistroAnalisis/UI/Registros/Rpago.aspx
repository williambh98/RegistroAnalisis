<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rpago.aspx.cs" Inherits="RegistroAnalisis.UI.Registros.Rpago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">Registro de Pago</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <%--PagoId--%>
                    <div class="form-group">
                        <label for="IDpagoTextBox" class="col-md-3 control-label input-sm">ID Pago: </label>
                        <div class="col-md-4">
                            <asp:TextBox class="form-control input-sm" TextMode="Number" ID="IdTextBox" Text="0" runat="server"></asp:TextBox>
                        </div>
                        <asp:Button class="btn btn-info btn-sm" ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                    </div>

                    <%--Analisis pago--%>
                    <div class="form-group">
                        <label for="AnalisisTextBox" class="col-md-3 control-label input-sm">Analisis: </label>
                        <div class="col-md-4">
                            <div>
                                <asp:DropDownList ID="AnalisisDropdownList" AutoPostBack="true" OnSelectedIndexChanged ="AnalisisDropdownList_SelectedIndexChanged" CssClass=" form-control dropdown-item" AppendDataBoundItems="true" runat="server" Height="2.8em">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <%--Balance--%>
                    <div class="form-group">
                        <label for="BalanceTextBox" class="col-md-3 control-label input-sm">Balance: </label>
                        <div class="col-md-4">
                            <asp:TextBox class="form-control input-sm" ReadOnly="True" ID="BalanceTextBox" Text="0" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <%--  Monto--%>
                    <div class="form-group">
                        <label for="MontoTextBox" class="col-md-3 control-label input-sm">Monto: </label>
                        <div class="col-md-4">
                            <asp:TextBox class="form-control input-sm" ReadOnly="False" ID="MontoTextBox" Text="0" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <%--  Fecha--%>
                    <div class="form-group">
                        <label for="fechaTextBox" class="col-md-3 control-label input-sm">Fecha: </label>
                        <div class="col-md-4">
                            <asp:TextBox class="form-control" ID="fechaTextBox" TextMode="Date" runat="server"></asp:TextBox>
                        </div>
                        <%--Agregar--%>
                        <asp:Button class="btn btn-info btn-sm" ID="AgregarButton" runat="server" Text="Agregar" OnClick="AgregarButton_Click" />
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
                    <div class="panel-footer">
                        <div class="text-center">
                            <div class="form-group" style="display: inline-block">

                                <asp:Button Text="Nuevo" class="btn btn-warning btn-sm" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                                <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="GuadarButton" OnClick="GuardarButton_Click" />
                                <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" runat="server" ID="EliminarButton" Onclik="EliminarButton_Click" />
                                <asp:RequiredFieldValidator ID="EliminarRequiredFieldValidator" CssClass="col-md-1 col-sm-1" runat="server" ControlToValidate="IdTextBox" ErrorMessage="Es necesario elegir ID valido para eliminar" ValidationGroup="Eliminar">Porfavor elige un ID valido.</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="EliminarRegularExpressionValidator" CssClass="col-md-1 col-sm-1 col-md-offset-1 col-sm-offset-1" runat="server" ControlToValidate="PresupuestoTextBox" ErrorMessage="RegularExpressionValidator" ValidationExpression="\d+ " ValidationGroup="Eliminar" Visible="False"></asp:RegularExpressionValidator>


                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
