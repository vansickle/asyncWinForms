using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asyncWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var service = new Service();
            var foo = await service.RunMath();

            button1.Text = Convert.ToString(foo);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var service = new Service();
            var foo = await service.RunMathWrappedInTask();

            button2.Text = Convert.ToString(foo);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();

            var stringAsync = await httpClient.GetStringAsync("http://sports.ru");

            button3.Text = "done" + stringAsync.Length;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var service = new Service();

            var runDialog = await service.RunDialog();

            button4.Text = runDialog ? "OK" : "Cancel";
        }
    }
}
