class Rat {
    constructor(name) {
        this.name = name;
        this.unitedRats = [];
    }

    toString(){
        let result = this.name+'\n';
           for (let unitedRat of this.unitedRats) {
               result+= `##${unitedRat.name}\n`;
           }
        return result.trim();
    }

    getRats() {
        return this.unitedRats;
    }

    unite(otherRat) {
        if (otherRat instanceof Rat) {
            this.unitedRats.push(otherRat);
        }
    }
}

let test = new Rat("Pesho");
console.log(test.toString()); //Pesho

console.log(test.getRats()); //[]

test.unite(new Rat("Gosho"));
test.unite(new Rat("Sasho"));
console.log(test.getRats());
//[ Rat { name: 'Gosho', unitedRats: [] },
//  Rat { name: 'Sasho', unitedRats: [] } ]

console.log(test.toString());
// Pesho
// ##Gosho
// ##Sasho
