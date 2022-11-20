import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as materialService from '../services/materialService.js';


const postTemplate = (material) => html`
 
<div class="post">
    <h2 class="post-title">${material.title}</h2>
    <img class="post-image" src="${material.imageUrl}" alt="Material Image">
    <div class="btn-wrapper">
        <a href="/data/posts/${material._id}" class="details-btn btn">Details</a>
    </div>
</div>
`;


const mypostTemplate = (posts) => html`
<<!-- My Posts -->
    <section id="my-posts-page">
        <h1 class="title">My Posts</h1>

        <!-- Display a div with information about every post (if any)-->
        <div class="my-posts">

            ${posts.map(x => postTemplate(x))}

            ${posts.length == 0
            ? html`
            <!-- Display an h1 if there are no posts -->
            <h1 class="title no-posts-title">You have no posts yet!</h1>`
            : nothing
            }
        </div>
    </section>
       `;


export const mypostView = (ctx) => {

    materialService.getMyPosts(ctx.user._id)
        .then(posts => {
            ctx.render(mypostTemplate(posts));
        })


}