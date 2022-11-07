function attachEvents() {
    let urlPosts = 'http://localhost:3030/jsonstore/blog/posts';
    let urlComments = 'http://localhost:3030/jsonstore/blog/comments';

    let parentElementPosts = document.getElementById('posts');
    let viewButton = document.getElementById('btnViewPost');
    let loadButton = document.getElementById('btnLoadPosts');
    let h1Element = document.getElementById('post-title');
    let ulElementBody = document.getElementById('post-body');
    let ulElementComments = document.getElementById('post-comments');
    let posts;

    loadButton.addEventListener('click', () => {
        fetch(urlPosts)
            .then(res => res.json())
            .then((data) => {
                Object.keys(data).forEach(key => {

                    let createOptionElement = document.createElement('option');
                    createOptionElement.value = key;
                    createOptionElement.textContent = data[key]['title'];

                    parentElementPosts.appendChild(createOptionElement);
                })
                posts = data;
            })
    })

    viewButton.addEventListener('click', () => {
        ulElementComments.textContent = '';
        let commentsId = parentElementPosts.value;
        let title = parentElementPosts.querySelector(`option[value="${commentsId}"]`).textContent;
        h1Element.textContent = title;
        Object.values(posts).filter(x => x['id'] == commentsId).forEach(x => {
            ulElementBody.textContent = x['body'];
        });

        fetch(urlComments)
            .then(res => res.json())
            .then((data) => {

                Object.values(data).filter(x => x['postId'] == commentsId).forEach(comment => {
                    let createLiElement = document.createElement('li');
                    createLiElement.id = comment['id'];
                    createLiElement.textContent = comment['text'];
                    ulElementComments.appendChild(createLiElement);
                });
            })
    })
}

attachEvents();