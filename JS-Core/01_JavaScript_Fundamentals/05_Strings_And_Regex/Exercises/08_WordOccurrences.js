function wordCounter(text,word) {
    let matches = text.match(new RegExp(`\\${word}\\`,'gi'));

    return matches === null ? 0 : matches.length
}

console.log(wordCounter('The waterfall was so high, that the child couldn’t see its peak.\n' +
    'the\n'));