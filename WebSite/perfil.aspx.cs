using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Xml;

public partial class perfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Enabled = false;
        TextBox2.Enabled = false;
        DropDownList1.Enabled = false;
        DropDownList2.Enabled = false;
        DropDownList3.Enabled = false;
        DropDownList4.Enabled = false;
        DropDownList5.Enabled = false;
        DropDownList6.Enabled = false;
        string aux = "";
        this.Label5.Text = "";
        int con = 0;
        String id_us = Request.QueryString["id"];
        String id_tem = "";
        String name_grup = "";
        String fecha_na = "";
        String fecha_reg = "";
        String id_grup = "";
        String[] fecha;
        String[] fecha2;
        String name = "";
        String sex = "";
        String dia = "";
        String mes = "";
        String año = "";
        String dia2 = "";
        String mes2 = "";
        String año2 = "";
        String tpo_us = "";
        String tema = "";
        Int32 cont = 0;
        Int32 edad = 0;
        SqlConnection cn = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        SqlConnection cn2 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        SqlConnection cn3 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        SqlConnection cn4 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        SqlConnection cn5 = new SqlConnection("Data Source = Felipe ;Initial Catalog= BD2;Integrated Security=True");
        cn.Open();
        cn2.Open();
        cn3.Open();
        cn4.Open();
        cn5.Open();
        SqlCommand cmd = new SqlCommand("Select * From Usuario where id_usuario = " + id_us, cn);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            id_grup = Convert.ToString(dr["id_grupo"]);
            name = Convert.ToString(dr["nombre"]);
            sex = Convert.ToString(dr["sexo"]);
            fecha_na = Convert.ToString(dr["fecha_nacimiento"]);
            fecha_reg = Convert.ToString(dr["fecha_registro"]);
        }
        
        
        SqlCommand cmd2 = new SqlCommand("Select Count(id_comentario) from Comentario where id_usuario =" + id_us, cn2);
        cont = (Int32)cmd2.ExecuteScalar();
        SqlCommand cm3 = new SqlCommand("select * from Grupo_Usuario where id_grupo =" + id_grup, cn3);
        SqlDataReader dr3 = cm3.ExecuteReader();
        while (dr3.Read())
        {
            name_grup = Convert.ToString(dr3["nombre_grupo"]);
        }
        fecha = fecha_reg.Split('-');
        año = fecha_reg[6].ToString() + fecha_reg[7].ToString() + fecha_reg[8].ToString() + fecha_reg[9].ToString();
        mes = fecha_reg[3].ToString() + fecha_reg[4].ToString();
        dia = fecha_reg[0].ToString() + fecha_reg[1].ToString();
        fecha2 = fecha_na.Split('-');
        año2 = fecha_na[6].ToString() + fecha_na[7].ToString() + fecha_na[8].ToString() + fecha_na[9].ToString();
        mes2 = fecha_na[3].ToString() + fecha_na[4].ToString();
        dia2 = fecha_na[0].ToString() + fecha_na[1].ToString();
        DateTime nac = new DateTime(Int32.Parse(año2),Int32.Parse(mes2),Int32.Parse(dia2));
        edad = DateTime.Today.AddTicks(-nac.Ticks).Year - 1;
        this.TextBox1.Text = name;
        this.DropDownList1.Items.Add(edad.ToString());
        this.DropDownList2.Items.Add(sex);
        this.DropDownList3.Items.Add(cont.ToString());
        this.DropDownList4.Items.Add(dia);
        this.DropDownList5.Items.Add(mes);
        this.DropDownList6.Items.Add(año);
        this.TextBox2.Text = name_grup;
        this.Label5.Text = "<p><h3>" +
                "Ultimos 5 Temas creados" +
                "</h3></p>";
        SqlCommand cm4 = new SqlCommand("select * from Tema where publico = 1 and id_usuario =" + id_us + " order by id_tema desc", cn4);
        SqlDataReader dr4 = cm4.ExecuteReader();
        while (dr4.Read())
        {
            if (con == 5)
            {
                break;
            }
            else
            {
                this.Label5.Text = this.Label5.Text + aux;
                tema = Convert.ToString(dr4["nombre"]);
                aux = "<p>" + tema + "</p>";
            }
            con = con + 1;
        }
        con = 0;
        dr4.Close();
        this.Label5.Text = this.Label5.Text + aux;
        this.Label5.Text = this.Label5.Text + "<p><h3>" +
                "Ultimos 5 Temas comentados" +
                "</h3></p>";
        aux = "";
        tema = "";
        SqlCommand cm5 = new SqlCommand("select * from Comentario where id_usuario =" + id_us + " order by id_comentario desc", cn5);
        SqlDataReader dr5 = cm5.ExecuteReader();
        while (dr5.Read())
        {
            
            if (con == 5)
            {
                break;
            }
            else 
            {
                 this.Label5.Text = this.Label5.Text + aux;
                 id_tem = Convert.ToString(dr5["id_tema"]);
                 SqlCommand cm6 = new SqlCommand("select * from Tema where publico = 1 and id_tema =" + id_tem , cn4);
                 SqlDataReader dr6 = cm6.ExecuteReader();
                 while (dr6.Read())
                 {
                     tema = Convert.ToString(dr6["nombre"]);
                 }
                 dr6.Close();
                 aux = "<p>" + tema + "</p>";
            }
        }
        this.Label5.Text = this.Label5.Text + aux;

    }
}