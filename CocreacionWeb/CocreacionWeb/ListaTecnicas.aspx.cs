using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using System.Configuration;
using System.Data;

namespace CocreacionWeb
{
    public partial class ListaTecnicas : System.Web.UI.Page
    {
        static string strCnx = ConfigurationManager.AppSettings["con"];
        Data data = new Data(strCnx);
        string[] idTecnica = new string[3];
        static int indiceActual = 0;

        protected void Page_Load(object sender, EventArgs e)
        {            
            idTecnica[0] = Request.QueryString["tecnica1"];
            idTecnica[1] = Request.QueryString["tecnica2"];
            idTecnica[2] = Request.QueryString["tecnica3"];
            if (!IsPostBack)
            {              
                checkBtns();
                fillData();
            }
            
        }

        private void fillData()
        {
            DataTable tecnicaSeleccionada = data.getTecnicaById(idTecnica[indiceActual]);
            txtTitulo.Text = tecnicaSeleccionada.Rows[0][1].ToString();
            txtDescripcion.Text = tecnicaSeleccionada.Rows[0][2].ToString();

            gvLinks.DataSource = data.getLinksByIdTecnica(idTecnica[indiceActual]);
            gvLinks.DataBind();
            gvPasos.DataSource = data.getPasosByIdTecnica(idTecnica[indiceActual]);
            gvPasos.DataBind();
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            indiceActual++;
            checkBtns();
            fillData();
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            indiceActual--;
            checkBtns();
            fillData();
        }

        private void checkBtns() {
            if (indiceActual <= 0)
            {
                btnAnterior.Visible = false;
            }
            else
            {
                btnAnterior.Visible = true;
            }
            if (indiceActual >= 2)
            {
                btnSiguiente.Visible = false;
            }
            else
            {
                btnSiguiente.Visible = true;
            }
        }
    }
}