﻿using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net;
using System.Numerics;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        static void printLong(long num)
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
            List<int> colA = data.Select(x => int.Parse(x.Split("   ")[0])).ToList();
            List<int> colB = data.Select(x => int.Parse(x.Split("   ")[1])).ToList();
            int total = 0;

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
            List<int> colA = data.Select(x => int.Parse(x.Split("   ")[0])).ToList();
            List<int> colB = data.Select(x => int.Parse(x.Split("   ")[1])).ToList();
            int total = 0;

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

                    if (!valid)
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
                        List<int> r = s.Trim().Split(" ").Select(int.Parse).ToList();
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
        static void day3a() //162813399
        {
            string data = getData("3");
            int total = 0;
            Regex regex = new("mul\\([0-9]{1,3},[0-9]{1,3}\\)");
            Regex regexNums = new("[0-9]{1,3},[0-9]{1,3}");

            MatchCollection matches = regex.Matches(data);
            foreach(Match m in matches) 
            {
                total += int.Parse(regexNums.Match(m.Value).Value.Split(",")[0]) * int.Parse(regexNums.Match(m.Value).Value.Split(",")[1]);
            }

            printInt(total);
        }

        static void day3b() //53783319
        {
            string data = getData("3");
            int total = 0;
            Regex regex = new("mul\\([0-9]{1,3},[0-9]{1,3}\\)");
            Regex regexNums = new("[0-9]{1,3},[0-9]{1,3}");

            List<string> chunks = data.Split("do()").ToList();
            List<string> cleanedChunks = chunks.Select(x => x.Substring(0, x.IndexOf("don't()") > 0 ? x.IndexOf("don't()") : x.Length)).ToList();

            foreach (string chunk in cleanedChunks)
            {
                MatchCollection matches = regex.Matches(chunk);

                foreach (Match m in matches)
                {
                    total += int.Parse(regexNums.Match(m.Value).Value.Split(",")[0]) * int.Parse(regexNums.Match(m.Value).Value.Split(",")[1]);
                }
            }

            printInt(total);
        }
        #endregion

        #region day 4
        static void day4a() //2458
        {
            List<string> data = dataToList(getData("4"), Environment.NewLine);
            int count = 0;
            Regex forwards = new("XMAS");
            Regex backwards = new("SAMX");
            for (int r = 0; r < data.Count; r++) 
            {
                count += forwards.Count(data[r]);
                count += backwards.Count(data[r]);

                for (int c = 0; c < data.Count; c++)
                {
                    
                    if (r <= data.Count - 4)
                    {
                        //Vertical
                        string check = string.Concat(data[r][c], data[r + 1][c], data[r + 2][c], data[r + 3][c]);
                        if (forwards.IsMatch(check) || backwards.IsMatch(check))
                            count++;

                        //Diagonal \
                        if (c <= data[0].Length - 4)
                        {
                            check = string.Concat(data[r][c], data[r + 1][c + 1], data[r + 2][c + 2], data[r + 3][c + 3]);
                            if (forwards.IsMatch(check) || backwards.IsMatch(check))
                                count++;
                        }

                        //Diagonal /
                        if (c >= 3)
                        {
                            check = string.Concat(data[r][c], data[r + 1][c - 1], data[r + 2][c - 2], data[r + 3][c - 3]);
                            if (forwards.IsMatch(check) || backwards.IsMatch(check))
                                count++;
                        }
                    }
                }
            }

            printInt(count);
        }

        static void day4b() //1945
        {
            List<string> data = dataToList(getData("4"), Environment.NewLine);
            int count = 0;

            for (int r = 1; r < data.Count - 1; r++)
            {
                for (int c = 1; c < data.Count - 1; c++)
                {
                    bool good = false;
                    if (data[r][c] == 'A')
                    {
                        string UD = string.Concat(data[r - 1][c - 1], data[r + 1][c + 1]);
                        string DU = string.Concat(data[r + 1][c - 1], data[r - 1][c + 1]);

                        //Diagonal \
                        good = (UD == "SM" || UD == "MS");

                        //Diagonal /
                        good = good && (DU == "SM" || DU == "MS");

                        if (good)
                            count++;
                    }
                }
            }

            printInt(count);
        }
        #endregion

        #region day 5

        static List<string> d5Rules = new();
        static List<string> d5Updates = new();
        static List<string> d5BadUpdates = new();
        static void day5a() //5166
        {
            string data = getData("5");
            d5Rules = dataToList(data.Split(string.Concat(Environment.NewLine, Environment.NewLine))[0], Environment.NewLine);
            d5Updates = dataToList(data.Split(string.Concat(Environment.NewLine, Environment.NewLine))[1], Environment.NewLine);

            List<string> goodUpdates = day5GetGoodUpdates();

            int total = 0;

            foreach (string goodUpdate in goodUpdates)
            {
                List<string> pages = goodUpdate.Split(",").ToList();
                total += int.Parse(pages[pages.Count / 2]);
            }            

            printInt(total);
        }

        static List<string> day5GetGoodUpdates(bool setBad = false)
        {
            List<string> toReturn = new();

            foreach (string row in d5Updates)
            {
                if (day5IsGood(row))
                    toReturn.Add(row);
                else
                    d5BadUpdates.Add(row);
            }

            return toReturn;
        }

        static bool day5IsGood(string row)
        {
            List<string> pages = row.Split(",").ToList();

            for (int i = 0; i < pages.Count; i++)
            {
                string page = pages[i];
                List<string> curRules = d5Rules.FindAll(x => x.EndsWith(page));
   
                foreach (string rule in curRules)
                {
                    if (pages.Contains(rule.Split("|")[0]) && pages.IndexOf(rule.Split("|")[0]) > i)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static string day5FixRow(string row)
        {
            string fixedRow = row;

            List<string> pages = dataToList(row, ",");

            while (!day5IsGood(fixedRow))
            {
                for (int i = 0; i < pages.Count; i++)
                {
                    string page = pages[i];

                    List<string> curRules = d5Rules.FindAll(x => x.EndsWith(page));

                    for (int j = i + 1; j < pages.Count; j++)
                    {
                        page = pages[i];
                        string nextPage = pages[j];

                        foreach (string rule in curRules)
                        {
                            if (rule.StartsWith(nextPage))
                            {
                                pages[i] = nextPage;
                                pages[j] = page;
                                break;
                            }
                        }
                    }
                }

                fixedRow = "";
                foreach (string page in pages)
                {
                    fixedRow += page + ",";
                }

                fixedRow = fixedRow.Remove(fixedRow.Length - 1, 1);
            }
            
            return fixedRow;
        }

        static void day5b() //4679
        {
            string data = getData("5");
            d5Rules = dataToList(data.Split(string.Concat(Environment.NewLine, Environment.NewLine))[0], Environment.NewLine);
            d5Updates = dataToList(data.Split(string.Concat(Environment.NewLine, Environment.NewLine))[1], Environment.NewLine);

            day5GetGoodUpdates(true);

            int total = 0;

            foreach (string update in d5BadUpdates)
            {
                string updated = day5FixRow(update);

                List<string> pages = updated.Split(",").ToList();
                total += int.Parse(pages[pages.Count / 2]);
            }

            printInt(total);
        }
        #endregion

        #region day 6
        static void day6a() //4647
        {
            List<string> data = dataToList(getData("6"), Environment.NewLine);
            d6Points = new();

            int x = 0;
            int y = 0;
            int count = 0;
            d6Rows = data.Count;
            d6Columns = data[0].Length;

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data[0].Length; j++)
                {
                    d6Points.Add(new Point(i, j), data[i][j]);
                    if (data[i][j] == '^')
                    {
                        x = i;
                        y = j;
                    }
                }
            }

            count = day6Traverse(x, y, -1, 0).visited.Count();

            printInt(count);
        }

        static (IEnumerable<(int,int)> visited, bool looped) day6Traverse(int x, int y, int dirX, int dirY)
        {
            HashSet<(int,int,int,int)> points = new();
            bool looped = false;
            
            while (true)
            {
                looped = !points.Add((x, y, dirX, dirY));

                int newX = x + dirX; 
                int newY = y + dirY;

                if (looped || newX < 0 || newY < 0 || newX >= d6Rows || newY >= d6Columns)
                    break;

                if (d6Points[new Point(newX, newY)] == '#')
                {
                    int t = dirX;
                    dirX = dirY;
                    dirY = t * -1;
                    continue;
                }

                x += dirX;
                y += dirY;
            }

            return (points.Select(p => (p.Item1, p.Item2)).Distinct(), looped);
        }

        static Dictionary<Point, char> d6Points = new();
        static int d6Rows;
        static int d6Columns;
        static void day6b() //1723
        {
            List<string> data = dataToList(getData("6"), Environment.NewLine);
            d6Points = new();

            int x = 0;
            int y = 0;
            int count = 0;
            d6Rows = data.Count;
            d6Columns = data[0].Length;

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data[0].Length; j++)
                {
                    d6Points.Add(new Point(i, j), data[i][j]);
                    if (data[i][j] == '^')
                    {
                        x = i;
                        y = j;
                    }
                }
            }

            foreach((int X, int Y) in day6Traverse(x, y, -1, 0).visited.Skip(1))
            {
                char temp = d6Points[new Point(X,Y)];
                d6Points[new Point(X, Y)] = '#';

                if (day6Traverse(x, y, -1, 0).looped)
                    count++;

                d6Points[new Point(X, Y)] = temp;
            }

            printInt(count);
        }
        #endregion

        #region day 7
        static void day7a() //2664460013123
        {
            List<string> data = dataToList(getData("7"), Environment.NewLine);
            List<char> operators = new List<char>{ '+', '*' };
            long total = 0;

            foreach (string row in data)
            {
                long rowTotal = long.Parse(row.Split(':')[0]);
                List<int> nums = row.Split(':')[1].TrimStart().Split(" ").Select(int.Parse).ToList();

                List<char[]> combinations = day7Combinations(nums.Count-1,operators).ToList();

                foreach (char[] combination in combinations.FindAll(x => x.Length == nums.Count - 1))
                {
                    long curTotal = nums[0];
                    for (int i = 0; i < combination.Length; i++)
                    {
                        if (combination[i] == '+')
                        {
                            curTotal += nums[i + 1];
                        }
                        else
                            curTotal *= nums[i + 1];
                    }
                    if (rowTotal == curTotal)
                    {
                        total += curTotal;
                        break;
                    }
                }
            }
            printLong(total);
        }

        //https://stackoverflow.com/questions/76874321/all-combinations-and-permutations-of-a-set-of-characters-to-a-given-length-in-c
        private static IEnumerable<T[]> day7Combinations<T>(int maxLength, IEnumerable<T> chars)
        {
            if (maxLength < 0)
                throw new ArgumentOutOfRangeException(nameof(maxLength));

            if (chars is null)
                throw new ArgumentNullException(nameof(chars));

            var letters = chars.Distinct().ToArray();

            if (letters.Length == 0)
                yield break;

            for (var agenda = new Queue<T[]>(new[] { Array.Empty<T>() });
                     agenda.Peek().Length < maxLength;)
            {
                var current = agenda.Dequeue();

                foreach (var letter in letters)
                {
                    var next = current.Append(letter).ToArray();

                    agenda.Enqueue(next);

                    yield return next;
                }
            }
        }

        static void day7b() //426214131924213
        {
            List<string> data = dataToList(getData("7"), Environment.NewLine);
            List<char> operators = new List<char> { '+', '*' , '|'};
            BigInteger total = 0;

            foreach (string row in data)
            {
                BigInteger rowTotal = BigInteger.Parse(row.Split(':')[0]);
                List<int> nums = row.Split(':')[1].TrimStart().Split(" ").Select(int.Parse).ToList();
                List<char[]> combinations = day7Combinations(nums.Count - 1, operators).ToList();

                foreach (char[] combination in combinations.FindAll(x => x.Length == nums.Count - 1))
                {
                    BigInteger curTotal = nums[0];
                    for (int i = 0; i < combination.Length; i++)
                    {
                        if (combination[i] == '+')
                            curTotal += nums[i + 1];
                        else if (combination[i] == '*')
                            curTotal *= nums[i + 1];
                        else
                            curTotal = BigInteger.Parse($"{curTotal}{nums[i+1]}");
                    }
                    if (rowTotal == curTotal)
                    {
                        total += curTotal;
                        break;
                    }
                }
            }
            print(total.ToString());
        }
        #endregion

        #region day 8
        static void day8a() //361
        {
            List<string> data = dataToList(getData("8"), Environment.NewLine);
            List<(char c, int x, int y)> grid = new();
            List<Point> antennas = new();
            int rows = data.Count;
            int cols = data[0].Length;
            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (data[i][j] != '.')
                        grid.Add((data[i][j], i, j));
                }
            }

            for (int i = 0;i < grid.Count; i++)
            {
                (char c, int x, int y) cur = grid.ElementAt(i);

                List<(char c, int x, int y)> matches = grid.FindAll(x => x.c == cur.c).ToList();
                matches.Remove(cur);
                
                foreach ((char c, int x, int y) match in matches)
                {
                    int xDif = cur.x - match.x;
                    int yDif = cur.y - match.y;

                    Point a1 = new Point(cur.x + xDif, cur.y + yDif);
                    Point a2 = new Point(match.x - xDif, match.y - yDif);

                    if (day8isInBounds(a1.X, a1.Y, rows, cols))
                    {
                        if (!(antennas.Contains(a1) && grid.Select(x => x.x == a1.X && x.y == a1.Y) != null))
                            antennas.Add(a1);
                    }
                    if (day8isInBounds(a2.X, a2.Y, rows, cols))
                    {
                        if (!(antennas.Contains(a2) && grid.Select(x => x.x == a2.X && x.y == a2.Y) != null))
                            antennas.Add(a2);
                    }
                }
            }

            printInt(antennas.Count);
        }

        static bool day8isInBounds(int x, int y, int height, int width)
        {
            return (x >= 0 & x < height && y >= 0 && y < width);
        }

        static void day8b() //1249
        {
            List<string> data = dataToList(getData("8"), Environment.NewLine);
            List<(char c, int x, int y)> grid = new();
            List<Point> antennas = new();
            int rows = data.Count;
            int cols = data[0].Length;
            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (data[i][j] != '.')
                        grid.Add((data[i][j], i, j));
                }
            }

            for (int i = 0; i < grid.Count; i++)
            {
                (char c, int x, int y) cur = grid.ElementAt(i);

                List<(char c, int x, int y)> matches = grid.FindAll(x => x.c == cur.c).ToList();
                matches.Remove(cur);

                foreach ((char c, int x, int y) match in matches)
                {
                    int curX = cur.x;
                    int curY = cur.y;
                    int matchX = match.x;
                    int matchY = match.y;

                    int xDif = curX - matchX;
                    int yDif = curY - matchY;

                    while (true)
                    {
                        Point a1 = new Point(curX + xDif, curY + yDif);
                        Point a2 = new Point(matchX - xDif, matchY - yDif);

                        if (day8isInBounds(a1.X, a1.Y, rows, cols))
                        {
                            if (!(antennas.Contains(a1) && grid.Select(x => x.x == a1.X && x.y == a1.Y) != null))
                                antennas.Add(a1);
                        }
                        if (day8isInBounds(a2.X, a2.Y, rows, cols))
                        {
                            if (!(antennas.Contains(a2) && grid.Select(x => x.x == a2.X && x.y == a2.Y) != null))
                                antennas.Add(a2);
                        }

                        curX = a1.X;
                        curY = a1.Y;
                        matchX = a2.X;
                        matchY = a2.Y;

                        if (!day8isInBounds(curX, curY, rows, cols) && !day8isInBounds(matchX, matchY, rows, cols))
                            break;
                    }
                }
            }

            for (int i = 0; i < data.Count; i++)
            {
                List<char> s = data[i].ToCharArray().ToList();

                List<Point> ants = antennas.FindAll(x => x.X == i).OrderBy(x => x.Y).ToList();
                foreach (Point p in ants)
                {
                    if (s[p.Y] == '.')
                    { 
                        s[p.Y] = '#';
                        count++;
                    }
                }

                print(new string(s.ToArray()));
            }

            printInt(count + grid.Count);
        }
        #endregion

        #region day[9]
        static void day9a() //6385338159127
        {
            string data = getData("9");
            List<int> disk = data.ToList().Select(day9CharToInt).ToList();
            List<int> formattedDisk = new();
            long checksum = 0;

            for (int i = 0; i < disk.Count; i++)
            {
                int cur = disk[i];
                if (i % 2 == 1)
                {
                    for (int j = 0; j < cur; j++)
                    {
                        formattedDisk.Add(-1);
                    }
                }
                else
                {
                    for (int j = 0; j < cur; j++)
                    {
                        formattedDisk.Add(i / 2);
                    }
                }
            }

            for (int i = formattedDisk.Count - 1; i >= 0; i--)
            {
                if (formattedDisk[i] != -1)
                {
                    int index = formattedDisk.IndexOf(-1);
                    if (index > i)
                        break;
                    formattedDisk[index] = formattedDisk[i];
                    formattedDisk[i] = -1;
                }
            }

            for (int i = 0; i < formattedDisk.Count; i++)
            {
                if (formattedDisk[i] != -1)
                    checksum += (i * formattedDisk[i]);
            }

            printLong(checksum);
        }

        static int day9CharToInt(char c)
        {
            return int.Parse(c.ToString());
        }

        static string day9IntListToString(List<int> list)
        {
            string s = "";
            foreach (int i in list)
            {
                s += i.ToString();
            }
            return s.Replace("-1",".");
        }


        static void day9b() //6415163624282
        {
            string data = getData("9");
            List<int> disk = data.ToList().Select(day9CharToInt).ToList();
            List<int> formattedDisk = new();

            long checksum = 0;

            for (int i = 0; i < disk.Count; i++)
            {
                int cur = disk[i];
                if (i % 2 == 1)
                {
                    for (int j = 0; j < cur; j++)
                    {
                        formattedDisk.Add(-1);
                    }
                }
                else
                {
                    for (int j = 0; j < cur; j++)
                    {
                        formattedDisk.Add(i / 2);
                    }
                }
            }

            for (int i = formattedDisk.Count - 1; i >= 0; i--)
            {
                if (formattedDisk[i] != -1)
                {
                    int curlen = formattedDisk.FindAll(x => x == formattedDisk[i]).Count;
                    int gaplen = 0;
                    for(int j = 0; j < formattedDisk.Count; j++)
                    {
                        if (formattedDisk[j] == -1)
                            gaplen++;
                        else
                            gaplen = 0;
                        
                        if (gaplen == curlen)
                        {
                            for (int k = 0; k < gaplen; k++)
                            {
                                formattedDisk[j - k] = formattedDisk[i-k];
                                formattedDisk[i - k] = -1;
                            }
                            break;
                        }
                        if (j >= i)
                            break;
                    }
                }
            }

            for (int i = 0; i < formattedDisk.Count; i++)
            {
                if (formattedDisk[i] != -1)
                    checksum += (i * formattedDisk[i]);
            }

            printLong(checksum);
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
