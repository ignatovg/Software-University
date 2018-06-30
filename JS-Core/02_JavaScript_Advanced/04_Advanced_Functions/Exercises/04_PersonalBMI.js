function personalBMI(name, age, weight, height) {
    let bmi =  Math.round(weight / Math.pow(height/100,2));

    let person = {
        name: name,
        personalInfo: {
            age: age,
            weight: weight,
            height: height
        },
        BMI: bmi,
        status: getStatus(bmi)
    };

    if (person.status === 'obese') {
        person['recommendation'] = 'admission required';
    }
    return person;

    function getStatus(bmi) {
        if (bmi < 18.5) {
            return 'underweight';
        } else if (bmi < 25) {
            return 'normal';
        } else if (bmi < 30) {
            return 'overweight';
        } else {
            return 'obese';
        }
    }


}

function solve(name, age, weight, height) {
    let bmi = Math.round(weight / Math.pow(height/100,2));

    let status = '';
    if (bmi < 18.5) {
        status = 'underweight';
    } else if (bmi < 25) {
        status = 'normal';
    } else if (bmi < 30) {
        status = 'overweight';
    } else {
        status = 'obese';
    }

    let patient = {
        name: name,
        personalInfo: {
            age: age,
            weight: weight,
            height: height
        },
        BMI: bmi,
        status: status
    };
    if(status === 'obese'){
        patient['recommendation'] = 'admission required';
    }

    return patient;

}

console.log(solve('Peter', 9, 57, 137));