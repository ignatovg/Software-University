Array.prototype.toString = function () {
    return this.join('\n')
};

let rect = {
  width: 10,
  height: 4,
  grow: function (w,h) {
      this.width += w;
      this.height += h;
  },
    toString: function () {
        return (`[${this.width} x ${this.height}]`);
    }
};

let counter = (function(){
    let counter = 0;
    function getNextElement() {
        console.log(++counter);
    }
    return getNextElement;
})();

counter();
counter();
counter();

rect.grow(2, 3);
console.log(rect.toString()); // [12 x 7]
