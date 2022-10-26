const testFunction = require('./05.CheckForSymmetry');
const expect = require('chai').expect;

describe('Tests for isSymmetric(arr)', () => {

    describe('Regular cases', () => {

        it('Should be array argument return false', () => {
            expect(testFunction()).to.be.false;
        })
        it('Should be array argument', () => {
            expect(testFunction({})).to.be.false;
        })

        it('Should be return false when string is argument', () => {
            expect(testFunction('123')).to.be.false;
        });

        //it('Should be true argument of numbers is symmetric', () => {
        //    expect(testFunction([1, 2, 1])).to.be.true;

        // })

        it('Should be false if argument is  not symmetric', () => {
            expect(testFunction([1, 2, 3])).to.be.false;

        })
        // it('Should be true if argument of string is symmetric', () => {
        //  expect(testFunction(['a','b','a'])).to.be.true;

        // })

        it('Should be false is argument is even numbers symmetric', () => {
            expect(testFunction([1, 2, 2, 1])).to.be.true;

        })
    })
})

