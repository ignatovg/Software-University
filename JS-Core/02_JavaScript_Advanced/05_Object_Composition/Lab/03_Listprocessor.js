function processCommands(commands){

    let commandProcessor = (function () {
        let collectionArr = [];
        return commandsObj = {
            add: (elem) => collectionArr.push(elem),
            remove: (elem) => collectionArr = collectionArr.filter(e => e !== elem),
            print:  () => console.log(`${collectionArr.join(',')}`)
        };

    })();
    for(let cmd of commands){
        let [cmdName, arg] = cmd.split(' ');
        commandProcessor[cmdName](arg);
    }
}

processCommands(['add hello', 'add again', 'remove hello', 'add again', 'print']);

