var findLengthOfShortestSubarray = function(arr) {
    let n = arr.length;
    let left = 0, right = n - 1;

    // Find the longest non-decreasing prefix
    while (left + 1 < n && arr[left] <= arr[left + 1]) {
        left++;
    }

    // If the entire array is already sorted
    if (left === n - 1) return 0;

    // Find the longest non-decreasing suffix
    while (right > 0 && arr[right - 1] <= arr[right]) {
        right--;
    }

    // Consider removing the middle portion entirely
    let result = Math.min(n - left - 1, right);

    // Try merging the prefix and suffix
    let i = 0, j = right;
    while (i <= left && j < n) {
        if (arr[i] <= arr[j]) {
            result = Math.min(result, j - i - 1);
            i++;
        } else {
            j++;
        }
    }

    return result;
};
