<%@ Page Title="" Language="C#" MasterPageFile="~/Registrarse.master" AutoEventWireup="true" CodeFile="Registrarse.aspx.cs" Inherits="Registrarse" %>

<%-- Agregue aquí los controles de contenido --%>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">
    
    <asp:Table ID="Table1" runat="server" Width="900px">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="Label1" runat="server" Text="Nombre de usuario"></asp:Label>
            </asp:TableCell>       
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:TextBox ID="TextBox4" runat="server" class="form-poshytip" title="Ingrese Nombre de usuario"></asp:TextBox>
                <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
            </asp:TableCell>
                
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="Label2" type="Password" runat="server" Text="Contraseña"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:TextBox type="Password" ID="TextBox1" runat="server" class="form-poshytip" title="Ingrese Contraseña"></asp:TextBox>
                <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
            </asp:TableCell>
              
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="Label3" type="Password" runat="server" Text="Repita contraseña"></asp:Label>
            
</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:TextBox type="Password" ID="TextBox2" runat="server" class="form-poshytip" title="Repita su contraseña"></asp:TextBox>
                <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
            </asp:TableCell>
                 
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="Label4" runat="server" Text="Fecha de nacimiento"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem value ="01">01</asp:listitem>
                    <asp:ListItem value ="02">02</asp:listitem>
                    <asp:ListItem value ="03">03</asp:listitem>
                    <asp:ListItem value ="04">04</asp:listitem>
                    <asp:ListItem value ="05">05</asp:listitem>
                    <asp:ListItem value ="06">06</asp:listitem>
                    <asp:ListItem value ="07">07</asp:listitem>
                    <asp:ListItem value ="08">08</asp:listitem>
                    <asp:ListItem value ="09">09</asp:listitem>
                    <asp:ListItem value ="10">10</asp:listitem>
                    <asp:ListItem value ="11">11</asp:listitem>
                    <asp:ListItem value ="12">12</asp:listitem>
                    <asp:ListItem value ="13">13</asp:listitem>
                    <asp:ListItem value ="14">14</asp:listitem>
                    <asp:ListItem value ="15">15</asp:listitem>
                    <asp:ListItem value ="16">16</asp:listitem>
                    <asp:ListItem value ="17">17</asp:listitem>
                    <asp:ListItem value ="18">18</asp:listitem>
                    <asp:listitem value ="19">19</asp:listitem>
                    <asp:ListItem value ="20">20</asp:listitem>
                    <asp:ListItem value ="21">21</asp:listitem>
                    <asp:ListItem value ="22">22</asp:listitem>
                    <asp:ListItem value ="23">23</asp:listitem>
                    <asp:ListItem value ="24">24</asp:listitem>
                    <asp:ListItem value ="25">25</asp:listitem>
                    <asp:ListItem value ="26">26</asp:listitem>
                    <asp:ListItem value ="27">27</asp:listitem>
                    <asp:ListItem value ="28">28</asp:listitem>
                    <asp:ListItem value ="29">29</asp:listitem>
                    <asp:ListItem value ="30">30</asp:listitem>
                    <asp:ListItem value ="31">31</asp:listitem>
                </asp:DropDownList>
                
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem value ="01">Enero</asp:listitem>
                    <asp:ListItem value ="02">Febrero</asp:listitem>
                    <asp:ListItem value ="03">Marzo</asp:listitem>
                    <asp:ListItem value ="04">Abril</asp:listitem>
                    <asp:ListItem value ="05">Mayo</asp:listitem>
                    <asp:ListItem value ="06">Junio</asp:listitem>
                    <asp:ListItem value ="07">Julio</asp:listitem>
                    <asp:ListItem value ="08">Agosto</asp:listitem>
                    <asp:ListItem value ="09">Septiembre</asp:listitem>
                    <asp:ListItem value ="10">Octubre</asp:listitem>
                    <asp:ListItem value ="11">Noviembre</asp:listitem>
                    <asp:ListItem value ="12">Diciembre</asp:listitem>
                </asp:DropDownList>
                
                <asp:DropDownList ID="DropDownList3" runat="server">
                     <asp:ListItem value ="2014">2014</asp:listitem>
                    <asp:ListItem value ="2013">2013</asp:listitem>
                    <asp:ListItem value ="2012">2012</asp:listitem>
                    <asp:ListItem value ="2011">2011</asp:listitem>
                    <asp:ListItem value ="2010">2010</asp:listitem>
                    <asp:ListItem value ="2009">2009</asp:listitem>
                    <asp:ListItem value ="2008">2008</asp:listitem>
                    <asp:ListItem value ="2007">2007</asp:listitem>
                    <asp:ListItem value ="2006">2006</asp:listitem>
                    <asp:ListItem value ="2005">2005</asp:listitem>
                    <asp:ListItem value ="2004">2004</asp:listitem>
                    <asp:ListItem value ="2003">2003</asp:listitem>
                    <asp:ListItem value ="2002">2002</asp:listitem>
                    <asp:ListItem value ="2001">2001</asp:listitem>
                    <asp:ListItem value ="2000">2000</asp:listitem>
                    <asp:ListItem value ="1999">1999</asp:listitem>
                    <asp:ListItem value ="1998">1998</asp:listitem>
                    <asp:ListItem value ="1997">1997</asp:listitem>
                    <asp:listitem value ="1996">1996</asp:listitem>
                    <asp:ListItem value ="1995">1995</asp:listitem>
                    <asp:ListItem value ="1994">1994</asp:listitem>
                    <asp:ListItem value ="1993">1993</asp:listitem>
                    <asp:ListItem value ="1992">1992</asp:listitem>
                    <asp:ListItem value ="1991">1991</asp:listitem>
                    <asp:ListItem value ="1990">1990</asp:listitem>
                    <asp:ListItem value ="1989">1989</asp:listitem>
                    <asp:ListItem value ="1988">1988</asp:listitem>
                    <asp:ListItem value ="1987">1987</asp:listitem>
                    <asp:ListItem value ="1986">1986</asp:listitem>
                    <asp:ListItem value ="1985">1985</asp:listitem>
                    <asp:ListItem value ="1984">1984</asp:listitem>
                    <asp:ListItem value ="1983">1983</asp:listitem>
                    <asp:ListItem value ="1982">1982</asp:listitem>
                    <asp:ListItem value ="1981">1981</asp:listitem>
                    <asp:ListItem value ="1980">1980</asp:listitem>
                    <asp:ListItem value ="1979">1979</asp:listitem>
                    <asp:ListItem value ="1978">1978</asp:listitem>
                </asp:DropDownList>
            
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="Label5" runat="server" Text="Sexo"></asp:Label>
            
</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:DropDownList ID="DropDownList4" runat="server">
                    <asp:ListItem value ="Hombre"> Hombre </asp:listitem>
                     <asp:ListItem value ="Mujer"> Mujer </asp:listitem>
                     
                </asp:DropDownList>
            
        </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Label ID="Label6" runat="server" Text="Avatar Url"></asp:Label>
            
</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:TextBox ID="TextBox3" runat="server" class="form-poshytip" title="Ingrese url de su avatar"></asp:TextBox>
                <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
                
            </asp:TableCell>
             
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Finalizar" />
                
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

