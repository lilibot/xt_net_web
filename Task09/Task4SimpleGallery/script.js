var Timer;
var IsPause = false;
var IsStart = false;
var EndPage = 4;
var StartPage = 1;
var timeout = setTimeout(action, 10);
var IsFirstConfirm = true;

window.onload = function () {

    var moveButtons = document.getElementById('buttons');
    moveButtons.onclick = function (event) {
        var target = event.target;
        if (target.id === 'pause') {
            Pause();
        } else if (target.id === 'previous') {
            ToPreviousPage();
        } else if (target.id === 'next') {
            ToNextPage();
        }
    }
    action();

}
function start() {
    Timer = 3000 * 1;
    action();
}

function action() {
    if (!IsStart) {
        IsStart = true;
        start();
    }
    Timer--;
    document.getElementById('time').innerHTML = Timer / 100;
    if (!IsPause) {
        timeout = setTimeout(action, 10);
    }

    if (Timer < 0) {
        numOfCurrentPage = GetNumberOfCurrentPage();
        if (numOfCurrentPage != EndPage) {
            ToNextPage();
        }
        else {
            if (IsFirstConfirm) {
                var retVal = confirm("Do you want to continue scrolling gallery?");
                if (retVal == true) {
                    location.assign("./" + "page" + StartPage + ".html");
                }
                else {
                    var objWindow = window.open(location.href, "_self");
                    objWindow.close();
                }

                IsFirstConfirm = false;
            }
        }
    }
}

function GetNameOfNextPage() {
    var numOfCurrentPage = GetNumberOfCurrentPage();
    if (numOfCurrentPage == EndPage) {
        return "./page" + StartPage + ".html";
    }

    return "./page" + (1 + numOfCurrentPage) + ".html";
}

function GetNameOfPreviousPage() {
    var numOfCurrentPage = GetNumberOfCurrentPage();
    if (numOfCurrentPage == StartPage) {
        return "./page" + EndPage + ".html";
    }
    return "./page" + (numOfCurrentPage - 1) + ".html";
}

function GetNumberOfCurrentPage() {
    var pageName = location.href;
    pageName = pageName.substr(pageName.lastIndexOf("/") + 1);
    return pageName.match(/[0-9]+/) * 1;
}

function ToNextPage() {
    location.replace(GetNameOfNextPage());
}

function ToPreviousPage() {
    location.replace(GetNameOfPreviousPage());
}

function Pause() {
    if (!IsPause) {
        clearTimeout(timeout);
    }
    else {
        timeout = setTimeout(action, 10);
    }
    IsPause = !IsPause;
}