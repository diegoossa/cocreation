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
            //SqlConnection con = new SqlConnection(strCnx);
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

        public void editTecnica(string id)
        {

        }

        public void deleteTecnica(string id)
        {

        }

        public void createTecnica()
        {

        }

        #endregion

        #region Pasos

        public DataTable getPasosByIdTecnica(string id)
        {
            return selectQuery("select p.id_paso, p.id_tecnica, p.paso, c.criterio, c.id_criterio  from Paso p inner join Criterio c on p.id_criterio_rol = c.id_criterio where p.id_tecnica = " + id);
        }

        public DataTable getLinksByIdTecnica(string id)
        {
            return selectQuery("select * from Link where id_tecnica = " + id);
        }

        public void editCaracteristicas()
        {

        }

        public void deleteCaracteristicas(string id)
        {

        }

        public void createCaracteristicas()
        {

        }

        #endregion

        #region Pagina Formulario

        public DataTable getDatosFormulario()
        {
            return selectQuery("select * from criterio");
        }

        #endregion

        #region ---

        #endregion
    }
}
