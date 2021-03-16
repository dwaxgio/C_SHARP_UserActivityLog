using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace UserActivityLog
{
    class Main
    {
        private SqlConnection connection;
        public static SqlConnection GetConnection()
        {
            // <add name="constr" connectionString="Server=(LocalDB)\MSSQLLocalDB;Database=WCF_CRUD_CUSTOMER;User Id=sa;Password=Unemamad249;"         providerName="System.Data.SqlClient"/>
            //SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB; Initial Catalog=ActivityLog; Integrated Security = True");
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=ActivityLog; Integrated Security = True");
            return connection;
        }

        public string Converter_string(string SQL)
        {
            try
            {
                SqlConnection con = Main.GetConnection();
                DataTable consultanttable = new DataTable();
                string StringConsultant;
                SqlDataAdapter Consultantdataadapter = new SqlDataAdapter(SQL, con);
                Consultantdataadapter.Fill(consultanttable);
                foreach (DataRow myrow in consultanttable.Rows)
                {
                    StringConsultant = Convert.ToString(myrow[0]);
                    return StringConsultant;
                }
            }
            catch
            {
                throw;
            }
            return "0";
        }

        // Método para soportar la ejecución del sql query
        public void Excecute(string SQL)
        {
            try
            {
                SqlConnection con = Main.GetConnection();
                DataTable consultanttable = new DataTable();
                SqlDataAdapter Consultantdataadapter = new SqlDataAdapter(SQL, con);
                Consultantdataadapter.Fill(consultanttable);
            }
            catch 
            {

                throw;
            }
        }
    }
}
