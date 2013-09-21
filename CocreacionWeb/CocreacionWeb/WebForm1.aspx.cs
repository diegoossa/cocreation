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
    public partial class WebForm1 : System.Web.UI.Page
    {

        Data data = new Data(ConfigurationManager.AppSettings["con"]);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = rateTecnica("34, 35, 36, 46", "1", "13", "12", "10", "21, 22, 23", "4320", "18", "49");

        }

        public string rateTecnica(string problema, string fase, string noParticipantes, string conocimiento, string ubicacion, string participante, string duracion, string costo, string escalabilidad)
        {
            string[] problemas = (problema.Replace(" ", "")).Split(',');
            string[] participantes = (participante.Replace(" ", "")).Split(',');

            DataTable dtRating = data.selectQuery("select id_tecnica, nombre_tecnica from  Tecnica");
            dtRating.Columns.Add("rating", typeof(Int16));

            foreach (DataRow dr in dtRating.Rows)
            {
                dr["rating"] = "0";
            }

            DataTable dtReferencia = data.selectQuery("select * from Tecnica_Caracteristica_Criterio");

            string filtro;
            DataRow[] results;

            //Problemas ID = 1

            for (int i = 0; i < problemas.Length; i++)
            {
                filtro = "id_criterio = " + problemas[i];
                results = dtReferencia.Select(filtro);

                foreach (DataRow result in results)
                {
                    string idTecnica = result[0].ToString();
                    foreach (DataRow dr in dtRating.Rows)
                    {
                        if (dr[0].ToString() == idTecnica)
                        {
                            dr[2] = (int.Parse(dr[2].ToString()) + 1).ToString();
                        }
                    }
                }
            }

            //Fase ID = 2

            filtro = "id_criterio = " + fase;
            results = dtReferencia.Select(filtro);

            foreach (DataRow result in results)
            {
                string idTecnica = result[0].ToString();
                foreach (DataRow dr in dtRating.Rows)
                {
                    if (dr[0].ToString() == idTecnica)
                    {
                        dr[2] = (int.Parse(dr[2].ToString()) + 1).ToString();
                    }
                }
            }

            //No Participantes ID =3

            string[] numeroParticipantes = fuzzyNoParticipantes(int.Parse(noParticipantes));

            for (int i = 0; i < numeroParticipantes.Length; i++)
            {
                filtro = "id_criterio = " + numeroParticipantes[i];
                results = dtReferencia.Select(filtro);

                foreach (DataRow result in results)
                {
                    string idTecnica = result[0].ToString();
                    foreach (DataRow dr in dtRating.Rows)
                    {
                        if (dr[0].ToString() == idTecnica)
                        {
                            dr[2] = (int.Parse(dr[2].ToString()) + 1).ToString();
                        }
                    }
                }
            }

            //Nivel de Conocimiento ID = 4

            filtro = "id_criterio = " + conocimiento;
            results = dtReferencia.Select(filtro);

            foreach (DataRow result in results)
            {
                string idTecnica = result[0].ToString();
                foreach (DataRow dr in dtRating.Rows)
                {
                    if (dr[0].ToString() == idTecnica)
                    {
                        dr[2] = (int.Parse(dr[2].ToString()) + 1).ToString();
                    }
                }
            }

            //Ubicacion ID = 5

            filtro = "id_criterio = " + ubicacion;
            results = dtReferencia.Select(filtro);

            foreach (DataRow result in results)
            {
                string idTecnica = result[0].ToString();
                foreach (DataRow dr in dtRating.Rows)
                {
                    if (dr[0].ToString() == idTecnica)
                    {
                        dr[2] = (int.Parse(dr[2].ToString()) + 1).ToString();
                    }
                }
            }

            //Participantes ID = 6

            for (int i = 0; i < participantes.Length; i++)
            {
                filtro = "id_criterio = " + participantes[i];
                results = dtReferencia.Select(filtro);

                foreach (DataRow result in results)
                {
                    string idTecnica = result[0].ToString();
                    foreach (DataRow dr in dtRating.Rows)
                    {
                        if (dr[0].ToString() == idTecnica)
                        {
                            dr[2] = (int.Parse(dr[2].ToString()) + 1).ToString();
                        }
                    }
                }
            }

            //Duracion ID = 7

            string[] criterioDuracion = fuzzyDuracion(int.Parse(duracion));

            for (int i = 0; i < criterioDuracion.Length; i++)
            {
                filtro = "id_criterio = " + criterioDuracion[i];
                results = dtReferencia.Select(filtro);

                foreach (DataRow result in results)
                {
                    string idTecnica = result[0].ToString();
                    foreach (DataRow dr in dtRating.Rows)
                    {
                        if (dr[0].ToString() == idTecnica)
                        {
                            dr[2] = (int.Parse(dr[2].ToString()) + 1).ToString();
                        }
                    }
                }
            }

            //Costo ID = 8

            filtro = "id_criterio = " + costo;
            results = dtReferencia.Select(filtro);

            foreach (DataRow result in results)
            {
                string idTecnica = result[0].ToString();
                foreach (DataRow dr in dtRating.Rows)
                {
                    if (dr[0].ToString() == idTecnica)
                    {
                        dr[2] = (int.Parse(dr[2].ToString()) + 1).ToString();
                    }
                }
            }

            //Escalabilidad ID = 9

            filtro = "id_criterio = " + escalabilidad;
            results = dtReferencia.Select(filtro);

            foreach (DataRow result in results)
            {
                string idTecnica = result[0].ToString();
                foreach (DataRow dr in dtRating.Rows)
                {
                    if (dr[0].ToString() == idTecnica)
                    {
                        dr[2] = (int.Parse(dr[2].ToString()) + 1).ToString();
                    }
                }
            }

            DataView dv = dtRating.DefaultView;
            dv.Sort = "rating desc";
            dtRating = dv.ToTable();

            DataTable tecnicasElegidas = new DataTable();
            tecnicasElegidas = data.selectQuery("select * from  Tecnica where id_tecnica = " + dtRating.Rows[0][0] + " or id_tecnica = " + dtRating.Rows[1][0] + " or  id_tecnica = " + dtRating.Rows[2][0]);

            return GetJson(tecnicasElegidas);

            //return (problema + "\n" + fase + "\n" + noParticipantes + "\n" + conocimiento + "\n" + ubicacion + "\n" + participantes + "\n" + duracion + "\n" + costo + "\n" + escalabilidad);
        }

        protected string[] fuzzyNoParticipantes(int desFuzzy)
        {
            DataTable dt = data.selectQuery("select * from Criterio where id_criterio BETWEEN 4 AND 6");
            List<string> criterio = new List<string>();
            if (desFuzzy >= int.Parse(dt.Rows[0]["valor_inicial"].ToString()) && desFuzzy <= int.Parse(dt.Rows[0]["valor_final"].ToString()))
            {
                criterio.Add("4");
            }
            else if (desFuzzy >= int.Parse(dt.Rows[1]["valor_inicial"].ToString()) && desFuzzy <= int.Parse(dt.Rows[1]["valor_final"].ToString()))
            {
                criterio.Add("4");
                criterio.Add("5");
            }
            else
            {
                criterio.Add("4");
                criterio.Add("5");
                criterio.Add("6");
            }
            return criterio.ToArray();
        }

        protected string[] fuzzyDuracion(int desFuzzy)
        {
            DataTable dt = data.selectQuery("select * from Criterio where id_criterio BETWEEN 13 AND 17");
            List<string> criterio = new List<string>();

            if (desFuzzy >= int.Parse(dt.Rows[0]["valor_inicial"].ToString()) && desFuzzy <= int.Parse(dt.Rows[0]["valor_final"].ToString()))
            {
                criterio.Add("13");
            }
            else if (desFuzzy >= int.Parse(dt.Rows[1]["valor_inicial"].ToString()) && desFuzzy <= int.Parse(dt.Rows[1]["valor_final"].ToString()))
            {
                criterio.Add("13");
                criterio.Add("14");
            }
            else if (desFuzzy >= int.Parse(dt.Rows[2]["valor_inicial"].ToString()) && desFuzzy <= int.Parse(dt.Rows[2]["valor_final"].ToString()))
            {
                criterio.Add("13");
                criterio.Add("14");
                criterio.Add("15");
            }
            else if (desFuzzy >= int.Parse(dt.Rows[3]["valor_inicial"].ToString()) && desFuzzy <= int.Parse(dt.Rows[3]["valor_final"].ToString()))
            {
                criterio.Add("13");
                criterio.Add("14");
                criterio.Add("15");
                criterio.Add("16");
            }
            else
            {
                criterio.Add("13");
                criterio.Add("14");
                criterio.Add("15");
                criterio.Add("16");
                criterio.Add("17");
            }

            return criterio.ToArray();
        }

        public string GetJson(DataTable dt)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;

            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName.Trim(), dr[col]);
                }
                rows.Add(row);
            }
            return "{ \"criterios\":" + serializer.Serialize(rows) + "}";
        }
    }
}