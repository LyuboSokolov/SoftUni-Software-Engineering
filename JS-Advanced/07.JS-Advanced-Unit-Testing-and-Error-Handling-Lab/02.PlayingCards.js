function factory(face, suit) {

    let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    let validSuits = {
        S: '\u2660 ',
        H: '\u2665 ',
        D: '\u2666 ',
        C: '\u2663 '
    };
    let result = {};

    if (!validFaces.includes(face) || !validSuits[suit]) {
        throw new Error('Error');
    }
    result = {
        face,
        suit,
        toString() {
            return `${this.face}${(validSuits[suit])}`;
        }
    };
    return result.toString();
}
console.log(factory('K', 'S'));