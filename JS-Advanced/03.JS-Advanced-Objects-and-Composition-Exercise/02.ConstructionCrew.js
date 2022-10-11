function solve(person) {
    if (person.dizziness) {
        person.levelOfHydrated += person.experience * 0.1 * person.weight;
        person.dizziness = false;
    }
    return person;
}
solve({
    weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true
});