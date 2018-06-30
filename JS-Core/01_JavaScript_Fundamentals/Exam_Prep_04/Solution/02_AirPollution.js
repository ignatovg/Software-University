function solve(map, arguments) {
    let matrix = [];
    for (let line of map) {
        matrix.push(line.split(' ').map(Number));
    }
    //foreach arguments
    for (let arg of arguments) {
        let [command, value] = arg.split(' ');
        value = Number(value);

        switch (command) {
            case 'breeze':
                useBreeze(matrix, value);
                break;
            case 'gale':
                useGale(matrix, value);
                break;
            case 'smog':
                useSmog(matrix, value);
                break;
        }
    }

    //get polluted areas
    let pollutedAreas = [];
    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix.length; col++) {
            if (matrix[row][col] >= 50) {
                pollutedAreas.push(`[${row}-${col}]`)
            }
        }
    }
    //print
    if (pollutedAreas.length === 0) {
        console.log(`No polluted areas`);
    } else {
        console.log(`Polluted areas: ${pollutedAreas.join(', ')}`);
    }

    function useSmog(matrix, value) {
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix.length; col++) {
                matrix[row][col] += value;
            }
        }
    }

    function useGale(matrix, col) {
        for (let row = 0; row < map.length; row++) {
            matrix[row][col] -= 20;
            if(matrix[row][col] < 0){
                matrix[row][col] = 0;
            }
        }
    }

    function useBreeze(matrix, row) {
        for (let col = 0; col < matrix.length; col++) {
            matrix[row][col] -= 15;
            if(matrix[row][col] < 0){
                matrix[row][col] = 0;
            }
        }
    }
}

solve([
        "5 7 72 14 4",
        "41 35 37 27 33",
        "23 16 27 42 12",
        "2 20 28 39 14",
        "16 34 31 10 24",
    ],
    ["breeze 1", "gale 2", "smog 25"]
);
console.log();
solve([
        "5 7 2 14 4",
        "21 14 2 5 3",
        "3 16 7 42 12",
        "2 20 8 39 14",
        "7 34 1 10 24",
    ],
    ["breeze 1", "gale 2", "smog 35"]
);
console.log();
solve([
        "5 7 3 28 32",
        "41 12 49 30 33",
        "3 16 20 42 12",
        "2 20 10 39 14",
        "7 34 4 27 24",
    ],
    [
        "smog 11", "gale 3",
        "breeze 1", "smog 2"
    ]
);

