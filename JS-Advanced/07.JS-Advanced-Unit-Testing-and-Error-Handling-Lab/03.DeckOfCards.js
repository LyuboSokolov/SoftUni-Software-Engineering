function printDeckOfCards(cards) {

    let result = [];

    let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    let validSuits = {
        S: '\u2660 ',
        H: '\u2665 ',
        D: '\u2666 ',
        C: '\u2663 '
    };
    let isInvalideCard = false;
    createCard();

    function createCard() {

        for (let i = 0; i < cards.length; i++) {

            let currentCard = {};
            let suit = cards[i].substring(cards[i].length - 1);
            let face = cards[i].substring(0, cards[i].length - 1);
            if (!validFaces.includes(face) || !validSuits[suit]) {
                console.log(`Invalid card: ${cards[i]}`);
                isInvalideCard = true;
                break;
            }
            currentCard = `${face}${validSuits[suit]}`;
            result.push(currentCard);
        }
        if (isInvalideCard) {
            return;
        }
    }

    if (isInvalideCard) {
        return;
    }
    console.log(result.join(' '));
}
printDeckOfCards(['AS', '10D', 'KH', '2C']);