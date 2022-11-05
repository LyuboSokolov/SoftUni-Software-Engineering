function loadRepos() {
	let liElementWithHref = document.getElementById('repos');
	let parentElement = document.getElementById('repos');
	let inputUsername = document.getElementById('username');

	let button = document.querySelector('button');

	button.addEventListener('click', () => {
		let aElement = document.createElement('a');
		aElement.href = '{repo.html_url}';
		aElement.textContent = '{repo.full_name}';
		let lieElement = document.createElement('li');
		lieElement.appendChild(aElement);
		parentElement.innerHTML = '';
		parentElement.appendChild(lieElement);

	})

	liElementWithHref.addEventListener('click', (e) => {
		e.preventDefault();
		parentElement.innerHTML = '';

		fetch(`https://api.github.com/users/${inputUsername.value}/repos`)
			.then((res) => res.json())
			.then((data) => {
				Object.values(data).forEach(repo => {
					let createLiElement = document.createElement("li");
					createLiElement.textContent = repo['full_name'];
					parentElement.appendChild(createLiElement);
				});
			});
	})
}