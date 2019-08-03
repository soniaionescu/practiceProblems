public class Solution {
    public void Rotate(int[] nums, int k) {
        if(k > nums.Length){
            k = k%nums.Length;
        }
        int[] storage = new int[k];
        //fill storage
        for(int i = 0; i < k; i++){
            storage[i] = nums[nums.Length - k + i];
        }
        // move everything to the right k, starting at the end of the elements that haven't been copied
        for(int j = nums.Length - k - 1; j >= 0; j--){
            nums[j+k] = nums[j];
        }
        // now fill in the first k elements 
        for(int l = 0; l < storage.Length; l++){
            nums[l] = storage[l];
        }
    }
}
