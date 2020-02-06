window.onload = function () {

    var calculate = document.getElementById('calculate');
    calculate.onclick = function () {
        var str = document.getElementById("textArea").value;
        var digitArr = String(str).match(/[0-9]+(\.[0-9])*/g);
        var operationArr = String(str).match(/[+-]|[*/]|=/g);

        var value = digitArr[0] * 1;

        for (var i = 0; i < digitArr.length; i++) {
            if (operationArr[i] != '=') {
                value = performTheOperation(value, digitArr[i + 1], operationArr[i]);
            }
        }

        document.getElementById("resultOfCalculate").innerHTML = value.toFixed(2);
    }
}

function performTheOperation(value, nextDigit, operation) {
    switch (operation) {
        case '+':
            {
                value += nextDigit * 1;
                break;
            }

        case '-':
            {
                value -= nextDigit;
                break;
            }

        case '*':
            {
                value *= nextDigit;
                break;
            }

        case '/':
            {
                value /= nextDigit;
                break;
            }

        default:
            {
                break;
            }
    }

    return value;
}