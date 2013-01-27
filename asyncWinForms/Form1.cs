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

        public string Button7Text
        {
            set { button7.Text = value; }
        }

        public string Button8Text
        {
            set { button8.Text = value; }
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

        private async void button5_Click(object sender, EventArgs e)
        {
            var service = new Service();

            var math = await service.RunMathImplicitlyCastedToTask();

            button5.Text = Convert.ToString(math);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var service = new Service();

            Action<Task<double>> callBack = t => button6.Text = Convert.ToString(t.Result);
            
            service.RunMathAsyncWithoutAsyncKeyword(callBack);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var service = new Service();

            service.RunMathInternallyAsync(this);
        }

        public event Action RunMath;

        private void button8_Click(object sender, EventArgs e)
        {
            var service = new Service();
            service.Form1 = this;

            var onRunMath = RunMath;

            if(onRunMath!=null)
                onRunMath.Invoke();
        }
    }
}
