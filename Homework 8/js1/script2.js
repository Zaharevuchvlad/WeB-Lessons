var size = prompt('Введіть обсяг флешки в ГБ');
size = size * 1024;
var canbewritten = parseInt(size / 820);
alert(`Можливо записати ${canbewritten} файлів обсягом 820мб`);