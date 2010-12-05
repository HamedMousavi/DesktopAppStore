function ToggleAccordionList(itemName) {
    var elm = document.getElementById(itemName);
    var i, others = document.getElementById('product_categories');
    for (i = 0; i < others.childNodes.length; i++) {
        var other = others.childNodes[i];
        if ((other.className == 'accordion_dropdown') && (other != elm))
            other.style.display = 'none';
    }
    if (elm.style.display == 'block') elm.style.display = 'none';
    else elm.style.display = 'block';
    return false;
}
