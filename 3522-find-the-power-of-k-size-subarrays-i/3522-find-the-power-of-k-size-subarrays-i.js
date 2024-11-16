/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number[]}
 */
var resultsArray = function(nums, k) {
   let n = nums.length;
    let results = [];
    
    for (let i = 0; i <= n - k; i++) {
        let isConsecutiveAndSorted = true;
        for (let j = i + 1; j < i + k; j++) {
            if (nums[j] !== nums[j - 1] + 1) {
                isConsecutiveAndSorted = false;
                break;
            }
        }
        if (isConsecutiveAndSorted) {
            results.push(Math.max(...nums.slice(i, i + k)));
        } else {
            results.push(-1);
        }
    }
    
    return results;
};
