import { html } from '../../node_modules/lit-html/lit-html.js';
import * as userService from '../services/userService.js'

const loginTemplate = (submitHandler) => html`

<!-- Login Page ( Only for Guest users ) -->
<section id="login-page" class="auth">
    <form id="login" @submit = ${submitHandler}>

        <div class="container">
            <div class="brand-logo"></div>
            <h1>Login</h1>
            <label for="email">Email:</label>
            <input type="email" id="email" name="email" placeholder="Sokka@gmail.com">

            <label for="login-pass">Password:</label>
            <input type="password" id="login-password" name="password">
            <input type="submit" class="btn submit" value="Login">
            <p class="field">
                <span>If you don't have profile click <a href="/register">here</a></span>
            </p>
        </div>
    </form>
</section>
`;

export const loginView = (ctx) => {
    const submitHandler = (e) => {
        e.preventDefault();

        const { email, password } = Object.fromEntries(new FormData(e.currentTarget));

        if (!(email && password)) {
            alert('Fill in all fields!');
            return;
        }
        userService.login(email, password)
            .then(() => {
                ctx.page.redirect('/');
            })
            .catch(err => {
                alert(err);
            })
    }
    ctx.render(loginTemplate(submitHandler));
}

