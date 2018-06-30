function getDayOfWeek(day) {
    let dayToLower = day.toLowerCase();

    let daysOfWeek = ['monday','tuesday','wednesday','thursday','friday','saturday','sunday'];

    if(daysOfWeek.includes(dayToLower)){
        return (daysOfWeek.indexOf(dayToLower)) + 1;
    }
    return 'error';
}

console.log(getDayOfWeek('Monday'));
console.log(getDayOfWeek('Friday'));
console.log(getDayOfWeek('non'));

