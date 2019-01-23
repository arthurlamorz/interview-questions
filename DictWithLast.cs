using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ValueWithIndex = System.Tuple<string, long>;
using DictWithIndex = System.Collections.Generic.Dictionary<string, System.Tuple<string, long>>;

// Source:
// https://www.careercup.com/question?id=5702735421243392

// Write a new data structure, "Dictionary with Last" 

// Methods: 
// set(key, value) - adds an element to the dictionary 
// get(key) - returns the element 
// delete(key) - removes the element 
// last() - returns the last key that was added or read. 

// In case a key was removed, last will return the previous key in order.



class DictWithLast {
    DictWithIndex _dict;
    long _max;
    
    public DictWithLast() {
        _dict = new DictWithIndex();
    }
    
    public void set(string key, string value) {
        _max++;
        _dict.Add(key, new ValueWithIndex(value, _max));
    }
                  
    public string get(string key) {
        _max++;
        _dict[key] = new ValueWithIndex(_dict[key].Item1, _max);
        return _dict[key].Item1;
    }
    
    public void delete(string key) {
        _dict.Remove(key);
        _max = _dict.ToList().OrderByDescending(p => p.Value.Item2).First().Value.Item2;
    }
    
    public string last() {
        return _dict.Where(p => p.Value.Item2 == _max).First().Key;
    
    }
    
}

class Solution
{
   
    static void Main(string[] args)
    {
        var theDict = new DictWithLast();
        theDict.set("first", "qwerty");
        theDict.set("second", "haha");
        theDict.set("third", "1233567");
        theDict.set("fourth", "77788899");
        
        Console.WriteLine(theDict.last());
        Console.WriteLine(theDict.get("second"));
        Console.WriteLine(theDict.last());
        Console.WriteLine(theDict.get("third"));
        Console.WriteLine(theDict.last());
        theDict.delete("third");
        Console.WriteLine(theDict.last());
    }
}