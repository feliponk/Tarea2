
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class Registrarse : System.Web.UI.Page
{
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        String msg;
        try
        {
            
            Int32 cont = 0;
            Int32 aux = 0;
            String name;
            DateTime hoy = DateTime.Today;
            String fecha_act = hoy.ToString("yyyy-MM-dd");
            

            SqlConnection cn = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
            
      
            cn.Open();
            

            SqlCommand cmd = new SqlCommand("insert into Usuario(id_grupo,nombre,contraseña,cantidad_comentarios,avatar_url,fecha_nacimiento,sexo,fecha_registro) values(@id_grupo,@nombre,@contraseña,@cantidad_comentarios,@avatar_url,@fecha_nacimiento,@sexo,@fecha_registro)", cn);
           
            this.Label8.Text = "";
            this.Label9.Text = "";
            this.Label10.Text = "";
            this.Label11.Text = "";

            String fecha;
            aux = 0;
            if (string.Compare(this.TextBox3.Text, "") == 0)
            {
                this.Label11.Text = " Dejo campo url avatar en blanco";
                TextBox3.Focus();
                aux = 1;
            }
            if (string.Compare(this.TextBox2.Text, "") == 0 || string.Compare(this.TextBox1.Text, this.TextBox2.Text) != 0)
            {
                this.Label10.Text = " Las contraseñas no coenciden";
                TextBox2.Focus();
                aux = 1;
            }
            if (string.Compare(this.TextBox1.Text, "") == 0)
            {
                this.Label9.Text = " Dejo campo contraseña en blanco";
                TextBox1.Focus();
                aux = 1;
            }
            if (string.Compare(this.TextBox4.Text, "") == 0)
            {
                this.Label8.Text = " Dejo campo Usuario en blanco";
                TextBox1.Focus();
                aux = 1;
            }
            if(aux == 0)
            {
                SqlConnection cn2 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
                cn2.Open();
                SqlCommand cmd2 = new SqlCommand("select * from Usuario", cn2);
                SqlDataReader dr = cmd2.ExecuteReader();
                while (dr.Read())
                {
                    name = Convert.ToString(dr["nombre"]);
                    if (String.Compare(name, this.TextBox4.Text) == 0)
                    {
                        this.Label8.Text = " Usuario ya registrado";
                        cont = 1;
                        break;
                    }
                }
                if (cont == 0)
                {
                    
                    fecha = DropDownList3.Text + "-" + DropDownList2.Text + "-" + DropDownList1.Text;
                    
                   
                    cmd.Parameters.AddWithValue("id_grupo", 3);
                    cmd.Parameters.AddWithValue("nombre", this.TextBox4.Text);
                    cmd.Parameters.AddWithValue("contraseña", this.TextBox1.Text);
                    cmd.Parameters.AddWithValue("cantidad_comentarios", 0);
                    cmd.Parameters.AddWithValue("avatar_url", this.TextBox3.Text);
                    cmd.Parameters.AddWithValue("fecha_nacimiento", fecha);
                    cmd.Parameters.AddWithValue("sexo", this.DropDownList4.Text);
                    cmd.Parameters.AddWithValue("fecha_registro", fecha_act);

                    int nfila = cmd.ExecuteNonQuery();
                    if( nfila > 0)
                    {
                        System.Web.HttpContext.Current.Response.Write("<script languaje = 'javascript'> alert('El registro fue exitoso')</script>");
                        Server.Transfer("indice.aspx");
                    }
                }
               
                


            }
            
        }
        catch(Exception ex)
        {

            msg = ex.Message;
         
        }
        
    }
}