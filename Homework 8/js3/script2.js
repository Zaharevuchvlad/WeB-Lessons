var num = +prompt('Введіть число');
if (num != NaN)
{
    num = num.toString().length;
}
alert(`Кількість цифр у числі - ${num}`);