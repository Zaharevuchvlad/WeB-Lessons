var number = 0;
var pos = 0;
var neg = 0;
var zero = 0;
var pair = 0;
var notpair = 0;
for(var i = 0; i < 10; i++)
{
    number = +prompt('Введіть число');
    if (number != NaN)
    {
        if (number > 0) {pos++;}
        if (number < 0) {neg++;}
        if (number == 0) {zero++;}
        if (number % 2 == 0) {pair++;}
        if (number % 2 != 0) {notpair++;}
    }
}
alert(`Позитивних ${pos} Негативних ${neg} Нулів ${zero} Парних ${pair} Непарних ${notpair}`);