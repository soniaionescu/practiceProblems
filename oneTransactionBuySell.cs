public class Solution {
    public int MaxProfit(int[] prices) {
        if(prices.Length <= 1){
            return 0;
        }
        int minSoFar = prices[0];
        int maxProfit = 0;
        int currentProfit;
        for(int i = 1; i < prices.Length; i++){
            if(prices[i] < minSoFar){
                minSoFar = prices[i];
            }
            else{
                currentProfit = prices[i] - minSoFar;
                if(currentProfit > maxProfit){
                    maxProfit = currentProfit;
                }
            }
        }
        return maxProfit;
    }
}
