/*
https://leetcode.com/problems/combination-sum-ii

A variation of problem 1.
*/
class CombinationSumII{
    private const int MaxA = 51;
    public static List<List<int>> Combinations(int[] a,int P){

        int[] k = new int[MaxA];//How many repetitions from this element are
        foreach(int e in a)++k[e];

        int[] current = new int[MaxA];//How many times this element is on the solution
        
        List<List<int>> storage = new List<List<int>>();
        Backtrack(current,k,P,0,storage);
        return storage;
    }
    private static void Backtrack(int[] current, int[] k,int P,int element,List<List<int>> storage){
        
        if(P == 0){
            storage.Add(Rebuild(current));
            return;
        }
        
        if(element >= k.Length)return;
        
        for(int rep = 0;rep <= k[element] && element * rep <= P;++rep){
            //How many times will be the element choosed
            current[element] += rep;
            Backtrack(current,k,P - element * rep,element + 1,storage);
            current[element] -= rep;
        }
    }
    //Builds a sequence
    private static List<int> Rebuild(int[] current){
        List<int> s = new List<int>();
        for(int i=0;i<current.Length;++i){
            int rep = current[i];
            while(rep > 0){
                --rep;
                s.Add(i);
            }
        }
        return s;
    }
}