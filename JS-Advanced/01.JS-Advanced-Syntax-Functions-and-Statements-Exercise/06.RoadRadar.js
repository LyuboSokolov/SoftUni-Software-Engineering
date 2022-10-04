function solve(currentSpeed, area) {
    let motorway = 130;
    let interstate = 90;
    let city = 50;
    let residential = 20;
    let difference = 0;
    let status;
    if (area == 'motorway') {
        if (currentSpeed <= 130) {
            console.log(`Driving ${currentSpeed} km/h in a ${motorway} zone`)
        } else {
            if (currentSpeed - 20 <= motorway) {
                status = 'speeding';
            } else if (currentSpeed - 40 <= motorway) {
                status = 'excessive speeding';
            } else {
                status = 'reckless driving';
            }
            difference = currentSpeed - motorway;
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${motorway} - ${status}`)
        }
    }
    if (area == 'interstate') {
        if (currentSpeed <= interstate) {
            console.log(`Driving ${currentSpeed} km/h in a ${interstate} zone`)
        } else {
            if (currentSpeed - 20 <= interstate) {
                status = 'speeding';
            } else if (currentSpeed - 40 <= interstate) {
                status = 'excessive speeding';
            } else {
                status = 'reckless driving';
            }
            difference = currentSpeed - interstate;
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${interstate} - ${status}`)
        }
    }
    if (area == 'city') {
        if (currentSpeed <= city) {
            console.log(`Driving ${currentSpeed} km/h in a ${city} zone`)
        } else {
            if (currentSpeed - 20 <= city) {
                status = 'speeding';
            } else if (currentSpeed - 40 <= city) {
                status = 'excessive speeding';
            } else {
                status = 'reckless driving';
            }
            difference = currentSpeed - city;
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${city} - ${status}`)
        }
    }
    if (area == 'residential') {
        if (currentSpeed <= residential) {
            console.log(`Driving ${currentSpeed} km/h in a ${residential} zone`)
        } else {
            if (currentSpeed - 20 <= residential) {
                status = 'speeding';
            } else if (currentSpeed - 40 <= residential) {
                status = 'excessive speeding';
            } else {
                status = 'reckless driving';
            }
            difference = currentSpeed - residential;
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${residential} - ${status}`)
        }
    }
}
