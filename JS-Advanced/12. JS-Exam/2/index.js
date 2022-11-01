class LibraryCollection {

    constructor(capacity) {
        this.capacity = capacity;
        this.books = [];
    }

    addBook(bookName, bookAuthor) {
        if (!((typeof bookName == 'string') && (typeof bookAuthor == 'string'))) {
            return;
        }
        if (this.books.length == this.capacity) {
            throw new Error("Not enough space in the collection.");
        }

        let currentBook = {
            bookName,
            bookAuthor,
            payed: false
        };

        this.books.push(currentBook);

        return `The ${bookName}, with an author ${bookAuthor}, collect.`
    }

    payBook(bookName) {
        let currentBook = this.books.find(x=> x.bookName == bookName);

        if (!currentBook) {
            throw new Error(`${bookName} is not in the collection.`)
        }
        if (currentBook.payed) {
            throw new Error(`${bookName} has already been paid.`)
        }

        currentBook.payed = true;

        return `${bookName} has been successfully paid.`;
    }

    removeBook(bookName) {
        let currentBook = this.books.find(x=> x.bookName == bookName);

        if (!currentBook) {
            throw new Error("The book, you're looking for, is not found.");
        }
        if (currentBook.payed == false) {
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        }

        let indexRemove = this.books.indexOf(currentBook);
        this.books.splice(indexRemove,1);

        return `${bookName} remove from the collection.`
    }

    getStatistics(bookAuthor) {
        

        if (!bookAuthor) {
            let result;
            result = `The book collection has ${this.capacity - this.books.length} empty spots left.`

            let sortBooksByName = this.books.sort((a,b) => {
                return (a.bookName).localeCompare(b.bookName);
            });

         for (const currentElement of sortBooksByName) {
             
            let hasPaid = 'Not Paid';
            if (currentElement.payed) {
                hasPaid = 'Has Paid';
            }

            result += `\n${currentElement.bookName} == ${currentElement.bookAuthor} - ${hasPaid}.`
         }

         return result; 
        }

        if (bookAuthor) {

            if (!this.books.some(x=> x.bookAuthor ==bookAuthor)) {
                throw new Error (`${bookAuthor} is not in the collection.`)
            }

            let filtredBooks = this.books.filter(x=> x.bookAuthor == bookAuthor);
            let result =[];
            for (const currentElement of filtredBooks) {
             
                let hasPaid = 'Not Paid';
                if (currentElement.payed) {
                    hasPaid = 'Has Paid';
                }
    
                result.push(`${currentElement.bookName} == ${currentElement.bookAuthor} - ${hasPaid}.`);
             }

             return result.join('\n');
    
        }
    }
}

const library = new LibraryCollection(2)
console.log(library.addBook('In Search of Lost Time', 'Marcel Proust'));
console.log(library.addBook('Don Quixote', 'Miguel de Cervantes'));
console.log(library.addBook('Ulysses', 'James Joyce'));
