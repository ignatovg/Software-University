function processOddNumbers(nums) {
    return nums
        .filter((e,i) => i % 2 !== 0)
        .map(e=>e*2)
        .reverse((a,b)=> b-a)
        .join(' ');
}

console.log(processOddNumbers([10,15,20,25]));