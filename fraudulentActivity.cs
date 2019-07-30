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

    // Complete the activityNotifications function below.
    static int activityNotifications(int[] expenditure, int d) {
        double currentMedian;
        int numberAlerts=0;
        for(int i = d; i < expenditure.Length; i++){
            int[] sorted = mergeSort(segment(expenditure, i, d));
            currentMedian = calculateMedian(sorted);
            if(expenditure[i] >= currentMedian*2){
                numberAlerts++;
            }
        }
        return numberAlerts;
    }
    static int[] segment(int[] arr, int i, int d){
        int[] segmentedArr = new int[d];
        for(int j = 0; j < d; j++){
            segmentedArr[j] = arr[i-d+j];
        }
        return segmentedArr;
    }
    static double calculateMedian(int[] arr){ //takes in a sorted array
        double median;
        if(arr.Length%2 == 1){ //odd
            median = arr[(arr.Length-1)/2];
        }
        else{
            median = (double) (arr[(arr.Length)/2-1]+arr[(arr.Length)/2])/2;
        } 
        return median;
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

        string[] nd = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nd[0]);

        int d = Convert.ToInt32(nd[1]);

        int[] expenditure = Array.ConvertAll(Console.ReadLine().Split(' '), expenditureTemp => Convert.ToInt32(expenditureTemp))
        ;
        int result = activityNotifications(expenditure, d);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
