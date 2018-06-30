function printNthElementFromArr(params) {
    let n = Number(params.pop());

    for (let i = 0; i < params.length; i+=n) {
        console.log(params[i]);
    }
}

printNthElementFromArr([5,20,31,4,20,2]);