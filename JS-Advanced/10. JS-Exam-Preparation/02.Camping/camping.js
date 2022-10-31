class SummerCamp {

    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location;
    }

    listOfParticipants = [];

    priceForTheCamp = {
        child: 150,
        student: 300,
        collegian: 500
    }

    registerParticipant(name, condition, money) {

        if (!this.priceForTheCamp.hasOwnProperty(condition)) {
            throw new Error('Unsuccessful registration at the camp.');
        }
        if (this.listOfParticipants.includes(this.listOfParticipants.find(x=> x.name ==name))) {
            return `The ${name} is already registered at the camp.`;

        }

        if (this.priceForTheCamp[condition] > money) {
            return `The money is not enough to pay the stay at the camp.`
        }

        let participant = {
            name,
            condition,
            power: 100,
            wins: 0
        };
        this.listOfParticipants.push(participant);

        return `The ${name} was successfully registered.`;
    }

    unregisterParticipant(name) {

        let currentParticipant = this.listOfParticipants.find(x => x.name == name);

        if (currentParticipant == undefined) {
            throw new Error(`The ${name} is not registered in the camp.`);
        }
        let index = this.listOfParticipants.indexOf(currentParticipant);
        this.listOfParticipants.splice(index, 1);

        return `The ${name} removed successfully.`;
    }

    timeToPlay(typeOfGame, participant1, participant2 = null) {

        let firstPlayer = this.listOfParticipants.find(x => x.name == participant1);
        let secondPlayer = this.listOfParticipants.find(x => x.name == participant2);

        if (firstPlayer == undefined) {
            throw new Error(`Invalid entered name/s.`);
        }

        if (typeOfGame == 'WaterBalloonFights') {

            if (secondPlayer == undefined) {
                throw new Error(`Invalid entered name/s.`);
            }
            if (firstPlayer.condition != secondPlayer.condition) {
                throw new Error(`Choose players with equal condition.`);
            }

            if (firstPlayer.power > secondPlayer.power) {
                firstPlayer.wins++;
                return `The ${firstPlayer.name} is winner in the game ${typeOfGame}.`;
            } else if (firstPlayer.power < secondPlayer.power) {
                secondPlayer.wins++;
                return `The ${secondPlayer.name} is winner in the game ${typeOfGame}.`;
            } else {
                return `There is no winner.`;
            }

        } else if (typeOfGame == 'Battleship') {
            firstPlayer.power += 20;
            return `The ${firstPlayer.name} successfully completed the game ${typeOfGame}.`;
        }
    }

    toString() {
        let result = `${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`;

        let sortParticipants = this.listOfParticipants.sort((a, b) => {
            return b.wins - a.wins;
        });

        this.listOfParticipants.forEach(x => {
            result +=`\n${x.name} - ${x.condition} - ${x.power} - ${x.wins}`
        });

        return result;
    }
}
const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.unregisterParticipant("Petar"));
console.log(summerCamp.unregisterParticipant("Petar Petarson"));

