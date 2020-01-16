using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Technician_Maintenance
{
    public partial class technicianMaintenanceForm : Form
    {
        public technicianMaintenanceForm()
        {
            InitializeComponent();
        }

        private void techniciansBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {

                this.Validate();
                this.techniciansBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.techSupportDataSet);
            }
            catch (DBConcurrencyException)
            {
                MessageBox.Show("A concurrency error occurred. "
                    + "some rows were not updated.", "Concurrency Exception");
                this.techniciansTableAdapter.Fill(this.techSupportDataSet.Technicians);

            }
            catch (DataException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                this.techniciansBindingSource.CancelEdit();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error # " + ex.Number +
                    ": " + ex.Message, ex.GetType().ToString());
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'techSupportDataSet.Technicians' table. You can move, or remove it, as needed.
            try
            {
                this.techniciansTableAdapter.Fill(this.techSupportDataSet.Technicians);

            }
            catch(SqlException ex)
            {
                MessageBox.Show("Database error # " + ex.Number +
                    ": " + ex.Message, ex.GetType().ToString());
            }

        }

        private void techIDTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
