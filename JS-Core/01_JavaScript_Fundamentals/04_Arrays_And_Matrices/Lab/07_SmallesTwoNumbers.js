function getSmallestTwoNumbers(nums) {
    return nums
        .sort((a, b)=>a-b)
        .splice(0,2)
        .join(' ');
}

console.log(getSmallestTwoNumbers([30, 15, 50, 5]));