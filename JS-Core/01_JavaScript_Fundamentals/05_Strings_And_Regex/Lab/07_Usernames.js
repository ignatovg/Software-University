function getUsername(arr) {
    let names = arr.map(e => e.split('@')[0]);
    let domains = arr.map(e => e.split('@')[1]);
    let fullNames = [];
    for (let i = 0; i < domains.length; i++) {
        let letter = domains[i].split('.').map(e=>e[0] + '').join('');
      fullNames.push(names[i] + '.' + letter);
   }
    console.log(fullNames.join(', '));
}

getUsername(['peshoo@gmail.com', 'todor_43@mail.dir.bg', 'foo@bar.com']);