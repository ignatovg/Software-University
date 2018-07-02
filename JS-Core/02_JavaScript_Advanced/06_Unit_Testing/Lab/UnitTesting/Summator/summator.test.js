const createCalculator = require('./summator').createCalculator;
let expect = require('chai').expect;

describe('Calculator maker', ()=>{
    let calc;
    beforeEach(() => {
        calc = createCalculator();
    });

    it('should return an object', function () {
        expect(typeof calc).to.equal('object');
    });
    it('should have zero value when created', function () {
        expect(calc.get()).to.equal(0);
    });
    it('should add', function () {
        calc.add(3);
        calc.add(5);
        expect(calc.get()).to.equal(8);
    });
    it('should subtract', function () {
        calc.subtract(3);
        calc.subtract(5);
        expect(calc.get()).to.equal(-8);
    });
    it('should work with fractions', function () {
        calc.add(3.14);
        calc.subtract(1.13);
        expect(calc.get()).to.be.closeTo(2.01,0.001);
    });
    it('should work with negative numbers', function () {
        calc.add(-4);
        calc.subtract(-3);
        expect(calc.get()).to.equal(-1);
    });
    it('should not add NaNs', function () {
        calc.add('pesho');
        calc.subtract(-3);
        expect(calc.get()).to.be.NaN;
    });
    it('should not subtract NaNs', function () {
        calc.subtract('prakash');
        expect(calc.get()).to.be.NaN;
    });
    it('should with numbers as strings', function () {
        calc.add('7');
        calc.add(3);
        expect(calc.get()).to.equal(10);
    });
});