/*
1) Given an integer n generate all the permutations of
numbers 1, 2 ... n

https://leetcode.com/problems/permutations-ii
2) Given an array that might contain duplicates return all possible permutations of the
given array.
The key observation on this problem is that on position k you can have several options of putting
an element but if some element is repeated it just has to be putted once.
Position  0  1  2
Element   1  2  1
Permutations:   By position         By value
                0 1 2               1 2 1
                0 2 1               1 1 2
                1 0 2               2 1 1
                1 2 0               2 1 1//  Repeated
                2 0 1               1 1 2//    ""
                2 1 0               1 2 1//    ""

A tree of decision
[1 1][2] -> [1][2] -> [2] -> Yields 1 1 2
                   -> [1] -> Yields 1 2 1
         -> [1 1]  -> [1] -> Yields 2 1 1
Where [1 1] , [2] are equivalence classes, all elements who belong to the same
class are considered equivalent. Therefore on each step the decision is from what class
do i chose instead of what element i choose.
*/
static class Permutations{
    public static void GeneratePermutations(int n){
        bool[] used = new bool[n];//This is for having account of what elements have been used.
        Stack<int> s = new Stack<int>();//This stack is for storing the elements
        GeneratePermutations(n,used,s);
    }
    static void GeneratePermutations(int step,bool[] used,Stack<int> s){
        if(step<=0){
            foreach(int x in s.ToArray())Console.Write(x + " ");
            Console.WriteLine();
            return;
        }
        for(int i=0;i<used.Length;++i){
            if(!used[i]){
                used[i] = true;
                s.Push(i+1);
                GeneratePermutations(step-1,used,s);
                s.Pop();
                used[i] = false;
            }
        }
    }

    //Generate all permutations but in order
    public static void GeneratePermutationsInOrder(int n){
        bool[] used = new bool[n];
        int[] elements = new int[n];//This is where the elements are going to be
        GeneratePermutationsInOrder(0,used,elements);
    }
    /*
    pos represents the position on elements where the actual element shold be.
    the recursio stops after pos is equal to the size of elements because
    that means n elements has been used
    */
    static void GeneratePermutationsInOrder(int pos,bool[] used,int[] elements){
        if(pos >= used.Length){
            foreach(int x in elements)Console.Write(x + " ");
            Console.WriteLine();
            return;
        }
        for(int i=0;i<used.Length;++i){
            if(!used[i]){
                used[i] = true;
                elements[pos] = i + 1;
                GeneratePermutationsInOrder(pos + 1,used,elements);
                used[i] = false;
            }
        }
    }

    /*
    Generate all unique permutations of some given elements where can be repeated elements
    */
    public static List<List<int>> GenerateUniquePermutations(int[] nums){
        // -10 <= nums[i] <= 10
        //  0  <= nums[i] + 10 <= 20
        for(int i=0;i<nums.Length;++i)nums[i] += 10;

        //Create the equivalence classes
        int[] eclass = new int[21];
        foreach(int e in nums)++eclass[e];

        List<List<int>> storage = new List<List<int>>();//for storing the generated permutations
        int[] permutation = new int[nums.Length];//For storing the current permutation

        GenerateUniquePermutations(0,permutation,storage,eclass);
        return storage;
    }
    //permutation is mutable
    //storage is mutable
    //eclass is mutable but will mantain its initial state
    static void GenerateUniquePermutations(int pos,int[] permutation,List<List<int>> storage,int[] eclass){
        if(pos >= permutation.Length){
            //Process current permutation
            storage.Add(new List<int>(permutation));//print after completition
            // foreach(int t in permutation)Console.Write(t + " ");
            // Console.WriteLine();
            return;
        }

        for(int i=0;i<eclass.Length;++i){
            if(eclass[i] == 0)continue;//No more elements are left on this class

            permutation[pos] = i - 10;//i its the number that represents the equivalence class, its added 10 because it could be negative
            --eclass[i];
            GenerateUniquePermutations(pos + 1,permutation,storage,eclass);
            ++eclass[i];
        }
    }
}