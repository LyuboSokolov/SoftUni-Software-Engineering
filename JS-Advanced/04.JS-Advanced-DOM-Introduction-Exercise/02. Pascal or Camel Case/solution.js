function solve() {
  let text = document.getElementById('text').value;
  let namingConvention = document.getElementById('naming-convention').value;
  let textArray = text.split(' ');
  let result = [];
  let isCamalCase = false;

  if (namingConvention != 'Camel Case' && namingConvention != 'Pascal Case') {
    result.push('Error!');
  } else {
    if (namingConvention == 'Camel Case') {
      isCamalCase = true;
    }
    for (let i = 0; i < textArray.length; i++) {

      currentWord = textArray[i].toLowerCase();
      let firstChar = currentWord[0];
      if (isCamalCase && i == 0) {
        result.push(currentWord);
      } else {
        currentWord = currentWord.replace(firstChar, firstChar.toUpperCase());
        result.push(currentWord);
      }
    }
  }
  document.getElementById('result').textContent = result.join('');
}