using System;
using System.Collections.Generic;
using System.IO;

class Solution {
    internal static Dictionary<int, int> seenPairs = new Dictionary<int, int>{{0, 0}, {1, 1}}; 
    public static int Fibonacci(int n) {
        if(seenPairs.ContainsKey(n)){
            return seenPairs[n];
        }
        else{
            int current = Fibonacci(n-1) + Fibonacci(n-2);
            seenPairs.Add(n, current);
            return current;
        }
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(Fibonacci(n));
    }
}

