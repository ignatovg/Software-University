
function arenaTier(strArr) {
    let gladiatorsData = new Map();

    for (let line of strArr) {
        if (line.includes(' -> ')) {
            let [gladiator, technique, skill] = line.split(' -> ');
            skill = Number(skill);
            //fill gladiatorsData
            if (!gladiatorsData.has(gladiator)) {
                gladiatorsData.set(gladiator, new Map());
            }
            if (!gladiatorsData.get(gladiator).has(technique)) {
                gladiatorsData.get(gladiator).set(technique, skill);
            }
            let currentSkill = gladiatorsData.get(gladiator).get(technique);
            //check skill
            if (currentSkill < skill) {
                gladiatorsData.get(gladiator).set(technique, skill);
            }

        } else if (line.includes(' vs ')) {
            let [gladiatorOne, gladiatorTwo] = line.split(' vs ');
            let gladOneTechnique = gladiatorsData.get(gladiatorOne);
            let gladTwoTechnique = gladiatorsData.get(gladiatorTwo);

            if(!gladiatorsData.has(gladiatorOne) || !gladiatorsData.has(gladiatorTwo)){
                continue
            }
            let gladOneKeys = gladOneTechnique.keys();
            let gladTwoKeys = gladTwoTechnique.keys();

            let techniqueOneArr = [...gladOneKeys].toString();
            let techniqueTwoArr = [...gladTwoKeys];

            for (let technique of techniqueTwoArr) {
                if(techniqueOneArr.includes(technique)){
                   if(gladiatorsData.get(gladiatorOne).get(technique) <
                       gladiatorsData.get(gladiatorTwo).get(technique)){
                       gladiatorsData.delete(gladiatorOne);
                       break;
                   }else {
                       gladiatorsData.delete(gladiatorTwo);
                       break;
                   }
                }
            }
        } else if (line === 'Ave Cesar') {
            break;
        }
    }
    //sort gladiatorsData
    let sortedData = [...gladiatorsData].sort((g1,g2) =>{
        let glScore1 = [...g1[1].values()].reduce((a,b) => a + b);
        let glScore2 = [...g2[1].values()].reduce((a,b) => a + b);
        let diffInScore =  glScore2 - glScore1;
        if(diffInScore === 0 ){
            return g1[0].localeCompare(g2[0])
        }
        return diffInScore;
    });

    //print gladiatorsData
    for (let [key, values] of sortedData) {
        console.log(`${key}: ${[...values.values()].reduce((a,b) => a +b )} skill`);
        let sortedTechnique = [...values].sort((g1,g2) => {
            let skill1 = g1[1];
            let skill2 = g2[1];
            let diffInSkill = skill2 - skill1;
            if(diffInSkill === 0){
                return g1[0].localeCompare(g2[0]);
            }
            return diffInSkill;
        });
        sortedTechnique.forEach(e=> console.log(`- ${e[0]} <!> ${e[1]}`))
    }
}

/*
function solve(arr) {
    let result = {}
    for (const string of arr) {
        if (string.includes(' -> ')) {
            let [name, item, score] = string.split(' -> ')
            if (!result.hasOwnProperty(name)) {
                result[name] = {}
                result[name][item] = Number(score)
                result[name]['__total__'] = Number(score)
            } else {
                if (!result[name].hasOwnProperty(item)) {
                    result[name][item] = Number(score)
                    result[name]['__total__'] += Number(score)
                } else {
                    if (result[name][item] < score) {
                        result[name]['__total__'] -= result[name][item]
                        result[name]['__total__'] += Number(score)
                        result[name][item] = Number(score)
                    }
                }
            }
        } else if (string.includes(' vs ')) {
            let [gladiator1, gladiator2] = string.split(' vs ')
            if (result.hasOwnProperty(gladiator1) && result.hasOwnProperty(gladiator2)) {
                for (const g1Item in result[gladiator1]) {
                    let g1Score = result[gladiator1][g1Item]
                    let g2Score = result[gladiator2][g1Item]
                    if (g1Score && g2Score && g1Item !== '__total__') {
                        if (g1Score > g2Score) {
                            delete result[gladiator2]
                            break
                        } else if (g1Score < g2Score) {
                            delete result[gladiator1]
                            break
                        }
                    }
                }
            }
        } else {
            break
        }
    }
    let sortedGladiators = Object.keys(result).sort((g1, g2) => {
        let diffInScore = result[g2]['__total__'] - result[g1]['__total__']
        if (diffInScore === 0) {
            return g1.localeCompare(g2)
        }
        return diffInScore
    })
    for (const gl of sortedGladiators) {
        console.log(`${gl}: ${result[gl]['__total__']} skill`)
        let sortedItems = Object.keys(result[gl]).filter(i => i !== '__total__').sort((i1, i2) => {
            let diffInScore = result[gl][i2] - result[gl][i1]
            if (diffInScore === 0) {
                return i1.localeCompare(i2)
            }
            return diffInScore
        })
        for (const item of sortedItems) {
            console.log(`- ${item} <!> ${result[gl][item]}`)
        }
    }
}
*/
/*
arenaTier([
    'Pesho -> BattleCry -> 400',
    'Gosho -> PowerPunch -> 300',
    'Stamat -> Duck -> 200',
    'Stamat -> Tiger -> 250',
    'Ave Cesar',
]);
*/
arenaTier([
    'Pesho -> Duck -> 400',
    'Julius -> Shield -> 150',
    'Gladius -> Heal -> 200',
    'Gladius -> Support -> 250',
    'Gladius -> Shield -> 250',
    'Pesho vs Gladius',
    'Gladius vs Julius',
    'Gladius vs Gosho',
    'Ave Cesar',
]);