/*
The structure of the glasses is like this
0 _
1 _ _
2 _ _ _
3 _ _ _ _
..
..
..
100 _ _ _ ....

Glass (i,j) pours on glasses (i+1,j) and (i+1,j+1), thats it, the one below and the one below and to the right.
Glass (i,j) receives from glasses (i-1,j) and (i-1,j-1), the one above and the one above and to the left.

Glass (i,j) is as full as the maximum between what it receives from its upper glasses and 1.

The recursion idea is that i can calculate how much do i have by calculation how much does my upper glasses has and how much they pass to me.
*/
class Solution{
    public double ChampagneTower(int poured, int query_row, int query_glass) {
        double[,] memo = new double[100,100];//Stores the result for avoid recalculation.
        bool[,] used = new bool[100,100];//Determines wheter this result has been calculated.
        Fill(poured,query_row,query_glass,memo,used);
        return stored;
    }
    private double stored = 0;//How much has stored the last visited glass
    private double Fill(double poured,int row,int col,double[,] memo, bool[,] used){
        
        if(used[row,col])return memo[row,col];//return if already calculated, memoization
        if(row == 0 && col == 0){//base case, the topmost glass
            if(poured > 0){
                stored = 1;
                return (poured - 1) / 2;
            }
            return 0;
        }
        double received = 0;//How much do i receive from upper glasses
        if(row - 1 >= 0 && row - 1 >= col)received += Fill(poured,row - 1,col,memo,used);//receive from my upper left glass
        if(row - 1 >=0 && col - 1 >= 0) received += Fill(poured,row - 1,col - 1,memo,used);//receive from my upper right glass


        double take = Math.Min(received,1);//take the minimum between what i received or what can i hold.
        
        stored = take;//save the result
        //(received - take) is what is left and is divided by 2 because it its splitted between the cup of my lower left and the cup of my lower right
        memo[row,col] = (received - take) / 2;//store the result to avoid recalculation
        used[row,col] = true;//marked it as calculated

        return (received - take) / 2;
    }
}
