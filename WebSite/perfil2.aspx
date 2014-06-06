<%@ Page Title="" Language="C#" MasterPageFile="~/perfil2.master" AutoEventWireup="true" CodeFile="perfil2.aspx.cs" Inherits="perfil2" %>

<%-- Agregue aquí los controles de contenido --%>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <asp:Table ID="Table1" runat="server" Width="430px">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label runat="server" Text="Nombre"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:TextBox ID="TextBox1" runat="server" class="form-poshytip" title="Ingrese su usuarios"></asp:TextBox>
                
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="Label1" runat="server" Text="Edad"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="Label2" runat="server" Text="Sexo"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="Label3" runat="server" Text="Numero de comentarios"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="Label4" runat="server" Text="Fecha de registro"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:DropDownList ID="DropDownList4" runat="server"></asp:DropDownList>/
                <asp:DropDownList ID="DropDownList5" runat="server"></asp:DropDownList>/
                <asp:DropDownList ID="DropDownList6" runat="server"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label runat="server" Text="Tipo de usuario"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:TextBox ID="TextBox2" runat="server" class="form-poshytip" title="Ingrese su usuarios"></asp:TextBox>
                
            </asp:TableCell>

        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Editar"/>
                
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    
    <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
</asp:Content>
