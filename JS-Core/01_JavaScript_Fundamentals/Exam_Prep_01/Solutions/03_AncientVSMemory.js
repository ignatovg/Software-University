function readAncientMemory(strArr) {
    let tokens = strArr.join(' ').split(' 0 ').filter(e => e !== '0');

    for (let i = 2; i < tokens.length; i += 3) {

        let line = tokens[i].split(' ');
        let str = '';
        for (let integer of line) {
            str += String.fromCharCode(integer);
        }
        console.log(str);
    }
}

/*
readAncientMemory([
    '32656 19759 32763 0 5 0 80 101 115 104 111 0 0 0 0 0 0 0 0 0 0 0',
    '0 32656 19759 32763 0 7 0 83 111 102 116 117 110 105 0 0 0 0 0 0 0', 0

]);
*/

readAncientMemory([
    '0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 32656 19759 32763 0',
    '5 0 71 111 115 104 111 0 0 0 0 0 0 0 0 0 32656 19759 32763 0 4 0',
    '75 105 114 111 0 0 0 0 0 0 0 0 0 0 32656 19759 32763 0 8 0 86 101',
    '114 111 110 105 107 97 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0',

]);
