function solve() {
    //Abstract class
    class Employee {
        constructor(name, age) {
            if (this.constructor === Employee) {
                //new.target
                throw new TypeError(`Cannot instantiate directly`)
            }
            this.name = name;
            this.age = Number(age);
            this.salary = 0;
            this.tasks = [];
        }

        work() {
            let currentTask = this.tasks.shift();
            console.log(this.name + currentTask);
            this.tasks.push(currentTask);
        }

        collectSalary() {
            console.log(`${this.name} received ${this.getSalary()} this month.`);
        }
        getSalary(){
            return this.salary;
        }
    }

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks.push(' is working on a simple task.')
        }
    }

    class Senior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks.push(' is working on a complicated task.');
            this.tasks.push(' is taking time off work.');
            this.tasks.push(' is supervising junior workers.');
        }
    }

    class Manager extends Employee {
        constructor(name, age) {
            super(name, age);
            this.dividend = 0;
            this.tasks.push(' scheduled a meeting.');
            this.tasks.push(' is preparing a quarterly report.');
        }
        getSalary(){
            return this.salary + this.dividend;
        }
    }
    return {Employee, Junior,Senior,Manager};
}
let Junior = solve().Junior;
let guy1 = new Junior('Peter', 27);
guy1.salary = 1200;
guy1.collectSalary();
//('Peter received 1200 this month.', "Junior's salary was not logged.");

