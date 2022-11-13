const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

const url = 'http://127.0.0.1:5500/05.%20Accordion/index.html';
let browser, page;


describe('E2E tests', function () {
    this.timeout(10000);
    before(async () => {
        browser = await chromium.launch({ handless: false, slowMo: 500 });
    });
    after(async () => {
        await browser.close();
    });
    beforeEach(async () => {
        page = await browser.newPage();
    });
    afterEach(async () => {
        await page.close();
    });

    it('load static page', async () => {
        await page.goto(url);

        const content = await page.textContent('.accordion .head span');
        expect(content).to.contains('Scalable Vector Graphics');
    });

    it('toggles content', async () => {
        await page.goto(url);

        await page.click('#main>.accordion:first-child >> text=More');
        //await page.waitForSelector('#main>.accordion:first-child >> .extra p');
        const visible = await page.textContent('#main>.accordion:first-child >> text=Less');
        expect(visible).to.be.equal('Less');
    });


    it('toggles content', async () => {
        await page.goto(url);

        await page.click('#main>.accordion:first-child >> text=More');
        //await page.waitForSelector('#main>.accordion:first-child >> .extra p');
        await page.click('#main>.accordion:first-child >> text=Less');

        const visible = await page.textContent('#main>.accordion:first-child >> text=More');
        expect(visible).to.be.equal('More');
    });

})
