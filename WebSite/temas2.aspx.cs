using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class temas2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String grup = (String)Session["grup"];
        String contenido = "";
        String id_tem;
        String id_user;
        String id_cat = Request.QueryString["id"];
        String aux = "";
        string nombre;
        String descp;
        Int32 cont;
        String autor = "";
        SqlConnection cn = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        SqlConnection cn2 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        SqlConnection cn3 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        cn3.Open();
        cn.Open();
        cn2.Open();
        SqlCommand cmd = new SqlCommand("Select * From Tema where publico = 1 and id_categoria =" + id_cat, cn);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            this.Label1.Text = this.Label1.Text + aux;
            id_tem = Convert.ToString(dr["id_tema"]);
            nombre = Convert.ToString(dr["nombre"]);
            descp = Convert.ToString(dr["descripcion"]);
            id_user = Convert.ToString(dr["id_usuario"]);
            SqlCommand cmd2 = new SqlCommand("Select Count(id_comentario) from Comentario where id_tema =" + id_tem, cn2);
            cont = (Int32)cmd2.ExecuteScalar();

            SqlCommand cmd3 = new SqlCommand("Select * From Usuario where id_usuario =" + id_user, cn3);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                autor = Convert.ToString(dr3["nombre"]);
            }
            dr3.Close();
            if (String.Compare(grup, "1") == 0)
            {
                contenido = "<span class='tags'><a href='eliminart.aspx?idt=" + id_tem + "'  class='post-heading' >Eliminar</a></span>" +
                            "<span class='tags'><a href='agregart.aspx?idc=" + id_cat + "'class='post-heading' >Agregar tema</a></span>";
            }

            if (String.Compare(grup, "2") == 0)
            {
                contenido = "<span class='tags'><a href='eliminart.aspx?idt=" + id_tem+ "'  class='post-heading' >Eliminar</a></span>" +
                            "<span class='tags'><a href='agregart.aspx?idc="+id_cat+"'class='post-heading' >Agregar tema</a></span>";

            }
            if (String.Compare(grup, "3") == 0)
            {
                contenido = "<span class='tags'><a href='agregart.aspx?idc=" + id_cat + "'class='post-heading' >Agregar tema</a></span>";

            }
            aux = "<article class='format-standard'>" +

                     "<div class='box cf'>" +
                         "<div class='entry-date'><div class='number'>" + Convert.ToString(DateTime.Now.ToString("dd")) + "</div><div class='month'>" + Convert.ToString(DateTime.Now.ToString("MMM")) + "</div></div>" +

                         "<div class='excerpt'>" +
                             "<a href='comentarios2.aspx?id=" + id_tem + "'  class='post-heading' >" + nombre + "</a>" +
                             "<p>" + descp + "</p>" +
                         "</div>" +

                         "<div class='meta'>" +

                             "<span class='user'><a href='perfil2.aspx?id=" + id_user + "'  class='post-heading'> Por " + autor + "</a></span>" +
                             "<span class='comments'>" + cont + " Comentarios</span>" +
                             contenido +
                         "</div>" +

                     "</div>" +
                 "</article>";

        }
        this.Label1.Text = this.Label1.Text + aux;
        this.Label2.Text = "<ul  class='widget-cols cf'>" +
                "<li class='first-col'>" +

                    "<div class='widget-block'>" +
                        "<h4>RECENT POSTS</h4>" +
                        "<div class='recent-post cf'>" +
                            "<a href='#' class='thumb'><img src='img/dummies/54x54.gif' alt='Post' /></a>" +
                            "<div class='post-head'>" +
                                "<a href='#'>Pellentesque habitant morbi senectus</a><span> March 12, 2011</span>" +
                            "</div>" +
                        "</div>" +
                        "<div class='recent-post cf'>" +
                            "<a href='#' class='thumb'><img src='img/dummies/54x54.gif' alt='Post' /></a>" +
                            "<div class='post-head'>" +
                                "<a href='#'>Pellentesque habitant morbi senectus</a><span> March 12, 2011</span>" +
                            "</div>" +
                        "</div>" +
                        "<div class='recent-post cf'>" +
                            "<a href='#' class='thumb'><img src='img/dummies/54x54.gif' alt='Post' /></a>" +
                            "<div class='post-head'>" +
                                "<a href='#'>Pellentesque habitant morbi senectus</a><span> March 12, 2011</span>" +
                            "</div>" +
                        "</div>" +
                    "</div>" +
                "</li>" +

                "<li class='second-col'>" +

                    "<div class='widget-block'>" +
                        "<h4>ABOUT</h4>" +
                        "<p>Folder it's completely free this means you don't have to pay anything <a href='http://luiszuno.com/blog/license' >read license</a>.</p>" +
                        "<p>Visit <a href='http://templatecreme.com/' >Template Creme</a> and find the most beautiful free templates up to date.</p>" +
                    "</div>" +

                "</li>" +

                "<li class='third-col'>" +

                    "<div class='widget-block'>" +
                        "<div id='tweets' class='footer-col tweet'>" +
                            "<h4>TWITTER WIDGET</h4>" +
                        "</div>" +
                    "</div>" +

                "</li>" +

                "<li class='fourth-col'>" +

                    "<div class='widget-block'>" +
                        "<h4>CATEGORIES</h4>" +
                        "<ul>" +
                            "<li class='cat-item'><a href='#' >Design</a></li>" +
                            "<li class='cat-item'><a href='#' >Photo</a></li>" +
                            "<li class='cat-item'><a href='#' >Art</a></li>" +
                            "<li class='cat-item'><a href='#' >Game</a></li>" +
                            "<li class='cat-item'><a href='#' >Film</a></li>" +
                            "<li class='cat-item'><a href='#' >TV</a></li>" +
                        "</ul>" +
                    "</div>" +

                "</li>" +
            "</ul>";
    }
}