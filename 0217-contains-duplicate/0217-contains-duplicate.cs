public class Solution {
 public bool ContainsDuplicate(int[] nums)
{
    HashSet<int> seen = new HashSet<int>();

    foreach (var num in nums)
    {
        if (seen.Contains(num))
            return true;
        seen.Add(num);
    }

    return false;
}


}