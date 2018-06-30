function buildArray(commands) {
    let currentValue = 1;
    let result = [];

    for (let command of commands){
        command.toLowerCase() === 'add'? result.push(currentValue++) : result.pop(currentValue++);
    }

    return result.length === 0? 'Empty': result.join('\n');

}

console.log(buildArray(['add', 'add', 'remove', 'add', 'add']));

