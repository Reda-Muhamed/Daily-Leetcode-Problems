/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var shortestSubarray = function(nums, k) {
    let n = nums.length;
    let prefixSum = [0]; // Prefix sum array
    for (let num of nums) {
        prefixSum.push(prefixSum[prefixSum.length - 1] + num);
    }

    let deque = []; // Deque to store indices of prefixSum
    let minLength = Infinity; // Minimum length of the subarray

    for (let i = 0; i <= n; i++) {
        // Check if the current subarray satisfies the condition
        while (deque.length > 0 && prefixSum[i] - prefixSum[deque[0]] >= k) {
            minLength = Math.min(minLength, i - deque.shift());
        }

        // Maintain monotonicity of the deque
        while (deque.length > 0 && prefixSum[i] <= prefixSum[deque[deque.length - 1]]) {
            deque.pop();
        }

        deque.push(i); // Add the current index
    }

    return minLength === Infinity ? -1 : minLength;
};
