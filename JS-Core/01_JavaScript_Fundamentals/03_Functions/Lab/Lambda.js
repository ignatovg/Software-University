let f = count => ++count;

console.log(f(5));

console.log((c => ++c)(10));


[10,20,30,40].forEach(e => console.log(e));
console.log([10, 20, 30, 40].filter(e => e <= 30));