function Ajax(url, onsuccess)
{
    var xmlhttp = window.XMLHttpRequest ? new XMLHttpRequest() : new ActiveXObject('Microsoft XMLHTTP');
    xmlhttp.open("POST",url, true);
    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4) {
            if (xmlhttp.status == 200) {
                onsuccess(xmlhttp.responseText);
                //alert(xmlhttp.responseText);
            }
            else {
                alert("Ajax服务返回错误啦！");
            }
        }
    }
    xmlhttp.send();
}