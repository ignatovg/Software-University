function sumFirstLastElement(params) {
    let sum = Number(params[0]) + Number(params[params.length-1]);
    return sum;


}


console.log(sumFirstLastElement(['20','30','40']));