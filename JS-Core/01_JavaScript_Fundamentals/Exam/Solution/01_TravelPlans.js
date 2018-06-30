function solve(inputArr) {
    let totalGold = 0;
    let specializedCustomers = 0;
    let clumsyCustomers = 0;
    let specializedProf = ['Programming', 'Hardware maintenance', 'Cooking', 'Translating', 'Designing'];
    let clumsyProf = ['Singing', 'Accounting', 'Teaching', 'Exam-Making', 'Acting', 'Writing', 'Lecturing', 'Modeling', 'Nursing'];


    for (let line of inputArr) {
        let [profession, offered] = line.split(' : ');
        let goldOffered = Number(offered);

        //specialized customers
        if (specializedProf.includes(profession)) {
            if (goldOffered <= 200) {
                continue;
            }
            ++specializedCustomers;

           //for candies
            goldOffered = goldOffered* 0.80;

            if (specializedCustomers % 2 === 0) {
                totalGold += 200;
            }
        }else if (clumsyProf.includes(profession)) {
            clumsyCustomers++;
            if (clumsyCustomers % 2 === 0) {

                goldOffered = goldOffered* 0.95;
            }
            if (clumsyCustomers % 3 === 0) {
                goldOffered = goldOffered * 0.90;
            }
        }
        totalGold += goldOffered;
    }

    console.log(`Final sum: ${totalGold.toFixed(2)}`);
    if(totalGold<1000){
        let result = (1000 - totalGold)*100/100;

        console.log(`Mariyka need to earn ${(1000 - totalGold).toFixed(2)} gold more to continue in the next task.`);
    }else if(totalGold >= 1000){
        console.log(`Mariyka earned ${(totalGold - 1000).toFixed(2)} gold more.`);
    }
}


solve([
'Programming : 300',
'Cooking : 75',
'Hardware maintenance : 50',
]);