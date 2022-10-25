function getArticleGenerator(articles) {

    return function showNext() {
        if (articles.length == 0) {
            return;
        }
        let divResult = document.getElementById('content');
        let createArticle = document.createElement('article');
        createArticle.textContent = articles[0];
        articles.shift();
        divResult.appendChild(createArticle);

    }
}
