/*
Template Name: Amezia - Responsive Bootstrap 4 Admin Dashboard
Author: Themesbrand
Version: 1.0.0
Website: https://themesbrand.com/
Contact: themesbrand@gmail.com
File: Form Advanced Js File
*/

!function($) {
    "use strict";

    var AdvancedForm = function() {};
    
    AdvancedForm.prototype.init = function() {

        // Select2
        $(".select2").select2();

        $(".select2-limiting").select2({
            maximumSelectionLength: 2
        });
        //creating various controls

        //colorpicker start
        //colorpicker
            $('#cp1').colorpicker();
            $('#cp2').colorpicker();
            $('#cp3').colorpicker({
            color: '#ff679b',
            format: 'rgb'
        });
        $('#cp6').colorpicker({
            color: "#88cc33",
            horizontal: true
        });

           // Date Picker
           $('#datepicker').datepicker();
           $('#datepicker-inline').datepicker();
           $('#datepicker-multiple').datepicker({
               numberOfMonths: 3,
               showButtonPanel: true
           });
           
           $('#datepicker').datepicker();
           $('#datepicker-autoclose').datepicker({
               autoclose: true,
               todayHighlight: true
           });
           $('#datepicker-multiple-date').datepicker({
               format: "mm/dd/yyyy",
               clearBtn: true,
               multidate: true,
               multidateSeparator: ","
           });
           $('#date-range').datepicker({
               toggleActive: true
           });
 


        //Bootstrap-TouchSpin
        var defaultOptions = {
        };

        // touchspin
        $('[data-toggle="touchspin"]').each(function (idx, obj) {
            var objOptions = $.extend({}, defaultOptions, $(obj).data());
            $(obj).TouchSpin(objOptions);
        });

        $("input[name='demo1']").TouchSpin({
            initval: 40,
            buttondown_class: "btn btn-primary",
            buttonup_class: "btn btn-primary"
        });
        $("input[name='demo2']").TouchSpin({
            initval: 40,
            buttondown_class: "btn btn-primary",
            buttonup_class: "btn btn-primary"
        });

        $("input[name='demo3']").TouchSpin({
            buttondown_class: 'btn btn-primary',
            buttonup_class: 'btn btn-primary'
        });
        $("input[name='demo3_21']").TouchSpin({
            initval: 40,
            buttondown_class: 'btn btn-primary',
            buttonup_class: 'btn btn-primary'
        });
        $("input[name='demo3_22']").TouchSpin({
            initval: 40,
            buttondown_class: 'btn btn-primary',
            buttonup_class: 'btn btn-primary'
        });
     
        $("input[name='demo5']").TouchSpin({
            prefix: "pre",
            postfix: "post",
            buttondown_class: 'btn btn-primary',
            buttonup_class: 'btn btn-primary'
        });
        $("input[name='demo0']").TouchSpin({
            buttondown_class: 'btn btn-primary',
            buttonup_class: 'btn btn-primary'
        });

        $(document).ready(function(){$(".input-mask").inputmask()});



    },
    //init
    $.AdvancedForm = new AdvancedForm, $.AdvancedForm.Constructor = AdvancedForm
}(window.jQuery),

//initializing
function ($) {
    "use strict";
    $.AdvancedForm.init();
}(window.jQuery);