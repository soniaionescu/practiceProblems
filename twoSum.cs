public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> seen = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++){
            int goal = target - nums[i];
            if (seen.ContainsKey(goal))        
                return new int[] {seen[goal], i};            
            if (!seen.ContainsKey(nums[i]))
                seen.Add(nums[i], i); 
            
        }
        return new int[] {};
    }
}
