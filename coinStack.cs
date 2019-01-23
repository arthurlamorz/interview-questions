using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// To execute C#, please define "static void Main" on a class
// named Solution.

class Solution
{
    
    static void Main(string[] args)
    {
        int[] coinTypes = {10, 15, 55};   
        bool[] coinMap = new bool[1000];
        
        for (int i = 0; i<1000; i++) {
        
            if(coinTypes.ToList().Any(x => (i==x) || ((i >= x) && coinMap[i-x] == true))) {
                
                coinMap[i] = true;
                Console.WriteLine(i);
            }
        }
    }
}
