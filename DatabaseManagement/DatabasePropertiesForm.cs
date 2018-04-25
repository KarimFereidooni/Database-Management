using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DatabaseManagement
{
    public partial class DatabasePropertiesForm : Form
    {
        public DatabasePropertiesForm(string Database)
        {
            InitializeComponent();
            try
            {
                DataAccess.Instance.Connection.Open();
                DataAccess.Instance.Connection.ChangeDatabase(Database);
                string script = "SELECT * FROM [sys].[database_files]";
                DataTable dt = DataAccess.Instance.GetData(script);
                if (dt.Rows.Count >= 2)
                {
                    DatabaseProperties p = new DatabaseProperties(dt.Rows[0]["name"].ToString(), dt.Rows[0]["physical_name"].ToString(), dt.Rows[0]["type_desc"].ToString(), dt.Rows[0]["size"].ToString(), dt.Rows[1]["name"].ToString(), dt.Rows[1]["physical_name"].ToString(), dt.Rows[1]["type_desc"].ToString(), dt.Rows[1]["size"].ToString());
                    propertyGrid1.SelectedObject = p;
                }
                else
                {
                    MessageBox.Show("Error: " + dt.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DataAccess.Instance.Connection.Close();
            }
        }

        private void DatabasePropertiesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }

    }
}
