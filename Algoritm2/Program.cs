using System;
using System.Diagnostics;

public class Sort
{
    public static IComparable[] MergeSort(IComparable[] mass, ref int a, ref int b8)
    {
        a++;
        b8 += mass.Length * 8;
        if (mass.Length == 1) return mass;
        int mid = mass.Length / 2;

        return Merge(MergeSort(mass.Take(mid).ToArray(), ref a, ref b8 ), MergeSort(mass.Skip(mid).ToArray(), ref a, ref b8));
    }
    static IComparable[] Merge(IComparable[] mass1, IComparable[] mass2)
    {
        int a = 0, b = 0;
        IComparable[] merged = new IComparable[mass1.Length + mass2.Length];
        for (int i = 0; i < mass1.Length + mass2.Length; i++)
        {
            if (b.CompareTo(mass2.Length) < 0 && a.CompareTo(mass1.Length) < 0)
                if (mass1[a].CompareTo(mass2[b]) > 0)
                    merged[i] = mass2[b++];
                else
                    merged[i] = mass1[a++];
            else
                if (b < mass2.Length)
                merged[i] = mass2[b++];
            else
                merged[i] = mass1[a++];
        }
        return merged;
    }
    public static void Randomich(IComparable[] arr, int N)
    {
        var rand = new Random();
        for (int i = 0; i < N; i++)
        {
            arr[i] = rand.NextDouble() * 2 - 1;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        string path = @"C:\asd\note.txt";
        string text;
        int N = 1000;
        using (StreamWriter fstream = new StreamWriter(path))
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    IComparable[] mas = new IComparable[N];
                    Sort.Randomich(mas, N);
                    int a = 0;
                    int b8 = 0;
                    stopwatch.Start();
                    mas = Sort.MergeSort(mas, ref a, ref b8);
                    stopwatch.Stop();
                    Console.WriteLine(N + " Количетсво рекурсий = " + a + " Занятая память = " + b8 + " Время = " + stopwatch.ElapsedMilliseconds);
                    text = /*stopwatch.ElapsedMilliseconds.ToString() + "   " + a.ToString() + "   " +*/ b8.ToString();
                    fstream.WriteLine(text);
                    stopwatch.Reset();
                }
                N *= 2;
                fstream.WriteLine();
            }
        }
    }
}