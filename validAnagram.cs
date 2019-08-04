public class Solution {
    public bool IsAnagram(string s, string t) {
        char[] sc = s.ToCharArray();
        char[] st = t.ToCharArray();
        if(sc.Length != st.Length){
            return false;
        }
        // make dictionaries of frequencies
        Dictionary<char, int> freqS = new Dictionary<char, int>();
        Dictionary<char, int> freqT = new Dictionary<char, int>();
        // populate the dictionaries
        for(int i = 0; i < sc.Length; i++){
            if (freqT.ContainsKey(st[i])){
                freqT[st[i]]++;
            }
            if (freqS.ContainsKey(sc[i])){
                freqS[sc[i]]++;
            }
            if(!freqS.ContainsKey(sc[i])){
                freqS.Add(sc[i], 1);
            }
            if(!freqT.ContainsKey(st[i])){
                freqT.Add(st[i], 1);
            }
        }
        // check that each character has the same frequency
        foreach(KeyValuePair<char, int> entry in freqS){

            if(!freqT.ContainsKey(entry.Key)){
                return false;
            }
            else if(entry.Value != freqT[entry.Key] ){
                return false;
            }
        }
        return true;
    }
}
