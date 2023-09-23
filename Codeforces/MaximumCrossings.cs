// https://codeforces.com/problemset/problem/1676/H2

/*
Let i,j be the position of two segments such that i < j.
Let ai be the position where the line from segment i ends.
Intersection condition:
    No intersection: ai < aj
    Intersection: ai = aj
    Intersection: ai > aj
i,j intercept if and only if ai >= aj

So the problem is to find the how many inversions are.
This can be done with a variation of the merge sort.
*/

static class MaximumCrossings{
    public static long MaxCross(int[] A){
        return MergeSortCount(0,A.Length,A);
    }
    static long MergeSortCount(int l,int r,int[] A){
        if(r - l <= 1)return 0;//A single element has no inversions

        int mid = (l + r) / 2;
        
        //Sort step
        long inversions = MergeSortCount(l,mid,A) + MergeSortCount(mid,r,A);

        //Merge step
        int[] left = new int[mid - l];
        for(int i=l;i<mid;++i)left[i - l] = A[i];

        int[] right = new int[r - mid];
        for(int i=mid;i<r;++i)right[i - mid] = A[i];

        int iL = 0;//Index on left array
        int iR = 0;//index on right array
        int iA = l;//index on array A
        while(iL < left.Length && iR < right.Length){
            if(left[iL] < right[iR]){
                A[iA] = left[iL];
                ++iL;
            }
            else{
                inversions += left.Length - iL;
                A[iA] = right[iR];
                ++iR;
            }
            ++iA;
        }
        while(iL < left.Length){
            A[iA++] = left[iL++];
        }
        while(iR<right.Length){
            A[iA++] = right[iR++];
        }

        return inversions;
    }
}
