using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var csv = new AlpacaTech.CsvFile("data.csv", ",", Encoding.GetEncoding("shift-jis"));

            //  ランダムアクセス([y][x])
            System.Console.WriteLine(csv.lines[5][3] );
            System.Console.WriteLine("------------------------");

            //  全てにアクセス
            foreach (var line in csv.lines)
            {
                foreach (var v in line)
                {
                    System.Console.WriteLine(v);
                }
            }

        }
    }
}
