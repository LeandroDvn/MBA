<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Vendas.aspx.cs" Inherits="BigData.Graficos.Vendas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>       
        <div style="float:left"><asp:Literal ID="ltScripts" runat="server"></asp:Literal></div>
        <div style="float:left"><asp:GridView ID="gvProdutos" class="table table-striped" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Código" HeaderText="Código" />
            <asp:BoundField DataField="Produto" HeaderText="Produto" />
            <asp:BoundField DataField="Preço de venda" HeaderText="Preço de venda" DataFormatString="{0:c}" HtmlEncode="False" ItemStyle-HorizontalAlign="Right"  />
        </Columns></asp:GridView></div>
    </div>
</asp:Content>
