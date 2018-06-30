function createRectLecturer(width, height) {
    let rect = {
        width: width,
        height: height,
        area: () => rect.width * rect.height,
        compareTo: function (other) {
            let result = other.area() - rect.area();
            return result || (other.width - rect.width);
        },
        toString: function () {
            return `[${this.width} x ${this.height}]`
        }
    };
    return rect;
}

/*
let myRect = createRect(7, 5) ;
let otherRect = createRect(20,16);
let rectArr = [myRect, otherRect];
console.log(rectArr.map(e=>e.toString()));
rectArr.sort((a,b) => a.compareTo(b));
console.log(rectArr.map(e=>e.toString()));
*/

function orderRects(rectsData) {
    let rects = [];
    for (let [width, height] of rectsData) {
        let rect = createRect(width, height);
        rects.push(rect);
    }
    rects.sort((a, b) => a.compareTo(b));
    return rects;

    function createRect(width, height) {
        return rect = {
            width,
            height,
            area: () => rect.width * rect.height,
            compareTo: function (other) {
                let comparisonResult = other.area() - rect.area();
                if (comparisonResult === 0) {
                    return other.width - rect.width;
                }
                return comparisonResult;
            }
        };
    }
}

console.log(orderRects([[15, 5],[5, 15], [5, 12]]));