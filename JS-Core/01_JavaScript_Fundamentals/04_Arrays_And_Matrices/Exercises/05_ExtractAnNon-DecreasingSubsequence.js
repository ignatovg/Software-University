function modifyArray(array) {

    if(array.length === 0){
        return '';
    }
    let result = [];
    result.push(array[0]);
    let lastElement = array[0];

    for (let i = 0; i < array.length; i++) {
        if(lastElement < array[i]){
            lastElement = array[i];
            result.push(array[i]);
        }
    }
    return (result.join('\n'));
}


let increasingSequence = arr => arr
    .filter((e, i) => e >= Math.max.apply(null, arr.slice(0, i)))
    .join('\n');


modifyArray([1,3,8,4,10,12,3,2,24]);
