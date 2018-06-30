function findVariableName(text) {
    let pattern = /\b_([a-zA-Z0-9]+)\b/g;
    let result = [];
    let match = pattern.exec(text);

    while (match) {
        result.push(match[1]);
        match = pattern.exec(text);
    }

    console.log(result.join(','));

}
//66/100
function zero(text) {
    let pattern = /\b_([a-zA-Z0-9]+)\b/g;
    let names = [],match;

    for (let word of text.split(' ')) {
        match = pattern.exec(word);
        if(match)
            names.push(match[1]);
    }

    console.log(names.join(','));
}

findVariableName('The _id and _age variables are both integers.');