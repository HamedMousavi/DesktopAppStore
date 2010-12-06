var CurrentSelectedMessage = "";

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

function ToggleForumMessage(itemId) {

    // Shall we expand?
    var expand = (CurrentSelectedMessage != itemId);

    // Collapse current message
    CollapseCurrentSelectedMessage();

    // Don't expand if item is clicked on previous message
    if (!expand) {
        return false;
    }

    // Expand selected item
    ExpandAndSelectMessage(itemId);


    return false;
}


function CollapseCurrentSelectedMessage() {

    var old = document.getElementById(CurrentSelectedMessage);
    if (old)
    {
        if (old.style.display == 'block') old.style.display = 'none';

        EnableHighlight(CurrentSelectedMessage, false);

        CurrentSelectedMessage = '';
    }
}

// Expands a message in discussion forum
function ExpandAndSelectMessage(itemId) {
    var elm = document.getElementById(itemId);
    if (elm) {
        //ExpandForumMessage
        if (elm.style.display == 'none') elm.style.display = 'block';
        CurrentSelectedMessage = itemId;

        EnableHighlight(itemId, true);

        EnsureVisible(itemId);
    }
}


// Highlights head of a message in discussion forum
function EnableHighlight(itemId, enable) {

    var headId = itemId.replace("bd", "hd");
    elm = document.getElementById(headId);

    if (elm) {
        if (enable == true) {
            elm.className = elm.className.replace("normal", "selected");
        }
        else {
            elm.className = elm.className.replace("selected", "normal");
        }
    }
}


function EnsureVisible(itemId) {
    var webkitWeird = document.documentElement.scrollTop < document.body.scrollTop;

    var msgBody = document.getElementById(itemId);
    var msgHeader = document.getElementById(itemId.replace("bd", "hd"));

    if (!msgBody || !msgHeader) return;

    var scrollContainer = document.documentElement;
    var top = msgHeader.offsetTop;
    var bottom = msgBody.offsetTop + msgBody.offsetHeight;

    var scrollTop = webkitWeird ? scrollTop = document.body.scrollTop : document.documentElement.scrollTop;
    if (scrollTop > top && !bShowTop) scrollTop = top - scrollContainer.clientHeight / 10;
    if (scrollTop + scrollContainer.clientHeight < bottom) scrollTop = bottom - scrollContainer.clientHeight;
    if (scrollTop > top && bShowTop) scrollTop = top - scrollContainer.clientHeight / 10;
    if (webkitWeird) document.body.scrollTop = scrollTop; else scrollContainer.scrollTop = scrollTop;
}


function ConfirmMessageReport() {
    return window.confirm("Are you sure you want to report this message?");
}