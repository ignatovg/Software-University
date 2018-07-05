function getPersons() {
    class Person {
        constructor(firstName, lastName, age, email) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.email = email;
        }

        toString() {
            return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`
        }
    }

    return [
        new Person('Maria', 'Petrova', 22, 'mp@yahoo.com'),
        new Person('SoftUni'),
        new Person('Stephan', 'Nikolov', 25),
        new Person('Peter', 'Kolev', 24, 'ptr@gmail.com'),
    ]
}

/*
console.log(getPersons().join('\n'));
let p1 = new Person('Maria','Ivanova',22,'MI@gmail.com');
console.log(p1.toString());
*/

class Circle {
    constructor(radius) {
        this.radius = radius;
    }

    get diameter() {
        return 2 * this.radius;
    }

    set diameter(value) {
        this.radius = value / 2;
    }

    get area() {
        return Math.PI * this.radius ** 2;
    }
}

/*
let c1 = new  Circle(4);
console.log(c1);
console.log(c1.diameter) ;
*/

class Point {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }

    static distance(a, b) {
        const dx = a.x - b.x;
        const dy = a.y - b.y;
        return Math.sqrt(dx ** 2 + dy ** 2);
    }
}


// let p1 = new Point(5,5);
// let p2 = new Point(10,10);
// console.log(Point.distance(p1,p2));

class Cat {
    constructor(name, age) {
        this.name=name;
        this.age=age;
        Object.seal(this);
    }
}

let cat = new Cat('Mayu',5);
    cat.name='Tom';
    cat.sex = 'm';
console.log(cat.name);
console.log(cat.sex);
