const flowerShop = require('./flowerShop');
const expect = require('chai').expect;

describe("Test flowerShop", function () {

    describe("Test function calcPriceOfFlowers", () => {

        it('Test calcPriceOfFlowers when input flower not a string', () => {
            expect(() => flowerShop.calcPriceOfFlowers([], 25, 1)).to.throw(Error, 'Invalid input!');
        })

        it('Test calcPriceOfFlowers when input price not in a number', () => {
            expect(() => flowerShop.calcPriceOfFlowers('orxide', '23', 1)).to.throw(Error, 'Invalid input!');
        })
        it('Test calcPriceOfFlowers when input quantity not in a number', () => {
            expect(() => flowerShop.calcPriceOfFlowers('orxide', 23, '1')).to.throw(Error, 'Invalid input!');
        })
        it('Test calcPriceOfFlowers when parameter is invalid', () => {
            expect(() => flowerShop.calcPriceOfFlowers(2, '23', '1')).to.throw(Error, 'Invalid input!');
        })

        it('Test calcPriceOfFlowers when input isValid', () => {
            expect(flowerShop.calcPriceOfFlowers('orxide', 23, 1)).to.equal('You need $23.00 to buy orxide!');
        })

    });

    describe('Test function checkFlowersAvailable', () => {
        it('Check flower available', () => {
            expect(flowerShop.checkFlowersAvailable("Rose", ["Rose", "Lily", "Orchid"])).to.equal(`The Rose are available!`);
        })
        it('Check flower not available', () => {
            expect(flowerShop.checkFlowersAvailable("Rose", ["Lily", "Orchid"])).to.equal(`The Rose are sold! You need to purchase more!`);
        })
    })
    describe('Test function sellFlowers', () => {
        it('Test function when firstParam not is Array', () => {

            expect(()=> flowerShop.sellFlowers('1',3)).to.throw(Error,'Invalid input!');
        })

        it('Test function when space not is number', () => {

            expect(()=> flowerShop.sellFlowers(["Rose", "Lily", "Orchid"],'3')).to.throw(Error,'Invalid input!');
        })
        it('Test function when space is less then 0', () => {

            expect(()=> flowerShop.sellFlowers(["Rose", "Lily", "Orchid"],-4)).to.throw(Error,'Invalid input!');
        })
        it('Test function when space bigger than gardanArray', () => {

            expect(()=> flowerShop.sellFlowers(["Rose", "Lily", "Orchid"],4)).to.throw(Error,'Invalid input!');
        })
        it('Test function when space equal to gardanArray', () => {

            expect(()=> flowerShop.sellFlowers(["Rose", "Lily", "Orchid"],3)).to.throw(Error,'Invalid input!');
        })
        it('Test function when space equal to 0 and gardanArray with 0 element', () => {

            expect(()=> flowerShop.sellFlowers([],0)).to.throw(Error,'Invalid input!');
        })

        //Correct input

        it('Test function when input isValid', () => {

            expect(flowerShop.sellFlowers(["Rose", "Lily", "Orchid"],1)).to.equal('Rose / Orchid');
        })

    })

});
