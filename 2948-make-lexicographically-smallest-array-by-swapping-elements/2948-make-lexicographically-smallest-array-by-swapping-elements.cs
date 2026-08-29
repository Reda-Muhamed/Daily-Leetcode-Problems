public class Solution {
    public int[] LexicographicallySmallestArray(int[] nums, int limit) {
        int n = nums.Length;
        var arr = new (int value, int index)[n];
        for (int i = 0;i<n; i++){
            arr[i] = (nums[i], i);
        }
        Array.Sort(arr, (a, b) => a.value.CompareTo(b.value));
        // nums → [1,2,0]
        // arr → [(0,2), (1,0), (2,1)]
        int start = 0;
        while (start<n) {

            int end = start;

            // now we divide into groups
            while(end + 1 < n && arr[end + 1].value - arr[end].value <= limit) {
                end++;
            }

             // Get original indices of this group
            List<int> indices = new List<int>();

            for (int i = start; i <= end; i++) {
                indices.Add(arr[i].index);
            }

            indices.Sort();

            // Values are already sorted because arr is sorted
            for (int i = 0; i < indices.Count; i++)
            {
                nums[indices[i]] = arr[start + i].value;
            }

            start = end + 1;
        }
        return nums;

    }
}