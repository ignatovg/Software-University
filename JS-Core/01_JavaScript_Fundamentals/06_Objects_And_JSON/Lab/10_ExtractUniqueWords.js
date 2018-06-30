function extractWords(strArr) {
    let pattern = /\w+/g;
    let words = strArr.join('').match(pattern);
    let uniqueWords = new Set();

    for (let word of words) {
        uniqueWords.add(word.toLowerCase());
    }

   return [...uniqueWords].join(', ');
}

console.log(extractWords([
    'JS devs use Node.js for server-side JS.',
    'JS devs use JS.',
    '-- JS for devs --',
]));