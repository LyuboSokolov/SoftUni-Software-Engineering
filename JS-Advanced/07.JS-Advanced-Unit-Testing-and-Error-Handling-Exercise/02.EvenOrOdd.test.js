const isOddOrEven = require('./02.EvenOrOdd');
const expect = require('chai').expect;

describe('Test isOddOrEven function', () => {
    it('Test with argument which is array', () => {
        expect(isOddOrEven([1,2])).to.equal(undefined);
    })

    it('Test with argument which is object', () => {
        expect(isOddOrEven({})).to.equal(undefined);
    })

    it('Test with odd argument', () => {
        expect(isOddOrEven('abc')).to.equal('odd');
    })
    it('Test with even argument', () => {
        expect(isOddOrEven('abcd')).to.equal('even');
    })

})

    