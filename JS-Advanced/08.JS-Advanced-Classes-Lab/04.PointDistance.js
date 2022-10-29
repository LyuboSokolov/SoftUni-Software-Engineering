class Point {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }
    static distance(firstPoint, secontPoint) {
        let sideA = firstPoint.x - secontPoint.x;
        let sideB = firstPoint.y - secontPoint.y;

        let distance = Math.sqrt(sideA ** 2 + sideB ** 2);
        return distance;
    }
}

let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));
