const library = require('./library');
const expect = require('chai').expect;

describe('Test library', () => {
    describe('Test function calcPriceOfBook', () => {
        it('Test calcPriceOfBook witn invalid nameOfbook', () => {
            expect(() => library.calcPriceOfBook([], 2000)).to.throw(Error, "Invalid input");
        })
        it('Test calcPriceOfBook witn invalid year', () => {
            expect(() => library.calcPriceOfBook('KingKong', "2000")).to.throw(Error, "Invalid input");
        })
        it('Test calcPriceOfBook witn invalid year 220.5', () => {
            expect(() => library.calcPriceOfBook('KingKong', 2202.5)).to.throw(Error, "Invalid input");
        })

        it('Test calcPriceOfBook witn invalid nameOfBook and year', () => {
            expect(() => library.calcPriceOfBook([], "2000")).to.throw(Error, "Invalid input");
        })
        it('Test calcPriceOfBook witn valid input and year before 1980', () => {
            expect(library.calcPriceOfBook('KingKong', 1980)).to.equal('Price of KingKong is 10.00');
        })
        it('Test calcPriceOfBook witn valid input and year before 1980', () => {
            expect(library.calcPriceOfBook('KingKong', 1970)).to.equal('Price of KingKong is 10.00');
        })
        it('Test calcPriceOfBook witn valid input and year after 1980', () => {
            expect(library.calcPriceOfBook('KingKong', 2000)).to.equal('Price of KingKong is 20.00');
        })
    })

    describe('Test function findBook', () => {

        it('Test findBook with empty array', () => {
            expect(() => library.findBook([], 'Troy')).to.throw(Error, 'No books currently available');
        })
        it('Test findBook with correct input', () => {
            expect(library.findBook(["Troy", "Life Style", "Torronto"], 'Troy')).to.equal('We found the book you want.');
        })
        it('Test findBook with array,but missing currentBook', () => {
            expect(library.findBook(["Troy", "Life Style", "Torronto"], 'KingKong')).to.equal('The book you are looking for is not here!');
        })
    })

    describe('Test function arrangeTheBooks', () => {
        it('Test function arrangeTheBooks with incorrect countOfBooks with other type', () => {
            expect(() => library.arrangeTheBooks('2')).to.throw(Error, "Invalid input");
        })
        it('Test function arrangeTheBooks with incorrect countOfBooks with negative number', () => {
            expect(() => library.arrangeTheBooks(-2)).to.throw(Error, "Invalid input");
        })
        it('Test function arrangeTheBooks with incorrect countOfBooks with float number', () => {
            expect(() => library.arrangeTheBooks(2.5)).to.throw(Error, "Invalid input");
        })

        it('Test function arrangeTheBooks with correct countOfBooks', () => {
            expect(library.arrangeTheBooks(2)).to.equal("Great job, the books are arranged.");
        })
        it('Test function arrangeTheBooks with correct countOfBooks 40', () => {
            expect(library.arrangeTheBooks(40)).to.equal("Great job, the books are arranged.");
        })
        it('Test function arrangeTheBooks with correct countOfBooks but bigger then space', () => {
            expect(library.arrangeTheBooks(41)).to.equal("Insufficient space, more shelves need to be purchased.");
        })
        it('Test function arrangeTheBooks with correct countOfBooks 0', () => {
            expect(library.arrangeTheBooks(0)).to.equal("Great job, the books are arranged.");
        })
    })


})