/// <reference path="bootstrap.js" />
/// <reference path="bootstrap-slider.js" />
/// <reference path="modernizr-2.6.2.js" />
$(function () {

    $('#ex1').slider({
        formater: function (value) {
            return 'Current value: ' + value;
        }
    });
})