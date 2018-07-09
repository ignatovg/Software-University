class Person {
    constructor(name, email, saying) {
        
        this.name = name;
        this.email = email;
        this.saying = saying
    }

    talk() {
        return `${this.name} says: ${this.saying}`;
    }

    toString() {
        let className = this.constructor.name;
        return `${className} (name: ${this.name} email: ${this.email})`;
    }
}


class Teacher extends Person {
    constructor(name, email, subject, saying) {
        super(name, email, saying);
        this.subject = subject;
    }

    exclaim() {
        return super.talk() + '!!!!';
    }

    toString() {
        let base = super.toString().slice(0, -1);
        return `${base}, subject: ${this.subject})`;
    }
}


let p1 = new Person('Minka', 'Yordan@.av', 'Hi');

let t1 = new Teacher('Iva', 'iv@abv.bg', 'How are you', 'Bulgarski');

console.log(t1);
console.log(p1);

function extendPrototype (baseClass){
    baseClass.prototype.species = 'Human';
    baseClass.prototype.toSpeciesString = function () {
        return `I am a ${this.species}. ${this.toString()}`;
    };
}

extendPrototype(Person);

t1.species = 'Koala'

console.log(p1.toSpeciesString());
console.log(t1.toSpeciesString());


