function rotateArray(params) {
    let rotations = params.pop();

    for (let i = 0; i < rotations % params.length ; i++) {
        let temp = params.pop();
        params.unshift(temp);
    }

    return params.join(' ');
}