// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(".header-menu .fd-menu .toggle-item").on("click", function () {
    if ($(this).hasClass("selected")) {
        hideMenu();
    } else {
        showMenu();
    }
});

var showMenu = function () {
    $(".header-menu .fd-menu .toggle-item").addClass("selected");
    $(".left-panel").css("display", "block");
    $(".page-toolbar-wrapper").css("left", "272px");
    $(".content-page-wrapper").css("left", "272px");
}

var hideMenu = function () {
    $(".header-menu .fd-menu .toggle-item").removeClass("selected");
    $(".left-panel").css("display", "none");
    $(".page-toolbar-wrapper").css("left", "0");
    $(".content-page-wrapper").css("left", "0");
}

function showLoadingScreen() {
    $('body').addClass('loading');
}

function hideLoadingScreen() {
    $('body').removeClass('loading');
}
var delay = (function () {
    var timer = 0;
    return function (callback, ms) {
        clearTimeout(timer);
        timer = setTimeout(callback, ms);
    };
})();