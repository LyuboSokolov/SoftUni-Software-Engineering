import { html, nothing } from '../../node_modules/lit-html/lit-html.js';

import * as animalService from '../services/animalService.js';

const detailsTemplate = (game, isOwner, isUser) => html`

<!--Details Page-->
<section id="game-details">
    <h1>Game Details</h1>
    <div class="info-section">

        <div class="game-header">
            <img class="game-img" src="${game.imageUrl}" />
            <h1>${game.title}</h1>
            <span class="levels">MaxLevel: ${game.maxLevel}</span>
            <p class="type"> ${game.category}</p>
        </div>

        <p class="text">
          ${game.summary}}
        </p>

      

        <!-- Edit/Delete buttons ( Only for creator of this game )  -->
        ${isOwner

        ? html` 
            <div class="buttons">
            <a href="/games/${game._id}/edit" class="button">Edit</a>
            <a href="/games/${game._id}/delete" class="button">Delete</a>
        </div>`
        : nothing
        }
       
    </div>

  

</section>
`;


export const detailsView = (ctx) => {

    animalService.getCurrent(ctx.params.gameId)
        .then(game => {
            console.log(game._id);
            let isOwner;
            let isUser = false;
            console.log(game);
            if (ctx.user) {
                isOwner = ctx.user._id == game._ownerId;
                isUser = true;
            }

            ctx.render(detailsTemplate(game, isOwner, isUser));
        });
}

