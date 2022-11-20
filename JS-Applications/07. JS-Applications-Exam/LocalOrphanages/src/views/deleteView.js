import * as materialService from '../services/materialService.js';



export const deleteView = async (ctx) => {

        let confirmed = confirm('Do you want to delete?');

        if (confirmed) {
            await materialService.remove(ctx.params.materialId);
            ctx.page.redirect('/');

        }
   
    }
