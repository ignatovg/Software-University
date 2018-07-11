const list = require('./02_AddDeleteInList').list;
let expect = require('chai').expect;

describe('AddDeleteInList', function () {
    describe('Testing ToString',()=>{
        it('should return empty arr', function () {
            expect(list.toString()).to.equal('');
        });
    });

    describe('Testing AddItem', () => {
        it('should appends given item to the end of the list', function () {
            list.add(2);
            expect(list.toString()).to.equal('2');
        });
        it('should appends given item to the end of the list', function () {
            list.add('joro');
            expect(list.toString()).to.equal('2, joro');
        });
    });
    describe('Testing Delete',()=>{
        it('should return undefined form negative number', function () {
            expect(list.delete(-1)).to.be.undefined;
        });
        it('should return undefined from index larger then length', function () {
            expect(list.delete(100)).to.be.undefined;
        });
        it('should return undefined from floating-point number', function () {
            expect(list.delete(3.12)).to.be.undefined;
        });
        it('should retrun undefined from negativev floating point number', function () {
            expect(list.delete(-3.14)).to.be.undefined;
        });
        it('should return correct result', function () {
            list.delete(0);
            expect(list.toString()).to.equal('joro');
        });
        it('should return correct result', function () {
            list.delete(0);
            expect(list.toString()).to.equal('');
        });
        it('should return correct result', function () {
           list.add(1);
           list.add(2);
           list.add(3);
            list.delete(2);
            expect(list.toString()).to.equal('1, 2');
        });
    })
});

