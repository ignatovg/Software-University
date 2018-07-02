let makeCards = require('./02_PlayingCards').makeCard;

function printDeckOfCards(cardsArr) {
    function makeCard(face, suit) {
        const validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        const validSuits = ['S', 'H', 'D', 'C'];

        if (!validFaces.includes(face)) {
            throw new Error('Invalid face.')
        }
        if (!validSuits.includes(suit)) {
            throw new Error('Invalid suit.')
        }
        let card = {
            face: face,
            suit: suit,
            toString: function () {
                let suitToChar = {
                    'S': '\u2660',  //(♠)
                    'H': '\u2665',  //(♥)
                    'D': '\u2666',  //(♦)
                    'C': '\u2663'   //(♣)
                };

                return `${card.face}${suitToChar[suit]}`
            }
        };
        return card;
    }

    let deck = [];

    for (const cardsAssString of cardsArr) {
        let face = cardsAssString.substring(0, cardsAssString.length - 1);
        let suit = cardsAssString[cardsAssString.length - 1];

        try {
            deck.push(makeCard(face, suit));
        }catch (e) {
            console.log(`Invalid card: ${cardsAssString}`);
            return;
        }
    }
    return deck.join(' ');
}

function solution (cards){
    function makeCard(face, suit) {
        const validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        const validSuits = ['S', 'H', 'D', 'C'];

        if (!validFaces.includes(face)) {
            throw new Error('Invalid face.')
        }
        if (!validSuits.includes(suit)) {
            throw new Error('Invalid suit.')
        }
        let card = {
            face: face,
            suit: suit,
            toString: function () {
                let suitToChar = {
                    'S': '\u2660',  //(♠)
                    'H': '\u2665',  //(♥)
                    'D': '\u2666',  //(♦)
                    'C': '\u2663'   //(♣)
                };

                return `${card.face}${suitToChar[suit]}`
            }
        };
        return card;
    }

    let desk = [];
    for (let cardSr of cards) {
        let face = cardSr.substring(0,cardSr.length-1);
        let suit = cardSr[cardSr.length-1];
        try {
            desk.push(makeCard(face,suit));
        }catch (e) {
            console.log(`invalid card: ${cardSr}`);
            return
        }
    }
    return desk.join(' ');
}

console.log(solution(['AS', '10D', 'KH', '2C']));
console.log(solution(['5S', '3D', 'QD', '1C']));