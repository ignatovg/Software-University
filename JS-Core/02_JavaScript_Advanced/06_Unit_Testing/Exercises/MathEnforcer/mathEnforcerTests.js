const mathEnforcer = require('./mathEnforcer').mathEnforcer;
let expect = require('chai').expect;

describe('mathEnforcer', ()=>{

   describe('addFive method', ()=>{
       it('with a non-number parameter, should return undefined', function () {
           expect(mathEnforcer.addFive('pesho')).to.be.undefined;
       });
       it('with negative parameter, should return correct value', function () {
           expect(mathEnforcer.addFive(-1)).to.equal(4);
       });
       it('with positive parameter, should return correct value', function () {
           expect(mathEnforcer.addFive(1)).to.equal(6);
       });
       it('with negative floating point parameter, should return correct value', function () {
           expect(mathEnforcer.addFive(-1.15)).to.closeTo(3.85,0.01);
       });
       it('with positive floating point parameter, should return correct value', function () {
           expect(mathEnforcer.addFive(1.15)).to.closeTo(6.15,0.01);
       });
   });
    describe('subtractTen method', ()=>{
        it('with a non-number parameter, should return undefined', function () {
            expect(mathEnforcer.subtractTen('pesho')).to.be.undefined;
        });
        it('with negative parameter, should return correct value', function () {
            expect(mathEnforcer.subtractTen(-1)).to.equal(-11);
        });
        it('with positive parameter, should return correct value', function () {
            expect(mathEnforcer.subtractTen(1)).to.equal(-9);
        });
        it('with negative floating point parameter, should return correct value', function () {
            expect(mathEnforcer.subtractTen(-1.15)).to.closeTo(-11.15,0.01);
        });
        it('with positive floating point parameter, should return correct value', function () {
            expect(mathEnforcer.subtractTen(1.15)).to.closeTo(-8.85,0.01);
        });
    });
    describe('sum method', ()=>{
        it('with a non-number first parameter, should return undefined', function () {
            expect(mathEnforcer.sum('pesho',2)).to.be.undefined;
        });
        it('with a non-number second parameter, should return undefined', function () {
            expect(mathEnforcer.sum(2,'pesho')).to.be.undefined;
        });
        it('with negative first parameter, should return correct value', function () {
            expect(mathEnforcer.sum(-1,5)).to.equal(4);
        });
        it('with negative second parameter, should return correct value', function () {
            expect(mathEnforcer.sum(5,-2)).to.equal(3);
        });
        it('with positive parameters, should return correct value', function () {
            expect(mathEnforcer.sum(1,2)).to.equal(3);
        });
        it('with negative floating point first  parameter, should return correct value', function () {
            expect(mathEnforcer.sum(-1.15,2)).to.closeTo(0.85,0.01);
        });
        it('with negative floating point second parameter, should return correct value', function () {
            expect(mathEnforcer.sum(2,-1.15)).to.closeTo(0.85,0.01);
        });
        it('with negative floating point parameters, should return correct value', function () {
            expect(mathEnforcer.sum(-0.5,-0.5)).to.closeTo(-1,0.01);
        });
        it('with positive floating point parameters, should return correct value', function () {
            expect(mathEnforcer.sum(0.5,0.5)).to.closeTo(1,0.01);
        });
    });
});