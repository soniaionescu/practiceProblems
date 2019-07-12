import java.io.*;
import java.math.*;
import java.security.*;
import java.text.*;
import java.util.*;
import java.util.concurrent.*;
import java.util.regex.*;

public class Solution {

    // Complete the luckBalance function below.
    static int luckBalance(int k, int[][] contests) {
        //create arraylist of important luck
        ArrayList<Integer> importantLuck = new ArrayList<Integer>();
        int unimportantLuck = 0;
        for(int i = 0; i < contests.length; i++){
            // if it is important, add to the list of important lucks
            if(contests[i][1] == 1){
                importantLuck.add(contests[i][0]);
            }
            // if it's not important, add the luck, since we can lose all unimportant contests
            else if(contests[i][1] == 0){
                unimportantLuck += contests[i][0];
            }
        }
        // sort the arraylist in descending order
        Collections.sort(importantLuck);
        Collections.reverse(importantLuck);
        System.out.println(importantLuck);
        int importantLuckValue = 0;
        //go through and add the k most important ones to the luck we gain by losing
        for(int j = 0; j < importantLuck.size() ;  j++){
            if(j < k){
                importantLuckValue += importantLuck.get(j);
                System.out.println("Contest lost: " + importantLuck.get(j));
            }
            else if(j >= k){
                importantLuckValue -= importantLuck.get(j);
            }
        }
        int totalLuck = importantLuckValue+unimportantLuck;
        return totalLuck;
    }

    private static final Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) throws IOException {
        BufferedWriter bufferedWriter = new BufferedWriter(new FileWriter(System.getenv("OUTPUT_PATH")));

        String[] nk = scanner.nextLine().split(" ");

        int n = Integer.parseInt(nk[0]);

        int k = Integer.parseInt(nk[1]);

        int[][] contests = new int[n][2];

        for (int i = 0; i < n; i++) {
            String[] contestsRowItems = scanner.nextLine().split(" ");
            scanner.skip("(\r\n|[\n\r\u2028\u2029\u0085])?");

            for (int j = 0; j < 2; j++) {
                int contestsItem = Integer.parseInt(contestsRowItems[j]);
                contests[i][j] = contestsItem;
            }
        }

        int result = luckBalance(k, contests);

        bufferedWriter.write(String.valueOf(result));
        bufferedWriter.newLine();

        bufferedWriter.close();

        scanner.close();
    }
}
