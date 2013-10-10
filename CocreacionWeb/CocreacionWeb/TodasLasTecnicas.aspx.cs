using DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CocreacionWeb
{
    public partial class TodasLasTecnicas : System.Web.UI.Page
    {
        static string strCnx = ConfigurationManager.AppSettings["con"];
        Data data = new Data(strCnx);
        string[] idTecnica = new string[18];
        static int indiceActual = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < idTecnica.Length; i++)
            {
                idTecnica[i] = (i + 1).ToString();
            }

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

        private void checkBtns()
        {
            if (indiceActual <= 0)
            {
                btnAnterior.Visible = false;
            }
            else
            {
                btnAnterior.Visible = true;
            }
            if (indiceActual >= idTecnica.Length - 1)
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