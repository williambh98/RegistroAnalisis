<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ranalisis.aspx.cs" Inherits="RegistroAnalisis.UI.Registros.Ranalisis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">Registro de Analisis</div>

            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <%--AnalisisId--%>
                    <div class="form-group">
                        <label for="IdTextBox" class="col-md-3 control-label input-sm">Id: </label>
                        <div class="col-md-1 col-sm-2 col-xs-4">
                            <asp:TextBox ID="IdTextBox" runat="server" ReadOnly="True" placeholder="0" class="form-control input-sm"></asp:TextBox>
                        </div>
                        <div class="col-md-1 col-sm-2 col-xs-4">
                            <asp:LinkButton ID="BusquedaButton" CssClass="btn btn-info btn-block btn-md" data-toggle="modal" data-target="#myModal" CausesValidation="False" runat="server" Text="<span class='glyphicon glyphicon-search'></span>" PostBackUrl="/UI/Consultas/Cusuario.aspx" />
                        </div>
                    </div>
                    <%--        Pacienetes--%>
                    <div class="form-group">
                        <label for="PacienteTextBox" class="col-md-3 control-label input-sm">Paciente: </label>
                        <div class="col-md-8">
                            <asp:TextBox ID="PacienteTextBox" CssClass=" form-control" placeholder="Paciente" runat="server" Height="2.5em"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                runat="server" ID="VPacienteTextBox"
                                ControlToValidate="PacienteTextBox" ForeColor="Red"
                                ErrorMessage="Por favor llenar el campo !"
                                Display="Dynamic" SetFocusOnError="true">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <%--     TipoAnalisis--%>
                    <div class="form-group">
                        <label for="TipoDropDownList" class="col-md-3 control-label input-sm">Tipo Analisis:</label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="TipoDropDownList" Class=" col-md-1 col-sm-2 col-xs-4" AppendDataBoundItems="true" runat="server" Height="2.5em">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-6 col-md-offset-0">

                        <asp:LinkButton ID="AddLinkButton" CssClass="btn btn-primary " runat="server">
                          <span class="fas fa-plus"></span> Agregar
                         
                        </asp:LinkButton>
                    </div>
                    <%--GRID--%>
                    <div class="row">
                        <asp:GridView ID="DatosGridView"
                            runat="server"
                            class="table table-condensed table-bordered table-responsive"
                            CellPadding="4" ForeColor="#333333" GridLines="None">

                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:HyperLinkField ControlStyle-ForeColor="blue"
                                    DataNavigateUrlFields="AnalisisID"
                                    DataNavigateUrlFormatString="~/UI/Registros/RUsuario.aspx?Id={0}"
                                    Text="Editar"></asp:HyperLinkField>
                            </Columns>
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" />

                           <%-- <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                        </asp:GridView>
                    </div>
                </div>

            </div>
            <div class="col-md-6 col-md-offset-0">

                <asp:LinkButton ID="RemoveLinkButton" CssClass="btn btn-danger " runat="server">
                          <span class="fas fa-plus"></span> Remove
                         
                </asp:LinkButton>
            </div>
        </div>
    </div>
    <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">

                <asp:Button Text="Nuevo" class="btn btn-warning btn-sm" runat="server" ID="NuevoButton" />
                <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="GuadarButton" />
                <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" runat="server" ID="EliminarButton" />

            </div>
        </div>

    </div>

</asp:Content>
