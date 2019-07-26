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
    // Complete the maximumToys function below.
    static int maximumToys(int[] prices, int k) {
        int[] pricesSorted = mergeSort(prices);
        int numberToys = 0;
        int totalCost = 0;
        while(totalCost + pricesSorted[numberToys] <= k && numberToys < prices.Length){
            totalCost += pricesSorted[numberToys];
            numberToys++;
        }
        
        return numberToys;
    }

    static int[] mergeSort(int[] arr){
        if(arr.Length<=1){
            return arr;
        }
        else{
            int[] right = new int[(int) arr.Length/2];
            // left will be bigger if the array has an odd length
            int[] left = new int[(int) Math.Ceiling((double) arr.Length/2)];
            // create left
            for(int i = 0; i < (int) Math.Ceiling((double) arr.Length/2); i++){
                left[i] = arr[i];
            }
            //create right 
            for(int j = 0; j < (int) arr.Length/2; j++){
                right[j] = arr[(int) Math.Ceiling((double) arr.Length/2) + j];
            }
            return merge(mergeSort(left), mergeSort(right));
        }
    }
    static int[] merge(int[] left, int[] right){
        int[] merged = new int[left.Length + right.Length];
        int leftIndex = 0;
        int rightIndex = 0;
        for(int mergedIndex = 0; mergedIndex < merged.Length; mergedIndex++){
            if(leftIndex == left.Length){
                merged[mergedIndex] = right[rightIndex];
                rightIndex++;
            }
            else if(rightIndex == right.Length){
                merged[mergedIndex] = left[leftIndex];
                leftIndex++;
            }
            else if(left[leftIndex] <= right[rightIndex]){
                merged[mergedIndex] = left[leftIndex];
                leftIndex++;
            }
            else{
                merged[mergedIndex] = right[rightIndex];
                rightIndex++;
            }
        }
        return merged;
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[] prices = Array.ConvertAll(Console.ReadLine().Split(' '), pricesTemp => Convert.ToInt32(pricesTemp))
        ;
        int result = maximumToys(prices, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
