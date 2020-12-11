var global = (function () {
    return {
        getCookie: function (cname) {
            var name = cname + "=";
            var decodedCookie = decodeURIComponent(document.cookie);
            var ca = decodedCookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) == ' ') {
                    c = c.substring(1);
                }
                if (c.indexOf(name) == 0) {
                    return c.substring(name.length, c.length);
                }
            }
            return "";
        },
        removeCookie: function (name) {
            document.cookie = name + '=; Path=/; Expires=Thu, 01 Jan 1970 00:00:01 GMT;';
        },
        callApi: function (api, methodType, dataSend, token, callBackSuccess) {
            $.ajax({
                url: api,
                method: methodType,
                data: JSON.stringify(dataSend),
                headers: {
                    Authorization: 'Bearer ' + token,
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                beforeSend: function () {
                    //showLoadingScreen();
                },
                complete: function () {
                    //hideLoadingScreen();
                },
                success: function (res) {
                    if (callBackSuccess != undefined) {
                        callBackSuccess(res);
                    }
                },
                error: function (error) {
                    console.error(error);
                }
            });
        },
        setCookie: function (cname, cvalue, exdays, path) {
            var d = new Date();
            d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
            var expires = "expires=" + d.toUTCString();
            var cookieStr = cname + "=" + cvalue + "; " + expires + "; path=" + path
            document.cookie = cookieStr;
        },
    }
})();
