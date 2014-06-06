using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Xml;

public partial class privado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String aux = "";
        String asunto = "";
        String mensaje = "";
        String id_us = (String)Session["ids"];
        String id_re ="";
        String id_buzon = "";
        String fecha = "";
        String leido = "";
        String name_re = "";
        String id_mensaje = Request.QueryString["id"];
        SqlConnection cn = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        SqlConnection cn2 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        SqlConnection cn3 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        cn3.Open();
        cn.Open();
        cn2.Open();
        SqlCommand cmd = new SqlCommand("Select * From Mensaje_privado where id_mensaje =" + id_mensaje, cn);
        SqlDataReader dr = cmd.ExecuteReader();
        while( dr.Read() )
        {
            id_buzon = Convert.ToString(dr["id_buzon"]);
            mensaje = Convert.ToString(dr["mensaje"]);
            asunto = Convert.ToString(dr["asunto"]);
            id_re = Convert.ToString(dr["id_remitente"]);
            fecha = Convert.ToString(dr["fecha_de_envio"]);
            leido = Convert.ToString(dr["leido"]);
        }
        SqlCommand cmd2 = new SqlCommand("Select * From Usuario where id_usuario =" + id_re, cn2);
        SqlDataReader dr2 = cmd2.ExecuteReader();
        while( dr2.Read() )
        {
            name_re = Convert.ToString(dr2["nombre"]);
        }
        DateTime fechaf = Convert.ToDateTime(fecha).Date;
        this.Label1.Text = "<article class='format-standard'>" +

                     "<div class='box cf'>" +
                         "<div class='entry-date'><div class='number'>" + Convert.ToString(fechaf.ToString("dd")) + "</div><div class='month'>" + Convert.ToString(fechaf.ToString("MMM")) + "</div></div>" +

                         "<div class='excerpt'>" +
                             "<a href='privado.aspx?id=" + id_mensaje + "'  class='post-heading' >Asunto: "+ asunto +"</a>" +
                             "<p>"+ mensaje +"</p>" +
                         "</div>" +

                         "<div class='meta'>" +

                             "<span class='user'><a href='perfil2.aspx?id=" + id_re + "'  class='post-heading'>Remitente: " + name_re + "</a></span>" +
                             
                         "</div>" +

                     "</div>" +
                 "</article>";
        if (string.Compare(leido, "0") == 0)
        {
            SqlCommand cmd3 = new SqlCommand("update Mensaje_privado set  leido = 1 where id_mensaje = " + id_mensaje, cn3);
            cmd3.ExecuteNonQuery();
        }
        this.TextBox1.Text = "RE:" + asunto;
        this.TextBox1.Enabled = false;
        }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DateTime hoy = DateTime.Today;
        String fecha_act = hoy.ToString("yyyy-MM-dd");
        String aux = "";
        String asunto = "";
        String mensaje = "";
        String id_us = (String)Session["ids"];
        String id_re = "";
        String id_buzon = "";
         String idb = "";
        String fecha = "";
        String leido = "";
        String name_re = "";
        String id_mensaje = Request.QueryString["id"];
        SqlConnection cn = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        SqlConnection cn2 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        SqlConnection cn3 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        cn3.Open();
        cn.Open();
        cn2.Open();
        SqlCommand cmd = new SqlCommand("Select * From Mensaje_privado where id_mensaje =" + id_mensaje, cn);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            id_buzon = Convert.ToString(dr["id_buzon"]);
            mensaje = Convert.ToString(dr["mensaje"]);
            asunto = Convert.ToString(dr["asunto"]);
            id_re = Convert.ToString(dr["id_remitente"]);
            fecha = Convert.ToString(dr["fecha_de_envio"]);
            leido = Convert.ToString(dr["leido"]);
        }
        SqlCommand cmd2 = new SqlCommand("Select * From Buzon_entrada where id_usuario =" + id_re, cn2);
        SqlDataReader dr2 = cmd2.ExecuteReader();
        while (dr2.Read())
        {
            idb = Convert.ToString(dr2["id_buzon"]);
        }
        DateTime fechaf = Convert.ToDateTime(fecha).Date;
        if (String.Compare(this.TextBox2.Text,"") == 0)
        {
            this.Label4.Text = "Dejo mensaje en blanco";
        }
        else
        {
            SqlCommand cmd3 = new SqlCommand("insert into Mensaje_privado(id_remitente,id_buzon,leido,mensaje,fecha_de_envio,asunto) values(@idr,@idb,@leido,@msj,@fech,@asunto) ", cn3);
            cmd3.Parameters.AddWithValue("idr",id_us );
            cmd3.Parameters.AddWithValue("idb", idb);
            cmd3.Parameters.AddWithValue("leido",0);
            cmd3.Parameters.AddWithValue("msj", this.TextBox2.Text);
            cmd3.Parameters.AddWithValue("fech", fecha_act);
            cmd3.Parameters.AddWithValue("asunto", this.TextBox1.Text);
            int nfila = cmd3.ExecuteNonQuery();
            if (nfila > 0)
            {
                System.Web.HttpContext.Current.Response.Write("<script languaje = 'javascript'> alert('Mensaje enviado con exito')</script>");
                Server.Transfer("menu.aspx");
            }
        }
    }
    }