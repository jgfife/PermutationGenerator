using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of permutations desired: ");
            bool loop = true;
            int count = 1;
            int permutations = Convert.ToInt32(Console.ReadLine());
            var timer = Stopwatch.StartNew();
            List<int> a = new List<int>();
            List<int> end = new List<int>();
            for (int i = 1; i <= permutations; i++)
            {
                a.Add(i);
                end.Add(i);
            }

            end.Reverse();
            for (int i = 0; i < a.Count(); i++)
            {
                Console.Write(a[i].ToString() + ' ');
            }

            Console.Write("\r\n");
            while (loop)
            {
                bool eq = a.SequenceEqual(end);
                if (eq)
                {
                    timer.Stop();
                    Console.Write(count.ToString() + " Permutations!" + "\r\n");
                    Console.Write("Runtime: " + timer.Elapsed.TotalSeconds + " seconds. \r\n");
                    break;
                }
                int j = permutations - 2;
                while (a[j] > a[j + 1])
                {
                    j -= 1; //j:= j −1 { j is the largest subscript with a j < a j + 1}
                }
                int k = permutations - 1; //k:= n 
                while (a[j] > a[k]) //while a j > a k 
                {
                    k--;//k := k−1 
                }
                int tempj = a[j]; //{ ak is the smallest integer greater than a j to the right of a j} interchange a j and ak 
                int tempk = a[k];
                a[j] = tempk;
                a[k] = tempj;
                int r = permutations - 1; //r := n 
                int s = j + 1; //s:= j + 1 
                while (r > s) //while r > s
                {
                    int tempr = a[r];
                    int temps = a[s];
                    a[r] = temps; //interchange ar and as 
                    a[s] = tempr;
                    r--; //r := r −1 
                    s++; //s:= s + 1 { this puts the tail end of the permutation after the jth position in increasing order}
                }
                for (int i = 0; i < a.Count(); i++)
                {
                    Console.Write(a[i].ToString() + ' ');
                }
                Console.Write("\r\n");
                count++;
            }
        }
    }
}
