function findTreasure(cords) {
    let x = 0;
    let y = 0;

    for (let i = 0; i < cords.length; i+=2) {
        x = cords[i];
        y = cords[i+1];
        console.log(getTreasure(x, y));
    }

    function getTreasure(x, y) {
        if(checkTuvalu(x,y)){
            return 'Tuvalu';
        }else if(checkTokelau(x,y)){
            return 'Tokelau';
        }else if(checkSamoa(x,y)){
            return 'Samoa';
        }else if(checkTonga(x,y)){
            return 'Tonga';
        }else if(checkCook(x,y)){
            return 'Cook';
        }
        else {
            return 'On the bottom of the ocean';
        }
    }

    function checkTuvalu(x, y) {
        return x >= 1 && x<= 3 && y >= 1 && y <= 3;
    }

    function checkTokelau(x, y) {
        return x >= 8 && x<= 9 && y >= 0 && y <= 1;
    }

    function checkSamoa(x, y) {
        return x >= 5 && x<= 7 && y >= 3 && y <= 6;
    }

    function checkTonga(x, y) {
        return x >= 0 && x<= 2 && y >= 6 && y <= 8;
    }

    function checkCook(x, y) {
        return x >= 4 && x<= 9 && y >= 7 && y <= 8;
    }
}

findTreasure([4, 2, 1.5, 6.5, 1, 3]);
findTreasure([6, 4]);