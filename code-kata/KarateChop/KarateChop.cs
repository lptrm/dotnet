// Source: http://codekata.com/kata/kata02-karate-chop/

namespace KarateChop;
public class KarateChop
{
    public int Chop(int target, int[] array)
    {
        int right = array.Length - 1;
        int left = 0;
        while (left <= right){
            int mid = (left+right) / 2;
            if(array[mid] < target){
                left = mid + 1 ;
            } else if (array[mid] > target){
                right = mid - 1;
            } else {
                return mid;
            }
        }
        return -1;
    }
}
