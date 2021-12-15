using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class desflujo : System.Web.UI.Page
{
    motorFlujos mt;
    //string formularioActual = "desflujo.aspx?bandeja=no?flujo=F1&proceso=P0&formulario='POR VERSE'"; //OJO
    string formularioActual = "";
    string formularioSiguiente = "";
    string formularioAnterior = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Flujos"].Equals("True"))
        {
            mt = new motorFlujos();
            conexion conn = new conexion();
            conn.openCon();
            conn.command("SELECT formulario FROM flujoproceso WHERE flujo = '" + Request.QueryString["flujo"] + "' AND proceso = '" + Request.QueryString["proceso"] + "'", false);
            conn.readerQuery();
            if (conn.dtr.Read())
            {
                formularioActual = conn.dtr["formulario"].ToString();
            }
            conn.closeCon();
            mt.setProcesos(Request.QueryString["flujo"], Request.QueryString["proceso"], Request.QueryString["formulario"]);
        }

        if (Request.QueryString["bandeja"].Equals("Y"))
        {
            conexion con = new conexion();
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("Tramite", typeof(string)),
                            new DataColumn("Flujo", typeof(string)),
                            new DataColumn("Proceso",typeof(string)),
                            new DataColumn("Fecha Inicio", typeof(string)),
                            new DataColumn("Fecha Final", typeof(string)),
                            new DataColumn("Acción", typeof(string))});
            con.openCon();
            //con.intoAdapter("SELECT * FROM Usuario");
            con.command("SELECT * FROM seguimiento WHERE usuario = '" + Request.QueryString["user"] + "'", false);
            con.readerQuery();
            while (con.dtr.Read())
            {
                conexion conTemp = new conexion();
                conTemp.openCon();
                conTemp.command("SELECT formulario FROM flujoproceso WHERE proceso = '" + con.dtr["proceso"] + "'", false);
                conTemp.readerQuery();
                string cadaFlujoSeleccionado = "";
                if (conTemp.dtr.Read())
                {
                    cadaFlujoSeleccionado = "<a href='desflujo.aspx?bandeja=no&flujo=" + con.dtr["flujo"] + "&proceso=" + con.dtr["proceso"] + "&formulario=" + conTemp.dtr["formulario"] + "&Flujos=True'> Mostrar </a>";
                }
                    dt.Rows.Add(con.dtr["tramite"].ToString(), con.dtr["flujo"].ToString(), con.dtr["proceso"].ToString(), con.dtr["fechainicio"].ToString(), con.dtr["fechafin"].ToString(), new HtmlString(cadaFlujoSeleccionado));

                conTemp.closeCon();
            }
            con.closeCon();

            GridView1.DataSource = dt;

            GridView1.DataBind();

            Button1.Style["Visibility"] = "hidden";
            Button2.Style["Visibility"] = "hidden";
        }
        else
        {
            if (!formularioActual.Equals(""))
                Response.WriteFile(formularioActual);
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (mt.procesoAnterior.Equals("") && mt.pAnterior.Equals(""))
        {
            formularioAnterior = "desflujo.aspx?bandeja=no&flujo=" + Request.QueryString["flujo"] + "&proceso=" + Request.QueryString["proceso"] + "&formulario=" + formularioActual + "&Flujos=True";
        }
        else
        {
            formularioAnterior = "desflujo.aspx?bandeja=no&flujo=" + Request.QueryString["flujo"] + "&proceso=" + mt.pAnterior + "&formulario=" + mt.procesoAnterior + "&Flujos=True";
        }
        Response.Redirect(formularioAnterior);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (mt.procesoSiguiente.Equals("") && mt.pSiguiente.Equals(""))
        {
            formularioSiguiente = "desflujo.aspx?bandeja=no&flujo=" + Request.QueryString["flujo"] + "&proceso=" + Request.QueryString["proceso"] + "&formulario=" + formularioActual + "&Flujos=True";
        }
        else
        {
            formularioSiguiente = "desflujo.aspx?bandeja=no&flujo=" + Request.QueryString["flujo"] + "&proceso=" + mt.pSiguiente + "&formulario=" + mt.procesoSiguiente + "&Flujos=True";
        }

        Response.Redirect(formularioSiguiente);
    }

}