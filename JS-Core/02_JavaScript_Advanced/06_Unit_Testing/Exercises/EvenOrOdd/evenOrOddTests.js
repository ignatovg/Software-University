const isOddOrEven = require('./evenOrOdd').isOddOrEven;
let expect = require('chai').expect;

describe('Is odd or even', ()=>{
    it('should undefined from number parameter', function () {
        expect(isOddOrEven(3)).to.be.undefined;
    });

    it('should undefined from object parameter', function () {
        expect(isOddOrEven({})).to.be.undefined;
    });

    it('should return even from event length string', function () {
        expect(isOddOrEven('roar')).to.equal('even');
    });

    it('should return odd from odd lenght string', function () {
        expect(isOddOrEven('pesho')).to.equal('odd');
    });

    it('multiple consecutive check should return correct value', function () {
        expect(isOddOrEven('cat')).to.equal('odd');
        expect(isOddOrEven('dog')).to.equal('odd');
        expect(isOddOrEven('elephant')).to.equal('even');
        expect(isOddOrEven('leon')).to.equal('even');
    });
});
