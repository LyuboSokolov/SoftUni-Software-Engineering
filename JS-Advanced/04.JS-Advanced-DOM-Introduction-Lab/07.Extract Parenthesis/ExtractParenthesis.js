function extract(content) {
    let element = document.getElementById(content);
    let text = element.textContent;
    let result = [];

    let startIndex = 0;
    let endIndex = 0;

    for (let i = 0; i < text.length; i++) {
        let char = text[i];

        if (char == '(') {
            startIndex = i + 1;
        }
        else if (char == ')') {
            endIndex = i;
            let word = text.substring(startIndex, endIndex);
            result.push(word);
            startIndex = 0;
            endIndex = 0;
        }
    }
    return result.join(', ');
}