class getSortedList {
    constructor() {
        this.internalArray = [];
        this.size = 0;
    }

    add(element) {
        this.internalArray.push(element);
        this.size++;
        this.sort();
    }

    remove(index) {
        if (index >= 0 && index < this.internalArray.length) {
            this.internalArray.splice(index, 1);
            this.size--;
        }
    }

    get(index) {
        if (index >= 0 && index < this.internalArray.length) {
            return this.internalArray[index];
        }
    }

    toString() {
        return this.internalArray.join(' ');
    }

    sort() {
        this.internalArray = this.internalArray.sort((a, b) => a - b);
    }
}