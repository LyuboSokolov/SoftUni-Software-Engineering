function solve(input) {
    result = [];

    for (const line of input) {

        let [func, text] = line.split(" ");
        this.add(text);
    }
    return {
        add(str) {
            result.push(str);
        },
        remove(str) {
            result = result.filter(x => x != str);
        },
        print() {
            console.log(result, join(', '));
        }

    }

}



    solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);