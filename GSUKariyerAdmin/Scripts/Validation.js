function vString(e, IsTr, Space) {

    if (IsTr && Space)
        exp = /[^a-zA-ZığüşöçİĞÜŞÖÇ\s]/g;

    else if (IsTr && !Space)
        exp = /[^a-zA-ZığüşöçİĞÜŞÖÇ]/g;

    else if (!IsTr && Space)
        exp = /[^a-zA-Z\s]/g;

    else if (!IsTr && !Space)
        exp = /[^a-zA-Z]/g;

    e.value = e.value.replace(exp, '');
}

function vNumber(e) {
    var exp = /[^\d]/g;
    e.value = e.value.replace(exp, '');
}

function vPriceFormat(e) {
    var exp = /[^\d.,]/g;
    e.value = e.value.replace(exp, '');
}

function vPrice(e) {
    var exp = /[^\d,]/g;
    e.value = e.value.replace(exp, '');
}

function vEmail(e) {
    exp = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    e.value = exp.exec(e.value) == null ? "" : exp.exec(e.value);
}

function vMinLength(e, Len) {
     e.value = (e.value.length < Len) ? "" : e.value;
}

function vUpper(e) {
    e.value = e.value.replace("i", "İ").replace("ı", "I").toUpperCase();
}