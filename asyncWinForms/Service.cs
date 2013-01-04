using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asyncWinForms
{
    public class Service
    {
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


        public Task<bool> RunDialog()
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();

            var newMessageBox = new NewMessageBox();

            newMessageBox.OnResult += b => taskCompletionSource.SetResult(b);

            newMessageBox.Show();

            return taskCompletionSource.Task;
        }
    }
}