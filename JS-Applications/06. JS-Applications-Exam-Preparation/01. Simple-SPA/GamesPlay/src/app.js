import page from '../node_modules/page/page.mjs';
import { authMiddleware } from './middlewares/authMiddleware.js';
import { renderNavigationMiddleware, renderContentMiddleware } from './middlewares/renderMiddleware.js';
import { createView } from './views/createView.js';
import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { logoutView } from './views/logoutView.js';
import { registerView } from './views/registerView.js';
import { detailsView } from './views/detailsView.js';
import { editView } from './views/editView.js';
import { deleteView } from './views/deleteView.js';
import { catalogView } from './views/catalogView.js';


page(authMiddleware);
page(renderNavigationMiddleware);
page(renderContentMiddleware);


page('/',homeView);
page('/login',loginView);
page('/register',registerView);
page('/logout',logoutView);
page('/catalog',catalogView);
page('/create',createView);
page('/data/games/:gameId',detailsView);
page('/games/:gameId/edit',editView);
page('/games/:gameId/delete',deleteView);


page.start();