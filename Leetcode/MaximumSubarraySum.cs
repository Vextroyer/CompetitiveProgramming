// @problem https://leetcode.com/problems/maximum-subarray/description/

//Given an integer array nums, find the subarray with the largest sum, and return its sum.

public class Solution {
    public int MaxSubArray(int[] nums) {
        return MaximumSumSubarrayLog(0,nums.Length,nums);
    }
    //[l,r)
    private int MaximumSumSubarrayLog(int l,int r, int[] A){
        if(r - l == 1)return A[l];//Size 1
        int middle = (l + r) / 2;
        
        int sumMiddle = A[middle] + SumFromMiddleToLeft(l,middle,A) + SumFromMiddleToRight(middle,r,A);

        int L = MaximumSumSubarrayLog(l,middle,A);
        int R = MaximumSumSubarrayLog(middle,r,A);

        return Math.Max(Math.Max(L,R),sumMiddle);
    }

    //Calculate the maximum sum from the middle position to the left position on A.
    private int SumFromMiddleToLeft(int l,int middle,int[] A){
        //l <= middle
        int MaxSum = 0;
        int CumulativeSum = 0;
        for(int i=middle-1;i>=l;--i){
            CumulativeSum += A[i];
            MaxSum = Math.Max(MaxSum,CumulativeSum);
        }
        return MaxSum;
    }
    //Calculate the maximum sum from the middle position to the right position on A.
    private int SumFromMiddleToRight(int middle,int r,int[] A){
        //middle <= r
        int MaxSum = 0;
        int CumulativeSum = 0;
        for(int i=middle+1;i<r;++i){
            CumulativeSum += A[i];
            MaxSum = Math.Max(MaxSum,CumulativeSum);
        }
        return MaxSum;
    }
}
