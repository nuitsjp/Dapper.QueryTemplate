using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dapper.QueryTemplate.ItemTemplate.Wizard
{
    public partial class EntryEntityNameForm : Form
    {
        public EntryEntityNameForm()
        {
            InitializeComponent();
        }

        public string EntityName { get; set; } = string.Empty;

        private void OkButton_Click(object sender, EventArgs e)
        {
            EntityName = EntityNameTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void EntityNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Return)
            {
                EntityName = EntityNameTextBox.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
