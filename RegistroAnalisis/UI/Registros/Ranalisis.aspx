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
                        <div class="container">
                            <div class="form-group">
                                <asp:Label ID="LabelID" runat="server" Text="Id:"></asp:Label>
                                <asp:Button class="btn btn-info btn-sm" ID="BuscarButton" runat="server" Text="Buscar" />
                                <asp:TextBox class="form-control" ID="IdTextBox" Text="0" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <%--    Fecha--%>
                    <div class="col-md-4 col-md-offset-3">
                        <div class="container">
                            <div class="form-group">
                                <asp:Label ID="LabelFecha" runat="server" Text="Fecha:"></asp:Label>
                                <asp:TextBox class="form-control" ID="fechaTextBox" type="date" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                <%--  Pacienetes--%>
                <div class="form-group">
                    <label for="PacienteTextBox" class="col-md-3 control-label input-sm">Paciente: </label>
                    <div class="col-md-8">
                        <div aria-describedby="PacienteDropdownList">
                            <asp:DropDownList ID="PacientsDropdownList" CssClass=" form-control dropdown-item" AppendDataBoundItems="true" runat="server" Height="2.8em">
                            </asp:DropDownList>
                        </div>
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

                <asp:Button Text="Nuevo" class="btn btn-warning btn-sm" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" />
                <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />

            </div>
        </div>

    </div>
    <!-- Modal -->

    <div class="modal fade" id="PacientesModal" tabindex="-1" role="dialog" aria-labelledby="ModalLabel" aria-hidden="true">
        <div class="modal" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Modal title</h5>
                        <button type="button" class="Cerrar" data-dismiss="modal" aria-label="Cerrar">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <p>Modal body text goes here.</p>
                    </div>
                    <div class="modal-footer">
                        <asp:LinkButton ID="PacientesButton" CssClass="btn btn-info btn-block btn-md" data-toggle="modal" data-target="#myModal" CausesValidation="False" runat="server" Text="<span class='glyphicon glyphicon-search'></span>" />
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
