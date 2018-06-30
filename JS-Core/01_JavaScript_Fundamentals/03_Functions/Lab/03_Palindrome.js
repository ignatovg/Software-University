function getPalindrome(word) {
    for (let i = 0; i < word.length/2; i++) {
        if(word[i] !== word[word.length - 1 - i]){
            return false;
        }
    }
    return true;
}

console.log(getPalindrome('haha'));
console.log(getPalindrome('racecar'));
console.log(getPalindrome('unitinu'));
