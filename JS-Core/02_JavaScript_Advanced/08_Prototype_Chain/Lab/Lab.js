function myModule() {
    class Person {
        constructor(name, email,saying) {
            this.name = name;
            this.email = email;
            this.saying = saying
        }

        talk(){
           return `${this.name} says: ${this.saying}`;
        }

        toString() {
            let className = this.constructor.name;
            return `${className} (name: ${this.name} email: ${this.email})`;
        }
    }



    class Teacher extends Person {
        constructor(name, email,subject,saying) {
            super(name,email,saying);
            this.subject = subject;
        }

        exclaim(){
            return super.talk() + '!!!!';
        }

        toString(){
            let base = super.toString().slice(0, -1);
            return `${base}, subject: ${this.subject})`;
        }
    }
    return {Person,Teacher};
}

let Teacher = myModule().Teacher;
let Person = myModule().Person;

let p1= new Person('Minka','Yordan@.av','Hi');

let t1 = new Teacher('Iva','iv@abv.bg','How are you', 'Bulgarski');

console.log(t1);
console.log(p1);

console.log(t1.exclaim());
console.log(p1.talk());

console.log(Object.getPrototypeOf(t1));
console.log(Object.getPrototypeOf(Teacher));
console.log(Object.getPrototypeOf(Person));
console.log(Object.getPrototypeOf(Function));
