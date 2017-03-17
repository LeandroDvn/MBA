<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Todos.aspx.cs" Inherits="BigData.Graficos.Todos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView
        ID="gvProdutos"
        class="table table-striped"
        runat="server"
        AllowPaging="True"
        OnPageIndexChanging="gvProdutos_PageIndexChanging"
        PageSize="14" PagerStyle-HorizontalAlign="Center" PagerStyle-VerticalAlign="NotSet" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Código" HeaderText="Código" />
            <asp:BoundField DataField="Produto" HeaderText="Produto" />
            <asp:BoundField DataField="Quantidade de Vendas" HeaderText="Quantidade de Vendas" DataFormatString="{0:n}" HtmlEncode="False" ItemStyle-HorizontalAlign="Right"  />
            <asp:BoundField DataField="Preço de venda" HeaderText="Preço de venda" DataFormatString="{0:c}" HtmlEncode="False" ItemStyle-HorizontalAlign="Right"  />
            <asp:BoundField DataField="Custo" HeaderText="Custo" DataFormatString="{0:c}" HtmlEncode="False"  ItemStyle-HorizontalAlign="Right"   />
        </Columns>
    </asp:GridView>
</asp:Content>
