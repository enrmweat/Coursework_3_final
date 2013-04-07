using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Coursework3
{
    public partial class Form1 : Form
    {
        private DBConnector Students;
        public Form1()
        {
            InitializeComponent();
            //intansiate the object in memory
            Students = new DBConnector();

        }

        private void btnstudentdetails_Click(object sender, EventArgs e)
        {
            new studentdetails(Students.DBDataSet).ShowDialog();
        }

        private void studentstblBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.studentstblBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.studentsDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentsDataSet.Studentstbl' table. You can move, or remove it, as needed.
            this.studentstblTableAdapter.Fill(this.studentsDataSet.Studentstbl);
            // TODO: This line of code loads data into the 'studentsDataSet.Studentstbl' table. You can move, or remove it, as needed.
            this.studentstblTableAdapter.Fill(this.studentsDataSet.Studentstbl);

        }

        private void studentstblBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.studentstblBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.studentsDataSet);

        }

        private void iDTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            new studentdetails(Students.DBDataSet).ShowDialog();
            this.Update();
        }
    }
}
