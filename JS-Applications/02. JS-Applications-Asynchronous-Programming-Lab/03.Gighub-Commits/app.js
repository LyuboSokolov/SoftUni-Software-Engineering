function loadCommits() {
    let inputUsername = document.getElementById('username');
    let inputRepo = document.getElementById('repo');
    let parentElement = document.getElementById('commits');

    parentElement.innerHTML = '';
    fetch(`https://api.github.com/repos/${inputUsername.value}/${inputRepo.value}/commits`)
        .then(res => res.json())
        .then((data) => {
            Object.values(data).forEach(x => {
                let liElement = document.createElement('li');
                liElement.textContent = `${x['commit']['author']['name']}: ${x['commit']['message']}`;
                parentElement.appendChild(liElement);
            })
        })
}