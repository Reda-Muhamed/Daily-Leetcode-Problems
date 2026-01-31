public class Solution {
    public char NextGreatestLetter(char[] letters, char target) {
        Array.Sort(letters);
       
        foreach(var i in letters){
            if(i>target){
               return i;
            }
        }
        return letters[0];
    }
}