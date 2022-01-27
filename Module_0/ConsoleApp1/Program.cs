using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // DoeIetsInAndereThread();
            //NogMooier();
            ParallelAsync();
            Console.WriteLine("En verder...");
            Console.ReadLine();
        }

        private static async Task ParallelAsync()
        {
            Task<int>[] taken = new Task<int>[10];
            for(int i = 0; i < 10; i++)
            {
                taken[i] = Task.Run(() => {
                    Task.Delay(100).Wait(); 
                   return i * 100;
                });
            }

            await Task.WhenAll(taken);
            var res = taken.Sum(t => t.Result);
            Console.WriteLine(res);
        }

        private static async void NogMooier()
        {
            try
            {
                await Task.Run(() =>
                {
                    throw new Exception("Ooops");
                //return data;
            });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //string result = await DoeIetsAsync();
            // Console.WriteLine("Vervolg");
            // Console.WriteLine(result);

        }

        static void DeTaak()
        {
            var data = DoeIets();
            Console.WriteLine(data);
        }
        private static void DoeIetsInAndereThread()
        {
           Task.Run(() =>
            {
                var data = DoeIets();
                return data;
            }).ContinueWith(pt => {
                Console.WriteLine(pt.Result);
            });

          //  t1.Start();

          
        }

        static string DoeIets()
        {
            Task.Delay(5000).Wait();
            return "hoi";
        }
        static Task<string>DoeIetsAsync()
        {
            return Task.Run(() => DoeIets()) ;
        }
    }
}
