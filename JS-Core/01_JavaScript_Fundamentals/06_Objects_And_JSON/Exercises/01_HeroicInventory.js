function registerHero(strArr) {
    let data = [];
    for (let row of strArr) {
        let heroTokens = row.split(' / ');
        let heroName = heroTokens[0];
        let heroLevel = Number(heroTokens[1]);
        let items = [];

        if(heroTokens.length > 2) {
            items = heroTokens[2].split(', ');
        }
        let hero = {
            name: heroName,
            level: Number(heroLevel),
            items: items
        };
        data.push(hero);
    }

        console.log(JSON.stringify(data));
}


registerHero([
   ' /  / Gauss'
]);
