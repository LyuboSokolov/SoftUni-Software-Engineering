const mathEnforcer = require('./04.MathEnforcer');
const expect = require('chai').expect;

describe('Test addFive function', () => {
    it('param is not a number', () => {
        expect(mathEnforcer.addFive("1")).to.equal(undefined);
    });
    it('param is negative number', () => {
        expect(mathEnforcer.addFive(-5)).to.equal(0);
    });
    it('param is a number', () => {
        expect(mathEnforcer.addFive(1)).to.equal(6);
        expect(mathEnforcer.addFive(1.5)).to.equal(6.5);
    });
    it('param is not a number', () => {
        expect(mathEnforcer.addFive('')).to.equal(undefined);
    });

});
describe('Test subtractTen function', () => {
    it('param is not a number', () => {
        expect(mathEnforcer.subtractTen("1")).to.equal(undefined);
    });
    it('param is a number', () => {
        expect(mathEnforcer.subtractTen(10)).to.equal(0);
        expect(mathEnforcer.subtractTen(10.5)).to.equal(0.5);
    });
    it('param is not a number', () => {
        expect(mathEnforcer.subtractTen(-1)).to.equal(-11);
    });
});

describe('Test sum function', () => {
    it('first param not is number', () => {
        expect(mathEnforcer.sum('1', 2)).to.equal(undefined);
    });
    it('second param not is number', () => {
        expect(mathEnforcer.sum(1, '2')).to.equal(undefined);
    });
    it('Two param is number', () => {
        expect(mathEnforcer.sum(1, 2)).to.equal(3);
        expect(mathEnforcer.sum(1.5, 2.5)).to.equal(4);
    });
    it('Two param is negative number', () => {
        expect(mathEnforcer.sum(-11, -22)).to.equal(-33);
    });
});