function radarRoad([speed, zone]) {

    let limit = getLimit(zone);
    let infraction = getInfraction(speed, limit);
    if (infraction) {
       return (infraction);
    }else {return ''};

    function getLimit(zone) {
        switch (zone) {
            case 'motorway':
                return 130;
            case 'interstate':
                return 90;
            case 'city':
                return 50;
            case 'residential':
                return 20;

        }
    }

    function getInfraction(speed, limit) {
        let overSpeed = speed - limit;
        if (overSpeed <= 0) {
            return false;
        } else {
           if(overSpeed > 0 && overSpeed <= 20){
               return `speeding`;
           }else if(overSpeed>20 && overSpeed <= 40){
               return 'excessive speeding';
           }else {
               return 'reckless driving';
           }

        }
    }
}

console.log(radarRoad([40, 'city']));
console.log(radarRoad([21, 'residential']));
console.log(radarRoad([210, 'motorway']));