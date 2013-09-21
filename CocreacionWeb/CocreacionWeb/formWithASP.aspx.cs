using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DataAccess;

namespace CocreacionWeb
{
    public partial class form : System.Web.UI.Page
    {
        static string strCnx = ConfigurationManager.AppSettings["con"];
        Data data = new Data(strCnx);
        DataTable dataScore;

        protected void Page_Load(object sender, EventArgs e)
        {
            init();
        }

        protected void init()
        {
            DataTable dt = getDatos();
            dataScore = getScoreData();

            //Objetivo y Problema

            DataRow[] dataRows;
            dataRows = dt.Select("grupo = '9'");

            foreach (DataRow r in dataRows)
            {
                CheckBox chk = new CheckBox();
                chk.Text = r["criterio"].ToString();
                pnl_problema.Controls.Add(chk);
                pnl_problema.Controls.Add(new LiteralControl("<br>"));
            }

            //Fases

            dataRows = dt.Select("grupo = '1'");

            foreach (DataRow r in dataRows)
            {
                RadioButton rb = new RadioButton();
                rb.Text = r["criterio"].ToString();
                rb.GroupName = "fases";
                rb.Checked = true;
                pnl_fase.Controls.Add(rb);
                pnl_fase.Controls.Add(new LiteralControl("<br>"));
            }


            //Nivel de Conocimiento

            dataRows = dt.Select("grupo = '3'");

            foreach (DataRow r in dataRows)
            {
                RadioButton rb = new RadioButton();
                rb.Text = r["criterio"].ToString();
                rb.GroupName = "nivel_conocimiento";
                rb.Checked = true;
                pnl_nivel_conocimiento.Controls.Add(rb);
                pnl_nivel_conocimiento.Controls.Add(new LiteralControl("<br>"));
            }

            //Ubicacion

            dataRows = dt.Select("grupo = '4'");

            foreach (DataRow r in dataRows)
            {
                RadioButton rb = new RadioButton();
                rb.Text = r["criterio"].ToString();
                rb.GroupName = "ubicacion";
                rb.Checked = true;
                pnl_ubicacion.Controls.Add(rb);
                pnl_ubicacion.Controls.Add(new LiteralControl("<br>"));
            }

            //Participantes

            dataRows = dt.Select("grupo = '8'");

            foreach (DataRow r in dataRows)
            {
                CheckBox chk = new CheckBox();
                chk.Text = r["criterio"].ToString();
                pnl_participantes.Controls.Add(chk);
                pnl_participantes.Controls.Add(new LiteralControl("<br>"));
            }

            //Costo

            dataRows = dt.Select("grupo = '6'");

            foreach (DataRow r in dataRows)
            {
                RadioButton rb = new RadioButton();
                rb.Text = r["criterio"].ToString();
                rb.GroupName = "costo";
                rb.Checked = true;
                pnl_costo.Controls.Add(rb);
                pnl_costo.Controls.Add(new LiteralControl("<br>"));
            }

            //Escalabilidad

            dataRows = dt.Select("grupo = '6'");

            foreach (DataRow r in dataRows)
            {
                RadioButton rb = new RadioButton();
                rb.Text = r["criterio"].ToString();
                rb.GroupName = "escalabilidad";
                rb.Checked = true;
                pnl_escalabilidad.Controls.Add(rb);
                pnl_escalabilidad.Controls.Add(new LiteralControl("<br>"));
            }
        }

        private DataTable getDatos()
        {
            return data.getDatosFormulario();
        }

        private DataTable getScoreData()
        {
            DataTable dt = new DataTable();
            dt = data.getTecnicas();
            dt.Columns.RemoveAt(2);
            dt.Columns.Add("Score", typeof(int));
            return dt;
        }


        protected void checkProblem(object sender, EventArgs e)
        {
            foreach (Control ctrl in pnl_problema.Controls)
            {
                if (ctrl is CheckBox)
                {
                    if (((CheckBox)ctrl).Checked)
                    {
                        Console.Write("Esta chequeado");
                    }
                }
            }
            error_problema.Style.Add("display", "block");
            //Response.Redirect("form.aspx#/step-4");


        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

    }
}