var numStart = +prompt('Введіть початкове число');
var numEnd = +prompt('Введіть кінцеве число');
var resNum = numStart;
if (numStart == NaN || numEnd == NaN || numStart > numEnd) {
    alert(`Невірно вказані числа`);
}
else {
    for (var i = numStart + 1; i <= numEnd; i++) {
        resNum += i;
    }
    alert(`Сума діапазону - ${resNum}`);
}