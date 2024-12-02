using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AoC2024
{
    internal class Program
    {
        record struct Point(int X, int Y);
        static Regex regexNum = new Regex(@"\d+");
        static void Main(string[] args)
        {
            string selection = string.Empty;
            while (selection.ToLower() != "e")
            {
                printMenu();

                switch (selection)
                {
                    case "1a":
                        day1a();
                        break;
                    case "1b":
                        day1b();
                        break;
                    case "2a":
                        day2a();
                        break;
                    case "2b":
                        day2b();
                        break;
                    case "3a":
                        day3a();
                        break;
                    case "3b":
                        day3b();
                        break;
                    case "4a":
                        day4a();
                        break;
                    case "4b":
                        day4b();
                        break;
                    case "5a":
                        day5a();
                        break;
                    case "5b":
                        day5b();
                        break;
                    case "6a":
                        day6a();
                        break;
                    case "6b":
                        day6b();
                        break;
                    case "7a":
                        day7a();
                        break;
                    case "7b":
                        day7b();
                        break;
                    case "8a":
                        day8a();
                        break;
                    case "8b":
                        day8b();
                        break;
                    case "9a":
                        day9a();
                        break;
                    case "9b":
                        day9b();
                        break;
                    case "10a":
                        day10a();
                        break;
                    case "10b":
                        day10b();
                        break;
                    case "11a":
                        day11a();
                        break;
                    case "11b":
                        day11b();
                        break;
                    case "12a":
                        day12a();
                        break;
                    case "12b":
                        day12b();
                        break;
                    case "13a":
                        day13a();
                        break;
                    case "13b":
                        day13b();
                        break;
                    case "14a":
                        day14a();
                        break;
                    case "14b":
                        day14b();
                        break;
                    case "15a":
                        day15a();
                        break;
                    case "15b":
                        day15b();
                        break;
                    case "16a":
                        day16a();
                        break;
                    case "16b":
                        day16b();
                        break;
                    case "17a":
                        day17a();
                        break;
                    case "17b":
                        day17b();
                        break;
                    case "18a":
                        day18a();
                        break;
                    case "18b":
                        day18b();
                        break;
                    case "19a":
                        day19a();
                        break;
                    case "19b":
                        day19b();
                        break;
                    case "20a":
                        day20a();
                        break;
                    case "20b":
                        day20b();
                        break;
                    case "21a":
                        day21a();
                        break;
                    case "21b":
                        day21b();
                        break;
                    case "22a":
                        day22a();
                        break;
                    case "22b":
                        day22b();
                        break;
                    case "23a":
                        day23a();
                        break;
                    case "23b":
                        day23b();
                        break;
                    case "24a":
                        day24a();
                        break;
                    case "24b":
                        day24b();
                        break;
                    case "25a":
                        day25a();
                        break;
                    case "25b":
                        day25b();
                        break;
                }
                Console.WriteLine("'e' to exit");
                selection = Console.ReadLine() ?? string.Empty;
            }
        }
        #region utility
        static void printMenu()
        {
            Console.Clear();
            Console.WriteLine("Enter a day number and A or B");
        }

        static void print(string message)
        {
            Console.WriteLine(message);
        }

        static void printInt(int num)
        {
            Console.WriteLine(num);
        }

        static void printDecimal(decimal num)
        {
            Console.WriteLine(num);
        }

        static void printFloat(float num)
        {
            Console.WriteLine(num);
        }

        static string getData(string day)
        {
            return File.ReadAllText("..\\..\\..\\data\\day" + day + ".txt");
        }

        static List<string> dataToList(string data, string splitOn)
        {
            return data.Split(splitOn).ToList();
        }

        static List<int> dataToIntList(string data, string splitOn)
        {
            return data.Split(splitOn).Select(int.Parse).ToList();
        }

        static List<double> dataToDoubleList(string data, string splitOn)
        {
            return data.Split(splitOn).Select(double.Parse).ToList();
        }
        #endregion

        #region day 1
        static void day1a() //1722302
        {
            List<string> data = dataToList(getData("1"), Environment.NewLine);
            List<int> colA = new();
            List<int> colB = new();
            int total = 0;

            foreach (string s in data)
            {
                colA.Add(int.Parse(s.Split("   ")[0]));
                colB.Add(int.Parse(s.Split("   ")[1]));
            }

            colA.Sort();
            colB.Sort();

            for (int i = 0; i < colA.Count; i++)
            {
                total += Math.Abs(colA[i] - colB[i]);
            }

            printInt(total);
        }

        static void day1b() //20373490
        {
            List<string> data = dataToList(getData("1"), Environment.NewLine);
            List<int> colA = new();
            List<int> colB = new();
            int total = 0;

            foreach (string s in data)
            {
                colA.Add(int.Parse(s.Split("   ")[0]));
                colB.Add(int.Parse(s.Split("   ")[1]));
            }

            for (int i = 0; i < colA.Count; i++)
            {
                int count = colB.FindAll(x => x == colA[i]).Count();
                total += colA[i] * count;
            }

            printInt(total);
        }
        #endregion

        #region day 2
        static void day2a() //287
        {
            List<string> data = dataToList(getData("2"), Environment.NewLine);
            int count = 0;

            foreach (string s in data)
            {
                List<int> reports = s.Trim().Split(" ").Select(int.Parse).ToList();

                if (day2safe(reports))
                    count++;
            }

            printInt(count);
        }

        static private bool day2safe(List<int> reports)
        {
            int p = -1;
            bool? increasing = null;
            bool valid = false;
            foreach (int i in reports)
            {
                if (p != -1)
                {
                    if (increasing == null)
                        increasing = i > p;

                    if ((bool)increasing && i > p && i <= p + 3)
                    {
                        valid = true;
                    }
                    else if (!(bool)increasing && i < p && i >= p - 3)
                    {
                        valid = true;
                    }
                    else
                        valid = false;

                    if (valid == false)
                        break;
                }

                p = i;
            }
            return valid;
        }

        static void day2b() //354
        {
            List<string> data = dataToList(getData("2"), Environment.NewLine);
            int count = 0;

            foreach (string s in data)
            {
                List<int> reports = s.Trim().Split(" ").Select(int.Parse).ToList();

                bool safe = day2safe(reports);
                if (safe)
                {
                    count++;
                }
                else
                {
                    for (int i = 0; i < reports.Count; i++)
                    {
                        List<int> r = new List<int>();
                        r.AddRange(s.Trim().Split(" ").Select(int.Parse).ToList());
                        r.RemoveAt(i);

                        safe = day2safe(r);

                        if (safe)
                        {
                            count++;
                            break;
                        }
                    }
                }
            }

            printInt(count);
        }
        #endregion

        #region day 3
        static void day3a() //
        {

        }

        static void day3b() //
        {

        }
        #endregion

        #region day 4
        static void day4a() //
        {

        }

        static void day4b() //
        {

        }
        #endregion

        #region day 5
        static void day5a() //
        {

        }

        static void day5b() //
        {

        }
        #endregion

        #region day 6
        static void day6a() //
        {

        }

        static void day6b() //
        {

        }
        #endregion

        #region day 7
        static void day7a() //
        {

        }

        static void day7b() //
        {

        }
        #endregion

        #region day 8
        static void day8a() //
        {

        }

        static void day8b() //
        {

        }
        #endregion

        #region day[9]
        static void day9a() //
        {

        }

        static void day9b() //
        {

        }
        #endregion

        #region day 10
        static void day10a() //
        {

        }

        static void day10b() //
        {

        }
        #endregion

        #region day 11
        static void day11a() //
        {

        }

        static void day11b() //
        {

        }
        #endregion

        #region day 12
        static void day12a() // 
        {

        }

        static void day12b() // 
        {

        }
        #endregion

        #region day 13
        static void day13a() //
        {

        }

        static void day13b() //
        {

        }
        #endregion

        #region day 14
        static void day14a() //
        {

        }

        static void day14b() //
        {

        }
        #endregion

        #region day15
        static void day15a() //
        {

        }

        static void day15b() //
        {

        }
        #endregion

        #region day16
        static void day16a() // 
        {

        }

        static void day16b() // 
        {

        }
        #endregion

        #region day17
        static void day17a() // 
        {

        }

        static void day17b() // 
        {

        }
        #endregion

        #region day18
        static void day18a() // 
        {

        }

        static void day18b() // 
        {

        }
        #endregion

        #region day19
        static void day19a() // 
        {

        }

        static void day19b() // 
        {

        }
        #endregion

        #region day20
        static void day20a() // 
        {

        }

        static void day20b() // 
        {

        }
        #endregion

        #region day21
        static void day21a() // 
        {

        }

        static void day21b() // 
        {

        }
        #endregion

        #region day22
        static void day22a() // 
        {

        }

        static void day22b() // 
        {

        }
        #endregion

        #region day23
        static void day23a() // 
        {

        }

        static void day23b() // 
        {

        }
        #endregion

        #region day24
        static void day24a() // 
        {

        }

        static void day24b() // 
        {

        }
        #endregion

        #region day25
        static void day25a() // 
        {

        }

        static void day25b() // 
        {

        }
        #endregion
    }
}
