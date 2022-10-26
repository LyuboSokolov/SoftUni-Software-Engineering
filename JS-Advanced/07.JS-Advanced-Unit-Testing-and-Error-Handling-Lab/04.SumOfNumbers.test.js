const sum = require('./04.SumOfNumbers');
const expect = require('chai').expect;

it('Expected sum should be equal to actual sum', () => {
    expect(sum([1, 2, 3, 4])).to.equal(10);
});

it('Expected string convert sum to be equal actual sum', () => {
    expect(sum(['1', '2', '3', '4'])).to.equal(10);
})

it('Should be sum zero', () => {
    expect(sum([0])).to.equal(0);
})