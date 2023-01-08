/*
Template Name: Amezia - Responsive Bootstrap 4 Admin Dashboard
Author: Themesbrand
Version: 1.0.0
Website: https://themesbrand.com/
Contact: themesbrand@gmail.com
File: tooltipster 
*/

(function ($) {

    "use strict";

    tippy('.tippy-btn');       
    tippy('#myElement', {
        html: document.querySelector('#feature__html'), // DIRECT ELEMENT option
        arrow: true,
        animation: 'fade'
    });

})(jQuery);