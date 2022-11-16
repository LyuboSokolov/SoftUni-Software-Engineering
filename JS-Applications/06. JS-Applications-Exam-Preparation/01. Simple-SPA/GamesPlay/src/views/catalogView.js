import { html, nothing } from '../../node_modules/lit-html/lit-html.js';

import * as animalService from '../services/animalService.js';

const gameTemplate = (game) => html` 

<div class="allGames">
<div class="allGames-info">
    <img src="${game.imageUrl}">
    <h6>${game.category}</h6>
    <h2>${game.title}</h2>
    <a href="/data/games/${game._id}" class="details-button">Details</a>
</div>
</div>
`;

const gamesTemplate = (games) => html`
<!-- Catalogue -->
<section id="catalog-page">
    <h1>All Games</h1>
    <!-- Display div: with information about every game (if any) -->

        ${games.map(x => gameTemplate(x))};

        ${games.length == 0
        ? html`  <!-- Display paragraph: If there is no games  -->
        <h3 class="no-articles">No articles yet</h3>
    </section>`
        : nothing
          }

`;

export const catalogView = (ctx) => {

    animalService.getAll()
        .then(animals => {

            ctx.render(gamesTemplate(animals));
        })

}   