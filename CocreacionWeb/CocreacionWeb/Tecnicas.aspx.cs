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

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            pnlTablaTecnicas.Visible = true;
            pnlTecnicaDetalle.Visible = false;
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
            pnlTecnicaDetalle.Visible = true;
            asignarDetalles(idTecnica);
        }

        protected void asignarDetalles(string idTecnica)
        {
            DataTable tecnicaSeleccionada = data.getTecnicaById(idTecnica);
            lblNombreTecnicaDetalle.Text = tecnicaSeleccionada.Rows[0][1].ToString();
            txtNombreTecnicaDetalle.Text = tecnicaSeleccionada.Rows[0][1].ToString();
            lblDescripcionDetalle.Text = tecnicaSeleccionada.Rows[0][2].ToString();
            txtDescripcionDetalle.Text = tecnicaSeleccionada.Rows[0][2].ToString();
            DataTable pasos = data.getPasosByIdTecnica(idTecnica);
            foreach (DataRow r in pasos.Rows)
            {
                Label lblNPaso = new Label();
                lblNPaso.Text = r[0].ToString() + "  ";
                pnlPasos.Controls.Add(lblNPaso);
                TextBox txtPaso = new TextBox();
                txtPaso.Text = r[2].ToString();
                txtPaso.ID = "txtPaso" + r[0].ToString();
                pnlPasos.Controls.Add(txtPaso);
                Label lblRol = new Label();
                lblRol.Text = "  Responsable:  ";
                pnlPasos.Controls.Add(lblRol);
                TextBox txtRol = new TextBox();
                txtRol.Text = r[3].ToString();
                txtRol.ID = "txtRol" + r[4].ToString();
                pnlPasos.Controls.Add(txtRol);
                pnlPasos.Controls.Add(new LiteralControl("<br>"));
            }
            DataTable links = data.getLinksByIdTecnica(idTecnica);
            foreach (DataRow r in links.Rows)
            {
                Label lblLink = new Label();
                lblLink.Text = r[0].ToString() + "  ";
                pnlLinks.Controls.Add(lblLink);
                TextBox txtLink = new TextBox();
                txtLink.Text = "txtLink" + r[2].ToString();
                txtLink.ID = r[0].ToString();
                pnlLinks.Controls.Add(txtLink);
                pnlLinks.Controls.Add(new LiteralControl("<br>"));
            }
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

        protected void btnNuevoPaso_Click(object sender, EventArgs e)
        {
            Label lblNuevoPaso = new Label();
            lblNuevoPaso.Text = "Nuevo paso:  ";
            pnlNuevoPaso.Controls.Add(lblNuevoPaso);
            TextBox txtNuevoPaso = new TextBox();
            txtNuevoPaso.ID = "txtNuevoPaso";
            pnlNuevoPaso.Controls.Add(txtNuevoPaso);
            Label lblRol = new Label();
            lblRol.Text = "  Responsable:  ";
            pnlNuevoPaso.Controls.Add(lblRol);
            TextBox txtRol = new TextBox();
            txtRol.ID = "txtNuevoRol";
            pnlNuevoPaso.Controls.Add(txtRol);
            pnlNuevoPaso.Controls.Add(new LiteralControl("<br>"));
        }

        protected void btnNuevoLink_Click(object sender, EventArgs e)
        {

        }

        protected void lblAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}