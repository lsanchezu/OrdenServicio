
function splot(control, dataset, options) {
    $.plot(control, dataset, options);
}

function gd(year, month, day) {
    return new Date(year, month - 1, day).getTime();
}