using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;

namespace Business
{
    public class Bus
    {
        static string strCnx;
        Data data;

        public Bus(string s)
        {
            strCnx = s;
            data = new Data(strCnx);
        }

        public DataTable getCaracteristicas()
        {
            return data.getCaracteristicas();
        }

        public DataTable getTecnicas()
        {
            return data.getTecnicas();
        }

        //---

        #region Pagina Formulario

        public DataTable getDatosFormulario()
        {
            return data.getDatosFormulario();
        }

        #endregion

    }
}
