<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SimpleSevenWonders.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>7 Wonders App</h1>
    </div>

    <div class="row">
        <div class="col-md-4">
	        <h2>Register Game</h2>
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
            <h2>Create Player</h2>
			<asp:TextBox ID="PlayerName" runat="server"></asp:TextBox>
			<asp:Button ID="CreatePlayer" runat="server" Text="Create Player" OnClick="CreatePlayer_Click" />
        </div>
        <div class="col-md-4">
            <h2>Players</h2>
			<asp:GridView ID="Players" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1">
				<Columns>
					<asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
					<asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
				</Columns>
			</asp:GridView>
        	<asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="SimpleSevenWonders.Data.WondersContext" EntityTypeName="" Select="new (Id, Name)" TableName="Players">
			</asp:LinqDataSource>
			<asp:EntityDataSource ID="EntityDataSource1" runat="server">
			</asp:EntityDataSource>
        </div>
    </div>

</asp:Content>
