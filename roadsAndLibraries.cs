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
    // Complete the roadsAndLibraries function below.
    internal static int numberComponents = 0;
    static long roadsAndLibraries(int n, int c_lib, int c_road, int[][] cities) {
        if(c_road >= c_lib){
            return c_lib*n;
        }
        else{
            // create adjacency matrix
            int[,] adjacencyMatrix = new int[n,n];
            for(int i = 0; i < cities.Length; i++){
                Console.WriteLine("i is {0}", i);
                int city1 = cities[i][0]-1; //-1 so it is 0 indexed
                int city2 = cities[i][1]-1; // -1 so it is 0 indexed
                adjacencyMatrix[city1,city2] = 1;
                adjacencyMatrix[city2,city1] = 1;
            }
            // print adjacency matrix
            Console.WriteLine("The adjacency matrix is:");
            int rowLength = adjacencyMatrix.GetLength(0);
            int colLength = adjacencyMatrix.GetLength(1);
            for (int i = 0; i < rowLength; i++){
                for (int j = 0; j < colLength; j++){
                    Console.Write(string.Format("{0} ", adjacencyMatrix[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            // find number of components
            numberComponents = 0;
            // create boolean array of visited
            bool[] visited = new bool[n];
            // do DFS to find the number of components
            for(int j = 0; j < n; j++){
                if(!visited[j]){
                    numberComponents++;
                    dfs(adjacencyMatrix, j, visited);
                    Console.WriteLine("the number of components is: {0}", numberComponents);
                }
            }     
        }
        return (long) (c_lib*numberComponents + c_road*(n - 1*numberComponents)); //n-1 *number components is number of roads
    }
    static void dfs(int[,] adjacencyMatrix, int vertex, bool[] visited){
        visited[vertex] = true;
        for(int i = 0; i < visited.Length; i++){
            Console.WriteLine("vertex is {0}, i is {1}, adjacencyMatrix[vertex, i] is {2}, and visited[i] is {3}", vertex, i, adjacencyMatrix[vertex, i], visited[i]);
            if(adjacencyMatrix[vertex,i] == 1 && !visited[i]){
                Console.WriteLine("visiting {0}", i);
                dfs(adjacencyMatrix, i, visited);
            }
        }
        
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            string[] nmC_libC_road = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nmC_libC_road[0]);

            int m = Convert.ToInt32(nmC_libC_road[1]);

            int c_lib = Convert.ToInt32(nmC_libC_road[2]);

            int c_road = Convert.ToInt32(nmC_libC_road[3]);

            int[][] cities = new int[m][];

            for (int i = 0; i < m; i++) {
                cities[i] = Array.ConvertAll(Console.ReadLine().Split(' '), citiesTemp => Convert.ToInt32(citiesTemp));
            }

            long result = roadsAndLibraries(n, c_lib, c_road, cities);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
