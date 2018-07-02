function sum(arr) {
    let sum = 0;
    for(let num of arr){
        sum += Number(num);
    }
    return sum;
}

let expect = require('chai').expect;

describe('Test summator',function () {
    //with chai
    it('should return 3 for [1,2]', function () {
        expect(sum([1, 2])).to.equal(3);
    });

    it('should return NaN', function () {
        expect(sum(['pesho',2,3])).to.be.NaN;
    });

    it('should return 3.3', function () {
        expect(sum([1.1,1.1,1.1])).to.be.closeTo(3.3,0.001);
    });

    it('should work with negative numbers', function () {
        expect(sum([-1,-2,5])).to.equal(2);
    });

    it('should return NaN', function () {
        expect(sum(['pesho'])).to.be.NaN;
    });

    it('should return 1 for [1]', function () {
        expect(sum([1])).to.equal(1);
    });
    //without chai
    it('should return 0 for []', function () {
        let expected = 0;
        let actual = sum([]);
        if (expected !== actual) {
            throw new Error('0 != 0');
        }
    });
});
