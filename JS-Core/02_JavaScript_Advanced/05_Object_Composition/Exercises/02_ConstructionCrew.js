/* {
    weight: Number,
    experience: Number,
    bloodAlcoholLevel: Number,
    handsShaking: Boolean
} */

function processObject(personData) {
    if(personData.handsShaking === false){
        return personData;
    }
    intakeAlcohol();
    return personData;

    function intakeAlcohol() {
        let requiredAmount = 0.1 * personData.weight * personData.experience;
        personData.bloodAlcoholLevel+= requiredAmount;
        personData.handsShaking = false;
    }
}

function modifyWorker(worker){
    if(worker.handsShaking){
        worker.bloodAlcoholLevel += 0.1 * worker.weight * worker.experience;
        worker.handsShaking = false;
    }
    return worker;
}

console.log(processObject(
    { weight: 120,
        experience: 20,
        bloodAlcoholLevel: 200,
        handsShaking: true }

));