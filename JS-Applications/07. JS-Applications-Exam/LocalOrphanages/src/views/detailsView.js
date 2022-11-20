import { html, nothing } from '../../node_modules/lit-html/lit-html.js';

import * as materialService from '../services/materialService.js';

const detailsTemplate = (material, isOwner, isUser) => html`

   <!-- Details Page -->
<section id="details-page">
    <h1 class="title">Post Details</h1>

    <div id="container">
        <div id="details">
            <div class="image-wrapper">
                <img src="${material.imageUrl}" alt="Material Image" class="post-image">
            </div>
            <div class="info">
                <h2 class="title post-title">${material.title}</h2>
                <p class="post-description">Description: ${material.description}</p>
                <p class="post-address">Address: ${material.address}</p>
                <p class="post-number">Phone number: ${material.phone}</p>
                <p class="donate-Item">Donate Materials: 0</p>

                <!--Edit and Delete are only for creator-->
                ${isOwner

                ? html`
                <div class="btns">
                    <a href="/posts/${material._id}/edit" class="edit-btn btn">Edit</a>
                    <a href="/posts/${material._id}/delete" class="delete-btn btn">Delete</a>


                    <!--Bonus - Only for logged-in users ( not authors )-->
                    <!--<a href="#" class="donate-btn btn">Donate</a>-->
                </div>`
                : nothing
            }

            </div>
        </div>
    </div>
</section>

`;

export const detailsView = (ctx) => {
 
    materialService.getCurrent(ctx.params.materialId)
        .then(material => {
           
            let isOwner;
            let isUser = false;
        
            if (ctx.user) {
                isOwner = ctx.user._id == material._ownerId;
                isUser = true;
            }

            ctx.render(detailsTemplate(material, isOwner, isUser));
        });
}