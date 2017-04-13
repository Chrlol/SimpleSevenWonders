<%@ Page Title="New Game" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewGame.aspx.cs" Inherits="SimpleSevenWonders.NewGame" %>
<%@ Import Namespace="SimpleSevenWonders.Models" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<h2><%: Title %></h2>

	<asp:Panel ID="inputBoard" runat="server"></asp:Panel>

	<asp:Button ID="Submit" runat="server" Text="Submit game" OnClick="Submit_Click" />
</asp:Content>
