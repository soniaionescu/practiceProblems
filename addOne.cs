public class Solution {
    public int[] PlusOne(int[] digits) {
        // get the number which will be correct
        Console.WriteLine(digits.Length);
        for(int i = digits.Length-1; i>=0; i--){
            bool carry = false;
            Console.WriteLine(digits[i]);
            if(digits[i] < 9){
                digits[i] = digits[i]+1;
                break;
            }
            else if (digits[i] == 9){
                digits[i] = 0;
                carry = true;
            }
            if (digits[i] == 0 && i == 0){
                int[] newdigits = new int[digits.Length+1];
                for(int j = 0; j < newdigits.Length; j++){
                    if(j == 0){
                        newdigits[j] = 1;
                    }
                    else{
                        newdigits[j] = 0;
                    }
                }
                return newdigits;
            }
        }
        return digits;
    }
}
