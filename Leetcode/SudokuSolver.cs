/*
https://leetcode.com/problems/sudoku-solver/
*/
class SudokuSolver{
    public void SolveSudoku(char[][] board) {
        (int,int) beginingCell = PeekNext(0,0,board);
        SolveSudoku(beginingCell.Item1,beginingCell.Item2,board);
    }

    //This method solves the sudoku recursively
    //the row and column parameters indicate the position of the current cell being solved
    public bool SolveSudoku(int row,int col,char[][] board){
        //Consider every posibility
        for(char num = '1';num<='9';++num){
            //Only explore possibilities that do not generate conflicts

            if(ValidChoice(num,row,col,board)){
                //Try this possibility
                board[row][col] = num;
                (int,int) next = PeekNext(row,col,board);
                if(next == (-1,-1))return true;//There are no more empty cells, the sudoku is solved
                if(SolveSudoku(next.Item1,next.Item2,board))return true;//If with this decision i can solve the sudoku great
                //explore a new possibility
                board[row][col] = empty;
            }
        }

        return false;
    }
    //Returns true if the number of choice doesnt conflict whith other cells on the same row, column or square
    private bool ValidChoice(char num,int row,int col,char[][] board){
        return ValidRow(num,row,col,board) && ValidColumn(num,row,col,board) && ValidSquare(num,row,col,board);
    }
    private bool ValidRow(char num,int row,int col,char[][] board){
        //Check every column on this row, except the one where the number is
        for(int j = 0;j<board[row].Length;++j){
            if(board[row][j] == num)return false;
        }
        return true;
    }

    private bool ValidColumn(char num, int row,int col,char[][] board){
        //Check every row on this column
        for(int i=0;i<board.Length;++i){
            if(board[i][col] == num)return false;
        }
        return true;
    }

    private bool ValidSquare(char num, int row,int col,char[][] board){
        int divRow = (row / 3) * 3;
        int divCol = (col / 3) * 3;
        for(int i=divRow;i<divRow + 3;++i){
            for(int j=divCol;j<divCol + 3;++j){
                if(board[i][j] == num)return false;
            }
        }
        return true;
    }
    //Returns the next empty cell
    //It travels the board from left to right and from up to bottom
    //If no empty cell is found returns (-1,-1)
    private (int,int) PeekNext(int row,int col,char[][] board){
        for(int i=row;i<board.Length;++i){
            int j;
            if(i > row)j = 0;
            else j = col;
            for(;j<board[i].Length;++j){
                if(board[i][j] == empty)return (i,j);
            }
        }
        return (-1,-1);
    }
    private char empty = '.';//Indicates an empty cell
}