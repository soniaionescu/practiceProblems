public class Solution {
    public void MoveZeroes(int[] nums) {
        int numberZeros = 0;
        for(int i = 0; i < nums.Length; i++){
            if(nums[i] != 0){
                nums[i-numberZeros] = nums[i];
            }
            if(nums[i] == 0){
                numberZeros++;
            }
        }
        for(int j = nums.Length-numberZeros; j < nums.Length; j++){
            nums[j] = 0;
        }
    }
}
