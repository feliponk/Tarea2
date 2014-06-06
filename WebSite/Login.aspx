<%@ Page Title="" Language="C#" MasterPageFile="~/Login.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%-- Agregue aquí los controles de contenido --%>



<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <asp:Table ID="Table1" runat="server" Width="430px">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label runat="server" Text="Usuario"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:TextBox ID="TextBox1" runat="server" class="form-poshytip" title="Ingrese su usuarios"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="Label1" runat="server" Text="Contraseña"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:TextBox ID="TextBox2" type="Password" runat="server" class="form-poshytip" title="Ingrese su contraseña"></asp:TextBox>
                  <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Finalizar" />
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            
        </asp:TableRow>
    </asp:Table>
</asp:Content>




