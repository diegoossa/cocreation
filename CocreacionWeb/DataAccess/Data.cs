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

        public DataTable getTecnicaCaracteristicaCriterio()
        {
            return selectQuery("select * from Tecnica_Caracteristica_Criterio");
        }

        public DataTable getTecnicaById(string id)
        {
            return selectQuery("select * from Tecnica where id_tecnica = " + id);
        }



        public void editTecnica()
        {

        }

        public void deleteTecnica(string id)
        {

        }

        public void createTecnica()
        {

        }

        #endregion

        #region Caracteristicas

        public DataTable getCaracteristicas()
        {
            return selectQuery("select * from Caracteristica");
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
