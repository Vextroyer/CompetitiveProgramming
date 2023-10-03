/*
https://leetcode.com/problems/combination-sum

Let candidates be a1 , a2 ... , a30
Let target be P

2 <= ai <= 40
1 <= P <= 40

The combination sum problem can stated as 
which are the different ki such that:

k1a1 + k2a2 + ... + k30a30 = P

(k1,k2,...,k30) = k can be considered a vector and ai the coefficients

So the answer is how many different vectors satisfy the equality.

For all i:
0 <= ki <= [P / ai]
Where [x] is the integer part of x.

For example for P = 40 and a1 = 2 k1 has 21 possibilities
... And so on.
*/
class CombinationSum{
    public static List<List<int>> Combinations(int[] a,int P){
        Array.Sort(a);//Guarntee a0 < a1 < ... < ai < ... < a29

        int[] k = new int[a.Length];//the vector, starts on 0
        
        List<List<int>> storage = new List<List<int>>();
        Backtrack(k,a,P,0,storage);
        return storage;
    }
    private static void Backtrack(int[] k,int[] a,int P,int pos,List<List<int>> storage){
        //P >=0 always
        if(P == 0){
            storage.Add(Rebuild(k,a));
            return;
        }
        if(pos >= k.Length)return;

        for(int kValue = 0;kValue <= P / a[pos];++kValue){
            //For every possible value of K
            k[pos] = kValue;
            Backtrack(k,a,P - kValue * a[pos],pos+1,storage);
        }
    }
    //Builds a sequence
    private static List<int> Rebuild(int[] k,int[] a){
        List<int> s = new List<int>();
        for(int i=0;i<k.Length;++i){
            int rep = k[i];
            while(rep > 0){
                --rep;
                s.Add(a[i]);
            }
        }
        return s;
    }
}