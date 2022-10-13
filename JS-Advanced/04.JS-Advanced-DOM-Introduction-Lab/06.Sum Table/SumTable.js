function sumTable() {
    let elements = document.querySelectorAll('td:nth-last-of-type(1)');
    let array = Array.from(elements);
    array.pop();
    let sum = 0;
    array.forEach(x => {
        sum += Number(x.textContent);
    })
    document.getElementById('sum').textContent = sum;
}