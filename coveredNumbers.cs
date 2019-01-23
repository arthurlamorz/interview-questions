using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// Source:
// https://www.careercup.com/question?id=5687609083297792

// Given a list of arrays of time intervals, write a function that calculates the total amount of time covered by the intervals. 
// For example: 
// input = [(1,4), (2,3)] 
// return 3 
// input = [(4,6), (1,2)] 
// return 3 
// input = {{1,4}, {6,8}, {2,4}, {7,9}, {10, 15}} 
// return 11



class Solution
{
    static void Main(string[] args)
    {
        var timeIntervals = new List<Tuple<double, double>>();
        timeIntervals.Add(new Tuple<double, double>(1,4));
        timeIntervals.Add(new Tuple<double, double>(6,8));
        timeIntervals.Add(new Tuple<double, double>(2,4));
        timeIntervals.Add(new Tuple<double, double>(7,9));
        timeIntervals.Add(new Tuple<double, double>(11,15));
        timeIntervals.Add(new Tuple<double, double>(13,18));
        timeIntervals.Add(new Tuple<double, double>(4,6));
       
        var combinedIntervals = 
        timeIntervals.Aggregate(
            new List<Tuple<double, double>>(),
            (a, t) => {
                if (a.Count == 0) {
                    a.Add(t);
                    return a;
                }
                // if inside any of interval
                if (a.Any(i => i.Item1 <= t.Item1 && i.Item2 >= t.Item2))
                    return a;
                
                var includedList = a
                    .Where(i => !(i.Item2 < t.Item1 || t.Item2 < i.Item1))
                    .OrderBy(i => i.Item1);
                               
                if (includedList.ToList().Count == 0){
                    a.Add(t);
                    return a;
                }
                var newTuple = new Tuple<double, double>(
                    includedList.First().Item1 < t.Item1? includedList.First().Item1 : t.Item1,
                    includedList.Last().Item2 > t.Item2? includedList.Last().Item2 : t.Item2);
                
                a.RemoveAll(i => includedList.Contains(i));
                a.Add(newTuple);
                return a;                 
            }
        );
        
        Console.WriteLine(combinedIntervals.Aggregate(0.0, (a, i) => a + i.Item2 - i.Item1));    
    }
}
