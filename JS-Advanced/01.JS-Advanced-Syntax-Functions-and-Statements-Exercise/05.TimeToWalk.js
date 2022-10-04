function solve(steps, stepLength, speed) {
    let way = steps * stepLength;
    let allTime = ((way / 1000) / speed);
    let hours = 0;
    let minutes = 0;
    let seconds = 0;
    let b = Math.floor(way / 500);
    if (allTime >= 1) {
        hours = Math.floor(allTime);
        minutes = Math.floor(allTime * 60 - hours * 60);
        seconds = Math.round(allTime * 60 * 60 - (hours * 60 * 60 + minutes * 60));

    } else {
        minutes = Math.floor(allTime * 60);
        seconds = Math.round(allTime * 60 * 60 - minutes * 60);
    }
    minutes += b;
    let resultHours = `${hours}`;
    let resultMinutes = `${minutes}`;
    let resultSeconds = `${seconds}`;

    if (hours > 0 && hours <= 9) {
        resultHours = '0' + hours;
    } else if (hours == 0) {
        resultHours = '00';
    }
    if (minutes > 0 && minutes <= 9) {
        resultMinutes = '0' + minutes;
    } else if (minutes == 0) {
        resultMinutes = '00';
    }
    if (seconds > 0 && seconds <= 9) {
        resultSeconds = '0' + seconds;
    } else if (seconds == 0) {
        resultSeconds = '00';
    }
    console.log(`${resultHours}:${resultMinutes}:${resultSeconds}`);
}
