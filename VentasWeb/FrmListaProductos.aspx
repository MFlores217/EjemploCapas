<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="FrmListaProductos.aspx.cs" Inherits="VentasWeb.FrmListaProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function MostrarMensaje(mensaje) {
            alert(mensaje);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-8 mx-auto">
                <h1>Listado de productos</h1>
                <hr/>
                <asp:Label runat="server" Text="Descripción" CssClass="form-label" ID="lblDescripcion"></asp:Label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-success mt-2" OnClick="btnBuscar_Click"/>
                <asp:Button ID="btnNuevo" runat="server" Text="Agregar nuevo producto" CssClass="btn btn-primary mt-2" OnClick="btnNuevo_Click"/>
                <hr/>
                <asp:GridView ID="grdLista" runat="server" AllowPaging="True" EmptyDataText="No hay registros disponibles" Width="100%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="grdLista_PageIndexChanging" PageSize="5">
                    <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                    <Columns>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripci&#243;n"></asp:BoundField>
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad"></asp:BoundField>
                        <asp:BoundField DataField="Precio" HeaderText="Precio"></asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkModificar" runat="server" CommandName="Modificar" CommandArgument='<%# Eval("Id").ToString() %>' OnCommand="lnkModificar_Command">Modificar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("Id").ToString() %>' OnCommand="lnkEliminar_Command">Eliminar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White"></FooterStyle>

                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White"></HeaderStyle>

                    <PagerStyle HorizontalAlign="Center" BackColor="#FFCC66" ForeColor="#333333"></PagerStyle>

                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333"></RowStyle>

                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy"></SelectedRowStyle>

                    <SortedAscendingCellStyle BackColor="#FDF5AC"></SortedAscendingCellStyle>

                    <SortedAscendingHeaderStyle BackColor="#4D0000"></SortedAscendingHeaderStyle>

                    <SortedDescendingCellStyle BackColor="#FCF6C0"></SortedDescendingCellStyle>

                    <SortedDescendingHeaderStyle BackColor="#820000"></SortedDescendingHeaderStyle>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
