function getBill(arr) {
    let bill = arr.filter((a,i) => i % 2 !== 0).map(Number).reduce((a,b) => a+b);
    let products = arr.filter((a,i) => i % 2 === 0);
    console.log(`You purchased ${products.join(', ')} for a total sum of ${bill}`);
}

getBill(['Beer Zagorka', '2.65', 'Tripe soup', '7.80','Lasagna', '5.69']);