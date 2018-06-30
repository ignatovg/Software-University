let add = (function () {
    let sum = 0;

    function result(num) {
        sum += num;
        return result;
    }

    result.toString = () => sum.toString();
    return result;
})();


let solve  = (function () {
    let sum = 0;

    return function add(number) {
        sum+= number;
        //overwrite
        add.toString = function () {
            return sum ;
        };

        return add;
    }
})();




console.log(solve(1).toString());
console.log(solve(1)(6)(-3).toString());

