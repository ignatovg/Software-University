function countTheWords(strArr) {
    strArr = strArr.join('').split(/\W+/).filter(e=>e!== '').map(e=>e.toLowerCase());
    let words = new Map();

    for (let word of strArr) {
        if(!words.has(word)){
            words.set(word,0);
        }
        words.set(word,words.get(word) + 1);
    }
    let arr = [...words].sort();
    for (let [key,value] of arr) {
        console.log(`'${key}' -> ${value} times`);
    }
}

countTheWords('Far too slow, you\'re far too slow.');