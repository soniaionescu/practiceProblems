public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        Dictionary<int, int> contains1 = new Dictionary<int, int>();
        Dictionary<int, int> contains2 = new Dictionary<int, int> ();
        int intersectionLength = 0;
        // create two maps from int -> frequency
        for(int i = 0; i < nums1.Length; i++){
            if(!contains1.ContainsKey(nums1[i])){
                contains1.Add(nums1[i], 1);
            } 
            else if(contains1.ContainsKey(nums1[i])){
                contains1[nums1[i]] ++;
            }
        }
        for(int j = 0; j < nums2.Length; j++){
            if(!contains2.ContainsKey(nums2[j])){
                contains2.Add(nums2[j], 1);
            } 
            else if(contains2.ContainsKey(nums2[j])){
                contains2[nums2[j]] ++;
            }
        }
        List<int> intersection = new List<int>();
        foreach(KeyValuePair<int, int> entry in contains1){
            if(contains2.ContainsKey(entry.Key)){
                for(int k = 0; k < Math.Min(entry.Value, contains2[entry.Key]); k++){
                    intersection.Add(entry.Key);
                }
            } 
        }
        return intersection.ToArray();
    }
}
