let expect = require('chai').expect;
let jsdom = require('jsdom-global')();
let $ = require('jquery');

let sharedObject = {
    name: null,
    income: null,
    changeName: function (name) {
        if (name.length === 0) {
            return;
        }
        this.name = name;
        let newName = $('#name');
        newName.val(this.name);
    },
    changeIncome: function (income) {
        if (!Number.isInteger(income) || income <= 0) {
            return;
        }
        this.income = income;
        let newIncome = $('#income');
        newIncome.val(this.income);
    },
    updateName: function () {
        let newName = $('#name').val();
        if (newName.length === 0) {
            return;
        }
        this.name = newName;
    },
    updateIncome: function () {
        let newIncome = $('#income').val();
        if (isNaN(newIncome) || !Number.isInteger(Number(newIncome)) || Number(newIncome) <= 0) {
            return;
        }
        this.income = Number(newIncome);
    }
};


document.body.innerHTML = `
<body>
    <div id="wrapper">
        <input type="text" id="name">
        <input type="text" id="income">
    </div>
</body>
`;

describe('Shared object unit tests', ()=>{
    describe('Initial value tests',()=>{
        it('name should be null', function () {
            expect(sharedObject.name).to.be.null;
        });
        it('income should be null', function () {
            expect(sharedObject.income).to.be.null;
        });
    });
    describe('change name tests',()=>{
        it('with empty string, name should be null', function () {
            sharedObject.changeName('');
            expect(sharedObject.name).to.be.null;
        });
        it('with a non-empty string, name should not be null', function () {
            sharedObject.changeName('Pesho');
            expect(sharedObject.name).to.be.equal('Pesho');
        });
    });
    describe('Name input tests',()=>{
        it('with empty string, name should be null', function () {
            sharedObject.changeName('Nakov');
            sharedObject.changeName('');
            let nameTxtVal = $('#name');
            expect(nameTxtVal.val()).to.be.equal('Nakov');
        });
        it('with a non-empty string, name should not be null', function () {
            sharedObject.changeName('Pesho');
            let nameTxtVal = $('#name');
            expect(nameTxtVal.val()).to.be.equal('Pesho');
        });
    });
    describe('Change income tests',()=>{
        it('with a string, should stay null', function () {
            sharedObject.changeIncome('d');
            expect(sharedObject.income).to.be.null;
        });
        it('with a positive number, should change correctly', function () {
            sharedObject.changeIncome(5);
            expect(sharedObject.income).to.be.equal(5);
        });
        it('with a floating-point', function () {
            sharedObject.changeIncome(5);
            sharedObject.changeIncome(4.11);
            expect(sharedObject.income).to.be.equal(5);
        });
        it('with a negative number', function () {
            sharedObject.changeIncome(5);
            sharedObject.changeIncome(-4);
            expect(sharedObject.income).to.be.equal(5);
        });
        it('with a zero', function () {
            sharedObject.changeIncome(5);
            sharedObject.changeIncome(0);
            expect(sharedObject.income).to.be.equal(5);
        });
    });
    describe('Income input tests', ()=>{
        it('with a string, should not change correctly', function () {
            sharedObject.changeIncome(5);
            sharedObject.changeIncome('d');
            let incomeTxt = $('#income');
            expect(incomeTxt.val()).to.be.equal('5');
        });
        it('with a positive number', function () {
            sharedObject.changeIncome(5);
            let incomeTxt = $('#income');
            expect(incomeTxt.val()).to.be.equal('5');
        });
        it('with a floating point number', function () {
            sharedObject.changeIncome(5);
            sharedObject.changeIncome(2.11);
            let incomeTxt = $('#income');
            expect(incomeTxt.val()).to.be.equal('5');
        });
        it('with a negative number', function () {
            sharedObject.changeIncome(5);
            sharedObject.changeIncome(-2);
            let incomeTxt = $('#income');
            expect(incomeTxt.val()).to.be.equal('5');
        });
        it('with a zero', function () {
            sharedObject.changeIncome(5);
            sharedObject.changeIncome(0);
            let incomeTxt = $('#income');
            expect(incomeTxt.val()).to.be.equal('5');
        });
    });
    describe('Update name tests',()=>{
        it('with an empty string, should not change property', function () {
            sharedObject.changeName('Victor');
            let nameEl = $('#name');
            nameEl.val('');
            sharedObject.updateName();
            expect(sharedObject.name).to.be.equal('Victor');
        });
        it('with an non - empty string, should change property', function () {
            sharedObject.changeName('Victor');
            let nameEl = $('#name');
            nameEl.val('Kiril');
            sharedObject.updateName();
            expect(sharedObject.name).to.be.equal('Kiril');
        });
    });

    describe('Update income test',()=>{
        it('with a string, should not change property', function () {
            sharedObject.changeIncome(3);
            let incomeEl = $('#income');
            incomeEl.val('income');
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(3);
        });
        it('with a floating-point, should not change property', function () {
            sharedObject.changeIncome(3);
            let incomeEl = $('#income');
            incomeEl.val('3.11');
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(3);
        });
        it('with a negative, should not change property', function () {
            sharedObject.changeIncome(3);
            let incomeEl = $('#income');
            incomeEl.val('-3');
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(3);
        });
        it('with a zero, should not change property', function () {
            sharedObject.changeIncome(3);
            let incomeEl = $('#income');
            incomeEl.val('0');
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(3);
        });
        it('with a positive number, should change property', function () {
            sharedObject.changeIncome(3);
            let incomeEl = $('#income');
            incomeEl.val('5');
            sharedObject.updateIncome();
            expect(sharedObject.income).to.be.equal(5);
        });
    });
});