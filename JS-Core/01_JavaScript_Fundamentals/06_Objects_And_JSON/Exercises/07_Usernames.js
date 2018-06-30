function printUsername(strArr) {
    let data = new Set();

    for (let row of strArr) {
        data.add(row);
    }

    console.log([...data].sort(compare).join('\n'));

    function compare(a, b) {
        if (a.length < b.length) {
            return -1;
        }else if (a.length > b.length) {
            return 1;
        }else{
            if (a < b) {
                return -1;
            }
            if (a > b) {
                return 1;
            }
            return 0;
        }
    }
}

printUsername([
    'Ashton',
    'Kutcher',
    'Ariel',
    'Lilly',
    'Keyden',
    'Aizen',
    'Billy',
    'Braston',
]);