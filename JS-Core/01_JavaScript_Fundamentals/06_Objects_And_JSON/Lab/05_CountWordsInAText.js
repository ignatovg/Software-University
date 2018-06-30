function countWords(strArr) {
    let words ={};
    strArr = strArr.join('').split(/\W+/).filter(e=>e!=='');

    for (let word of strArr) {
        if(!words.hasOwnProperty(word)){
            words[word] = 0;
        }
        words[word]++;
    }
   return JSON.stringify(words);
}

console.log(countWords('Far too slow, youre far too slow.'));