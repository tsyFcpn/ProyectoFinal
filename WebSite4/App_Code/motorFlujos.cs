using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// Descripción breve de motorFlujos
/// </summary>
public class motorFlujos
{
    public string procesoSiguiente;
    public string procesoAnterior;
    public string pSiguiente;
    public string pAnterior;

    public motorFlujos()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public void siguiente(String flujo, String proceso, String formulario)
    {
        String sql = "SELECT * FROM flujoproceso WHERE flujo = '" + flujo + "' AND proceso = '" + proceso + "' ";
        conexion con = new conexion();
        con.openCon();
        con.command(sql,false);
        con.readerQuery();
        
        String tempForm = "";
        String tempProc = "";
        if (con.dtr.Read())
        {
            conexion conTemp = new conexion();
            tempForm = con.dtr["procesosiguiente"].ToString();
            sql = "SELECT * FROM flujoproceso WHERE proceso = '" + tempForm + "'";
            conTemp.openCon();
            conTemp.command(sql,false);
            conTemp.readerQuery();
            if (conTemp.dtr.Read())
            {
                tempForm = conTemp.dtr["formulario"].ToString();
                tempProc = conTemp.dtr["proceso"].ToString();
            }
            conTemp.closeCon();
        }
        con.closeCon();
        procesoSiguiente = tempForm;
        pSiguiente = tempProc;
    }
    public void anterior(String flujo, String proceso, String formulario)
    {
        String sql = "SELECT * FROM flujoproceso WHERE flujo = '" + flujo + "' AND procesosiguiente = '" + proceso + "' ";
        conexion con = new conexion();
        con.openCon();        
        con.command(sql,false);
        con.readerQuery();
        String tempForm = "";
        String tempProc = "";
        if (con.dtr.Read())
        {
            conexion conTemp = new conexion();
            tempForm = con.dtr["proceso"].ToString();
            sql = "SELECT * FROM flujoproceso WHERE proceso = '" + tempForm + "'";
            conTemp.openCon();
            conTemp.command(sql,false);
            conTemp.readerQuery();
            if (conTemp.dtr.Read())
            {
                tempForm = conTemp.dtr["formulario"].ToString();
                tempProc = conTemp.dtr["proceso"].ToString();
            }
            conTemp.closeCon();
        }
        con.closeCon();
        procesoAnterior = tempForm;
        pAnterior = tempProc;
    }
    public void setProcesos(String flujo, String proceso, String formulario)
    {
        siguiente(flujo, proceso, formulario);
        anterior(flujo, proceso, formulario);
    }
    public string prueba()
    {
        String sql = "SELECT * FROM usuario";
        conexion con = new conexion();
        con.openCon();
        con.command(sql,false);
        con.readerQuery();
        con.dtr.Read();
        String temp = con.dtr["usuario"].ToString() + con.dtr["contrasenia"].ToString() + con.dtr["rol"].ToString();
        con.closeCon();
        return temp;
    }
}