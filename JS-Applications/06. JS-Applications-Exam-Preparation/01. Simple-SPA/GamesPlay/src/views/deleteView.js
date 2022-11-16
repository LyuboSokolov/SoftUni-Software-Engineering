import * as animalService from '../services/animalService.js'



export const deleteView = async (ctx) => {

        let confirmed = confirm('Do you want to delete?');

        if (confirmed) {
            await animalService.remove(ctx.params.gameId);
            ctx.page.redirect('/');

        }
   
    }
