var hou = "00", min = "00", second = 0;

var j = function (arg) {
    return arg >= 10 ? arg : "0" + arg;
}

window.onload = function () {
    startit();
    onemin();
}

function startit() {
    second++;
    //second += 10;
    if (second >= 60) {
        second = 0;
        onemin();
    }
    timer.innerHTML = hou + ":" + min + ":" + j(second);
    setTimeout("startit()", 990);
}

window.onbeforeunload = function () {
    return "关闭页面会立即结束签到哟!";
}
window.onunload = function () {
    $.ajax({ url: "../handler/sign_in.ashx?sign=endd" });
}

function onemin() {
    $.ajax({
        url: "../handler/sign_in.ashx?sign=add",
        type: 'post',
        success: function (re) {
            if (re == "notON") {
                alert("你已经下线，请重新签到！");
                window.onbeforeunload = function () { }
                location = "login.html";
            }
            else if (re == "没有登录!") {
                alert("你还没有登陆，请登陆！");
                window.onbeforeunload = function () { }
                location = "login.html";
            }
        }
    });

    $.ajax({
        url: '../handler/totalmin.ashx?time=day',
        type: 'post',
        success: function (re) {
            hou = parseInt(re / 60);
            min = re % 60;
            hou = hou >= 10 ? hou : "0" + hou;
            min = min >= 10 ? min : "0" + min;
        }
    })

    $.ajax({
        url: '../handler/totalmin.ashx?time=week',
        type: 'post',
        success: function (re) {
            var h = parseInt(re / 60);
            var m = re % 60;
            h = h >= 10 ? h : "0" + h;
            m = m >= 10 ? m : "0" + m;
            hour0.innerHTML = h + ":" + m;
        }
    })

    $.ajax({
        url: '../handler/info.ashx?info=you',
        type: 'post',
        success: function (re) {
            table_right.innerHTML = re;
        }
    })

    $.ajax({
        url: '../handler/info.ashx?info=all',
        type: 'post',
        success: function (re) {
            table_left.innerHTML = re;
        }
    })
}