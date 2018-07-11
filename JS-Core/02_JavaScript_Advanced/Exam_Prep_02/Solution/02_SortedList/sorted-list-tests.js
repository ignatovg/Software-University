let SortedList = require('./sorted-list').SortedList;
let expect = require('chai').expect;

describe('Sorted list unit tests',()=>{
   let myList;
   beforeEach(function () {
       myList = new SortedList();
   });

   describe('Test initial state',()=>{
       it('add exists', function () {
           expect(SortedList.prototype.hasOwnProperty('add')).to.equal(true);
       });
       it('remove exists', function () {
           expect(SortedList.prototype.hasOwnProperty('remove')).to.equal(true);
       });
       it('get exists', function () {
           expect(SortedList.prototype.hasOwnProperty('get')).to.equal(true);
       });
       it('size exists', function () {
           expect(SortedList.prototype.hasOwnProperty('size')).to.equal(true);
       });
   });

   describe('Test add',function () {
       it('with one element', function () {
           myList.add(5);
           expect(myList.list.join(', ')).to.equal('5','List did not add correctly!');
       });
       it('with many elements', function () {
           myList.add(5);
           myList.add(4);
           myList.add(3);
           expect(myList.list.join(', ')).to.equal('3, 4, 5')
       });
   });
   describe('Test remove',function () {
       it('with empty list', function () {
           expect(()=> myList.remove()).throw(Error,'Collection is empty.');
       });
       it('with negative index',function () {
           myList.add(3);
           expect(()=> myList.remove(-1)).throw(Error,'Index was outside the bounds of the collection.')
       });
       it('with index equal to list length', function () {
           myList.add(3);
           expect(()=> myList.remove(1)).throw(Error,'Index was outside the bounds of the collection.')
       });
       it('with index bigger than list length', function () {
           myList.add(3);
           expect(()=> myList.remove(10)).throw(Error,'Index was outside the bounds of the collection.')
       });
       it('with correct index, should remove', function () {
           myList.add(3);
           myList.add(5);
           myList.add(6);
           myList.remove(1);
           expect(myList.list.join(', ')).to.equal('3, 6');
       });
   });
   describe('Test get',function () {
       it('with empty list', function () {
           expect(()=> myList.get()).throw(Error,'Collection is empty.');
       });
       it('with negative index',function () {
           myList.add(3);
           expect(()=> myList.get(-1)).throw(Error,'Index was outside the bounds of the collection.')
       });
       it('with index equal to list length', function () {
           myList.add(3);
           expect(()=> myList.get(1)).throw(Error,'Index was outside the bounds of the collection.')
       });
       it('with index bigger than list length', function () {
           myList.add(3);
           expect(()=> myList.get(10)).throw(Error,'Index was outside the bounds of the collection.')
       });
       it('with correct index, should remove', function () {
           myList.add(3);
           myList.add(5);
           myList.add(6);
           let element = myList.get(1);
           expect(element).to.equal(5);
       });
   });
   describe('Test size',function () {
       it('with empty list', function () {
           expect(myList.size).to.equal(0);
       });
       it('with non-empty list', function () {
           myList.add(5);
           myList.add(2);
           expect(myList.size).to.equal(2);
       });
   })
});