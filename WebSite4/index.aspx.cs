using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    String usuario = "";
    String contrasenia = "";

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        conexion con = new conexion();
        con.openCon();
        con.command("SELECT * FROM Usuario WHERE usuario = '" + TextBox1.Text + "' AND contrasenia = '" + TextBox2.Text + "'", false);
        
        con.readerQuery();
        if (con.dtr.Read())
        {
            usuario = con.dtr["usuario"].ToString();
            contrasenia = con.dtr["contrasenia"].ToString();
        }
        con.closeCon();
        if (TextBox1.Text.Equals(usuario) && TextBox2.Text.Equals(contrasenia))
        {
            Response.Redirect("desflujo.aspx?bandeja=Y&user=" + usuario + "&pass=" + contrasenia+"&Flujos=False");
        }
        else
        {
            Response.Redirect("index.aspx");
        }
    }
}