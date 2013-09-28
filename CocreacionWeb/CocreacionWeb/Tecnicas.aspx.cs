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
        #region Principales

        static string strCnx = ConfigurationManager.AppSettings["con"];
        Data data = new Data(strCnx);
        string idTecnicaActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            loadTecnicas();
        }

        private void loadLinks(string id)
        {
            gvLinks.DataSource = data.getLinksByIdTecnica(id);
            gvLinks.DataBind();
        }

        private void loadPasos(string id)
        {
            gvPasos.DataSource = data.getPasosByIdTecnica(id);
            gvPasos.DataBind();
        }

        private void loadTecnicas()
        {
            gvTecnicas.DataSource = data.getTecnicas();
            gvTecnicas.DataBind();
        }

        protected void lblAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            pnlTablaTecnicas.Visible = true;
            pnlTecnicaDetalle.Visible = false;
        }

        #endregion


        #region Administracion Tecnica

        protected void tableTecnicas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idTecnica = gvTecnicas.SelectedDataKey.Value.ToString();
            idTecnicaActual = idTecnica;
            pnlTablaTecnicas.Visible = false;
            pnlTecnicaDetalle.Visible = true;
            asignarDetalles(idTecnica);
            loadLinks(idTecnica);
            loadPasos(idTecnica);
        }

        protected void asignarDetalles(string idTecnica)
        {
            DataTable tecnicaSeleccionada = data.getTecnicaById(idTecnica);
            lblNombreTecnicaDetalle.Text = tecnicaSeleccionada.Rows[0][1].ToString();
            txtNombreTecnicaDetalle.Text = tecnicaSeleccionada.Rows[0][1].ToString();
            lblDescripcionDetalle.Text = tecnicaSeleccionada.Rows[0][2].ToString();
            txtDescripcionDetalle.Text = tecnicaSeleccionada.Rows[0][2].ToString();
        }

        protected void btnChangeTitle_Click(object sender, EventArgs e)
        {
            if (lblNombreTecnicaDetalle.Visible == false)
            {
                lblNombreTecnicaDetalle.Visible = true;
                txtNombreTecnicaDetalle.Visible = false;
            }
            else
            {
                lblNombreTecnicaDetalle.Visible = false;
                txtNombreTecnicaDetalle.Visible = true;
            }
        }

        protected void btnChangeDescription_Click(object sender, EventArgs e)
        {
            if (lblDescripcionDetalle.Visible == false)
            {
                lblDescripcionDetalle.Visible = true;
                txtDescripcionDetalle.Visible = false;
            }
            else
            {
                lblDescripcionDetalle.Visible = false;
                txtDescripcionDetalle.Visible = true;
            }
        }

        #endregion

        #region pasos

        protected void btnNuevoPaso_Click(object sender, EventArgs e)
        {
            gvPasos.ShowFooter = true;
            loadPasos(idTecnicaActual);
        }

        protected void gvPasos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void gvPasos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvPasos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPasos.EditIndex = e.NewEditIndex;
            loadPasos(idTecnicaActual);
        }

        #endregion

        #region Links

        protected void btnNuevoLink_Click(object sender, EventArgs e)
        {

        }

        protected void gvLinks_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void gvLinks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvLinks_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        #endregion
    }
}