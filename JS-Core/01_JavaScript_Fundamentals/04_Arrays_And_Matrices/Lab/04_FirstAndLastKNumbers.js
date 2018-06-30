function printKElements(params) {
    let k = params.splice(0,1);

    console.log((params.slice(0,k)).join(' '));
    console.log((params.slice(-k)).join(' '));
}

printKElements([2, 7, 8, 9]);