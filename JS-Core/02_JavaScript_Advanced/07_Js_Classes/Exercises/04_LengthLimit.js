class Stringer {
    constructor(innerString, innerLength) {
        this.innerString = innerString;
        this.innerLength = innerLength;
    }

    get innerString() {
        return this._innerString;
    }

    set innerString(value) {

        this._innerString = value;
    }

    get innerLength() {
        return this._innerLength
    };

    set innerLength(value) {
        if (value < 0) {
            value = 0
        }
        this._innerLength = value;
    }

    increase(length) {
        this.innerLength+=length;
    }

    decrease(length) {
        this.innerLength-=length;
    }
    toString(){
        if(this.innerLength >= this.innerString.length){
            return this.innerString;
        }else if(this.innerLength === 0){
            return '.'.repeat(3);
        }else {
          let firstPart = this.innerString.substr(0,this.innerLength);
          let secondPart = '.'.repeat(3);
          return firstPart+secondPart;
        }
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); //Test

test.decrease(3);
console.log(test.toString()); //Te...

test.decrease(5);
console.log(test.toString()); //...

test.increase(4);
console.log(test.toString()); //Test
