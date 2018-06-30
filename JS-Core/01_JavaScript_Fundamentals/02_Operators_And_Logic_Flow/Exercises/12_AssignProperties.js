function composeObj(params) {
    let obj = {};
    for (let i = 0; i < params.length; i+=2) {

        obj[params[i]] = params[i + 1];
    }

    console.log(obj);
}

composeObj(['name', 'Pesho', 'age', '23', 'gender', 'male']);