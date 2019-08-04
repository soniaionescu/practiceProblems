public class Solution {
    public int FirstUniqChar(string s) {
        char[] sc = s.ToCharArray();
        Dictionary<char, int> freq = new Dictionary<char, int>();
        for(int i = 0; i < sc.Length; i++){
            if(!freq.ContainsKey(sc[i])){
                freq.Add(sc[i], 1);
            }
            else{
                freq[sc[i]]++;
            }
        }
        for(int j = 0; j < sc.Length; j++){
            if(freq[sc[j]] == 1){
                return j;
            }
        }
        return -1;
    }
}
