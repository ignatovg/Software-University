function validateRequest(obj) {
    let methods = ["GET", "POST", "DELETE", "CONNECT"];
    if(!obj.hasOwnProperty('method') || !methods.includes(obj.method)){
        throwNewException('Method');
    }

    let pattern = /^[A-Za-z0-9.]+$/g;
    let matched = pattern.exec(obj.uri);
    if(!obj.hasOwnProperty('uri') || obj.uri === '' || matched === null){
        throwNewException('URI');
    }

    let versions = ["HTTP/0.9", "HTTP/1.0", "HTTP/1.1", "HTTP/2.0"];
    if(!obj.hasOwnProperty('version') || !versions.includes(obj.version)){
        throwNewException('Version');
    }

    if(!obj.hasOwnProperty('message')){
        throwNewException('Message');
    }
    let specialChars = [`<`, `>`, `\\`, `&`, `'`, `"`];
    for(let element of obj.message){
        if(specialChars.includes(element)){
            throwNewException('Message');
        }
    }

    return obj;

    function throwNewException(property) {
        throw new TypeError(`Invalid request header: Invalid ${property}`)
    }
}

try {
    validateRequest({
        method: 'POST',
        uri: 'home.bash',
        message: 'rm -rf /*'
    });




} catch (e) {
    console.log(e.message);
}

