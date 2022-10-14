function solve() {
  let inputText = document.getElementById('input').value.trim();
  let textArray = inputText.split('.');
  let count = 0;
  let result = '';
  let paragraphArray = [];
  while (textArray.length != 0) {
    console.log(textArray);
    if (count < 3) {
      if (textArray[0] == '') {
        textArray.shift();
        continue;
      }
      result += textArray.shift();
      result += '.';
      if (textArray.length == 0 || textArray[0] == '') {
        paragraphArray.push(result);
        continue;
      }
    } else if (count == 3) {
      paragraphArray.push(result);
      result = '';
      count = 0;
      continue;
    }
    if (textArray.length == 0) {
      paragraphArray.push(result);
    }
    count++;
  }

  for (let i = 0; i < paragraphArray.length; i++) {
    let para = document.createElement('p');
    let node = document.createTextNode(paragraphArray[i]);
    para.appendChild(node);
    const element = document.getElementById('output');
    element.appendChild(para);
  }
}