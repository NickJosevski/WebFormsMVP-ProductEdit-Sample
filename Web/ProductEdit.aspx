<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProductEdit.aspx.cs" Inherits="WebFormEventModelExperiments.ProductEdit" %>
<%@ Register Src="~/Controls/ProductEditControl.ascx" TagPrefix="uc" TagName="ProductEditControl" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>2-Way Data-binding Demo: Product CRUD</h1>
    <uc:ProductEditControl runat="server" />
</asp:Content>