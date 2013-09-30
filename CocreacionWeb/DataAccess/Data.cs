using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Data
    {

        #region Definicion y constructor
        private string strCnx;
        SqlConnection con;

        public Data(string s)
        {
            strCnx = s;
            con = new SqlConnection(strCnx);
        }
        #endregion

        #region Metodos Genericos

        public int executeQuery(string q)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(q, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return i;
        }

        public DataTable selectQuery(string q)
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(q, con);
            da.Fill(dt);
            da.Dispose();
            con.Close();
            return dt;
        }

        #endregion

        #region Tecnicas

        public DataTable getTecnicas()
        {
            return selectQuery("select * from Tecnica");
        }

        public DataTable getTecnicaCaracteristicaCriterio_Importancia()
        {
            return selectQuery("select tcc.id_caracteristica, tcc.id_criterio, tcc.id_tecnica, c.importancia from Tecnica_Caracteristica_Criterio tcc inner join Caracteristica c on tcc.id_caracteristica = c.id_caracteristica");
        }

        public DataTable getTecnicaById(string id)
        {
            return selectQuery("select * from Tecnica where id_tecnica = " + id);
        }

        public void editTecnica(string id, string campo, string valor)
        {
            executeQuery("UPDATE tecnica SET " + campo + " = '" + valor + "' WHERE id_tecnica = " + id);
        }

        public void deleteTecnica(string id)
        {
            executeQuery("DELETE from Tecnica where id_tecnica = " + id);
            executeQuery("DELETE from Tecnica_Caracteristica_Criterio where id_tecnica = " + id);
            executeQuery("DELETE from Paso where id_tecnica = " + id);
            executeQuery("DELETE from Link where id_tecnica = " + id);
        }

        public void createTecnica(string nombre, string descripcion)
        {
            executeQuery("INSERT INTO Tecnica (nombre_tecnica, descripcion) VALUES ('" + nombre + "','" + descripcion + "')");
        }

        public string getLastId() {
            DataTable dt = selectQuery("SELECT MAX(id_tecnica) FROM Tecnica");
            return dt.Rows[0][0].ToString();
        }
        #endregion

        #region Pasos

        public DataTable getPasosByIdTecnica(string id)
        {
            return selectQuery("select p.id_paso, p.id_tecnica, p.paso, c.criterio, c.id_criterio  from Paso p inner join Criterio c on p.id_criterio_rol = c.id_criterio where p.id_tecnica = " + id);
        }

        public void editPaso(string idPaso, string idTecnica, string paso, string idCriterio)
        {
            executeQuery("UPDATE Paso SET paso = '" + paso + "', id_criterio_rol = '" + idCriterio + "' WHERE id_paso = " + idPaso);
        }

        public void createPaso(string paso, string idCriterio, string idTecnica)
        {
            executeQuery("INSERT INTO Paso (id_tecnica, paso, id_criterio_rol) VALUES ('" + idTecnica + "','" + paso + "','" + idCriterio + "')");
        }

        public void deletePaso(string idPaso)
        {
            executeQuery("DELETE from Paso where id_paso = " + idPaso);
        }

        public DataTable getRoles()
        {
            return selectQuery("select criterio, id_criterio from Criterio where id_criterio between 21 and 33");
        }

        #endregion

        #region Links

        public DataTable getLinksByIdTecnica(string id)
        {
            return selectQuery("select * from Link where id_tecnica = " + id);
        }

        public void editLink(string idLink, string idTecnica, string link)
        {
            executeQuery("UPDATE Link SET link = '" + link + "' WHERE id_link = " + idLink);
        }

        public void createLink(string link, string idTecnica)
        {
            executeQuery("INSERT INTO Link (id_tecnica, link) VALUES ('" + idTecnica + "','" + link + "')");
        }

        public void deleteLink(string idLink)
        {
            executeQuery("DELETE from Link where id_link = " + idLink);
        }

        #endregion

        #region Pagina Formulario

        public DataTable getDatosFormulario()
        {
            return selectQuery("select * from criterio");
        }

        #endregion

        #region Caracteristicas

        public DataTable getCaracteristicasByTecnicaId(string idTecnica)
        {
            return selectQuery("select tcc.id_relacion, ca.id_caracteristica, ca.caracteristica, cr.grupo, cr.id_criterio, cr.criterio from Tecnica_Caracteristica_Criterio tcc inner join Caracteristica ca on tcc.id_caracteristica = ca.id_caracteristica inner join Criterio cr on tcc.id_criterio = cr.id_criterio where tcc.id_tecnica = " + idTecnica);
        }

        public void editCaracteristicaTecnica(string idRelacion, string idCaracteristica, string idCriterio)
        {
            executeQuery("UPDATE Tecnica_Caracteristica_Criterio SET id_caracteristica = '" + idCaracteristica + "', id_criterio = '" + idCriterio + "' where id_relacion = " + idRelacion);
        }

        public void deleteCaracteristicasTecnica(string idRelacion)
        {
            executeQuery("DELETE from Tecnica_Caracteristica_Criterio where id_relacion = " + idRelacion);
        }

        public void createCaracteristicasTecnica(string idTecnica, string idCaracteristica, string idCriterio)
        {
            executeQuery("INSERT INTO Tecnica_Caracteristica_Criterio (id_tecnica, id_caracteristica, id_criterio) VALUES ('" + idTecnica + "','" + idCaracteristica + "', '" + idCriterio + "')");
        }

        public DataTable getCaracteristicas()
        {
            return selectQuery("SELECT id_caracteristica, caracteristica FROM Caracteristica");
        }

        public DataTable getCriterio(string idCaracteristica)
        {
            return selectQuery("SELECT id_criterio, criterio FROM Criterio where grupo = (select grupo from Caracteristica where id_caracteristica = " + idCaracteristica + ")");
        }

        public DataTable getCriterio()
        {
            return selectQuery("SELECT id_criterio, criterio FROM Criterio");
        }
        
        #endregion
    }
}
