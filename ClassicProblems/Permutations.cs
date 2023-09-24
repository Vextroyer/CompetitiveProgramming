/*
Given an integer n generate all the permutations of
numbers 1, 2 ... n
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
}