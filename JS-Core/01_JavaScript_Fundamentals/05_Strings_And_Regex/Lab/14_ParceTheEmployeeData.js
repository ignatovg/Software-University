function parseData(dataArr) {
    let pattern = /\^([A-Z][a-z]*) - (\d+) - ([A-Za-z0-9- ]+)\$/;

    let match;
    for (let sentence of dataArr) {
        if (match = pattern.exec(sentence)){
            console.log(`Name: ${match[1]}`);
            console.log(`Position: ${match[3]}`);
            console.log(`Salary: ${match[2]}`);
        }
    }
}

parseData(['Isacc - 1000 - CEO',
    'Ivan - 500 - Employee',
    'Peter - 500 - Employee']
);