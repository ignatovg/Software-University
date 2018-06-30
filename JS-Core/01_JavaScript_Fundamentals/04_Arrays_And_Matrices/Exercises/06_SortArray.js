var firstBy = require('thenby');

function sortArray(arr){
    let sortedArr =  arr.sort(
        firstBy(function (v1, v2) { return v1 - v2; })
        .thenBy(function (v1, v2) { return v1.length - v2.length; })
        );
    return sortedArr;
}



console.log(sortArr(['5.а а', '2. z z z z','3.w w']));
console.log();

function sortArr(params) {
    params.sort(function(a, b) {
        return a.length - b.length || a.ца(b);})
    params.forEach(el => console.log(el))

};


