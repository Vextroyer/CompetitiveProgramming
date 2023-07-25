// @problem https://leetcode.com/problems/peak-index-in-a-mountain-array/

namespace Competitiva;

class PeakIndexInAMountainArray{
    public int PeakIndexInMountainArray(int[] arr) {
        //This is a binary search problem
        //Similar to the problem of returning the position of a given element in a sorted array.
        //Note that in any mountain array can only exist a peak index, its unique.
        //Note that if the peak index is at K, then arr[k-1] < arr[k] && arr[k] > arr[k + 1]
        //So there exist a unike K that holds arr[k-1] < arr[k] && arr[k] > arr[k + 1]
        //Consider an index J such that J < K, for J holds arr[j-1] < arr[j] && arr[j] < arr[j+1]
        //Consider an index L such that K < L, for L holds arr[l-1] > arr[l] && arr[l] > arr[l+1]
        
        //Arr is guarantee to be a mountain array. This avoid cheking corner cases like mid == 0 || mid == arr.Length - 1
        //because existence of the peak is guaranteed.
        int left = 0;
        int right = arr.Length - 1;
        while(left <= right){
            int mid = (left + right) / 2;
            
            //Consider corner cases when mid = 0 or mid = arr.length - 1

            //it is to the left side of the peak
            if( mid == 0 || (arr[mid - 1] < arr[mid] && arr[mid] < arr[mid + 1]) ){
                left = mid + 1;
            }
            //it is to the right side of the peak
            else if( mid == arr.Length || (arr[mid-1] > arr[mid] && arr[mid] > arr[mid + 1]) ){
                right = mid - 1;
            }
            else{
                //it is a peak
                return mid;
            }
        }
        //Here left >= right, if all goes well they should be equal
        
        //Not necesary, i just put it beacuse of the C# compiler
        return -1;
    }
}