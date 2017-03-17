<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Quantidade.aspx.cs" Inherits="BigData.Graficos.Quantidade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>       
        <div style="float:left"><asp:Literal ID="ltScripts" runat="server"></asp:Literal></div>
        
        <div style="float:left;width: 600px;">
            <asp:GridView ID="gvProdutos" class="table table-striped" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Código" HeaderText="Código" />
                    <asp:BoundField DataField="Produto" HeaderText="Produto" />
                    <asp:BoundField ItemStyle-CssClass="t-cost" DataField="Quantidade de Vendas" HeaderText="Quantidade de Vendas" DataFormatString="{0:n}" HtmlEncode="False"  ItemStyle-HorizontalAlign="Right" />
                </Columns>
            </asp:GridView>
        </div>

        <div style="float:left"><asp:Literal ID="ltScripts2" runat="server"></asp:Literal></div>
    </div>
</asp:Content>
