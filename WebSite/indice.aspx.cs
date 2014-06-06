using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Xml;


public partial class indice : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
       
        
           SqlConnection cn = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
           SqlConnection cn2 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
           SqlConnection cn3 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
           SqlConnection cn4 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
           SqlConnection cn5 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
           SqlConnection cn6 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
           SqlConnection cn7 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
           cn7.Open();
           cn6.Open();
           cn5.Open();
           cn4.Open();
           cn3.Open();
           cn.Open();
           cn2.Open();
           SqlCommand cmd = new SqlCommand("Select * From Categoria where publico = 1", cn);
           SqlDataReader dr = cmd.ExecuteReader();

           
           String id;
           String id2="0";
           String id3 = "0";
           String id4 = "0";
           String id5 = "0";
           String name;
           String name2 = "";
           String descripcion;
           String aux="";
           Int32 cont;
           Int32 cont3;
           Int32 cont2 = 0;
         
           while (dr.Read())
           {
               this.Label1.Text = this.Label1.Text + aux;
               id = Convert.ToString(dr["id_categoria"]);
               name = Convert.ToString(dr["nombre"]);
               descripcion = Convert.ToString(dr["descripcion"]);
               
               SqlCommand cmd2 = new SqlCommand("Select Count(nombre) from Tema where id_categoria = "+ id, cn2);
               cont = (Int32)cmd2.ExecuteScalar();
              
               SqlCommand cmd3 = new SqlCommand("Select * from Tema where id_categoria ="+ id, cn3);
               SqlDataReader dr3 = cmd3.ExecuteReader();
               while (dr3.Read())
               {
                   id2 = Convert.ToString(dr3["id_tema"]);
                   SqlCommand cmd4 = new SqlCommand("Select Count(id_comentario) from Comentario where id_tema =" + id2, cn4);
                   cont2 += (Int32)cmd4.ExecuteScalar();
                   

               }
               dr3.Close();
               SqlCommand cmd5 = new SqlCommand("Select * from Comentario order by id_comentario desc", cn5);
               SqlDataReader dr5 = cmd5.ExecuteReader();
               while (dr5.Read())
               {
                   id3 = Convert.ToString(dr5["id_tema"]);
                   SqlCommand cmd6 = new SqlCommand("Select * from Comentario order by id_comentario desc", cn6);
                   SqlDataReader dr6 = cmd6.ExecuteReader();
                   while (dr6.Read())
                   {
                       id4 = Convert.ToString(dr6["id_tema"]);
                       
                       SqlCommand cmd7 = new SqlCommand("Select * from Tema where id_tema = "+ id4, cn7);
                       SqlDataReader dr7 = cmd7.ExecuteReader();
                       while(dr7.Read())
                       {
                           id5 = Convert.ToString(dr7["id_categoria"]);
                           name2 = Convert.ToString(dr7["nombre"]);
                           if (String.Compare(id5,id) == 0)
                           {
                               break;
                           }
                       }
                       dr7.Close();
                       if (String.Compare(id5, id) == 0)
                       {
                           break;
                       }
                       else
                       {
                           name2 = "";
                       }

                   }
                   dr6.Close();
               }
               dr5.Close();

               aux = "<article class='format-standard'>"+
						
						"<div class='box cf'>"+
                            "<div class='entry-date'><div class='number'>"+Convert.ToString(DateTime.Now.ToString("dd"))+"</div><div class='month'>" + Convert.ToString(DateTime.Now.ToString("MMM")) + "</div></div>" +
							
							"<div class='excerpt'>"+
								"<a href='temas.aspx?id="+id+"'  class='post-heading' >"+ name +"</a>"+
								"<p>"+ descripcion +"</p>"+
								
								
							"</div>"+
							
							"<div class='meta'>"+
								"<span class='format'>"+ cont + " Temas</span>"+
								"<span class='user'><a href='#'> Ultimo: "+ name2 +"</a></span>"+
								"<span class='comments'>"+ cont2 +" Mensajes</span>"+
								"<span class='tags'><a href='#'>red</a>, <a href='#'>cyan</a>, <a href='#'>white</a>, <a href='#'>blue</a></span>"+
							"</div>"+
								
						"</div>"+
					"</article>";

               
           }
           this.Label1.Text = this.Label1.Text + aux;
          
           this.Label2.Text = "<ul  class='widget-cols cf'>"+
					"<li class='first-col'>"+
						
						"<div class='widget-block'>"+
							"<h4>RECENT POSTS</h4>"+
							"<div class='recent-post cf'>"+
								"<a href='#' class='thumb'><img src='img/dummies/54x54.gif' alt='Post' /></a>"+
								"<div class='post-head'>"+
									"<a href='#'>Pellentesque habitant morbi senectus</a><span> March 12, 2011</span>"+
								"</div>"+
							"</div>"+
							"<div class='recent-post cf'>"+
								"<a href='#' class='thumb'><img src='img/dummies/54x54.gif' alt='Post' /></a>"+
								"<div class='post-head'>"+
									"<a href='#'>Pellentesque habitant morbi senectus</a><span> March 12, 2011</span>"+
								"</div>"+
							"</div>"+
							"<div class='recent-post cf'>"+
								"<a href='#' class='thumb'><img src='img/dummies/54x54.gif' alt='Post' /></a>"+
								"<div class='post-head'>"+
									"<a href='#'>Pellentesque habitant morbi senectus</a><span> March 12, 2011</span>"+
								"</div>"+
							"</div>"+
						"</div>"+
					"</li>"+
					
					"<li class='second-col'>"+
						
						"<div class='widget-block'>"+
							"<h4>ABOUT</h4>"+
							"<p>Folder it's completely free this means you don't have to pay anything <a href='http://luiszuno.com/blog/license' >read license</a>.</p>"+ 
							"<p>Visit <a href='http://templatecreme.com/' >Template Creme</a> and find the most beautiful free templates up to date.</p>"+
						"</div>"+
						
					"</li>"+
					
					"<li class='third-col'>"+
						
						"<div class='widget-block'>"+
							"<div id='tweets' class='footer-col tweet'>"+
		         				"<h4>TWITTER WIDGET</h4>"+
		         			"</div>"+
		         		"</div>"+
		         		
					"</li>"+
					
					"<li class='fourth-col'>"+
						
						"<div class='widget-block'>"+
							"<h4>CATEGORIES</h4>"+
							"<ul>"+
								"<li class='cat-item'><a href='#' >Design</a></li>" +
								"<li class='cat-item'><a href='#' >Photo</a></li>"+
								"<li class='cat-item'><a href='#' >Art</a></li>"+
								"<li class='cat-item'><a href='#' >Game</a></li>"+
								"<li class='cat-item'><a href='#' >Film</a></li>" +
								"<li class='cat-item'><a href='#' >TV</a></li>" +
							"</ul>"+
						"</div>"+
		         		
					"</li>"+	
				"</ul>";
        
    }

}
