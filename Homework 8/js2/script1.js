var num = +prompt('Введіть число від 0 до 9');
switch (num) {
    case 0:
        num = ")";
        break;
    case 1:
        num = "!";
        break;
    case 2:
        num = "@";
        break;
    case 3:
        num = "#";
        break;
    case 4:
        num = "$";
        break;
    case 5:
        num = "%";
        break;
    case 6:
        num = "^";
        break;
    case 7:
        num = "&";
        break;
    case 8:
        num = "*";
        break;
    case 9:
        num = "(";
        break;
    default:
        alert("Ви ввели невірне число");
}
if (num != NaN)
{
    alert(`Символ, розташований на цій клавіші - ${num}`);
}