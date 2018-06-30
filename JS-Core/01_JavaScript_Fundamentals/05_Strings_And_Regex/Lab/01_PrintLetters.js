function printLetters(word) {
    Array
        .from(word)
        .forEach((e,i) => console.log(`str[${i}] -> ${e}`));


    // for(let i in word){
    //      console.log(`str[${i}] -> ${word[i]}`);
    // }
}

printLetters('hello');