function round(params) {
    let number = params[0];
    let precision = params[1];

    var factor = Math.pow(10, precision);
    return Math.round(number * factor) / factor;
}

round([3.1415926535897932384626433832795, 2]);
round([10.5, 3]);