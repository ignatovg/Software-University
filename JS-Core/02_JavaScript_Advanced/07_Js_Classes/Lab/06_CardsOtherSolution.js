let Suits = {
    SPADES: '♠',
    HEARTS: '♥',
    DIAMONDS: '♦',
    CLUBS: '♣',
};

//copy of all get and set functions
class Card {
    constructor(inFace, inSuit) {
        let face;
        let suit;

        this.getFace = function () {
            return face;
        };
        this.setFace = function (value) {
            if (!Card.validFaces.includes(value)) {
                throw new Error('Invalid face');
            }
           face = value;
        };

        this.getSuit = function () {
            return suit;
        };
        this.setSuit = function (value) {
            if (!Object.keys(Suits).map(k => Suits[k]).includes(value)) {
                throw new Error('Invalid suit')
            }
            suit = value;
        };

        this.setFace(inFace);
        this.setSuit(inSuit);
    }

    toString() {
        return this.getFace() + this.getSuit();
    }

}
Object.defineProperty(Card, 'validFaces',{
    value: ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"],
    enumerable:false

    });
Card._validFaces =c1 = new Card('2', Suits.SPADES);
console.log(c1.toString());

console.log(Object.keys(Card));
Card.validFaces.push('1');
let c2 = new Card('1',Suits.SPADES);
console.log(c2.toString());