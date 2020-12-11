function showLoadingScreen() {
    $('body').addClass('loading');
}

function hideLoadingScreen() {
    $('body').removeClass('loading');
}

function redirectTo(url) {
    window.location.href = url;
}

function userLogout() {
    $.ajax({
        url: '/Administrator/UserLogout',
        method: 'GET',
        success: function () {
            redirectTo('/Administrator/Login');
        }
    });
}

function alertModal(message, type) {
    $('#alertModal .modal-body').html(message);
    if (!type) {
        //do nothing
    } else if (type == 'error') {
        $('#alertModal .modal-body').css('color', 'red');
    } else if (type == 'success') {
        $('#alertModal .modal-body').css('color', 'green');
    } else {
        $('#alertModal .modal-body').css('color', type);
    }
    $('#alertModal').modal('show');
}

function setCookie(name, value, days) {
    var expires = "";
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
}
function getCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function eraseCookie(name) {
    document.cookie = name + '=; Path=/; Expires=Thu, 01 Jan 1970 00:00:01 GMT;';
}

function showMenu() {
    document.getElementById("sidebar").style.width = "260px";
    document.getElementById("sidebarWrapper").style.width = "260px";
    $(".main-panel").css("width", "calc(100% - 260px)");
    $("#btnToggleMenu").removeClass("close");
    $(".btn-toggle-menu-icon").removeClass("fa-chevron-right");
    $(".nav-link p").show();
    setCookie("isHideMenu", "false");
}

function hideMenu() {
    document.getElementById("sidebar").style.width = "85px";
    document.getElementById("sidebarWrapper").style.width = "85px";
    $(".main-panel").css("width", "calc(100% - 85px)");
    $("#btnToggleMenu").addClass("close");
    $(".btn-toggle-menu-icon").addClass("fa-chevron-right");
    $(".nav-link p").hide();
    setCookie("isHideMenu", "true");
}
$(function () {
    if (getCookie("isHideMenu") == "true") {
        hideMenu();
    } else {
        showMenu();
    }
    $("#btnToggleMenu").on("click", function () {
        if ($("#btnToggleMenu").hasClass("close")) {
            showMenu();
        } else {
            hideMenu();
        }

    });
});