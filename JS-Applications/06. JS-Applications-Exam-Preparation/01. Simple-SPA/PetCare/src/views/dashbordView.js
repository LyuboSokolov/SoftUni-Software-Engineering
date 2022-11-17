import { html, nothing } from '../../node_modules/lit-html/lit-html.js';

import * as animalService from '../services/animalService.js';

const animalTemplate = (animal) => html` 
<div class="animals-board">
    <article class="service-img">
        <img class="animal-image-cover" src="${animal.image}">
    </article>
    <h2 class="name">${animal.name}</h2>
    <h3 class="breed">${animal.breed}</h3>
    <div class="action">
        <a class="btn" href="/data/pets/${animal._id}">Details</a>
    </div>
</div>
`;

const animalsTemplate = (animals) => html`

<section id="dashboard">
    <h2 class="dashboard-title">Services for every animal</h2>
    <div class="animals-dashboard">

        ${animals.map(x => animalTemplate(x))};

        ${animals.length == 0
        ? html` <div>
            <p class="no-pets">No pets in dashboard</p>
        </div>`
        : nothing
          }
    </div>

`;

export const dashbordView = (ctx) => {

    animalService.getAll()
        .then(animals => {

            ctx.render(animalsTemplate(animals));
        })

}