function ajax(url, onsuccess) {
    var xmlhttp = window.XMLHttpRequest ? new XMLHttpRequest : new ActiveXObject('Microsoft.XMLHTTP');
    xmlhttp.open("POST", url, true);
    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4) {
            {
                if (xmlhttp.status == 200) {
                    onsuccess(xmlhttp.responseText);
                }
                else {
                    onsuccess("AJAX服务器返回出现错误");
                }
            }
        }

    }
    xmlhttp.send();
}