function solve(inputStr) {
    let startPoint = Number(inputStr.shift());
    let endPoint = Number(inputStr.shift());
    let rightWord = inputStr.shift();
    let text = inputStr.shift();

    let pattern = /\b[A-Z]\S+[A-Z]\b/g;

    let match = (pattern.exec(text)[0]);
    let substring = match.substring(startPoint, endPoint + 1);
    let wholeWord = match.replace(substring, rightWord);
    wholeWord = [...wholeWord];
    wholeWord[wholeWord.length - 1] = wholeWord[wholeWord.length - 1].toLowerCase();
    wholeWord = wholeWord.join('');


    //let digitPattern = /(\d+[\/\d.]*|\d)/g;
    let digitPattern = /([0-9]{3}\.[0-9]+)|([0-9]){3}/g;
    let digitMatches = text.match(digitPattern);

    digitMatches = digitMatches.map(e => e.trim()).map(Number);

    digitMatches = digitMatches.map(e => Math.ceil(e));
    let result = '';

    for (let num of digitMatches) {
        result += String.fromCharCode(num);

    }
    result = [...result];
    result[0] = result[0].toUpperCase();
    result= result.join('');
    console.log(`${wholeWord} => ${result}`);
}

solve([
    `5`,
    `7`,
    `riA`,
    `BulgaziP 67 � sDf1d17ia aTe 1, 098 confin$4%#ed 117 likewise 114 103 it human 097 ity  Bulg35aria - VarnA railLery1a0s1 115 an unpacked as he`
]);