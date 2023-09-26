/*
https://leetcode.com/problems/generate-parentheses/

Generate all combinations of well formed parentheses, given n pairs of parentheses.
*/
static class GenerateParentheses{
    static public IList<string> GenerateParenthesis(int n) {
        List<string> storage = new List<string>();
        char[] paren = new char[2 * n];
        GenerateParenthesis(n,n,0,paren,storage);
        return storage;
    }
    //Opening indicates the amount of opening parentheses
    //Closing indicates the amount of closing parentheses
    //pos indicates the position on actual where the next parenthes goes
    //actual is the string of parentheses eing builded
    //storage is for storing the parentheses
    static private void GenerateParenthesis(int opening,int closing,int pos,char[] actual,List<string> storage){
        if(opening < 0 || closing < 0)return;
        //All parentheses have been placed
        if(pos == actual.Length){
            storage.Add(new string(actual));
            return;
        }

        //try with an opening parenthesis
        actual[pos] = '(';
        GenerateParenthesis(opening-1,closing,pos+1,actual,storage);
        //try with a closing parenthesis, but only if closing it will not unbalance the string
        if(opening <= closing - 1){
            actual[pos] = ')';
            GenerateParenthesis(opening,closing - 1,pos+1,actual,storage);
        }
    }
}