import page from '../node_modules/page/page.mjs';
import { authMiddleware } from './middlewares/authMiddleware.js';
import { renderNavigationMiddleware, renderContentMiddleware } from './middlewares/renderMiddleware.js';
import { createView } from './views/createView.js';
import { loginView } from './views/loginView.js';
import { logoutView } from './views/logoutView.js';
import { registerView } from './views/registerView.js';
import { detailsView } from './views/detailsView.js';
import { editView } from './views/editView.js';
import { deleteView } from './views/deleteView.js';
import { dashboardView } from './views/dashboardView.js';
import { mypostView } from './views/mypostView.js';


page(authMiddleware);
page(renderNavigationMiddleware);
page(renderContentMiddleware);


page('/',dashboardView);
page('/login',loginView);
page('/register',registerView);
page('/logout',logoutView);
page('/mypost',mypostView);
page('/create',createView);
page('/data/posts/:materialId',detailsView);
page('/posts/:materialId/edit',editView);
page('/posts/:materialId/delete',deleteView);


page.start();