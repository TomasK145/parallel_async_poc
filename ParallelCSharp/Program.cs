using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                ParallelForeachImagesPoc();
                sw.Stop();
                Console.WriteLine($"ParallelForeachPoc - duration: {sw.ElapsedMilliseconds} ms");

                sw.Restart();
                ParallelForImagesPoc();
                sw.Stop();
                Console.WriteLine($"ParallelForImagesPoc - duration: {sw.ElapsedMilliseconds} ms");

                sw.Restart();
                ForeachImagesPoc();
                sw.Stop();
                Console.WriteLine($"ForeachImagesPoc - duration: {sw.ElapsedMilliseconds} ms");

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ex: {ex.Message}");
            }
        }

        private static void ParallelForeachImagesPoc()
        {
            //https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-write-a-simple-parallel-foreach-loop
            string[] files = Directory.GetFiles(@"C:\Users\tkrchnak\Desktop\MB_foto_4K_test\foto_z_web", "*.jpg");
            string newDir = @"C:\Users\tkrchnak\Desktop\MB_foto_4K_test\foto_z_web_modified_" + Guid.NewGuid();
            Directory.CreateDirectory(newDir);

            Parallel.ForEach(files, (currentFile) => 
            {
                ProcessImage(currentFile, newDir);
            });
            Console.WriteLine("Processing complete");
        }

        private static void ParallelForImagesPoc()
        {
            //https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-write-a-simple-parallel-for-loop
            string[] files = Directory.GetFiles(@"C:\Users\tkrchnak\Desktop\MB_foto_4K_test\foto_z_web", "*.jpg");
            string newDir = @"C:\Users\tkrchnak\Desktop\MB_foto_4K_test\foto_z_web_modified_" + Guid.NewGuid();
            Directory.CreateDirectory(newDir);

            Parallel.For(0, files.Length, (index) =>
            {
                ProcessImage(files[index], newDir);
            });

            Console.WriteLine("Processing complete");
        }

        private static void ForeachImagesPoc()
        {
            string[] files = Directory.GetFiles(@"C:\Users\tkrchnak\Desktop\MB_foto_4K_test\foto_z_web", "*.jpg");
            string newDir = @"C:\Users\tkrchnak\Desktop\MB_foto_4K_test\foto_z_web_modified_" + Guid.NewGuid();
            Directory.CreateDirectory(newDir);

            foreach (var currentFile in files)
            {
                ProcessImage(currentFile, newDir);
            }

            Console.WriteLine("Processing complete");
        }

        private static void ProcessImage(string currentFile, string newDir)
        {
            string filename = Path.GetFileName(currentFile);
            using (var bitmap = new Bitmap(currentFile))
            {

                bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);

                var thumbnailImageName = filename.Replace("1", "1111").Replace("f", "aaaa");
                var thumbnailImage = bitmap.GetThumbnailImage(640, 480, null, IntPtr.Zero);
                thumbnailImage.Save(Path.Combine(newDir, thumbnailImageName));

                bitmap.Save(Path.Combine(newDir, filename));
            }
            //Console.WriteLine($"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
