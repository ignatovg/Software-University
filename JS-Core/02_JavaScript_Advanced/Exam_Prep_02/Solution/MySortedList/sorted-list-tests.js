const SortedList = require('./sorted-list').SortedList;
let expect = require('chai').expect;

describe('SortedList tests', () => {
    let myList;
    beforeEach(function () {
        myList = new SortedList();
    });
    describe('Test initial state', () => {
        it('should return true from prototype.hasOwnProperty(add)', function () {

            expect(SortedList.prototype.hasOwnProperty('add')).to.equal(true);
        });
        it('should return true from prototype.hasOwnProperty(remove)', function () {
            expect(SortedList.prototype.hasOwnProperty('remove')).to.equal(true);
        });
        it('should return true from prototype.hasOwnProperty(get)', function () {
            expect(SortedList.prototype.hasOwnProperty('get')).to.equal(true);
        });
        it('should return true from prototype.hasOwnProperty(size)', function () {
            expect(SortedList.prototype.hasOwnProperty('size')).to.equal(true);
        });
    });
    describe('Test add function', () => {
        it('should return empty list', function () {
            expect(myList.list.join(', ')).to.equal('');
        });
        it('should return 3, 1 from adding elements to list', function () {
            myList.add(3);
            myList.add(1);
            expect(myList.list.join(', ')).to.equal('1, 3');
        });
    });
    describe('Test remove function', () => {
        it('should throw error form empty list', function () {
            expect(() => myList.remove()).throw(Error, 'Collection is empty.');
        });
        it('should throw error from negative index', function () {
            myList.add(3);
            expect(() => myList.remove(-1)).throw(Error, 'Index was outside the bounds of the collection.');
        });
        it('should throw error from index larger than list lenght', function () {
            myList.add(1);
            expect(() => myList.remove(10)).throw(Error, 'Index was outside the bounds of the collection.')
        });
        it('should throw error from index equal to length of list', function () {
           myList.add(2);
           myList.add(3);
           expect(()=>myList.remove(2)).throw(Error,'Index was outside the bounds of the collection.')
        });
        it('should return correct result', function () {
            myList.add(3);
            myList.add(2);
            myList.add(1);
            myList.remove(1);
            expect(myList.list.join(', ')).to.equal('1, 3');
        });
    });
    describe('Test get index function', ()=>{
        it('should throw error form empty list', function () {
            expect(() => myList.get()).throw(Error, 'Collection is empty.');
        });
        it('should throw error from negative index', function () {
            myList.add(3);
            expect(() => myList.get(-1)).throw(Error, 'Index was outside the bounds of the collection.');
        });
        it('should throw error from index larger than list lenght', function () {
            myList.add(1);
            expect(() => myList.get(10)).throw(Error, 'Index was outside the bounds of the collection.')
        });
        it('should throw error from index equal to length of list', function () {
            myList.add(2);
            myList.add(3);
            expect(()=>myList.get(2)).throw(Error,'Index was outside the bounds of the collection.')
        });
        it('should return correct result', function () {
            myList.add(3);
            myList.add(2);
            myList.add(1);
            expect(myList.get(1)).to.equal(2);
        });
    });
    describe('Test size function',()=>{
        it('should return 0 from empty list', function () {
            expect(myList.size).to.equal(0);
        });
        it('should return 2 from list of two elements', function () {
            myList.add(1);
            myList.add(1);
            expect(myList.size).to.equal(2);
        });
    });
});