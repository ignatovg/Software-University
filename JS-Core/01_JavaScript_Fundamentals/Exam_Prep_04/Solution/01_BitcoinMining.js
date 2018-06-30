function mine(inputArr) {
    let oneBitcoin = 11949.16;
    let oneGOfGold = 67.51;
    let days = inputArr.map(Number);
    let bitcoin = 0;
    let dayOfFirstPurchased = [];
    let totalMoney= 0;


    for (let i = 0; i < days.length; i++) {
        let currentDay = days[i];
        if((i + 1) % 3 === 0){
            currentDay = currentDay - currentDay * 0.3;
        }
        totalMoney  += currentDay * oneGOfGold;

        if(totalMoney >= oneBitcoin){
            bitcoin += parseInt(totalMoney / oneBitcoin);
            totalMoney %= oneBitcoin;
            dayOfFirstPurchased.push(i+1);
        }
    }
    console.log(`Bought bitcoins: ${bitcoin}`);
    if(dayOfFirstPurchased.length !== 0){
        console.log(`Day of the first purchased bitcoin: ${dayOfFirstPurchased[0]}`);
    }
    console.log(`Left money: ${totalMoney.toFixed(2)} lv.`);
}

mine([
    '100',
    '200',
    '300',
]);