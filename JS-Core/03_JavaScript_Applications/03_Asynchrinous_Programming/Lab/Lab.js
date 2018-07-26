console.log('Before promise');

new Promise(function (resolve, reject) {
    setTimeout(function () {
        resolve('done');
    },500);
}).then(function (result) {
    console.log('Then returned: '+result);
}).catch(function (err) {
    console.log(err);
})

console.log('After promise');