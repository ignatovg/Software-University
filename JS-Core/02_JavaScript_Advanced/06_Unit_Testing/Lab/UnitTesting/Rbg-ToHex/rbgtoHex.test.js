let rgbToHexColor = require('./rbg-toHex').rgbToHexColor;
let expect = require('chai').expect;

describe('RBG to Hex color',() =>{
    it('should return #FF9EAA from (255, 158, 170)', function () {
        expect(rgbToHexColor(255, 158, 170)).to.contains('#FF9EAA');
    });
    it('should pad values with zeroes', function () {
        expect(rgbToHexColor(12,13,14)).to.contains('#0C0D0E');
    });
    it('should work at lower limit', function () {
        expect(rgbToHexColor(0,0,0)).to.contains('#000000');
    });
    it('should work at upper limit', function () {
        expect(rgbToHexColor(255,255,255)).to.contains('#FFFFFF');
    });
    it('should return undefined for negative values', function () {
        expect(rgbToHexColor(-1,-1,-1)).to.equal(undefined);
    });
    it('should return undefined for values greater then 255', function () {
        expect(rgbToHexColor(256,256,256)).to.equal(undefined);
    });
    it('should return undefined for values greater then 255', function () {
        expect(rgbToHexColor(15,15,256)).to.equal(undefined);
    });
    it('should return undefined for fractions', function () {
        expect(rgbToHexColor(3.15,5,19)).to.equal(undefined);
    });
    it('should return undefined for fractions', function () {
        expect(rgbToHexColor('pesho','gosho',2)).to.equal(undefined);
    });
});