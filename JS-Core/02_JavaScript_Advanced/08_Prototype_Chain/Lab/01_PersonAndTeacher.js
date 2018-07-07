let myModule = ()=>{

    class Person {
        constructor(name,email){
            this.name = name;
            this.email=email;
        }

        toString(){
            let className = this.constructor.name;
            return `${className} (name: ${this.name}, email: ${this.email})`
        }
    }

    class Teacher extends Person{
        constructor(name,email,subject){
            super(name,email);
            this.subject = subject;
        }
        toString(){
            let base = super.toString().slice(0,-1);
            return base + `,subject:${this.subject})`
        }
    }
    return{Person,Teacher};
}

let Person = myModule().Person;
let Teacher = myModule().Teacher;


let p1 = new Person('Ivan','Iv@a');
let t1= new Teacher('Maria','Mar@a','Technology');


console.log(p1.toString());
console.log(t1.toString());

