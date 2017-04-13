<%@ Page Title="New Game" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewGame.aspx.cs" Inherits="SimpleSevenWonders.NewGame" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<h2><%: Title %></h2>
	<asp:Label ID="TopText" runat="server" Text="Label"></asp:Label>
	
	<asp:Panel ID="inputBoard" runat="server"></asp:Panel>

	<asp:Button ID="Submit" runat="server" Text="Submit game" OnClick="Submit_Click" />
</asp:Content>
