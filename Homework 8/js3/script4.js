var confirmed = true;
var dayString = "Понеділок";
do {
    confirmed = confirm(`${dayString}. Хочете побачити наступний день?`);
    switch (dayString) {
        case "Понеділок":
            dayString = "Вівторок"
            break;
        case "Вівторок":
            dayString = "Середа"
            break;
        case "Середа":
            dayString = "Четвер"
            break;
        case "Четвер":
            dayString = "П'ятниця"
            break;
        case "П'ятниця":
            dayString = "Субота"
            break;
        case "Субота":
            dayString = "Неділя"
            break;
        case "Неділя":
            dayString = "Понеділок"
            break;
    }
}
while (confirmed);