<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SimpleSevenWonders.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>7 Wonders App</h1>
    </div>

    <div class="row">
        <div class="col-md-4">
	        <h2>Register game</h2>
			<p>Nr. of players</p>
			<asp:DropDownList ID="NrOfPlayers" runat="server" Width="75">
				<asp:ListItem>3</asp:ListItem>
				<asp:ListItem>4</asp:ListItem>
				<asp:ListItem>5</asp:ListItem>
				<asp:ListItem>6</asp:ListItem>
				<asp:ListItem>7</asp:ListItem>
			</asp:DropDownList>
			<asp:Button ID="GoToGameCreationPage" runat="server" Text="Go" OnClick="GoToGameCreationPage_Click" />
        </div>
        <div class="col-md-4">
            <h2>row 2</h2>

        </div>
        <div class="col-md-4">
            <h2>row 3</h2>

        </div>
    </div>

</asp:Content>
