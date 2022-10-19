function encodeAndDecodeMessages() {
    let buttons = document.querySelectorAll('button');
    let encodeButton = buttons[0];
    let decodeButton = buttons[1];
    let textArea = document.querySelectorAll('textarea');
    let textAreaMessage;
    let textAreaReceiveMessage = textArea[1];

    let encodeText = '';
    let decodeText = '';

    encodeButton.addEventListener('click', () => {

        textArea = document.querySelectorAll('textarea');
        textAreaMessage = textArea[0];
        encodeText = '';
        decodeText = textAreaMessage.value;

        for (let i = 0; i < textAreaMessage.value.length; i++) {

            let letterToASCII = textAreaMessage.value.charCodeAt(i);
            let encodingLetter = String.fromCharCode(letterToASCII + 1);
            encodeText += encodingLetter;

        }
        textAreaReceiveMessage.value = encodeText;
        textAreaMessage.value = '';
    });

    decodeButton.addEventListener('click', () => {
        textAreaReceiveMessage.value = decodeText;
        console.log(1);
    });
}