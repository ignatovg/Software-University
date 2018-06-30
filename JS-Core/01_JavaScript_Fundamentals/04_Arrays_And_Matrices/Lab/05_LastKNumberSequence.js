function generateSequence(n,k) {
    let sum = 0;
    let result = [];
    result.push(1);

    for (let i = 0; i < n-1; i++) {
        sum = sumNumbers(result.slice(-k));
        result.push(sum);
    }

    console.log(result.join(' '));

    function sumNumbers(arr) {
        let sum = 0;
        for(let elem of arr){
            sum+= elem;
        }
        return sum;
    }
}

generateSequence(8,2);