import java.io.*;
import java.math.*;
import java.security.*;
import java.text.*;
import java.util.*;
import java.util.concurrent.*;
import java.util.regex.*;

public class Solution {
    // create a method to calculate the hourglass sum from a certain starting index
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
        for(int i = 0; i < arr.length -2; i++){
            for(int j = 0 ; j < arr[0].length - 2; j++){
                if(sum(i, j, arr) > max){
                    max = sum(i, j, arr);
                }
            }
        }
        return max;
    }

    private static final Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) throws IOException {
        BufferedWriter bufferedWriter = new BufferedWriter(new FileWriter(System.getenv("OUTPUT_PATH")));

        int[][] arr = new int[6][6];

        for (int i = 0; i < 6; i++) {
            String[] arrRowItems = scanner.nextLine().split(" ");
            scanner.skip("(\r\n|[\n\r\u2028\u2029\u0085])?");

            for (int j = 0; j < 6; j++) {
                int arrItem = Integer.parseInt(arrRowItems[j]);
                arr[i][j] = arrItem;
            }
        }

        int result = hourglassSum(arr);

        bufferedWriter.write(String.valueOf(result));
        bufferedWriter.newLine();

        bufferedWriter.close();

        scanner.close();
    }
}
