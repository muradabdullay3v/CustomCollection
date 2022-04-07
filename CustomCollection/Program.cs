using System;

namespace CustomCollection
{
    class Program
    {
        public static void Main(string[] args)
        {
            CustomList<string> List = new CustomList<string>();
            List.Add("Baba");
            List.Add("Adam");
            List.Add("Qaqa");
            List.Sort();
            List.Remove("Baba");
            foreach (var item in List)
            {
                Console.WriteLine(item);
            }
        }
    }
}