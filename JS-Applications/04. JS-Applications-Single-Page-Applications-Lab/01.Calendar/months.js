
export function days(year) {


    let classDate = document.querySelectorAll('.date');
    let yearsSections = document.querySelector('.yearsCalendar');
    classDate.forEach(x => {
        x.addEventListener('click', (e) => {
            console.log(e.target.textContent);
            let days = {
                'Jan': 1,
                'Feb': 2,
                'Mar': 3,
                'Apr': 4,
                'May': 5,
                'Jun': 6,
                'Jul': 7,
                'Aug': 8,
                'Sept': 9,
                'Oct': 10,
                'Nov': 11,
                'Dec': 12
            }
            let month = days[e.target.textContent];
            let currentMonth = document.getElementById(`month-${year}-${month}`);
            console.log(currentMonth);
            currentMonth.style.display = 'block';
            yearsSections.style.display = 'none';
        })
    })
    // let day = document.querySelectorAll('.daysCalendar');
    // day.forEach(x => {
    //     //console.log(x);
    // })

}