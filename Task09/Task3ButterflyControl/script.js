window.onload = function () {

    var moveButtons = document.getElementById('buttons');
    moveButtons.onclick = function (event) {
        var target = event.target;
        if (target.id === 'moveAllRight') {
            var moveFrom = document.getElementById('leftSelect');
            var moveTo = document.getElementById('rightSelect');
            moveAll(moveFrom, moveTo);
        } else if (target.id === 'moveRight') {
            var moveFrom = document.getElementById('leftSelect');
            var moveTo = document.getElementById('rightSelect');
            moveSome(moveFrom, moveTo);
        } else if (target.id === 'moveLeft') {
            var moveFrom = document.getElementById('rightSelect');
            var moveTo = document.getElementById('leftSelect');
            moveSome(moveFrom, moveTo);
        } else if (target.id === 'moveAllLeft') {
            var moveFrom = document.getElementById('rightSelect');
            var moveTo = document.getElementById('leftSelect');
            moveAll(moveFrom, moveTo);
        }
    }
}

function moveSome(moveFrom, moveTo) {
    var optionsFrom = moveFrom.options;
    var selected = false;

    for (var i = 0; i < optionsFrom.length; i++) {
        if (optionsFrom[i].selected) {
            optionsFrom[i].selected = false;
            moveTo.add(optionsFrom[i]);
            i--;
        }
    }
}

function moveAll(moveFrom, moveTo) {
    var optionsFrom = moveFrom.options;
    for (var i = 0; i < optionsFrom.length; i++) {
        optionsFrom[i].selected = false;
        moveTo.add(optionsFrom[i]);
        i--;
    }
}