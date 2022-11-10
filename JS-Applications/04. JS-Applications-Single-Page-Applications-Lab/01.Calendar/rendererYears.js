import {days} from './months.js';
let yearsSections = document.querySelector('.yearsCalendar');

export function yearRenderer(event) {

    let year = event.textContent;
   
    let months = document.getElementById(`year-${year}`);
 
    months.style.display = 'block';
    yearsSections.style.display = 'none';

 console.log(year);

    
    days();
    
    
    let captionElement = months.querySelector('caption');
    captionElement.addEventListener('click', () => {

       months.style.display = 'none';
        yearsSections.style.display = 'block';
    })


    // function rendererMonths2020() {
    //     let months = document.getElementById('year-2020');
    //     months.style.display = 'block';
    // }
    // function rendererMonths2021() {
    //     let months = document.getElementById('year-2021').style.display = 'block';
    // }
    // function rendererMonths2022() {
    //     let months = document.getElementById('year-2022').style.display = 'block';
    // }
    // function rendererMonths2023() {
    //     let months = document.getElementById('year-2023').style.display = 'block';
    // }

}