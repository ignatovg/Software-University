function modifyAverage(num) {

    let avg = getAverage(num);
    if (avg > 5) {
        console.log(num);
    } else {
        num += '9';
        modifyAverage(num);
    }

    function getAverage(number) {
        let numberStr = number.toString();
        let total = 0;
        for (let i = 0; i < numberStr.length; i++) {
            total+= Number(numberStr[i]);
        }
        return total/numberStr.length;
    }
}

modifyAverage(5835);
modifyAverage(101);
