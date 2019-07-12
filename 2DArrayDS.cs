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

    public static int sum(int startrow, int startcolumn, int[][] arr){
        int hgsum = arr[startrow][startcolumn] + arr[startrow][startcolumn+1]+
        arr[startrow][startcolumn+2] + arr[startrow+1][startcolumn+1]+
        arr[startrow+2][startcolumn] + arr[startrow+2][startcolumn+1]
        + arr[startrow+2][startcolumn+2];
        return hgsum;
    }
    // Complete the hourglassSum function below.
    static int hourglassSum(int[][] arr) {
        // declare max
        int max = -9*7;
        // iterate through board
        for(int i = 0; i < arr.GetLength(0) -2; i++){
            for(int j = 0 ; j < arr[j].GetLength(0) - 2; j++){
                if(sum(i, j, arr) > max){
                    max = sum(i, j, arr);
                }
            }
        }
        return max;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int[][] arr = new int[6][];

        for (int i = 0; i < 6; i++) {
            arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        }

        int result = hourglassSum(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
