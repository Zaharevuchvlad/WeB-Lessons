var day = +prompt('Введіть день');
var month = +prompt('Введіть місяць');
var year = +prompt('Введіть рік');
var date = new Date(`${year}-${month}-${day}`);
if (date != NaN)
{
    date.setDate(date.getDate()+1);
    alert(`Наступна дата: ${date.toLocaleDateString()}`);
}else
{
    alert("Невірна дата");
}