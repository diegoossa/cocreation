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
    public partial class admin : System.Web.UI.Page
    {
        static string strCnx = ConfigurationManager.AppSettings["con"];
        Data data = new Data(strCnx);

        protected void Page_Load(object sender, EventArgs e)
        {
            loadTecnicas();
        }

        private void loadTecnicas()
        {
            tableTecnicas.DataSource = data.getTecnicas();
            tableTecnicas.DataBind();
        }

        
        protected void tableTecnicas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            tableTecnicas.EditIndex = e.NewEditIndex;
            loadTecnicas();
        }

        protected void tableTecnicas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            tableTecnicas.EditIndex = -1;
            loadTecnicas();
        }

        protected void tableTecnicas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }        

        protected void tableTecnicas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            tableTecnicas.ShowFooter = true;
            loadTecnicas();
        }

        protected void btnCancelarAgregar_Click(object sender, EventArgs e)
        {
            tableTecnicas.ShowFooter = false;
            loadTecnicas();
        }

        protected void tableTecnicas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idTecnica = tableTecnicas.SelectedDataKey.Value.ToString();
            pnlTablaTecnicas.Visible = false;
            DataTable tecnicaSeleccionada = data.getTecnicaById(idTecnica);
            lblNombreTecnicaDetalle.Text = tecnicaSeleccionada.Rows[0][1].ToString();

        }
    }
}