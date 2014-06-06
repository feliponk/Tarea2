using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Xml;

public partial class editarp : System.Web.UI.Page
{
    protected void Button1_Click(object sender, EventArgs e)
    {
        String msg;
        try
        {
            String grup = (String)Session["grup"];
            String ids = (String)Session["aux"];
            this.Label5.Visible = false;
            this.DropDownList4.Visible = false;

            if(String.Compare(grup,"1")==0)
            {
                this.Label5.Visible = true;
                this.DropDownList4.Visible = true;
                this.DropDownList4.SelectedIndex = int.Parse(grup)-1;
            }
            Int32 cont = 0;
            Int32 aux = 0;
            String name;
            DateTime hoy = DateTime.Today;
            String fecha_act = hoy.ToString("yyyy-MM-dd");


            SqlConnection cn = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");


            cn.Open();


            

           
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
           
            
               
            fecha = DropDownList3.Text + "-" + DropDownList2.Text + "-" + DropDownList1.Text;



            SqlCommand cmd = new SqlCommand("update Usuarios set id_grupo = "+ this.DropDownList4.Text +" , contraseña = '"+this.TextBox1.Text  +"' , fecha_nacimiento = '"+ fecha +"', avatar_url = '"+ this.TextBox3.Text+"' where id_usuario = " + ids, cn);
            int nfila = cmd.ExecuteNonQuery();
            if (nfila > 0)
           {
               System.Web.HttpContext.Current.Response.Write("<script languaje = 'javascript'> alert('Perfil editado con exito')</script>");
               Server.Transfer("menu.aspx");
           }
                




            

        }
        catch (Exception ex)
        {

            msg = ex.Message;

        }
    }
        
}