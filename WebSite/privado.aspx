<%@ Page Title="" Language="C#" MasterPageFile="~/privado.master" AutoEventWireup="true" CodeFile="privado.aspx.cs" Inherits="privado" %>

<%-- Agregue aquí los controles de contenido --%>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder4">
    <asp:Table ID="Table1" runat="server" Width="556px">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="Label2" runat="server" Text="Asunto"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="Label3" runat="server" Text="Mensaje"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:TextBox ID="TextBox2" runat="server" cols="45" rows="8"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Responder"/>
                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>



