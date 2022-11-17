import page from '../node_modules/page/page.mjs';
import { authMiddleware } from './middlewares/authMiddleware.js';
import { renderNavigationMiddleware, renderContentMiddleware } from './middlewares/renderMiddleware.js';
import { dashbordView } from './views/dashbordView.js';
import { createView } from './views/createView.js';
import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { logoutView } from './views/logoutView.js';
import { registerView } from './views/registerView.js';
import { detailsView } from './views/detailsView.js';
import { editView } from './views/editView.js';
import { deleteView } from './views/deleteView.js';


page(authMiddleware);
page(renderNavigationMiddleware);
page(renderContentMiddleware);


page('/',homeView);
page('/login',loginView);
page('/register',registerView);
page('/logout',logoutView);
page('/dashboard',dashbordView);
page('/create',createView);
page('/data/pets/:animalId',detailsView);
page('/pets/:animalId/edit',editView);
page('/pets/:animalId/delete',deleteView);


page.start();