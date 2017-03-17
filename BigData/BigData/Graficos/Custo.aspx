<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Custo.aspx.cs" Inherits="BigData.Graficos.Custo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" class="table table-striped" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="float:left"><asp:Literal ID="ltScripts" runat="server"></asp:Literal></div>
        <div style="float:left"><asp:GridView ID="gvProdutos" class="table table-striped" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Código" HeaderText="Código" />
                    <asp:BoundField DataField="Produto" HeaderText="Produto" />
                    <asp:BoundField ItemStyle-CssClass="t-cost" DataField="Custo" HeaderText="Custo" DataFormatString="{0:c}" HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
                </Columns></asp:GridView></div>
</asp:Content>
