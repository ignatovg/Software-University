function invokeAll(functionArr) {
    for (let func of functionArr) {
        func();
    }
}

let last = function () {
    console.error('last');
}

invokeAll([() => console.info('first'), ()=> console.warn('second'), last ]);