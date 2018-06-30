function result() {
    let f1 = 0;
    let f2 = 1;
    function solve() {
        let f3 = f1 + f2;
        [f1,f2] = [f2,f3];
        return f2;
    }
    return solve;
}

let fib = result();
console.log(fib());
fib();
fib();
fib();
fib();





