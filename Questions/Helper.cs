namespace Questions
{
    using System;
    using System.Linq;

    public static class Helper
    {
        public static int ReadN()
        {
            Console.WriteLine("Enter n");
            return int.Parse(Console.ReadLine());
        }

        public static int[] ReadElementsInOneLine(char separator = ' ')
        {
            Console.WriteLine("Enter in 1 line");
            string s = Console.ReadLine().Trim();
            return s.Split(separator).Select(s => int.Parse(s)).ToArray();
        }

        public static int[] ReadLineByLine(int n)
        {
            Console.WriteLine("Enter elements 1 by 1");
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            return arr;
        }

        public static string ReadString()
        {
            Console.WriteLine("Enter line");
            return Console.ReadLine();
        }

        public static void WriteLine(int s)
        {
            WriteLine(s.ToString());
        }

        public static void WriteLine(int[] s)
        {
            string ans = string.Empty;
            foreach(int i in s)
            {
                ans += i + " ";
            }

            WriteLine($"[{ans}]");
        }

        public static void WriteLine(bool s)
        {
            WriteLine(s.ToString());
        }

        public static void WriteLine(string s)
        {
            Console.WriteLine($"A: {s}");
        }
    }
}
