
import { html, nothing } from '../../node_modules/lit-html/lit-html.js';

import * as animalService from '../services/animalService.js'



const editTemplate = (animal,submitHandler) => html`
<!--Edit Page-->
<section id="editPage">
    <form class="editForm" @submit=${submitHandler}>
        <img src="${animal.image}">
        <div>
            <h2>Edit PetPal</h2>
            <div class="name">
                <label for="name">Name:</label>
                <input name="name" id="name" type="text" value="${animal.name}">
            </div>
            <div class="breed">
                <label for="breed">Breed:</label>
                <input name="breed" id="breed" type="text" value="${animal.breed}">
            </div>
            <div class="Age">
                <label for="age">Age:</label>
                <input name="age" id="age" type="text" value="${animal.age}">
            </div>
            <div class="weight">
                <label for="weight">Weight:</label>
                <input name="weight" id="weight" type="text" value="${animal.weight}">
            </div>
            <div class="image">
                <label for="image">Image:</label>
                <input name="image" id="image" type="text" value="${animal.image}">
            </div>
            <button class="btn" type="submit">Edit Pet</button>
        </div>
    </form>
</section>
`;

export const editView =(ctx) => {

    const animalId = ctx.params.animalId;

    const submitHandler =(e) => {
        e.preventDefault();

       
        const {name,breed,age, weight,image} = Object.fromEntries(new FormData(e.currentTarget));
      
        if (!(name && breed && age && weight && image)) {
            alert('Fill in all fields!');
            return;
        }
        let data = {
            name,
            breed,
            age,
            weight,
            image
        };
        animalService.edit(animalId,data)
            .then(() => {
                ctx.page.redirect(`/data/pets/${animalId}`);
            });
           
    };

    animalService.getOne(animalId)
    .then(animal => {
        ctx.render(editTemplate(animal,submitHandler));
    })
}