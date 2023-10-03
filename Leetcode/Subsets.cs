/*
https://leetcode.com/problems/subsets-ii
https://leetcode.com/problems/subsets

Generate all multisets from a given multiset
*/

class Subset{
    public static IList<IList<int>> GenerateSubsets(int[] nums){
        // -10 <= nums[i] <= 10
        // 0 <= nums[i] + 10 <= 20
        for(int i=0;i<nums.Length;++i)nums[i] += 10;
        const int MaxA = 21;
        int[] eclass = new int[MaxA];//How many repetition are from this elements
        foreach(int e in nums)++eclass[e];
        int[] taken = new int[MaxA];

        IList<IList<int>> store = new List<IList<int>>();//For storing the subsets
        Bactrack(0,eclass,taken,store);
        return store;
    }
    //element represents the actual index on eclass
    private static void Bactrack(int element,int[] eclass,int[] taken,IList<IList<int>> store){
        if(element >= eclass.Length){
            store.Add(Rebuild(taken));
            // foreach(var i in Rebuild(taken))Console.Write(i + " ");
            // Console.WriteLine();
            return;
        }

        //How many elements will i take from this equivalence class
        for(int rep=0;rep<=eclass[element];++rep){
            taken[element] = rep;
            Bactrack(element+1,eclass,taken,store);
        }
    }

    private static List<int> Rebuild(int[] taken){
        List<int> l =  new List<int>();
        for(int i=0;i<taken.Length;++i){
            int rep = taken[i];
            while(rep > 0){
                --rep;
                l.Add(i - 10);//Because the numbers are added 10
            }
        }
        return l;
    }
}