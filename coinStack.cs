using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// Source
// https://www.careercup.com/question?id=5638939143045120

// Question
// #################################
// Given many coins of 3 different face values, print the combination sums of the coins up to 1000. Must be printed in order. 
//
// eg: coins(10, 15, 55) 
// print: 
// 10 
// 15 
// 20 
// 25 
// 30 
// . 
// . 
// . 
// 1000


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
