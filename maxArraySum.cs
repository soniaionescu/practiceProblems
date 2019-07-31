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

    // Complete the maxSubsetSum function below.
    static int maxSubsetSum(int[] arr) {
        int[] maxes = new int[arr.Length];
        maxes[0] = arr[0];
        maxes[1] = Math.Max(arr[0], arr[1]);
        int currentMax = maxes[1];
        for(int i = 2; i < maxes.Length; i++){
            maxes[i] = Math.Max(arr[i], arr[i]+maxes[i-2]);
            maxes[i] = Math.Max(maxes[i], currentMax);
            if(maxes[i] > currentMax){
                currentMax = maxes[i];
            }
        }
        return currentMax;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        int res = maxSubsetSum(arr);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
