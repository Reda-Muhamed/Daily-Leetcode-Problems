/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public int[] NodesBetweenCriticalPoints(ListNode head) {
        var nums = new List<int>();
 
        while(head is not null) {
            nums.Add(head.val);
            head = head.next;
        }
        int[] numsArray = nums.ToArray();
        int len = numsArray.Length;
        var num = new (int value, char minormax)[len];
        num[0] = (numsArray[0],'-');
        for (int i = 1 ;i < len - 1 ;i++){
            if(numsArray[i]>numsArray[i-1] && numsArray[i]>numsArray[i+1]) {
                num[i] = (numsArray[i] , 'x');
            } else if(numsArray[i]<numsArray[i-1] && numsArray[i]<numsArray[i+1]) {
                num[i] = (numsArray[i] , 'n');
            } else {
                num[i] = (numsArray[i], '-');
            }
        }
        num[len-1] = (numsArray[0],'-');
        int min = 100000;
        int max = -1;
        var temp = new List<int>();
        for(int i = 1;i< len - 1;i++){
            if(num[i].minormax == 'x' || num[i].minormax == 'n') {
                temp.Add(i);
            }
        }
        if (temp.Count < 2)
            return [-1, -1];

        temp.Sort();
        max = temp[temp.Count - 1] - temp[0];
        for(int i = 0 ;i < temp.Count -1;i++){
            int tt = temp[i+1] - temp[i];
            min = Math.Min(min, tt);
        }
        if(min != 100000 && max != -1)
            return [min,max];
        else return [-1,-1];
    }
}