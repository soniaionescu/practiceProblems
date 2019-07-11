import java.io.*;
import java.math.*;
import java.security.*;
import java.text.*;
import java.util.*;
import java.util.concurrent.*;
import java.util.regex.*;

public class Solution {

    // Complete the checkMagazine function below.
    static void checkMagazine(String[] magazine, String[] note) {
        // get hashmaps of the words in the magazine and the number of times they show up as the values
        HashMap<String, Integer> magazineWords = new HashMap<String, Integer>();
        for(int i = 0; i < magazine.length; i++){
            //if it doesn't exist, add it to the hashmap and put that there's 1 instance
            if(magazineWords.containsKey(magazine[i]) == false){
                magazineWords.put(magazine[i], 1);
            }
            // if it's already in the hashmap, add 1 to the number of instances
            else if(magazineWords.containsKey(magazine[i]) == true){
                magazineWords.put(magazine[i], magazineWords.get(magazine[i])+1);
            }
        }
        //now go through the note and see if the words are in the magazine
        String containsAllWords = "Yes";
        for(int j = 0; j < note.length; j++){
            // if the magazine does contain the word, decrement the number of times it is there because you have "used it" once
            if(magazineWords.containsKey(note[j]) == true){
                magazineWords.put(note[j], magazineWords.get(note[j]) - 1);
                // if that put us below 0 instances, we should return false
                if(magazineWords.get(note[j]) < 0){
                    containsAllWords = "No";
                    break;
                }
            }
            // if the magazine doesn't contain the word, return false
            if(magazineWords.containsKey(note[j]) == false){
                containsAllWords = "No";
                break;
            }
        }
        System.out.print(containsAllWords);
    }

    private static final Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) {
        String[] mn = scanner.nextLine().split(" ");

        int m = Integer.parseInt(mn[0]);

        int n = Integer.parseInt(mn[1]);

        String[] magazine = new String[m];

        String[] magazineItems = scanner.nextLine().split(" ");
        scanner.skip("(\r\n|[\n\r\u2028\u2029\u0085])?");

        for (int i = 0; i < m; i++) {
            String magazineItem = magazineItems[i];
            magazine[i] = magazineItem;
        }

        String[] note = new String[n];

        String[] noteItems = scanner.nextLine().split(" ");
        scanner.skip("(\r\n|[\n\r\u2028\u2029\u0085])?");

        for (int i = 0; i < n; i++) {
            String noteItem = noteItems[i];
            note[i] = noteItem;
        }

        checkMagazine(magazine, note);

        scanner.close();
    }
}
