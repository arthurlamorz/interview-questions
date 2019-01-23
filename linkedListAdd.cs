using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// Source:
// https://www.careercup.com/question?id=5199653285396480

// Question:
// ####################
// You are given two non-empty linked lists representing two non-negative integers. 
// The most significant digit comes first and each of their nodes contain a single digit. 
// Add the two numbers and return it as a linked list.

class Solution
{
    static void Main(string[] args)
    {
        var l1 = new List<int>();
        var l2 = new List<int>();

        // 98765400 + 13699075 = 112464475
        
        l1.Add(9); 
        l1.Add(8);
        l1.Add(7);
        l1.Add(6);
        l1.Add(5);
        l1.Add(4);
        l1.Add(0);
        l1.Add(0);
        
        l2.Add(1);
        l2.Add(3);
        l2.Add(6);
        l2.Add(9);
        l2.Add(9);
        l2.Add(0);
        l2.Add(7);
        l2.Add(5);
        
        l1.Reverse();
        l2.Reverse();
        
        var tempList = new List<int>();
        
        for (int i=0; i<l1.Count; i++) {
            if (i >= l2.Count)
                tempList.Add(l1[i]);
            else
                tempList.Add(l1[i] + l2[i]);
        }
        
        for (int i=0; i< tempList.Count; i++) {
            if (tempList[i] >= 10)
            {
                tempList[i] -= 10;
                if (i == tempList.Count - 1)
                    tempList.Add(1);
                else
                    tempList[i+1] += 1;
            }
        }
        
        tempList.Reverse();
        tempList.ToList().ForEach(x => Console.Write(x));
    }  
}


