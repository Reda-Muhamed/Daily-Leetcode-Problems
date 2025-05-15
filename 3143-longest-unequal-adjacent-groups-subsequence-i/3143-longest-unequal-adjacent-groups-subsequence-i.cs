using System;
using System.Collections;
public class Solution {
    public IList<string> GetLongestSubsequence(string[] words, int[] groups) {
        int n = groups.Length;
         Stack<int> s = new Stack<int>(); // store groups val
         List<string>res = new List<string>();   
        s.Push(groups[0]);
        res.Add(words[0]);    
        for(int i =1 ;i<n;i++){
            if(groups[i]!=s.Peek()){
                 s.Push(groups[i]);
                  res.Add(words[i]);    
            }
        }
        return res;
    }
}