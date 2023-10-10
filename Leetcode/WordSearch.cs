/*
https://leetcode.com/problems/word-search/

Given a board consisting of letters and a word,
discover if its possible to find the word on the board.
*/
class WordSearch{
   public bool Exist(char[][] board, string word) {
        return IsFound(board,word);
    }
    bool IsFound(char[][] board, string word){
        bool[][] used = new bool[board.Length][];
        for(int i=0;i<used.Length;++i)used[i] = new bool[board[0].Length]; 
        for(int i=0;i<board.Length;++i){
            for(int j=0;j<board[0].Length;++j){
                if(IsFound(board,used,word,i,j,0))return true;
            }
        }

        return false;
    }
    bool IsFound(char[][] board,bool [][] used, string word,int row,int col,int pos){
        if(!IsValidPos(row,col,board)|| used[row][col] || board[row][col] != word[pos])return false;
        //Is a valid position and the character matches the current character
        if(pos == word.Length - 1)return true;
        
        used[row][col] = true;
        foreach((int,int) p in Neighbours(row,col)){
            if(IsFound(board,used,word,p.Item1,p.Item2,pos+1))return true;
        }
        used[row][col] = false;

        return false;
    }
    bool IsValidPos(int row,int col, char[][] board){
        if(row < 0 || row >= board.Length|| col < 0 || col >= board[0].Length)return false;
        return true;
    }
    List<(int,int)> Neighbours(int row,int col){
        List<(int,int)> list = new List<(int, int)>();
        list.Add((row-1,col));
        list.Add((row+1,col));
        list.Add((row,col-1));
        list.Add((row,col+1));
        return list;
    }
}