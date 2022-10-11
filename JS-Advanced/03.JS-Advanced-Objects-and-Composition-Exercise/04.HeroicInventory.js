function solve(input){
    let results = [];
    for (const element of input) {
        let [name,level,items] = element.split(' / ');
        level = Number(level);
        items = items ? items.split(', ') : [];
        let heroes = {
            name,
            level,
            items,
        };
        results.push(heroes);
    }
    let json = JSON.stringify(results);
    return json;
}
solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
);