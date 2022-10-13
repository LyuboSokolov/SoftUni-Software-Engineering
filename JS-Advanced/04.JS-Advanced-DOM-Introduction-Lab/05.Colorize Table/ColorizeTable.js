function colorize() {
    let elements = document.getElementsByTagName('tr');
    let rows = Array.from(elements);
    rows.forEach((x,i) => {
        if (i%2 != 0) {
            x.style.backgroundColor = 'teal';
        }
    });
}