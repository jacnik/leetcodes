// Solution to: https://leetcode.com/problems/best-time-to-buy-and-sell-stock/

static int MaxProfit(int[] prices) {

    var max_profit = 0;
    var current_min = prices[0];
    foreach (var price in prices.Skip(1))
    {
        max_profit = Math.Max(max_profit, price - current_min);
        current_min = Math.Min(current_min, price);
    }

    return max_profit;
}

var testA = MaxProfit([7,1,5,3,6,4]);
var testB = MaxProfit([7,6,4,3,1]);

var expectedA = 5; // buy on 1 (1) and sell on 4(6)
var expectedB = 0; // No transactions

Console.WriteLine($"Test A: {testA} => {expectedA}");
Console.WriteLine($"Test B: {testB} => {expectedB}");


