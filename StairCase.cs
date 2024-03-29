using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {
    internal static Dictionary<int, long> Perms = new Dictionary<int, long>{{0, 0}, {1, 1}, {2, 2}, {3, 4}};
    // Complete the stepPerms function below.
    static int stepPerms(int n) {
        long counter=0;
        if(Perms.ContainsKey(n)){
            return (int) Perms[n];
        }
        else{
            counter += stepPerms(n-1)+stepPerms(n-2)+stepPerms(n-3); 
            Perms.Add(n, counter);
        }
        return (int) counter;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int s = Convert.ToInt32(Console.ReadLine());

        for (int sItr = 0; sItr < s; sItr++) {
            int n = Convert.ToInt32(Console.ReadLine());

            int res = stepPerms(n);

            textWriter.WriteLine(res);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
