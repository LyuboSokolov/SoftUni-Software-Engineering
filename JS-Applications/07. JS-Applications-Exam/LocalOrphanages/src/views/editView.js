
import { html, nothing } from '../../node_modules/lit-html/lit-html.js';

import * as materialService from '../services/materialService.js';



const editTemplate = (material, submitHandler) => html`
<!-- Edit Page (Only for logged-in users) -->
<section id="edit-page" class="auth">
            <form id="edit" @submit = ${submitHandler}>
                <h1 class="title">Edit Post</h1>

                <article class="input-group">
                    <label for="title">Post Title</label>
                    <input type="title" name="title" id="title" value="${material.title}">
                </article>

                <article class="input-group">
                    <label for="description">Description of the needs </label>
                    <input type="text" name="description" id="description" value="${material.description}">
                </article>

                <article class="input-group">
                    <label for="imageUrl"> Needed materials image </label>
                    <input type="text" name="imageUrl" id="imageUrl" value="${material.imageUrl}">
                </article>

                <article class="input-group">
                    <label for="address">Address of the orphanage</label>
                    <input type="text" name="address" id="address" value="${material.address}">
                </article>

                <article class="input-group">
                    <label for="phone">Phone number of orphanage employee</label>
                    <input type="text" name="phone" id="phone" value="${material.phone}">
                </article>

                <input type="submit" class="btn submit" value="Edit Post">
            </form>
        </section>
`;

export const editView = (ctx) => {

    const materialId = ctx.params.materialId;

    const submitHandler = (e) => {
        e.preventDefault();


        const { title, description, imageUrl, address, phone } = Object.fromEntries(new FormData(e.currentTarget));

        if (!(title && description && imageUrl && address && phone)) {
            alert('Fill in all fields!');
            return;
        }
        let data = {
            title,
            description,
            imageUrl,
            address,
            phone
        };
        materialService.edit(materialId, data)
            .then(() => {
                ctx.page.redirect(`/data/posts/${materialId}`);
            });

    };

    materialService.getOne(materialId)
        .then(material => {
            ctx.render(editTemplate(material, submitHandler));
        })
}



