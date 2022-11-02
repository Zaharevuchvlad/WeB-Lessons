var birthYear = prompt('Введіть ваш рік народження');
var currYear = new Date().getFullYear();
alert(`Вам ${currYear-birthYear} років`);