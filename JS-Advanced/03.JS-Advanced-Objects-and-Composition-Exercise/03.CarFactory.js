function solve(car) {
    if (car.power <= 90) {
        car.power = {
            power: 90,
            volume: 1800
        }
    } else if (car.power <= 120) {
        car.power = {
            power: 120,
            volume: 2400
        }
    } else {
        car.power = {
            power: 200,
            volume: 3500
        }
    }
    car.carriage = {
        type: car.carriage,
        color: car.color
    }
    let wheelSize = car.wheelsize;
    if (car.wheelsize % 2 == 0) {
        wheelSize -= 1;
    }
    car.wheelsize = [wheelSize, wheelSize, wheelSize, wheelSize];

    car.engine = car.power;
    delete car.power;
    delete car.color;
    car.wheels = car.wheelsize;
    delete car.wheelsize;

    return car;
}
solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
);