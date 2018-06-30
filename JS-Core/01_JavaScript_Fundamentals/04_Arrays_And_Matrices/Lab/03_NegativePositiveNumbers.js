function modifyArr(params) {
    let result = [];
    for (let elem of params) {
            if(elem < 0){
                result.unshift(elem);
            }else {
                result.push(elem)
            }
    }
    return result.join('\n');
}

console.log(modifyArr([7, -2, 8, 9]));