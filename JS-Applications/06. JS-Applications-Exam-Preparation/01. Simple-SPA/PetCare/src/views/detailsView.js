import { html,nothing } from '../../node_modules/lit-html/lit-html.js';

import * as animalService from '../services/animalService.js';

const detailsTemplate = (animal,isOwner,isUser) => html`

<section id="detailsPage">
    <div class="details">
        <div class="animalPic">
            <img src="${animal.image}">
        </div>
        <div>
            <div class="animalInfo">
                <h1>Name: ${animal.name}</h1>
                <h3>Breed: ${animal.breed}</h3>
                <h4>Age: ${animal.age}</h4>
                <h4>Weight: ${animal.weight}</h4>
                <h4 class="donation">Donation: 0$</h4>
            </div>

            ${isOwner
                ? html ` <!-- if there is no registered user, do not display div-->
                        <div class="actionBtn">
                          <!-- Only for registered user and creator of the pets-->
                           <a href="/pets/${animal._id}/edit" class="edit">Edit</a>
                           <a href="/pets/${animal._id}/delete" class="remove">Delete</a>
                           <!--(Bonus Part) Only for no creator and user-->
                           <!--<a href="#" class="donate">Donate</a> -->
                         </div>`
                :nothing
            }

${ isUser && !isOwner
    ? html ` <!-- if there is no registered user, do not display div-->
            <div class="actionBtn">
              <!-- Only for registered user and creator of the pets-->
              <!-- <a href="/pets/${animal._id}/edit" class="edit">Edit</a>-->
              <!-- <a href="/pets/${animal._id}/delete" class="remove">Delete</a>-->
               <!--(Bonus Part) Only for no creator and user-->
               <a href="#" class="donate">Donate</a> 
             </div>`
    :nothing    
}
           
        </div>
    </div>
</section>
`;


export const detailsView =  (ctx) => {

    animalService.getCurrent(ctx.params.animalId)
    .then(animal => {
      let  isOwner ;
      let isUser = false;
      
    if (ctx.user) {
         isOwner = ctx.user._id == animal._ownerId;
         isUser = true;

   
    } 
   
       
       
          ctx.render(detailsTemplate(animal,isOwner,isUser));
    });
}

