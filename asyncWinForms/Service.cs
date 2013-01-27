using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asyncWinForms
{
    public class Service
    {
        private Form1 form1;

        public async Task<double> RunMath()
        {
            double result = 0;

            for (int i = 0; i < 500000000; i++)
            {
                result += Math.Sqrt(i);
            }

            return result;
        }

        public async Task<double> RunAsyncMathWrappedInTask()
        {
            return await Task.Run(() =>
                {
                    double result = 0;

                    Thread.Sleep(5000);

                    for (int i = 0; i < 5000000; i++)
                    {
                        result += Math.Sqrt(i);
                    }

                    Thread.Sleep(5000);

                    return result;
                });
        }

        public Task<double> RunMathWrappedInTask()
        {
            return Task.Run(() =>
            {
                return RunMathSync();
            });
        }

        public void RunMathAsyncWithoutAsyncKeyword(Action<Task<double>> onFinish)
        {
            var task = new Task<double>(RunMathSync);
            task.ContinueWith(onFinish, TaskScheduler.FromCurrentSynchronizationContext());
            task.Start();
        }

        public async Task<double> RunMathImplicitlyCastedToTask()
        {
            return RunMathSync();
        }

        private static double RunMathSync()
        {
            double result = 0;

            Thread.Sleep(5000);

            for (int i = 0; i < 5000000; i++)
            {
                result += Math.Sqrt(i);
            }

            Thread.Sleep(5000);

            return result;
        }


        public Task<bool> RunDialog()
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();

            var newMessageBox = new NewMessageBox();

            newMessageBox.OnResult += b => taskCompletionSource.SetResult(b);

            newMessageBox.Show();

            return taskCompletionSource.Task;
        }

        public async void RunMathInternallyAsync(Form1 form1)
        {
            var result = await RunMathWrappedInTask();

            form1.Button7Text = Convert.ToString(result);
        }

        public Form1 Form1
        {
            set
            {
                form1 = value;
                form1.RunMath += Form1OnRunMath;
            }
        }

        private async void Form1OnRunMath()
        {
            var result = await RunMathWrappedInTask();

            this.form1.Button8Text = Convert.ToString(result);
        }
    }
}