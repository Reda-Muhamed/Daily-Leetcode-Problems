public class Solution {
 public bool ContainsDuplicate(int[] nums)
{
    Dictionary<int, int> mp = new Dictionary<int, int>();

    foreach (var item in nums)
    {
        if (mp.ContainsKey(item))
            mp[item]++;
        else
            mp[item] = 1;
    }

    foreach (var kvp in mp)
    {
        if (kvp.Value > 1)
            return true;
    }

    return false;
}

}