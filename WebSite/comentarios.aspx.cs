using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Xml;

public partial class comentarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String id_tem;
        String avatar = "";
        String id_user = "";
        String id_cat = Request.QueryString["id"];
        String aux = "";
        string nombre = "";
        String descp = "";
        String msj = "";
        Int32 cont = 0;
        String autor = "";
        SqlConnection cn = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        SqlConnection cn2 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        SqlConnection cn3 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        SqlConnection cn4 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        SqlConnection cn5 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        cn5.Open();
        cn4.Open();
        cn3.Open();
        cn.Open();
        cn2.Open();
        SqlCommand cmd = new SqlCommand("Select * From Tema where id_tema =" + id_cat, cn);  
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            
            nombre = Convert.ToString(dr["nombre"]);
            descp = Convert.ToString(dr["descripcion"]);
            id_user = Convert.ToString(dr["id_usuario"]);
            msj = Convert.ToString(dr["mensaje"]);
            SqlCommand cmd2 = new SqlCommand("Select Count(id_comentario) from Comentario where id_tema =" + id_cat, cn2);
            cont = (Int32)cmd2.ExecuteScalar();

            SqlCommand cmd3 = new SqlCommand("Select * From Usuario where id_usuario =" + id_user, cn3);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                autor = Convert.ToString(dr3["nombre"]);
            }
            dr3.Close();
           
        }
        aux = "<article class='format-standard'>" +
                    "<div class='box cf'>" +
                        "<div class='entry-date'><div class='number'>" + Convert.ToString(DateTime.Now.ToString("dd")) + "</div><div class='month'>" + Convert.ToString(DateTime.Now.ToString("MMM")) + "</div></div>" +

                        "<div class='excerpt'>" +
                            "<div class='post-heading' >" + nombre + "</div>" +
                            "<div class='entry-content'>" +


                                "<p>" + descp + "</p>" +

                                "<p>" + msj + "</p>" +
                            "</div>" +


                        "</div>" +

                        "<div class='meta'>" +

                            "<span class='user'><a href='perfil.aspx?id=" + id_user + "'  class='post-heading'> Por " + autor + "</a></span>" +
                            "<span class='comments'>" + cont + " Comentarios</span>" +
                            "<span class='tags'><a href='#'>red</a>, <a href='#'>cyan</a>, <a href='#'>white</a>, <a href='#'>blue</a></span>" +
                        "</div>" +

                    "</div>" +
                "</article>" +
                "<div id='comments-wrap'>" +
                    "<h4 class='heading'>" + cont + " Comentarios</h4>";
        this.Label1.Text = aux;
        aux = "";
        SqlCommand cmd4 = new SqlCommand("Select * From Comentario where id_tema =" + id_cat, cn4);
        SqlDataReader dr4 = cmd4.ExecuteReader();
        msj = "";
        id_user = "";
        autor = "";
        while (dr4.Read())
        {
            this.Label2.Text = this.Label2.Text + aux;
            id_user = Convert.ToString(dr4["id_usuario"]);
            msj = Convert.ToString(dr4["mensaje"]);
            SqlCommand cmd5 = new SqlCommand("Select * From Usuario where id_usuario =" + id_user, cn5);
            SqlDataReader dr5 = cmd5.ExecuteReader();
            while (dr5.Read())
            {
                autor = Convert.ToString(dr5["nombre"]);
                avatar = Convert.ToString(dr5["avatar_url"]);
            }
            dr5.Close();
            aux =

                    "<ol class='commentlist'>" +


                        "<li class='comment even thread-even depth-1' id='li-comment-1'>" +

                            "<div id='comment-1' class='comment-body cf'>" +
                                "<img alt='' src='" + avatar + "' class='avatar avatar-35 photo' height='100' width='100' />" +
                                "<div class='comment-author vcard'><a href='perfil.aspx?id=" + id_user + "'  class='post-heading'>" + autor + "</a></div>"+
                                "<div class='comment-meta commentmetadata'>" +
                                "</div>" +
                                "<div class='comment-inner'>" +
                                    "<p>" + msj + "</p>" +
                                "</div>" +
                            "</div>" +


                        "</li>" +
                    "</ol>";
			

        }
        this.Label2.Text = this.Label2.Text + aux + "</div>";
      }
}