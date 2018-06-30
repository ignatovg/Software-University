function validateEmail(email) {
    let pattern = /^[a-zA-Z0-9]+@[a-z]+\.[a-z]+$/;

    if (pattern.test(email)) {
        console.log('Valid');
    } else {
        console.log('Invalid');
    }
}