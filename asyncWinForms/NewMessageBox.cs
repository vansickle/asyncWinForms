using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asyncWinForms
{
    public partial class NewMessageBox : Form
    {
        public NewMessageBox()
        {
            InitializeComponent();
        }

        public event Action<bool> OnResult;

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            OnResult(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            OnResult(false);
        }
    }
}
