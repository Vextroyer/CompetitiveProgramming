/*
https://leetcode.com/problems/n-queens/
https://leetcode.com/problems/n-queens-ii/
*/
class NQueens{
    //Place N queens on a nxn chessboard
    public IList<IList<string>> Place(int n){
        Init(n);
        Backtrack(0);
        return storage;
    }
    void Backtrack(int col){
        if(col == size){
            //A solution
            BuildSolution();
            return;
        }
        for(int row=0;row<size;++row){
            //try putting a queen on this cell
            if(!IsUnderTreat(row,col)){
                PutQueen(row,col);
                Backtrack(col + 1);
                RemoveQueen(row,col);
            }
        }
    }
    void Init(int n){
        rows = new int[n];
        cols = new int[n];
        diag1 = new int[2 * n - 1];
        diag2 = new int[2 * n - 1];
        board = new char[n,n];
        for(int i=0;i<n;++i)for(int j=0;j<n;++j)board[i,j] = '.';
        storage =  new List<IList<string>>();
        size = n;
    }
    int[] rows;//Queens on this row
    int[] cols;//Queens on this column
    int[] diag1;//Queens on the diagonal starting from the upper left
    int[] diag2;//Queens on the diagonals starting from the upper right
    char[,] board;//The board. Its a square.
    int size;//The size of the board.
    IList<IList<string>> storage;//Store the solutions
    bool IsValidPos(int row,int col){
        return row >= 0 && row < size && col >=0 && col < size;
    }
    //Given a position decide if a queen placed on this position will be threatened by another queen
    bool IsUnderTreat(int row,int col){
        return (rows[row] > 0) || (cols[col] > 0) || (diag1[row + col] > 0) || (diag2[row - col + size - 1] > 0);
        // if( (rows[row] > 0) || (cols[col] > 0) || (diag1[row + col] > 0) || (diag2[row - col + size - 1] > 0))return false;
        // return true;
    }
    void AddTreat(int row,int col){
        rows[row]++;
        cols[col]++;
        diag1[row + col]++;
        diag2[row - col + size - 1]++;
    }
    void RemoveTreat(int row,int col){
        rows[row]--;
        cols[col]--;
        diag1[row + col]--;
        diag2[row - col + size - 1]--;
    }
    void PutQueen(int row,int col){
        board[row,col] = 'Q';
        AddTreat(row,col);
    }
    void RemoveQueen(int row,int col){
        board[row,col] = '.';
        RemoveTreat(row,col);
    }
    void BuildSolution(){
        IList<string> state = new List<string>();
        for(int i=0;i<size;++i){
            char[] aux = new char[size];
            for(int j = 0;j<size;++j)aux[j] = board[i,j];
            state.Add(new string(aux));
        }
        storage.Add(state);
    }
}
