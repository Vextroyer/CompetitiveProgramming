/*
https://leetcode.com/problems/gray-code
*/
class GrayCode{
    /*
    After trial and error i found a way of constructing a GrayCode.
    Starting from a 0 on the first position, keeping track of the numbers used,
    the next number to use is selected by flipping a bit from the previous number
    on a way that the newly generated number isnt used.
    
    Time complexity O(nlogn), specifically O(16n)
    Space complexity O(n)
    */
    public static int[] GenerateGrayCode(int n){
        int[] code = new int[1 << n];
        bool[] used = new bool[1 << n];

        int start = 0;
        code[0] = 0;
        used[0] = true;
        for(int i=1;i<code.Length;++i){
            for(int bit = 0;bit < 32;++bit){
                int next = start ^ (1 << bit);//Alternate the ith bit of start
                if(!used[next]){
                    start = next;
                    used[start] = true;
                    code[i] = start;
                    break;
                }
            }
        }
        
        return code;
    }
    // This implementation gives tle
    /*public static int[] GenerateGrayCode(int n){
        int[] code = new int[1 << n];//The gray code
        code[0] = 0;

        bool[] used = new bool[1 << n];//Wheter the element has been chosed or not
        used[0] = true;

        Backtrack(1,code,used);
        return code;
    }
    private static bool Backtrack(int pos,int[] code,bool[] used){
        if(pos == used.Length - 1){
            //the last element
            int option = -1;//This is the only remaining element
            for(int i=1;i<used.Length;++i){
                if(!used[i]){
                    option = i;
                    break;
                }
            }
            if(option == -1)throw new Exception("Bad implementation");
            if(SingleBitDifference(option,code[pos - 1]) &&
                SingleBitDifference(option,0)){
                    code[pos] = option;
                    return true;
                }
            return false;
        }
        for(int i=1;i<used.Length;++i){
            if(used[i])continue;
            if(!SingleBitDifference(code[pos - 1],i))continue;//Only visit valid states
            code[pos] = i;
            used[i] = true;
            if(Backtrack(pos+1,code,used))return true;
            used[i] = false;
        }
        return false;
    }
    //Returns true wheter two numbers differ by only 1 bit on their binary representation
    public static bool SingleBitDifference(int a,int b){
        int x = a ^ b;
        // for(int i=0;i<32;++i)if(x == (1 << i))return true;
        // return false;
        return x != 0 && (x & (x - 1)) == 0;
    }
    */
}
