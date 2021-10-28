using ioet.Services;
using Syroot.Windows.IO;
using System;

namespace ioet.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string downloadsPath = $"{new KnownFolder(KnownFolderType.Downloads).Path}\\data.txt";
            Console.WriteLine("Path to read the file: " + downloadsPath);

            string[] paymentData = System.IO.File.ReadAllLines(downloadsPath);

            // Display the file contents by using a foreach loop.
            Console.WriteLine("Contents of data.txt = ");

            foreach (string data in paymentData)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + data);
            }

            var mapper = new MapperService();
            var paymentService = new PaymentService();
            var paymentResultsService = new PaymentsResultsService(paymentService, mapper);

            var results = paymentResultsService.GetPayments(paymentData);

            Console.WriteLine("\n *** RESULTS ***");

            foreach (string data in results)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + data);
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
