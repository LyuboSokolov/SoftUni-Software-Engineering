import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as animalService from '../services/animalService.js'


const gameTemplate = (game) => html`

<div class="game">
    <div class="image-wrap">
        <img src="${game.imageUrl}">
    </div>
    <h3>${game.title}</h3>
    <div class="rating">
        <span>☆</span><span>☆</span><span>☆</span><span>☆</span><span>☆</span>
    </div>
    <div class="data-buttons">
        <a href="/data/games/${game._id}" class="btn details-btn">Details</a>
    </div>
</div>
`;




const homeTemplate = (games) => html`
<!--Home Page-->
<section id="welcome-world">

    <div class="welcome-message">
        <h2>ALL new games are</h2>
        <h3>Only in GamesPlay</h3>
    </div>
    <img src="./images/four_slider_img01.png" alt="hero">

    <div id="home-page">
        <h1>Latest Games</h1>

       ${games.map(x => gameTemplate(x))}
       
            ${games.length == 0
        ? html`<!-- Display paragraph: If there is no games  -->
                <p class="no-articles">No games yet</p>`
        : nothing
    }
            </div>
</section>
       `;


export const homeView = (ctx) => {

    animalService.getMostGames()
        .then(games => {
            ctx.render(homeTemplate(games));
        })


}