
/**
 * Tuna Signup Form Wizard
 * @type Javascript Class
 */

var tunaWizard = {
    stepCount: 0,
    slider: null,
    /**
     * Resize for Responsive
     */
    setResponsive: function () {
        var self = this;
        var windowHeight = $(window).height();
        var windowWidth = $(window).width();
        windowHeight = windowHeight > 360 ? windowHeight : 360;
        var tunaContainer = $(".tuna-signup-container");
        var tunaLeft = $(".tuna-signup-left");
        var tunaRight = $(".tuna-signup-right");

        if (windowWidth >= 768) {
            tunaContainer.add(tunaLeft).add(tunaRight).innerHeight(windowHeight);
        } else {
            tunaContainer.add(tunaLeft).add(tunaRight).css("height", "auto");
        }

        //Testimonail Slider Show/Hide
        var sliderContainer = $(".tuna-slider-container");
        if (windowHeight < 600 || windowWidth < 768) {
            sliderContainer.hide();
        } else {
            sliderContainer.show();
            //Reload slider because of hidden
            self.slider.reloadSlider();
        }
        if (windowHeight < 400) {
            $(".button-container").css("bottom", "50px");
        }

    },
    /**
     * Change Step
     * @param int currentStep
     * @param int nextStep
     * @returns {void|Boolean}
     */
    changeStep: function (currentStep, nextStep) {
        var self = this;

        if (nextStep <= 0 && nextStep > 4) {
            return false;
        }

        //Validations
        if (nextStep === 2) {
            if (($("#from_auto_complete").has("option").length == 0) || ($("#to_auto_complete").has("option").length == 0)) {
                self.setInputError($("#from_auto_complete"));
                return;
            }
        }
        if (nextStep === 3) {
            if ($("input[name='from_room']:checked").length == 0) {
                self.setInputError($("input[name='from_room']"));
                return;
            }
        }
        //Checboxes validation
        if (nextStep === 4) {
            if ($("input[name='from_elevator']:checked").length == 0) {
                self.setInputError($("input[name='from_elevator']"));
                return;
            }
        }
        //Radio validation
        if (nextStep === 5) {
            if ($("input[name='from_floor']:checked").length == 0) {
                self.setInputError($("input[name='from_floor']"));
                return;
            }
        }
        if (nextStep === 6) {
            if ($("input[name='to_elevator']:checked").length == 0) {
                self.setInputError($("input[name='to_elevator']"));
                return;
            }
        }
        if (nextStep === 7) {
            if ($("input[name='to_floor']:checked").length == 0) {
                self.setInputError($("input[name='to_floor']"));
                return;
            }
        }
        if (nextStep === 8) {
            if ($("input[name='mobile_lift']:checked").length == 0) {
                self.setInputError($("input[name='mobile_lift']"));
                return;
            }
        }
        if (nextStep === 9) {
            if ($("input[name='packaging_options']:checked").length == 0) {
                self.setInputError($("input[name='packaging_options']"));
                return;
            }
        }
        if (nextStep === 10) {
            if ($("input[name='chose_montage']:checked").length == 0) {
                self.setInputError($("input[name='chose_montage']"));
                return;
            }
        }

        //Change Step
        if (nextStep > currentStep) {
            $(".step-active").removeClass("step-active").addClass("step-hide");
            self.slider.goToNextSlide();
            UpdateLeftStep(currentStep);
        } else {
            $(".step-active").removeClass("step-active");
            self.slider.goToPrevSlide();
            UpdateLeftStep(currentStep);
        }

        var nextStepEl = $(".step[data-step-id='" + nextStep + "']");
        nextStepEl.removeClass("step-hide").addClass("step-active");

        //Focus Input
        window.setTimeout(function () {
            if (nextStep !== self.stepCount) {
                nextStepEl.find("input").focus();
            }
        }, 500);

        var stepCountsEl = $(".steps-count");
        if (nextStep === self.stepCount) {
            stepCountsEl.html("Bilgileri Onayla");
            $(".button-container").hide();
            var stepConfirm = $(".step-confirm");
            //stepConfirm.find("input[name='name']").val($("#tn_name").val());

            stepConfirm.find("label#fromAddress").text($("#from_auto_complete option:selected").val());
            stepConfirm.find("label#toAddress").text($("#to_auto_complete option:selected").val());
            stepConfirm.find("select[name='roomCount']").selectpicker("val", $("input[name='from_room']:checked").val());
            stepConfirm.find("select[name='fromElevator']").selectpicker("val", $("input[name='from_elevator']:checked").val());
            stepConfirm.find("select[name='toElevator']").selectpicker("val", $("input[name='to_elevator']:checked").val());
            stepConfirm.find("select[name='fromFloor']").selectpicker("val", $("input[name='from_floor']:checked").val());
            stepConfirm.find("select[name='toFloor']").selectpicker("val", $("input[name='to_floor']:checked").val());
            stepConfirm.find("select[name='mobileLift']").selectpicker("val", $("input[name='mobile_lift']:checked").val());
            stepConfirm.find("select[name='packagingOptions']").selectpicker("val", $("input[name='packaging_options']:checked").val());
        }

        //Current Step Number update
        stepCountsEl.find("span.step-current").text(nextStep);


        //Hide prevButton if we are in first step
        var prevStepEl = $(".prevStep");
        if (nextStep === 1) {
            prevStepEl.hide();
        } else {
            prevStepEl.css("display", "inline-block");
        }
    },
    /**
     * Show Validation Message
     * @param HtmlElement el
     * @returns void
     */
    setInputError: function (el) {
        el.addClass("input-error");
        el.parents(".step").find(".help-info").hide();
        el.parents(".step").find(".help-error").show();
    },
    /**
     * Check email is valid or not
     * @param String value
     * @returns Boolean
     */
    isEmail: function (value) {
        value = value.toLowerCase();
        var reg = new RegExp(/^[a-z]{1}[\d\w\.-]+@[\d\w-]{3,}\.[\w]{2,3}(\.\w{2})?$/);
        return reg.test(value);
    },
    /**
     * Executes Signup Wizard
     * @returns void
     */
    start: function () {
        var self = this;
        /**
         * Testimonial Slider - Uses bxslider jquery plugin
         */
        self.slider = $('.tuna-slider').bxSlider({
            controls: false, // Left and Right Arrows
            auto: false, // Slides will automatically transition
            mode: 'horizontal', // horizontal,vertical,fade
            pager: false, // true, a pager will be added
            speed: 500, // Slide transition duration (in ms)
            pause: 5000, // The amount of time (in ms) between each auto transition
            touchEnabled: false
        });

        //Jquery Uniform Plugin
        $(".tuna-signup-container input[type='checkbox'],.tuna-signup-container input[type='radio'],.tuna-signup-container input[type='file'],.select").uniform();

        //Jquery Mask Plugin
        $('.tuna-signup-container input[name="phone"],.tuna-signup-container input[name="tn_phone"]').mask('000 000 00 00');

        // Focuses on name input, when page loaded
        window.setTimeout(function () {
            $("#from_auto_complete").focus();
        }, 500);

        // Responsive
        self.setResponsive();
        $(window).resize(function () {
            self.setResponsive();
        });

        // Steps Count
        self.stepCount = $(".tuna-steps .step").length;
        $(".step-count").text(self.stepCount);

        // Next Step
        $(".nextStep").on("click", function () {
            var currentStep = $(".step-active").attr("data-step-id")
            var nextStep = parseFloat(currentStep) + 1;
            self.changeStep(currentStep, nextStep);
        });

        // Prev Step
        $(".prevStep").on("click", function () {
            var currentStep = $(".step-active").attr("data-step-id")
            var nextStep = parseFloat(currentStep) - 1;
            self.changeStep(currentStep, nextStep);
        });

        // Confirm Details - Show Input
        var stepConfirm = $(".step-confirm");
        stepConfirm.find(".input-container a.editInput").on("click", function () {
            $(this).parent().find("input").focus();
        });

        // Confirm Details - Show Password
        stepConfirm.find(".input-container a.showPass").on("mousedown", function () {
            $(this).parent().find("input").attr("type", "text");
        }).mouseup(function () {
            $(this).parent().find("input").attr("type", "password");
        });

        stepConfirm.find(".input-container input").on("focus", function () {
            $(this).parent().find("a").hide();
        });

        stepConfirm.find(".input-container input").on("focusout", function () {
            if (!$(this).hasClass("confirm-input-error")) {
                $(this).parent().find("a").show();
            }
        })

        stepConfirm.find("select").on('shown.bs.select', function (e) {
            $(this).parents(".form-group").find("a.editInput").hide();
        }).on('hidden.bs.select', function (e) {
            $(this).parents(".form-group").find("a.editInput").show();
        });

        //Press Enter and go to nextStep
        $(".step input").not(".step-confirm input").on("keypress", function (e) {
            if (e.keyCode === 13) {
                $(".nextStep").click();
            }
        });

        var signupForm = $("#getOfferForm");
        //Press Enter and submit form
        signupForm.find("input").on("keypress", function (e) {
            if (e.keyCode === 13) {
                signupForm.submit();
            }
        });

        //Finish Button
        $("#getPrice").on("click", function () {
            signupForm.submit();
        })

        // Form Submit
        signupForm.on("submit", function (e) {

            e.preventDefault();

            $(this).find(".confirm-input-error").removeClass("confirm-input-error");


            var cusPhone = $("#txtCustomerNumber").val();
            if (cusPhone != "")
                $("#customer_phone").val(cusPhone);


            var fromAddressLabel = $(this).find('label#fromAddress');
            if (fromAddressLabel.text() === "") {
                fromAddressLabel.addClass("confirm-input-error").focus();
                return;
            }

            var toAddressLabel = $(this).find('label#toAddress');
            if (toAddressLabel.text() === "") {
                toAddressLabel.addClass("confirm-input-error").focus();
                return;
            }

            var roomCountInput = $(this).find("select[name='roomCount']");
            if (roomCountInput.length == 0) {
                roomCountInput.parents(".bootstrap-select").addClass("confirm-input-error").focus();
                roomCountInput.selectpicker('toggle');
                return;
            }

            var fromElevatorInput = $(this).find("select[name='fromElevator']");
            if (fromElevatorInput.length === 0) {
                //add class to parent element, because this is bootstrap-select.
                fromElevatorInput.parents(".bootstrap-select").addClass("confirm-input-error").focus();
                fromElevatorInput.selectpicker('toggle');
                return;
            }

            var fromFloorInput = $(this).find("select[name='fromFloor']");
            if (fromFloorInput.length === 0) {
                //add class to parent element, because this is bootstrap-select.
                fromFloorInput.parents(".bootstrap-select").addClass("confirm-input-error").focus();
                fromFloorInput.selectpicker('toggle');
                return;
            }

            var toElevatorInput = $(this).find("select[name='toElevator']");
            if (toElevatorInput.length === 0) {
                //add class to parent element, because this is bootstrap-select.
                toElevatorInput.parents(".bootstrap-select").addClass("confirm-input-error").focus();
                toElevatorInput.selectpicker('toggle');
                return;
            }

            var toFloorInput = $(this).find("select[name='toFloor']");
            if (toFloorInput.length === 0) {
                //add class to parent element, because this is bootstrap-select.
                toFloorInput.parents(".bootstrap-select").addClass("confirm-input-error").focus();
                toFloorInput.selectpicker('toggle');
                return;
            }

            var mobileLiftInput = $(this).find("select[name='mobileLift']");
            if (mobileLiftInput.length === 0) {
                //add class to parent element, because this is bootstrap-select.
                mobileLiftInput.parents(".bootstrap-select").addClass("confirm-input-error").focus();
                mobileLiftInput.selectpicker('toggle');
                return;
            }

            var packagingOptionsInput = $(this).find("select[name='packagingOptions']");
            if (packagingOptionsInput.length === 0) {
                //add class to parent element, because this is bootstrap-select.
                packagingOptionsInput.parents(".bootstrap-select").addClass("confirm-input-error").focus();
                packagingOptionsInput.selectpicker('toggle');
                return;
            }

            var montageInput = $(this).find("select[name='montage']");
            if (montageInput.length === 0) {
                //add class to parent element, because this is bootstrap-select.
                montageInput.parents(".bootstrap-select").addClass("confirm-input-error").focus();
                montageInput.selectpicker('toggle');
                return;
            }

            if ($("#agreement").prop("checked") == false) {
                swal({
                    title: "Dikkat",
                    text: "Sozlesme metnini kabul etmelisiniz.",
                    type: "warning",
                    confirmButtonText: "Ok"
                });
                return;
            }


            var data = {
                "FromAddress": fromAddressLabel.text(), "ToAddress": toAddressLabel.text(), "FromRoomCountID": roomCountInput.val(),
                "FromElevator": fromElevatorInput.val(), "FromFloor": fromFloorInput.val(), "ToElevator": toElevatorInput.val(), "ToFloor": toFloorInput.val(),
                "MobileElevatorID": mobileLiftInput.val(), "PackagingOptionID": packagingOptionsInput.val(), "Montage": montageInput.val()
            };

            $.ajax({
                url: '/Transport/GetPrice',
                type: 'POST',
                data: data,
                beforeSend: function () {
                    swal({
                        title: null,
                        text: "<img class='tuna_loading' src='images/loading.svg'/> Lütfen bekleyiniz...",
                        html: true,
                        showConfirmButton: false
                    });
                },
                complete: function (result) {
                    if (result.responseJSON.status == true) {
                        swal.close();
                        $("#reservation").modal("show");
                        $("#offer_price").text(result.responseJSON.price);
                        $("#offer_id").text(result.responseJSON.offerID);
                    }
                    else if (result.responseJSON.status == false) {
                        swal({
                            title: "Hata!",
                            text: result.responseJSON.msg,
                            type: "error",
                            confirmButtonText: "Ok"
                        });
                    }
                }
            });

            //Send form to php file
            //$.post("../php/smtp.php", $(this).serialize(), function (result) {
            //    if (result.success) {
            //        swal({
            //            title: "Success",
            //            text: "Your information submitted successfully!",
            //            type: "success",
            //            confirmButtonText: "Ok"
            //        });
            //    } else {
            //        swal({
            //            title: "Error!",
            //            text: result.msg,
            //            type: "error",
            //            confirmButtonText: "Ok"
            //        });
            //    }
            //}, 'json');

        });

        $("#BtnCreateReservation").click(function () {
            var error = false;
            var cusName = $("#customer_name");
            if (cusName.val() === "") {
                cusName.parents(".form-group").find(".help-error").show();
                error = true;
            }
            else
                cusName.parents(".form-group").find(".help-error").hide();

            var cusSurname = $("#customer_surname");
            if (cusSurname.val() === "") {
                cusSurname.parents(".form-group").find(".help-error").show();
                error = true;
            }
            else
                cusSurname.parents(".form-group").find(".help-error").hide();

            var cusPhone = $("#customer_phone");
            if (cusPhone.val() === "") {
                cusPhone.parents(".form-group").find(".help-error").show();
                error = true;
            }
            else
                cusPhone.parents(".form-group").find(".help-error").hide();

            var cusEmail = $("#customer_email");
            if (cusEmail.val() === "") {
                cusEmail.parents(".form-group").find(".help-error").show();
                error = true;
            }
            else
                cusEmail.parents(".form-group").find(".help-error").hide();

            var transportDate = $("#transportDate");
            if (transportDate.val() === "") {
                transportDate.parents(".form-group").find(".help-error").show();
                error = true;
            }
            else
                transportDate.parents(".form-group").find(".help-error").hide();

            var offerID = $("#offer_id");
            console.log(offerID.text());
            if (offerID.text() === "")
                error = true;

            if (error == true)
                return;


            var data = {
                "CustomerName": cusName.val(), "CustomerSurname": cusSurname.val(), "CustomerPhone": cusPhone.val(), "CustomerEmail": cusEmail.val(),
                "TransportDate": transportDate.val(), "OfferID": offerID.text()
            };

            $.ajax({
                url: '/Transport/CreateReservation',
                type: 'POST',
                data: data,
                beforeSend: function () {
                    swal({
                        title: null,
                        text: "<img class='tuna_loading' src='images/loading.svg'/> Lütfen bekleyiniz...",
                        html: true,
                        showConfirmButton: false
                    });
                },
                complete: function (result) {
                    if (result.responseJSON.status == true) {
                        $("#reservation").modal("hide");
                        swal({
                            title: "Tebrikler !",
                            text: "Rezervasyonunuz tamamlandı. Sizinle iletişime geçeceğiz..",
                            type: "success",
                            confirmButtonText: "Tamam"
                        });
                    }
                    else if (result.responseJSON.status == false) {
                        swal({
                            title: "Hata!",
                            text: result.responseJSON.msg,
                            type: "error",
                            confirmButtonText: "Ok"
                        });
                    }
                }
            });


        })

    },
}
function UpdateLeftStep(step) {
    $.post('Transport/UpdateCustomerLeftStep',
        { step: step });
};

/**
 * Material Input 
 * @returns object
 */
$.fn.materialInput = function () {

    var label;
    var el = this;

    el.find('input.formInput').keydown(function (e) {
        el.setLabel(e.target);
        el.checkFocused(e.target);
    });

    el.find('input.formInput').focusout(function (e) {
        el.setLabel(e.target);
        el.checkUnFocused(e.target);
    });

    this.setLabel = function (target) {
        label = el.find('label[for=' + target.id + ']');
    };

    this.getLabel = function () {
        return label;
    };

    this.checkFocused = function (target) {
        el.getLabel().addClass('active', '');
        $(target).removeClass("input-error");
        $(target).next().hide();
        $(target).parent().find(".info").show();
    };

    this.checkUnFocused = function (target) {
        if ($(target).val().length === 0) {
            el.getLabel().removeClass('active');
        }
    };
};


$(document).ready(function () {

    /**
     * Page Loader
     * If you remove loader, you can delete .tuna-loader-container element from Html, and delete this two rows.
     */
    $(".tuna-loader-container").fadeOut("slow");
    $(".tuna-signup-container").show();


    /**
     * Material Inputs
     * Makes, inputs in selected element material design.
     */
    $(".tuna-steps").materialInput();

    /**
     * Bootstrap Select Plugin
     */
    $(".selectpicker").selectpicker();

    /**
     * Tuna Signup Form Wizard
     * Let's Start
     */
    tunaWizard.start();

});
(function ($) {

    var bxSlider = jQuery.fn.bxSlider;
    var $window = $(window);

    jQuery.fn.bxSlider = function () {

        var slider = bxSlider.apply(this, arguments);

        if (!this.length || !arguments[0].mouseDrag) {
            return slider;
        }

        var posX;
        var $viewport = this.parents('.bx-viewport');

        $viewport
            .on('dragstart', dragHandler)
            .on('mousedown', mouseDownHandler);

        function dragHandler(e) {
            e.preventDefault();
        }

        function mouseDownHandler(e) {

            posX = e.pageX;

            $window.on('mousemove.bxSlider', mouseMoveHandler);
        }

        function mouseMoveHandler(e) {

            if (posX < e.pageX) {
                slider.goToPrevSlide();
            } else {
                slider.goToNextSlide();
            }

            $window.off('mousemove.bxSlider');
        }

        return slider;
    };

})(jQuery);
