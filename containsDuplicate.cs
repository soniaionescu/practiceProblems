public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        Dictionary<int, int> frequencies = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++){
            if (frequencies.ContainsKey(nums[i])){
                return true;
            }
            else{
                frequencies.Add(nums[i], 1);
            }
        }
        return false;
    }
}
