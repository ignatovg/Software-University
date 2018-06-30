function matchWords(text) {
    let pattern = /\w+/ig

   let collectedWords = text.match(pattern);
    console.log(collectedWords.join('|'));
}

matchWords('A Regular Expression needs to' +
    ' have the global flag in order to match' +
    ' all occurrences in the text');