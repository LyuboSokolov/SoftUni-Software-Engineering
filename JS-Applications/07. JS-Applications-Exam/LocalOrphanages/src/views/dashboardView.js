import { html, nothing } from '../../node_modules/lit-html/lit-html.js';


import * as materialService from '../services/materialService.js';

const materialTemplate = (material) => html` 
<div class="post">
    <h2 class="post-title">${material.title}</h2>
    <img class="post-image" src="${material.imageUrl}" alt="Material Image">
    <div class="btn-wrapper">
        <a href="/data/posts/${material._id}" class="details-btn btn">Details</a>
    </div>
</div>
`;

const materialsTemplate = (materials) => html`
<!-- Dashboard -->
<section id="dashboard-page">
    <h1 class="title">All Posts</h1>

    <!-- Display a div with information about every post (if any)-->
    <div class="all-posts">

        ${materials.map(x => materialTemplate(x))};

        ${materials.length == 0
        ? html`
        <!-- Display an h1 if there are no posts -->
        <h1 class="title no-posts-title">No posts yet!</h1>`
        : nothing
          }
</section>
`;

export const dashboardView = (ctx) => {

    materialService.getAll()
        .then(materials => {

            ctx.render(materialsTemplate(materials));
        })

}








