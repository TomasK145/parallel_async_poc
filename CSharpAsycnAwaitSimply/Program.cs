using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpAsycnAwaitSimply
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //https://dev.to/htissink/c-async-await-simply-5dh1?utm_source=digest_mailer&utm_medium=email&utm_campaign=digest_email
            var sw = new Stopwatch();
            sw.Start();

            #region async processing with order
            //await BuildAnEvilLair();
            //Task.WaitAll(HireSomeHenchman(), MakeMiniClone());
            //await SuperEvilPlan();
            //Task.WaitAll(MakeOneMilionDollars(), WorldDomination());
            #endregion

            #region async processing
            //await BuildAnEvilLair();
            //await HireSomeHenchman();
            //await MakeMiniClone();
            //await SuperEvilPlan();
            //await MakeOneMilionDollars();
            //await WorldDomination();
            #endregion

            #region sync processing
            //BuildAnEvilLair();
            //HireSomeHenchman();
            //MakeMiniClone();
            //SuperEvilPlan();
            //MakeOneMilionDollars();
            //WorldDomination();
            #endregion

            sw.Stop();
            Console.WriteLine("Done - duration: " + sw.ElapsedMilliseconds + " ms");
            Console.ReadLine();
        }

        #region async processing
        private static async Task BuildAnEvilLair()
        {
            await Task.Delay(5000);
            Console.WriteLine("Evil lair built!");
        }

        public static async Task HireSomeHenchman()
        {
            await Task.Delay(2000);
            Console.WriteLine("Henchman hired!");
        }

        public static async Task MakeMiniClone()
        {
            await Task.Delay(3000);
            Console.WriteLine("Mini Clone Created!");
        }

        public static async Task SuperEvilPlan()
        {
            await Task.Delay(4000);
            Console.WriteLine("Super Evil Plan completed!");
        }

        public static async Task<int> MakeOneMilionDollars()
        {
            await Task.Delay(2000);
            Console.WriteLine("Million dollars made");
            return 1000000;
        }

        public static async Task WorldDomination()
        {
            await Task.Delay(6000);
            Console.WriteLine("World domination achieved");
        }
        #endregion

        #region sync processing
        //private static void BuildAnEvilLair()
        //{
        //    //await Task.Delay(5000);
        //    Thread.Sleep(5000);
        //    Console.WriteLine("Evil lair built!");
        //}

        //public static void HireSomeHenchman()
        //{
        //    //await Task.Delay(2000);
        //    Thread.Sleep(2000);
        //    Console.WriteLine("Henchman hired!");
        //}

        //public static void MakeMiniClone()
        //{
        //    //await Task.Delay(3000);
        //    Thread.Sleep(3000);
        //    Console.WriteLine("Mini Clone Created!");
        //}

        //public static void SuperEvilPlan()
        //{
        //    //await Task.Delay(4000);
        //    Thread.Sleep(4000);
        //    Console.WriteLine("Super Evil Plan completed!");
        //}

        //public static int MakeOneMilionDollars()
        //{
        //    //await Task.Delay(2000);
        //    Thread.Sleep(2000);
        //    Console.WriteLine("Million dollars made");
        //    return 1000000;
        //}

        //public static void WorldDomination()
        //{
        //    //await Task.Delay(6000);
        //    Thread.Sleep(6000);
        //    Console.WriteLine("World domination achieved");
        //}
        #endregion
    }
}
