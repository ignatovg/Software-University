function calculateDistance(inputArr) {
    let speedOne = inputArr[0];
    let speedTwo = inputArr[1];
    let time = inputArr[2] / 3600;

    let dist1 = (speedOne * time) * 1000 ;
    let dist2 = (speedTwo * time) * 1000 ;

    let delta = Math.abs(dist1-dist2);
    console.log(delta);
}

calculateDistance([0, 60, 3600]);
calculateDistance([11, 10, 120]);
calculateDistance([5, -5, 40]);