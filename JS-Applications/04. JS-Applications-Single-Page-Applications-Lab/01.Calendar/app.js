import {yearRenderer} from './rendererYears.js';
let sections = document.querySelectorAll('section');
let yearsSections = document.querySelector('.yearsCalendar');


sections.forEach(x => {
    x.style.display = 'none';
})

yearsSections.style.display = 'block';

yearsSections.addEventListener('click', (e) => {
   
    if (e.target.tagName == 'DIV') {
     
        yearRenderer(e.target);
    }
})


