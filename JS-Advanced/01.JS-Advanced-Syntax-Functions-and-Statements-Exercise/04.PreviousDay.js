function nextDay2(year, month, day) {
    let dateInput = `${year}-${month}-${day}`
    let date = new Date(dateInput);
    date.setDate(date.getDate() - 1);
    let newYear = date.getFullYear();
    let newMonth = date.getMonth();
    let newDate = date.getDate();
    console.log(`${newYear}-${newMonth + 1}-${newDate}`);
}
nextDay2(2016, 10, 1);