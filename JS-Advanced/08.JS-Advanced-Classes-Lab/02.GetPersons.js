function getPersons() {
    class Person {
        constructor(firstName, lastName, age, email) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.email = email;
        }
        toString() {
            return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`
        }
    }
    let array = [];
    let firstPerson = new Person('Anna', 'Simpson', 22, 'anna@yahoo.com');
    let secondPerson = new Person('SoftUni');
    let thirdPerson = new Person('Stephan', 'Johnson', 25);
    let fourdPerson = new Person('Gabriel', 'Peterson', 24, 'g.p@gmail.com');
    array.push(firstPerson, secondPerson, thirdPerson, fourdPerson);

    return array;
}

solve();