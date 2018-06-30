function coverData(strArr) {
    let namesPattern = /(\*[A-Z][A-Za-z]*)(?=\s|$)/g;
    let numbersPattern = /\+[0-9-]{10}(?=\s|$)/g;
    let clientPattern = /\![0-9a-zA-Z]+(?=\s|$)/g;
    let secretBasePattern= /\_[0-9a-zA-Z]+(?=\s|$)/g;

    for (let line of strArr) {
        console.log(
            line
                .replace(namesPattern,  m=> '|'.repeat(m.length))
                .replace(numbersPattern,  m=> '|'.repeat(m.length))
                .replace(clientPattern,  m=> '|'.repeat(m.length))
                .replace(secretBasePattern,  m=> '|'.repeat(m.length))
        );
    }
}

coverData([
    `Agent *Ivankov was in the room when it all happened.`,
    `The person in the room was heavily armed.`,
    `Agent *Ivankov had to act quick in order.`,
    `He picked up his phone and called some unknown number.`,
    `I think it was +555-49-796`,
    `I can't really remember...`,
    `He said something about "finishing work" with subject !2491a23BVB34Q and returning to Base _Aurora21`,
    `Then after that he disappeared from my sight.`,
    `As if he vanished in the shadows.`,
    `A moment, shorter than a second, later, I saw the person flying off the top floor.`,
    `I really don't know what happened there.`,
    `This is all I saw, that night.`,
    `I cannot explain it myself...`,
]);