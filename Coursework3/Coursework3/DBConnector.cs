using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Coursework3
{
    public class DBConnector
    {
        #region Properties
        //Properties
        //connection object
        private System.Data.SqlClient.SqlConnection Conn;

        //dataset object
        private DataSet Ds1;
        //dataadapter object
        private System.Data.SqlClient.SqlDataAdapter DaStudents;
        #endregion
        #region constructors


        //constructors
        public DBConnector()
        {
            //call initialisation
            init();
        }
        #endregion
        #region methods

        //Methods
        //initialisation method
        private void init()
        {
            Conn = new System.Data.SqlClient.SqlConnection();

            //set the connection string to the location of our database file
            Conn.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Students.mdf;Integrated Security=True;User Instance=True";

            //open the conenction
            Conn.Open();

            //create a query to get all the records from the table
            string studentsquery = "SELECT * from Studentstbl";
            //create the data adapter for the database
            DaStudents = new System.Data.SqlClient.SqlDataAdapter(studentsquery, Conn);
            //create the memory space for the dataset
            Ds1 = new DataSet();
            //use it to fill the dataset as the first parameter the second is a name for the table we use later on
            DaStudents.Fill(Ds1, "Students");
            
            
            


            //close the connection
            Conn.Close();
            System.Windows.Forms.MessageBox.Show("Database connection Open", "Success");
        }

        public DataSet DBDataSet
        {
            get
            {
                return Ds1;
            }
        }

        //update method

        public void UpdateDB(DataSet ds, string table)
        {
            System.Data.SqlClient.SqlCommandBuilder cb;
            //if the table is students perform the update on the students table in the database
            if (table == "Students")
            {
                cb = new System.Data.SqlClient.SqlCommandBuilder(DaStudents);
                DaStudents.Update(ds, table);
            }
        }

        #endregion
        //{
        //    //create a command builder to reconnect to the database
        //    System.Data.SqlClient.SqlCommandBuilder cb;
        //    //set the comamnd builder to be our existing dataadapter
        //    cb = new System.Data.SqlClient.SqlCommandBuilder(Da);
        //    Da.Update(ds, table);
        //}





    }
}
   
