let f = (function (counter) {
    return function () {
        console.log(++counter);
    }
})(5);

f();
f();