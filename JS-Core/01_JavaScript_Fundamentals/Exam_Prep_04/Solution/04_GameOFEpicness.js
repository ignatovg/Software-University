function solve(inputObj, matrix) {
    let kingdomsMap = new Map();

    let generalsArr = [];

    for (let obj of inputObj) {
        if (!kingdomsMap.has(obj.kingdom)) {
            kingdomsMap.set(obj.kingdom, new Map());
        }
        if (!kingdomsMap.get(obj.kingdom).has(obj.general)) {
            kingdomsMap.get(obj.kingdom).set(obj.general, 0);
            generalsArr.push({'kingdom': obj.kingdom, 'general': obj.general, 'wins': 0, 'loses': 0});
        }
        let oldArmy = kingdomsMap.get(obj.kingdom).get(obj.general);
        kingdomsMap.get(obj.kingdom).set(obj.general, oldArmy + obj.army);
    }


    for (let line of matrix) {

        let attackingKingdom = line[0];
        let attackingGeneral = line[1];
        let defendingKingdom = line[2];
        let defendingGeneral = line[3];

        if (attackingKingdom === defendingKingdom) {
            continue;
        }

        if (!kingdomsMap.get(attackingKingdom).has(attackingGeneral) || !kingdomsMap.get(defendingKingdom).has(defendingGeneral)) {
            continue;
        }

        let attackingArmy = kingdomsMap.get(attackingKingdom).get(attackingGeneral);
        let defendingArmy = kingdomsMap.get(defendingKingdom).get(defendingGeneral);

        let attackObj = (generalsArr.filter(g => g.general === attackingGeneral))[0];
        let defendObj = (generalsArr.filter(g => g.general === defendingGeneral))[0];

        if (attackingArmy > defendingArmy) {
            attackingArmy = attackingArmy + attackingArmy * 0.1;
            defendingArmy = defendingArmy - defendingArmy * 0.1;

            attackObj.wins++;
            defendObj.loses++;

        } else if (attackingArmy < defendingArmy) {
            attackingArmy = attackingArmy - attackingArmy * 0.1;
            defendingArmy = defendingArmy + defendingArmy * 0.1;

            attackObj.loses++;
            defendObj.wins++;
        }

        kingdomsMap.get(attackingKingdom).set(attackingGeneral, Math.floor(attackingArmy));
        kingdomsMap.get(defendingKingdom).get(defendingGeneral, Math.floor(defendingArmy));
    }
    console.log(kingdomsMap);
    console.log();
    console.log(generalsArr);

    let sortKingdoms = generalsArr.sort((a, b) => {
        let winsDiff = b.wins - a.wins;
        if (winsDiff === 0) {
            let losesDiff = a.loses - b.loses;
            if(losesDiff === 0){
                return a.kingdom.localeCompare(b.kingdom);
            }
            return losesDiff;
        }
        return winsDiff;
    });
    console.log();
}

solve([{kingdom: "Maiden Way", general: "Merek", army: 5000},
        {kingdom: "Stonegate", general: "Ulric", army: 4900},
        {kingdom: "Stonegate", general: "Doran", army: 70000},
        {kingdom: "YorkenShire", general: "Quinn", army: 0},
        {kingdom: "YorkenShire", general: "Quinn", army: 2000},
        {kingdom: "Maiden Way", general: "Berinon", army: 100000}],
    [["YorkenShire", "Quinn", "Stonegate", "Ulric"],
        ["Stonegate", "Ulric", "Stonegate", "Doran"],
        ["Stonegate", "Doran", "Maiden Way", "Merek"],
        ["Stonegate", "Ulric", "Maiden Way", "Merek"],
        ["Maiden Way", "Berinon", "Stonegate", "Ulric"]]
);