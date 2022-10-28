function notify(message) {
  let divHidden = document.getElementById('notification');
  divHidden.textContent = message;
  divHidden.style.display = 'block';

  divHidden.addEventListener('click', () => {
    divHidden.style.display = 'none';
  })
}