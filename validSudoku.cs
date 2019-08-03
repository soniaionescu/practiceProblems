public class Solution {
    public bool IsValidSudoku(char[][] board) {
        // check each box
        for(int i = 0; i <7; i += 3){
            for(int j = 0; j < 7; j+=3){
                if(checkbox(i, j, board) == false){
                    Console.WriteLine("box starting at {0},{1} is returning false", i, j);
                    return false;
                }
            }
        }
        for(int k = 0; k < 9; k++){
            // check each row
            if(checkrow(k, board) == false){
                Console.WriteLine("row starting at {0} is returning false",k);
                return false;
            }
            if(checkcolumn(k, board) == false){
                Console.WriteLine("column starting at {0} is returning false",k);
                return false;
            }
        }
        return true;
    }
    public bool checkbox(int row, int column, char[][] board){
        Dictionary<char, int> seen = new Dictionary<char, int>();
        for(int i = row; i < row+3; i++){
            for(int j = column; j < column+3; j++){
                if(seen.ContainsKey(board[i][j])){
                    Console.WriteLine("{0}, {1}, {2}", i, j, board[i][j]);
                    return false;
                }
                else if(!board[i][j].Equals('.')){
                    Console.WriteLine("Adding {0}, {1}, {2}", i, j, board[i][j]);

                    seen.Add(board[i][j], 1);
                }
            }
        }
        return true;
    }
    public bool checkrow(int row, char[][] board){
        Dictionary<char, int> seen = new Dictionary<char, int>();
        for(int i = 0; i < 9; i++){
            if(seen.ContainsKey(board[row][i])){
                return false;
            }
            else if(!board[row][i].Equals('.')){
                seen.Add(board[row][i], 1);
            }

        }
        return true;
    }
    public bool checkcolumn(int column, char[][] board){
        Dictionary<char, int> seen = new Dictionary<char, int>();
        for(int i = 0; i < 9; i++){
            if(seen.ContainsKey(board[i][column])){
                return false;
            }
            else if(!board[i][column].Equals('.')){
                seen.Add(board[i][column], 1);
            }
        }
        return true;
    }
}
