/*!
 * Start Bootstrap - Agency Bootstrap Theme (http://startbootstrap.com)
 * Code licensed under the Apache License v2.0.
 * For details, see http://www.apache.org/licenses/LICENSE-2.0.
 */

// jQuery for page scrolling feature - requires jQuery Easing plugin
$(function() {
    $('a.page-scroll').bind('click', function(event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top
        }, 1500, 'easeInOutExpo');
        event.preventDefault();
    });
});

// Highlight the top nav as scrolling occurs
$('body').scrollspy({
    target: '.navbar-fixed-top'
})

// Closes the Responsive Menu on Menu Item Click
$('.navbar-collapse ul li a').click(function() {
    $('.navbar-toggle:visible').click();
});

$('.modal ').on('show.bs.modal', function () {
    $('.modal .modal-body').css('overflow-y', 'auto');
    $('.modal .modal-body').css('max-height', $(window).height() * 0.65);
    $('#modalscroll').css('overflow-y', 'auto');
    $('#modalscroll').css('max-height', $(window).height() * 0.5);
});

function GetMax() { //myModal1
    var num = Math.max(parseInt($("#slot1").val()),
                        parseInt($("#slot2").val()),
                        parseInt($("#slot3").val()),
                        parseInt($("#slot4").val()),
                        parseInt($("#slot5").val()));
    $("#series-result1").html("<b>" + num + "</b> is the max number.");
}
function GetMin() {
    var num = Math.min(parseInt($("#slot1").val()),
                        parseInt($("#slot2").val()),
                        parseInt($("#slot3").val()),
                        parseInt($("#slot4").val()),
                        parseInt($("#slot5").val()));

    $("#series-result2").html("<b>" + num + "</b> is the min number.");
}
function GetMean() {
    var num = (parseInt($("#slot1").val()) +
                parseInt($("#slot2").val()) +
                parseInt($("#slot3").val()) +
                parseInt($("#slot4").val()) +
                parseInt($("#slot5").val())) / 5;

    $("#series-result3").html("<b>" + num + "</b> is the mean number.");
}
function GetSum() {
    var num = (parseInt($("#slot1").val()) +
                parseInt($("#slot2").val()) +
                parseInt($("#slot3").val()) +
                parseInt($("#slot4").val()) +
                parseInt($("#slot5").val()));

    $("#series-result4").html("<b>" + num + "</b> is the sum number.");
}
function GetProduct() {
    var num = (parseInt($("#slot1").val()) *
                parseInt($("#slot2").val()) *
                parseInt($("#slot3").val()) *
                parseInt($("#slot4").val()) *
                parseInt($("#slot5").val()));

    $("#series-result5").html("<b>" + num + "</b> is the product number.");
}
function GetFactorial() { //myModal2
    var num = parseInt($("#n1").val());
    var ans = 1;
    while (num > 1) {
        ans = ans * num--; //allow the decrement in one line by using post algorithm
    }

    $("#fact-result").html("<b>" + ans + "</b> is the factorial number.");
}
function fizzBuzz() { //myModal3
    var result = "";
    for (var i = 1; i <= 100; i++) {
        if(i % 10 == 1)
        {
            result +="<br/>";
        }
        if (i % $("#fizz").val() == 0 && i % $("#buzz").val() == 0) {
            result += " <b>FizzBuzz</b> ";
        }
        else if (i % $("#fizz").val() == 0) {
            result += " <b>Fizz</b> ";
        }
        else if (i % $("#buzz").val() == 0) {
            result += " <b>Buzz</b> ";
        }
        else {
            result += " " + i + " ";
        }
    }
    $("#fizzbuzz-result").html("<br/><b>Fizzbuzz:</b>" + result);
}
function palindrome() {
    outputWord = "";
    inputWord = $("#word").val();
    message = inputWord.replace(/[^A-Z0-9]/ig, "").toLowerCase();

    for (var i = message.length; i >= 0; i--) {
        outputWord += message.charAt(i);
    }

    if (message === outputWord) {
        $("#pal-result").html("<b>" + inputWord + "</b>" + " is a Palindrome.");
    }
    else {
        $("#pal-result").html("<b>" + inputWord + "</b>" + " is not a Palindrome.");
    }
}

$(document).ready(function () {
    $("[id^=wrapper]").dotdotdot({
        /*	The text to add as ellipsis. */
        ellipsis: '... ',

        /*	How to cut off the text/html: 'word'/'letter'/'children' */
        wrap: 'word',

        /*	Wrap-option fallback to 'letter' for long words */
        fallbackToLetter: true,

        /*	jQuery-selector for the element to keep and put after the ellipsis. */
        after: "a.readmore",

        /*	Whether to update the ellipsis: true/'window' */
        watch: false,

        /*	Optionally set a max-height, can be a number or function.
            If null, the height will be measured. */
        height: 1000,

        /*	Deviation for the height-option. */
        tolerance: 0,

        /*	Callback function that is fired after the ellipsis is added,
            receives two parameters: isTruncated(boolean), orgContent(string). */
        callback: function (isTruncated, orgContent) { },

        lastCharacter: {

            /*	Remove these characters from the end of the truncated text. */
            remove: [' ', ',', ';', '.', '!', '?'],

            /*	Don't add an ellipsis if this array contains
                the last character of the truncated text. */
            noEllipsis: []
        }
    });
});

