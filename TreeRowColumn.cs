using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TripleT =  System.Tuple<double, int, int>;

// Source:
// https://www.careercup.com/question?id=5709428993556480

// Given the root of a binary tree, print the nodes column wise and row wise.
// ..............6
// ............/....\
// ...........9......4
// ........../..\......\
// .........5....1.....3
// ..........\........./
// ...........0.......7
// The answer would be 5 9 0 6 1 4 7 3.


class TreeNode {
    public TreeNode left;
    public TreeNode right;
    public double theValue;
    
    public TreeNode(double v) {
        this.theValue = v;   
    }
    
}

class Solution
{
    public static List<TripleT> searchTree(TreeNode tree, List<TripleT> list, int row, int column)
    {
        var resultList = new List<TripleT>();
        
        if (tree.left != null)
            resultList.AddRange(Solution.searchTree(tree.left, list, row+1, column-1));
        
        resultList.Add(new TripleT(tree.theValue, row, column));
        
        if (tree.right != null)
            resultList.AddRange(Solution.searchTree(tree.right, list, row+1, column+1));
        return resultList;
    
    }
    
    static void Main(string[] args)
    {
        var tree = new TreeNode(6);
        tree.left = new TreeNode(9);
            tree.left.left = new TreeNode(5);
                tree.left.left.right = new TreeNode(0);
            tree.left.right = new TreeNode(1);
        tree.right = new TreeNode(4);
            tree.right.right = new TreeNode(3);
                tree.right.right.left = new TreeNode(7);
        
        var orderList = new List<TripleT>();
        
        
        orderList = Solution.searchTree(tree, orderList, 0, 0);
        
        Console.WriteLine("By Column: ");
        
        orderList
            .OrderBy(t => t.Item3)
            .ThenBy(t => t.Item2)
            .ToList().ForEach(t => Console.Write(t.Item1 + " "));
        
         Console.WriteLine("\nBy Row: ");
        
        orderList
            .OrderBy(t => t.Item2)
            .ThenBy(t => t.Item3)
            .ToList().ForEach(t => Console.Write(t.Item1 + " "));
        
    }
}
