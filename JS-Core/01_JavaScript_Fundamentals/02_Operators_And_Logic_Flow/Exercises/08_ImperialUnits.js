function inperialUnits(inches) {
    let feet = Math.floor((inches) / 12);
    let remainder = inches % 12;

    console.log(`${feet}'-${remainder}"`);
}

inperialUnits(36);
inperialUnits(55);
inperialUnits(11);