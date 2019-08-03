public class Solution {
    public int SingleNumber(int[] nums) {
        Dictionary<int, int> frequencies = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++){
            if(frequencies.ContainsKey(nums[i])){
                frequencies[nums[i]] += 1;
            }
            else{
                frequencies.Add(nums[i], 1);
            }
        }
        foreach(KeyValuePair<int, int> entry in frequencies){
            if(entry.Value != 2){
                return entry.Key;
            }
        }
        return 0;
    }
}
