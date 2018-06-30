function captureNumbers(input) {
    let regex = /\d+/g;
    let numbers = [];
    let text= '';

    for (let i = 0; i < input.length; i++) {
       let currentSentence = input[i];
       text+= currentSentence;
    }
   
    let match = regex.exec(text);

    while (match){
        numbers.push(match[0]);
        match = regex.exec(text);
    }
    console.log(numbers.join(' '));
}

function simplier(input){

    let text  = input.join(' ');
    let regex = /\d+/g;
    let numbers = text.match(regex);
    console.log(numbers.join(' '));
}


captureNumbers('123a456\n' +
    '789b987\n' +
    '654c321\n' +
    '0\n');
