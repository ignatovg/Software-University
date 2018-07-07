let solve = () => {

    class Figure {
        constructor() {
            if (new.target === Figure) {
                //this.constructor is the same
                throw new TypeError("Can't do this");
            }
        }
        get area(){
            switch (this.constructor){
                case Circle:
                    return Math.PI * this.radius ** 2;
                case  Rectangle:
                    return this.width * this.height;
            }
        }
        toString(){
            let type = this.constructor.name;
           let props =  Object.getOwnPropertyNames(this);
           return type + ' - ' + props.map(p => `${p}: ${this[p]}`).join(', ');
        }
    }

    class Circle extends Figure {
        constructor(radius) {
            super();
            this.radius = radius;
        }
    }

    class Rectangle extends  Figure{
        constructor(width,height){
            super();
            this.width = width;
            this.height = height;
        }
    }
return{Figure,Circle,Rectangle};
};
let circle = new Circle(5);
console.log(circle.toString());

let rect = new Rectangle(5,8);
console.log(rect.area);
console.log(rect.toString());