function solve(inputArr) {
    let valid = [];
    let invalid = [];
    let companies = inputArr.shift();
    let delimiter = inputArr.shift();
    companies = companies.split(delimiter);

    for (let row of inputArr) {
        let line = row.toLowerCase();
        let isInvalid = false;

        for (let company of companies) {
            if(!line.includes(company)){
                isInvalid = true;
                break;
            }

        }
        if(isInvalid){
            invalid.push(line);
        }else if(!isInvalid){
            valid.push(line);
        }
    }
    if(valid.length > 0 && invalid.length > 0){
        console.log(`ValidSentences`);
        for (let i = 0; i < valid.length; i++) {
            console.log(`${i+1}. ${valid[i]}`);
        }
        console.log(`${'='.repeat(30)}`);

        console.log(`InvalidSentences`);
        for (let i = 0; i < invalid.length; i++) {
            console.log(`${i+1}. ${invalid[i]}`);
        }
    }else if(valid.length > 0){
        console.log(`ValidSentences`);
        for (let i = 0; i < valid.length; i++) {
            console.log(`${i+1}. ${valid[i]}`);
        }
    }else if(invalid.length > 0){
        console.log(`InvalidSentences`);
        for (let i = 0; i < invalid.length; i++) {
            console.log(`${i+1}. ${invalid[i]}`);
        }
    }
}