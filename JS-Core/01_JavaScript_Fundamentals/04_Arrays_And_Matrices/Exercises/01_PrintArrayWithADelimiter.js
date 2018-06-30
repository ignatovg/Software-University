function printArray(params) {
    let delimiter = params.pop();
    console.log(params.join(delimiter));
}

printArray(['one','two','tree','-']);