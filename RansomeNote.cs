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

    // Complete the checkMagazine function below.
    static void checkMagazine(string[] magazine, string[] note) {
        Dictionary<string, int> magazineWords = new Dictionary<string, int>();
        for(int i = 0; i < magazine.GetLength(0); i++){
            //if it doesn't exist, add it to the hashmap and put that there's 1 instance
            if(magazineWords.ContainsKey(magazine[i]) == false){
                magazineWords[magazine[i]] = 1;
            }
            // if it's already in the hashmap, add 1 to the number of instances
            else if(magazineWords.ContainsKey(magazine[i]) == true){
                magazineWords[magazine[i]] = magazineWords[magazine[i]]+1;
            }
        }
        //now go through the note and see if the words are in the magazine
        String containsAllWords = "Yes";
        for(int j = 0; j < note.GetLength(0); j++){
            // if the magazine does contain the word, decrement the number of times it is there because you have "used it" once
            if(magazineWords.ContainsKey(note[j]) == true){
                magazineWords[note[j]] = magazineWords[note[j]] - 1;
                // if that put us below 0 instances, we should return false
                if(magazineWords[note[j]] < 0){
                    containsAllWords = "No";
                    break;
                }
            }
            // if the magazine doesn't contain the word, return false
            if(magazineWords.ContainsKey(note[j]) == false){
                containsAllWords = "No";
                break;
            }
        }
        Console.WriteLine(containsAllWords);
    }
    

    static void Main(string[] args) {
        string[] mn = Console.ReadLine().Split(' ');

        int m = Convert.ToInt32(mn[0]);

        int n = Convert.ToInt32(mn[1]);

        string[] magazine = Console.ReadLine().Split(' ');

        string[] note = Console.ReadLine().Split(' ');

        checkMagazine(magazine, note);
    }
}
