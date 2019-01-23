using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// Source:
// https://www.careercup.com/question?id=5703421944922112

// Question:
// ####################
// find all numbers the sum of cube of each digits is the number itself 
// ex:153=1^3+5^3+3^3

class Solution
{
    static void Main(string[] args)
    {
        long z = 7493871987;
        long result = 0;
        
        while(z/10 > 0) {
            var i = z%10;
            result += i*i*i;
            z /= 10;
        }
        
        Console.WriteLine();
        Console.WriteLine(result);       
    }  
}
