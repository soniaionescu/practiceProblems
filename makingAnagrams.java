import java.io.*;
import java.math.*;
import java.security.*;
import java.text.*;
import java.util.*;
import java.util.concurrent.*;
import java.util.regex.*;

public class Solution {

    // Complete the makeAnagram function below.
    static int makeAnagram(String a, String b) {
        char[] aArr = a.toCharArray();
        char[] bArr = b.toCharArray();
        int deletedChar = 0;
        for(int i = 0; i < aArr.length; i++){
            //look to see if you can find the elements of a in b, and if you can't, 
            //increment the number of characters you have to delete.
            if(b.indexOf(aArr[i]) < 0){
                deletedChar++;
            }
            //if you do see it, take it out of the string (b) - this takes care of the case
            // where there are multiple of the letter. If you don't do this, if there are
            // more of one letter in one string than in the other string, it will still
            //return true
            else if(b.indexOf(aArr[i]) >= 0){
                b = b.substring(0, b.indexOf(aArr[i])) + b.substring(b.indexOf(aArr[i])+1);
            }
        }
         for(int j = 0; j < bArr.length; j++){
            if(a.indexOf(bArr[j]) < 0){
                deletedChar++;
            }

            else if(a.indexOf(bArr[j]) >= 0){
                a = a.substring(0, a.indexOf(bArr[j])) + a.substring(a.indexOf(bArr[j])+1);
            }
        }
        System.out.print(deletedChar);
        return deletedChar;
    }

    private static final Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) throws IOException {
        BufferedWriter bufferedWriter = new BufferedWriter(new FileWriter(System.getenv("OUTPUT_PATH")));

        String a = scanner.nextLine();

        String b = scanner.nextLine();

        int res = makeAnagram(a, b);

        bufferedWriter.write(String.valueOf(res));
        bufferedWriter.newLine();

        bufferedWriter.close();

        scanner.close();
    }
}
