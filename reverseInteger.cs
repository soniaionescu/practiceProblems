public class Solution {
    public int Reverse(int x) {
        long shortNumber = x;
        if(x<0){
            shortNumber = shortNumber*(-1);
        }
        int numberDigits = (int) Math.Floor(Math.Log10(shortNumber)+1);
        if(numberDigits == 1){
            return x;
        }
        else{
            long newNumber = 0;
            int newNumberInt = 0;
            for(int i = numberDigits; i >= 1; i--){
                newNumber += shortNumber%10*((int) Math.Pow(10, i-1));
                shortNumber = shortNumber/10;
                if(newNumber > Int32.MaxValue){
                    return 0;
                }
                else{
                    newNumberInt = (int) newNumber;
                }
            }
            if(x<0){
                return newNumberInt*(-1);
            }
            else{
              return newNumberInt;  
            }
            
        }
    }
}
