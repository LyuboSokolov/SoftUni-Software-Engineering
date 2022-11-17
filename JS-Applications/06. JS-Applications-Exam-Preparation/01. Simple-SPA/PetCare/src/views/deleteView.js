import * as animalService from '../services/animalService.js'



export const deleteView = async (ctx) => {


    try {
        const animal = await animalService.getOne(ctx.params.animalId);

        let confirmed = confirm('Do you want to delete?');

        if (confirmed) {
            await animalService.remove(ctx.params.animalId);
            ctx.page.redirect('/dashboard');

        }
    } catch (error) {
        alert(error);
    }

}