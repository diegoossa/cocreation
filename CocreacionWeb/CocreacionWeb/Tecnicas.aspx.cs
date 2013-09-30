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
        static string idTecnicaActual;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadTecnicas();
            }
        }

        private void loadLinks(string id)
        {
            DataTable d = data.getLinksByIdTecnica(id);
            if (d.Rows.Count == 0)
            {
                d.Rows.Add(d.NewRow());
            }
            gvLinks.DataSource = d;
            gvLinks.DataBind();
        }

        private void loadPasos(string id)
        {
            DataTable d = data.getPasosByIdTecnica(id);
            if (d.Rows.Count == 0)
            {
                d.Rows.Add(d.NewRow());
            }
            gvPasos.DataSource = d;
            gvPasos.DataBind();
        }

        private void loadTecnicas()
        {
            gvTecnicas.DataSource = data.getTecnicas();
            gvTecnicas.DataBind();
        }

        protected void lblAceptar_Click(object sender, EventArgs e)
        {
            if (txtTituloNueva.Text == "" || txtDescripcionNueva.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Error : Los campos Titulo y Descripción de la técnica son obligarios.');", true);
            }
            else
            {
                string titulo = txtTituloNueva.Text;
                string descripcion = txtDescripcionNueva.Text;
                data.createTecnica(titulo, descripcion);
                pnlNuevaTecnica.Visible = false;
                pnlTecnicaDetalle.Visible = true;
                idTecnicaActual = data.getLastId();
                asignarDetalles();
            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            pnlTablaTecnicas.Visible = true;
            pnlTecnicaDetalle.Visible = false;
        }

        protected void btnAtrasNueva_Click(object sender, EventArgs e)
        {
            pnlTablaTecnicas.Visible = true;
            pnlNuevaTecnica.Visible = false;
        }

        protected void gvTecnicas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idTecnica = gvTecnicas.DataKeys[e.RowIndex].Value.ToString();
            data.deleteTecnica(idTecnica);
            loadTecnicas();
        }

        #endregion

        #region Administracion Tecnica

        protected void tableTecnicas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idTecnica = gvTecnicas.SelectedDataKey.Value.ToString();
            idTecnicaActual = idTecnica;
            pnlTablaTecnicas.Visible = false;
            pnlTecnicaDetalle.Visible = true;
            asignarDetalles();
            loadLinks(idTecnicaActual);
            loadPasos(idTecnicaActual);
            loadCaracteristicas();
        }

        protected void asignarDetalles()
        {
            DataTable tecnicaSeleccionada = data.getTecnicaById(idTecnicaActual);
            lblNombreTecnicaDetalle.Text = tecnicaSeleccionada.Rows[0][1].ToString();
            txtNombreTecnicaDetalle.Text = tecnicaSeleccionada.Rows[0][1].ToString();
            lblDescripcionDetalle.Text = tecnicaSeleccionada.Rows[0][2].ToString();
            txtDescripcionDetalle.Text = tecnicaSeleccionada.Rows[0][2].ToString();
        }

        protected void btnChangeTitle_Click(object sender, EventArgs e)
        {
            lblNombreTecnicaDetalle.Visible = false;
            txtNombreTecnicaDetalle.Visible = true;
            btnChangeTitle.Visible = false;
            btnAceptarCambioTitulo.Visible = true;
            btnCancelarCambioTitulo.Visible = true;
        }

        protected void btnAceptarCambioTitulo_Click(object sender, EventArgs e)
        {
            data.editTecnica(idTecnicaActual, "nombre_tecnica", txtNombreTecnicaDetalle.Text);
            asignarDetalles();
            lblNombreTecnicaDetalle.Visible = true;
            txtNombreTecnicaDetalle.Visible = false;
            btnAceptarCambioTitulo.Visible = false;
            btnCancelarCambioTitulo.Visible = false;
            btnChangeTitle.Visible = true;
        }

        protected void btnCancelarCambioTitulo_Click(object sender, EventArgs e)
        {
            lblNombreTecnicaDetalle.Visible = true;
            txtNombreTecnicaDetalle.Visible = false;
            btnAceptarCambioTitulo.Visible = false;
            btnCancelarCambioTitulo.Visible = false;
            btnChangeTitle.Visible = true;
        }

        protected void btnChangeDescription_Click(object sender, EventArgs e)
        {
            lblDescripcionDetalle.Visible = false;
            txtDescripcionDetalle.Visible = true;
            btnChangeDescription.Visible = false;
            btnAceptarCambioDescripcion.Visible = true;
            btnCancelarCambioDescripcion.Visible = true;
        }

        protected void btnAceptarCambioDescripcion_Click(object sender, EventArgs e)
        {
            data.editTecnica(idTecnicaActual, "descripcion", txtDescripcionDetalle.Text);
            asignarDetalles();
            lblDescripcionDetalle.Visible = true;
            txtDescripcionDetalle.Visible = false;
            btnChangeDescription.Visible = true;
            btnAceptarCambioDescripcion.Visible = false;
            btnCancelarCambioDescripcion.Visible = false;
        }

        protected void btnCancelarCambioDescripcion_Click(object sender, EventArgs e)
        {
            lblDescripcionDetalle.Visible = true;
            txtDescripcionDetalle.Visible = false;
            btnChangeDescription.Visible = true;
            btnAceptarCambioDescripcion.Visible = false;
            btnCancelarCambioDescripcion.Visible = false;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            pnlTablaTecnicas.Visible = false;
            pnlNuevaTecnica.Visible = true;
        }

        #endregion

        #region pasos

        protected void btnNuevoPaso_Click(object sender, EventArgs e)
        {
            gvPasos.ShowFooter = true;
            loadPasos(idTecnicaActual);
            DropDownList ddlCriteriosCreate = gvPasos.FooterRow.FindControl("ddlCriteriosCreate") as DropDownList;
            ddlCriteriosCreate.DataSource = data.getRoles();
            ddlCriteriosCreate.DataTextField = "criterio";
            ddlCriteriosCreate.DataValueField = "id_criterio";
            ddlCriteriosCreate.DataBind();
        }

        protected void gvPasos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPasos.EditIndex = -1;
            loadPasos(idTecnicaActual);
        }

        protected void gvPasos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string idPaso = gvPasos.DataKeys[e.RowIndex].Value.ToString();
                data.deletePaso(idPaso);
                loadPasos(idTecnicaActual);
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        protected void gvPasos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvPasos.EditIndex = e.NewEditIndex;
                loadPasos(idTecnicaActual);
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        protected void gvPasos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gvPasos.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlCriteriosEdit = (DropDownList)e.Row.FindControl("ddlCriteriosEdit");
                ddlCriteriosEdit.DataSource = data.getRoles();
                ddlCriteriosEdit.DataTextField = "criterio";
                ddlCriteriosEdit.DataValueField = "id_criterio";
                ddlCriteriosEdit.DataBind();
                ddlCriteriosEdit.Items.FindByText((e.Row.FindControl("lblCriterio") as Label).Text).Selected = true;
            }
        }

        protected void btnCancelCreatePaso_Click(object sender, EventArgs e)
        {
            gvPasos.ShowFooter = false;
            loadPasos(idTecnicaActual);
        }

        protected void gvPasos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string paso = ((TextBox)gvPasos.Rows[e.RowIndex].FindControl("txtPasoEdit")).Text;
            string criterio = ((DropDownList)gvPasos.Rows[e.RowIndex].FindControl("ddlCriteriosEdit")).SelectedValue;
            string idPaso = gvPasos.DataKeys[e.RowIndex].Value.ToString();
            data.editPaso(idPaso, idTecnicaActual, paso, criterio);
            gvPasos.EditIndex = -1;
            loadPasos(idTecnicaActual);
        }

        protected void btnAceptarCreacionPaso_Click(object sender, EventArgs e)
        {
            string paso = ((TextBox)gvPasos.FooterRow.FindControl("txtPasoCreate")).Text;
            string criterio = ((DropDownList)gvPasos.FooterRow.FindControl("ddlCriteriosCreate")).SelectedValue;
            data.createPaso(paso, criterio, idTecnicaActual);
            gvPasos.ShowFooter = false;
            loadPasos(idTecnicaActual);
        }

        #endregion

        #region Links

        protected void btnNuevoLink_Click(object sender, EventArgs e)
        {
            gvLinks.ShowFooter = true;
            loadLinks(idTecnicaActual);
        }

        protected void gvLinks_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvLinks.EditIndex = -1;
            loadLinks(idTecnicaActual);
        }

        protected void gvLinks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string idLink = gvLinks.DataKeys[e.RowIndex].Value.ToString();
                data.deleteLink(idLink);
                loadLinks(idTecnicaActual);
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        protected void gvLinks_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvLinks.EditIndex = e.NewEditIndex;
                loadLinks(idTecnicaActual);
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        protected void btnCancelCreateLink_Click(object sender, EventArgs e)
        {
            gvLinks.ShowFooter = false;
            loadLinks(idTecnicaActual);
        }

        protected void btnAceptarCreacionLink_Click(object sender, EventArgs e)
        {
            string link = (gvLinks.FooterRow.FindControl("txtLinkCreate") as TextBox).Text;
            data.createLink(link, idTecnicaActual);
            gvLinks.ShowFooter = false;
            loadLinks(idTecnicaActual);
        }

        protected void gvLinks_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string link = ((TextBox)gvLinks.Rows[e.RowIndex].FindControl("txtLinkEdit")).Text;
            string idLink = gvLinks.DataKeys[e.RowIndex].Value.ToString();
            data.editLink(idLink, idTecnicaActual, link);
            gvLinks.EditIndex = -1;
            loadLinks(idTecnicaActual);
        }

        #endregion

        #region Caracteristicas

        protected void loadCaracteristicas()
        {
            DataTable d = data.getCaracteristicasByTecnicaId(idTecnicaActual);
            if (d.Rows.Count == 0)
            {
                d.Rows.Add(d.NewRow());
            }
            gvCaracteristica.DataSource = d;
            gvCaracteristica.DataBind();

        }

        protected void lbNuevaCaracteristica_Click(object sender, EventArgs e)
        {
            gvCaracteristica.ShowFooter = true;
            loadCaracteristicas();
            DropDownList ddlCaracteristicaCreate = gvCaracteristica.FooterRow.FindControl("ddlCaracteristicaCreate") as DropDownList;
            ddlCaracteristicaCreate.DataSource = data.getCaracteristicas();
            ddlCaracteristicaCreate.DataTextField = "caracteristica";
            ddlCaracteristicaCreate.DataValueField = "id_caracteristica";
            ddlCaracteristicaCreate.DataBind();

            DropDownList ddlCriterioCreate = gvCaracteristica.FooterRow.FindControl("ddlCriterioCreate") as DropDownList;
            ddlCriterioCreate.DataSource = data.getCriterio(ddlCaracteristicaCreate.SelectedValue);
            ddlCriterioCreate.DataTextField = "criterio";
            ddlCriterioCreate.DataValueField = "id_criterio";
            ddlCriterioCreate.DataBind();


        }

        protected void ddlCaracteristicaCreate_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlCaracteristicaCreate = gvCaracteristica.FooterRow.FindControl("ddlCaracteristicaCreate") as DropDownList;
            DropDownList ddlCriterioCreate = gvCaracteristica.FooterRow.FindControl("ddlCriterioCreate") as DropDownList;
            ddlCriterioCreate.DataSource = data.getCriterio(ddlCaracteristicaCreate.SelectedValue);
            ddlCriterioCreate.DataTextField = "criterio";
            ddlCriterioCreate.DataValueField = "id_criterio";
            ddlCriterioCreate.DataBind();
        }

        protected void ddlCaracteristicaEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlCaracteristicaEdit = gvCaracteristica.Rows[gvCaracteristica.EditIndex].FindControl("ddlCaracteristicaEdit") as DropDownList;
            DropDownList ddlCriterioEdit = gvCaracteristica.Rows[gvCaracteristica.EditIndex].FindControl("ddlCriterioEdit") as DropDownList;
            ddlCriterioEdit.DataSource = data.getCriterio(ddlCaracteristicaEdit.SelectedValue);
            ddlCriterioEdit.DataTextField = "criterio";
            ddlCriterioEdit.DataValueField = "id_criterio";
            ddlCriterioEdit.DataBind();
        }

        protected void gvCaracteristica_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gvCaracteristica.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlCaracteristicaEdit = (DropDownList)e.Row.FindControl("ddlCaracteristicaEdit");
                ddlCaracteristicaEdit.DataSource = data.getCaracteristicas();
                ddlCaracteristicaEdit.DataTextField = "caracteristica";
                ddlCaracteristicaEdit.DataValueField = "id_caracteristica";
                ddlCaracteristicaEdit.DataBind();
                ddlCaracteristicaEdit.Items.FindByText((e.Row.FindControl("lblCaracteristica") as Label).Text).Selected = true;

                DropDownList ddlCriterioEdit = (DropDownList)e.Row.FindControl("ddlCriterioEdit");
                ddlCriterioEdit.DataSource = data.getCriterio(ddlCaracteristicaEdit.SelectedValue);
                ddlCriterioEdit.DataTextField = "criterio";
                ddlCriterioEdit.DataValueField = "id_criterio";
                ddlCriterioEdit.DataBind();
            }
        }

        protected void gvCaracteristica_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCaracteristica.EditIndex = -1;
            loadCaracteristicas();
        }

        protected void gvCaracteristica_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idRelacion = gvCaracteristica.DataKeys[e.RowIndex].Value.ToString();
            data.deleteCaracteristicasTecnica(idRelacion);
            loadCaracteristicas();
        }

        protected void gvCaracteristica_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCaracteristica.EditIndex = e.NewEditIndex;
            loadCaracteristicas();
        }

        protected void gvCaracteristica_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string idCaracteristica = (gvCaracteristica.Rows[e.RowIndex].FindControl("ddlCaracteristicaEdit") as DropDownList).SelectedValue;
            string idCriterio = (gvCaracteristica.Rows[e.RowIndex].FindControl("ddlCriterioEdit") as DropDownList).SelectedValue;
            data.createCaracteristicasTecnica(idTecnicaActual, idCaracteristica, idCriterio);
            gvCaracteristica.EditIndex = -1;
            loadCaracteristicas();
        }

        protected void btnAceptarCreacionCaracteristica_Click(object sender, EventArgs e)
        {
            string idCaracteristica = (gvCaracteristica.FooterRow.FindControl("ddlCaracteristicaCreate") as DropDownList).SelectedValue;
            string idCriterio = (gvCaracteristica.FooterRow.FindControl("ddlCriterioCreate") as DropDownList).SelectedValue;
            data.createCaracteristicasTecnica(idTecnicaActual, idCaracteristica, idCriterio);
            gvCaracteristica.ShowFooter = false;
            loadCaracteristicas();
        }

        protected void btnCancelCreateCaracteristica_Click(object sender, EventArgs e)
        {
            gvCaracteristica.ShowFooter = false;
            loadCaracteristicas();
        }

        #endregion

    }
}