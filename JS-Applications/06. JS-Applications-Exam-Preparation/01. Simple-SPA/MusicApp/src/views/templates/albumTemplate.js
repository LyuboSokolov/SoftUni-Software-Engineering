import { html, nothing } from '../../../node_modules/lit-html/lit-html.js';


const albumDetails = (albumId) => html`
<div class="btn-group">
    <a href="/albums/${albumId}" id="details">Details</a>
</div>
`;

export const albumTemplate = (album, withDetails = true) => html` 

<div class="card-box">
    <img src=${album.imgUrl}>
    <div>
        <div class="text-center">
            <p class="name">${album.name}</p>
            <p class="artist">${album.artist}</p>
            <p class="genre">${album.genre}</p>
            <p class="price">Price:${album.price}</p>
            <p class="date">Release Date:${album.releaseDate}</p>
        </div>
        ${withDetails
        ? albumDetails(album._id)
        : nothing
     }
    </div>
</div>`;