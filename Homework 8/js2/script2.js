var birthYear = +prompt('Введіть ваш рік народження');
if (birthYear % 400 == 0 || (birthYear % 4 == 0 && birthYear % 100 != 0))
{
    alert(`Рік високосний`);
}
else
{
    alert(`Рік не високосний`);
}