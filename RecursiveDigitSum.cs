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

    // Complete the superDigit function below.
    static int superDigit(string n, int k) {
        // first, concatenate k times
        string originalN = n;
        for(int i = 1; i < k; i++){
            n = n + originalN;
        }
        // if it's one digit, return the one digit
        if(n.Length == 1){
            int nInt = Convert.ToInt32(n);
            return nInt;
        }
        else{
            int newSuperDigit = 0;
            char[] nArray = n.ToCharArray();
            for(int j = 0; j < n.Length; j++){
                newSuperDigit += (int)(nArray[j]) - 48;
            }
            return superDigit(newSuperDigit.ToString(), 1);
        }
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        string n = nk[0];

        int k = Convert.ToInt32(nk[1]);

        int result = superDigit(n, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
