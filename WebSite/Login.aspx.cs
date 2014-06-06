using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class Login : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        int aux = 0;
        string nombre;
        string id = "";
        string pass = "";
        string grupo = "";
        SqlConnection cn = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        cn.Open();
        aux = 0;
        this.Label2.Text = "";
        this.Label3.Text = "";
        this.Label4.Text = "";
        if (string.Compare(this.TextBox2.Text, "") == 0)
        {
            this.Label3.Text = "  Rellene este espacio";
            TextBox2.Focus();
            aux = 1;
        }

        if(string.Compare(this.TextBox1.Text,"") == 0)
        {
            this.Label4.Text = "  Rellene este espacio";
            TextBox1.Focus();
            aux = 1;
        }

        if (aux == 0)
        {
            nombre = this.TextBox1.Text;

            SqlCommand cmd = new SqlCommand("select * from Usuario where nombre = '" + nombre + "'", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id = Convert.ToString(dr["id_usuario"]);
                grupo = Convert.ToString(dr["id_grupo"]);
                pass = Convert.ToString(dr["contraseña"]);
                
            }
            if (String.Compare(id, "") == 0)
            {
                this.Label2.Text = " Usuario o contraseña invalida";

            }
            else if (string.Compare(id,"") != 0 && string.Compare(pass, this.TextBox2.Text) == 0)
            {
                if (string.Compare(grupo, "1") == 0)
                {
                    Session.Add("ids", id);
                    Session.Add("grup", grupo);
                    System.Web.HttpContext.Current.Response.Write("<script languaje = 'javascript'> alert('Inicio de sesion exitoso')</script>");
                    Server.Transfer("menu.aspx");
                }
                else if (string.Compare(grupo, "2") == 0)
                {
                    Session.Add("ids", id);
                    Session.Add("grup", grupo);
                    System.Web.HttpContext.Current.Response.Write("<script languaje = 'javascript'> alert('Inicio de sesion exitoso')</script>");
                    Server.Transfer("menu.aspx");
                }
                else
                {
                    Session.Add("ids", id);
                    Session.Add("grup", grupo);
                    System.Web.HttpContext.Current.Response.Write("<script languaje = 'javascript'> alert('Inicio de sesion exitoso')</script>");
                    Server.Transfer("menu.aspx");
                }
            }
            else
            {
                Label2.Text = "Usuario o contraseña invalida";
            }
        }

        
    }
   
}