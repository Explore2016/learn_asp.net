$(function ()
{
    $.ajax({
        url: '../handler/check_login.ashx',
        type: 'post',
        dataType: 'html',
        data: {},
        error: function ()
        {
            self.location = "../html/login.html";
        },
        success: function (re)
        {
            if (re != "yes")
            {
                self.location = "../html/login.html";
            }
        }
    });
});
