// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

//Attributes
int totalSum=0;
List<List<List<int>>> dataset = new List<List<List<int>>>();

try
{
    //init
    using (StreamReader sr = new StreamReader("data.txt"))
    {
        string line;
        int i = 0;
        while (!sr.EndOfStream) {
            line = sr.ReadLine();
            string[] lineAr = line.Split(' ');
            List<int> lineList = new List<int>();
            for(int y=0; y<lineAr.Length; y++)
            {
                lineList.Add(int.Parse(lineAr[y]));
            }
            List<List<int>> outerList = new List<List<int>>();
            outerList.Add(lineList);
            dataset.Add(outerList);
            i++;
        }
    }
    //dataset[0][0].ForEach(i  => Console.WriteLine($"{i} ")); //test
    //calc
    foreach (var item in dataset) //item is a table
    {
        List<int> sumRow = new List<int>();
        for (int y = 0; y < item.Count; y++)
        {
            List<int> newRow = new List<int>();
            int x = 0;
            while (x + 1 < item[y].Count) {
                newRow.Add(item[y][x + 1] - item[y][x]);
                x++;
            }
            item.Add(newRow);
            if (newRow.All(c => c == 0))
            {
                int modifier = 0;
                for(int u= item.Count-1; u>=0; u--)
                {
                    int temp = item[u].Last();
                    sumRow.Add(temp+modifier);
                    modifier = temp + modifier;
                }
                //totalSum+=sumRow.Sum(); //misunderstood task
                totalSum += sumRow.Last();
                sumRow.Clear();
                break;
            }
        }
    }
    Console.WriteLine(totalSum);

}
catch { }
