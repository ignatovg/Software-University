function distanceIn3D(inputArr) {
    let x1= inputArr[0];
    let y1= inputArr[1];
    let z1= inputArr[2];

    let x2= inputArr[3];
    let y2= inputArr[4];
    let z2= inputArr[5];

    let distance = Math.sqrt(Math.pow((x2-x1),2) + Math.pow((y2-y1),2) + Math.pow((z2-z1),2));

    return distance;
}

console.log(distanceIn3D([1, 1, 0, 5, 4, 0]));