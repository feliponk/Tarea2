using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Xml;

public partial class correo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String aux = "";
        String msj="";
        String msj_no_leido = "" ;
        String id_buzon = "";
        String asunto = "";
        String remitente="";
        String fecha="";
        String leido="";
        String name_re = "";
        String nam_leido = "";
        String id_mensaje = "";
        this.Label1.Text = "";

        SqlConnection cn = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        SqlConnection cn2 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        SqlConnection cn3 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        cn3.Open();
        cn.Open();
        cn2.Open();
        String id_us = (String)Session["ids"];
        SqlCommand cmd = new SqlCommand("Select * From Buzon_entrada where id_usuario =" + id_us , cn);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            this.Label1.Text = this.Label1.Text + aux;
            id_buzon = Convert.ToString(dr["id_buzon"]);
            msj = Convert.ToString(dr["mensajes"]);
            msj_no_leido = Convert.ToString(dr["mensajes_sin_leer"]);
            SqlCommand cmd2 = new SqlCommand("Select * From Mensaje_privado where id_buzon =" + id_buzon + " order by id_mensaje desc", cn2);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while( dr2.Read() )
            {
                id_mensaje = Convert.ToString(dr2["id_mensaje"]);
                asunto = Convert.ToString(dr2["asunto"]);
                remitente = Convert.ToString(dr2["id_remitente"]);
                fecha = Convert.ToString(dr2["fecha_de_envio"]);
                leido = Convert.ToString(dr2["leido"]);
            }
            dr2.Close();
            SqlCommand cmd3 = new SqlCommand("Select * From Usuario where id_usuario = " + remitente, cn3);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while( dr3.Read())
            {
                name_re = Convert.ToString(dr3["nombre"]);
            }
            dr3.Close();
            if ( String.Compare("0",leido) == 0)
            {
                nam_leido = "Sin leer";
            }
            else
            {
                nam_leido = "leido";
            }
            DateTime fechaf = Convert.ToDateTime(fecha).Date;
            aux = "<article class='format-standard'>" +

                     "<div class='box cf'>" +
                         "<div class='entry-date'><div class='number'>" + Convert.ToString(fechaf.ToString("dd")) + "</div><div class='month'>" + Convert.ToString(fechaf.ToString("MMM")) + "</div></div>" +

                         "<div class='excerpt'>" +
                             "<a href='privado.aspx?id=" + id_mensaje + "'  class='post-heading' >Asunto: "+ asunto +"</a>" +
                             "<p></p>" +
                         "</div>" +

                         "<div class='meta'>" +

                             "<span class='user'><a href='perfil2.aspx?id=" + remitente + "'  class='post-heading'>Remitente: " + name_re + "</a></span>" +
                             "<span class='comments'>N° mensajes: " + msj + "</span>" +
                             "<span class='comments'>N° sin leer: "+ msj_no_leido + "</span>" +
                             "<span class='tags'><a href='privado.aspx?id=" + id_mensaje + "'  class='post-heading'>Estado: " + nam_leido + "</a></span>" +
                         "</div>" +

                     "</div>" +
                 "</article>";
        }
        this.Label1.Text = this.Label1.Text + aux;
    
   }
   protected void Button1_Click(object sender, EventArgs e)
   {
       String idb = "";

       String id_re = (String)Session["ids"]; ;
       String id_us ="";
       DateTime hoy = DateTime.Today;
       String fecha_act = hoy.ToString("yyyy-MM-dd");
       SqlConnection cn = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
       SqlConnection cn2 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
       SqlConnection cn3 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
       cn3.Open();
       cn.Open();
       cn2.Open();
       SqlCommand cmd = new SqlCommand("Select * From Usuario where nombre = '"+ this.TextBox1.Text + "'"  , cn);
       SqlDataReader dr = cmd.ExecuteReader();
       while (dr.Read())
       {
           id_us = Convert.ToString(dr["id_usuario"]);

       }
       if (String.Compare(id_us,"") == 0)
       {
           this.Label4.Text = "Usuario no encontrado";
       }
       else if (String.Compare(this.TextBox1.Text,"") == 0 || String.Compare(this.TextBox2.Text,"") == 0 || String.Compare(this.TextBox3.Text,"") == 0)
       {
           this.Label4.Text = "Faltan datos por rellenar";
       }
       else
       {
           SqlCommand cmd2 = new SqlCommand("Select * From Buzon_entrada where id_usuario = " + id_us, cn2);
           SqlDataReader dr2 = cmd2.ExecuteReader();
           while (dr2.Read())
           {
               idb = Convert.ToString(dr2["id_buzon"]);

           }
           SqlCommand cmd3 = new SqlCommand("insert into Mensaje_privado(id_remitente,id_buzon,leido,mensaje,fecha_de_envio,asunto) values(@idr,@idb,@leido,@msj,@fech,@asunto) ", cn3);
           cmd3.Parameters.AddWithValue("idr", id_re);
           cmd3.Parameters.AddWithValue("idb", idb);
           cmd3.Parameters.AddWithValue("leido", 0);
           cmd3.Parameters.AddWithValue("msj", this.TextBox3.Text);
           cmd3.Parameters.AddWithValue("fech", fecha_act);
           cmd3.Parameters.AddWithValue("asunto", this.TextBox2.Text);
           int nfila = cmd3.ExecuteNonQuery();
           if (nfila > 0)
           {
               System.Web.HttpContext.Current.Response.Write("<script languaje = 'javascript'> alert('Mensaje enviado con exito')</script>");
               Server.Transfer("menu.aspx");
           }
       }
   }
}