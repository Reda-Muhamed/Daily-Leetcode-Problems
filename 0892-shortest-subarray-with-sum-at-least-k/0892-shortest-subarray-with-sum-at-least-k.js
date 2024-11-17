/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var shortestSubarray = function(nums, k) {
    let n = nums.length;
    let prefixSum = [0];
    for (let num of nums) {
        prefixSum.push(prefixSum[prefixSum.length - 1] + num);
    }

    let deque = []; 
    let res = Infinity;

    for (let i = 0; i <= n; i++) {
        while (deque.length > 0 && prefixSum[i] - prefixSum[deque[0]] >= k) {
            res = Math.min(res, i - deque.shift());
        }
        while (deque.length > 0 && prefixSum[i] <= prefixSum[deque[deque.length - 1]]) {
            deque.pop();
        }

        deque.push(i);
    }

    return res === Infinity ? -1 : res;
};
