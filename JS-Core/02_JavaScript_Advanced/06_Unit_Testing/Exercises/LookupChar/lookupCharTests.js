const lookupChar = require('./lookupChar').lookupChar;
let expect = require('chai').expect;

describe('lookup characters', ()=> {
    describe('check invalid params', ()=>{
        it('with a non-string first parameter, should return undefined', function () {
            expect(lookupChar(13,0)).to.be.undefined;
        });
        it('with a non-number second parameter, should retunr undefined', function () {
            expect(lookupChar('something','pesho'));
        });
        it('with a floating point number second parameter, should return undefined', function () {
            expect(lookupChar('something',3.12)).to.be.undefined;
        });
        it('should return undefined without second parameter', function () {
            expect(lookupChar('gosho')).to.be.undefined;
        });
        it('should return undefined with parameters as {} and []', function () {
            expect(lookupChar([],{})).to.be.undefined;
        });
        it('should return undefined with [] as first parameter', function () {
            expect(lookupChar([],-1)).to.be.undefined;
        });
        it('should return undefined from invalid first param and valid second', function () {
            expect(lookupChar(1,2)).to.be.undefined;
        });
        it('should return undefined from invalid first param and invalid second', function () {
            expect(lookupChar(1,'2')).to.be.undefined;
        });
        it('should return undefined form invalid second param', function () {
            expect(lookupChar('something','2')).to.be.undefined;
        });
    });
    describe('check invalid range', ()=>{
        it('should return Incorrect index from index bigger than str.length', function () {
            expect(lookupChar('something',25)).to.equal('Incorrect index');
        });
        it('should return Incorrect index from index equal to str.length', function () {
            expect(lookupChar('something',9)).to.equal('Incorrect index');
        });
        it('should return Incorrect index from negative index', function () {
            expect(lookupChar('something',-9)).to.equal('Incorrect index');
        });
    });

    describe('check for correct values', () =>{
        it('should return correct value (m)', function () {
            expect(lookupChar('something',2)).to.equal('m');
        });
        it('should return correct value (s)', function () {
            expect(lookupChar('something',0)).to.equal('s');
        });
        it('should return correct value (g)', function () {
            expect(lookupChar('something',8)).to.equal('g');
        });
    });
});