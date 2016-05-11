$(document).ready(function () {
    "use strict";


    var $btnSearch = $("#btnSearch");
    $btnSearch.live("click", function () {
        alert("Search feature is unavailable.");
    }).css("cursor", "pointer").attr({ 'data-toggle': "tooltip", title: "Search" }).tooltip(
    {
        delay: {
            show: 10,
            hide: 0
        },
        placement: "bottom"
    }
);
    //data-toggle="tooltip" target="_blank"
    //title="Evaluation Dashboard" 
    ///////////////////////////////////////////////
    $("#navLearningPortal").tooltip({
        placement: "bottom",
        delay: {
            show: 10,
            hide: 0
        }
    });
    $(".site-title a").tooltip({
        placement: "bottom",
        delay: {
            show: 10,
            hide: 0
        }
    });

    $("#newsBalloonRemove").tooltip({
        placement: "bottom",
        delay: {
            show: 10,
            hide: 0
        }
    });
    $("#newsBalloonRestore").tooltip({
        placement: "bottom",
        delay: {
            show: 10,
            hide: 0
        }
    });

    $("#logoVBA").tooltip({
        placement: "bottom",
        delay: {
            show: 10,
            hide: 0
        }
    });

    //$("#logoEDT").tooltip({
    //    placement: "bottom",
    //    delay: {
    //        show: 10,
    //        hide: 0
    //    }
    //});

    $(".thumbnail").tooltip({
        delay: {
            show: 10,
            hide: 0
        }
    });

    $(".nav-custom a").tooltip();
    $(".nav-btm-custom a").tooltip({
        placement: "bottom"
    });
    //$(".thumbnail").css({ "border-style": "solid", "background-color": "#7cc0d9" });


    $('a.thumbnaildisabled').click(function (event) {
        event.preventDefault(); // Prevent link from following its href
    })/*.css("cursor", "not-allowed")*/;



    ////////////////////////////////////

    var scrollText;
    var i = 0;
    var len = 0;
    var rotationDelay = 6000;
    //var rotationDelay = 2400;
    var div = $('#NewsRotator');
    var title = $("#NewsRotator #title");
    var copy = $("#NewsRotator #copy");
    var path = $("#NewsRotator #path");
    var action = $("#NewsRotator #action");
    var d;
    var btnPrevious = $('#btnPrevAnnouncement');
    var btnNext = $("#btnNextAnnouncement");
    var hoverPause = $("#NewsRotator");
    var btnPause = $("#btnPause");
    var btnPlay = $("#btnPlay");

    btnNext.tooltip();
    btnPrevious.tooltip();
    btnPause.tooltip();
    btnPlay.tooltip();

    $.getJSON(window.baseUrl, null, function (data) {
        i = 0;
        len = data.length - 1;
        d = data;
        setAnnouncemnt();
        i++;
        rotateAnnouncements();
    });

    btnNext.click(function () {
        toggleVisibility();
        clearInterval(scrollText);
        i = i >= len ? 0 : ++i;
        setAnnouncemnt();
        rotateAnnouncements();
    });

    btnPrevious.click(function () {
        toggleVisibility();
        clearInterval(scrollText);
        i = i <= 0 ? len : --i;
        setAnnouncemnt();
        rotateAnnouncements();

    });

    function rotateAnnouncements() {
        scrollText = setInterval(function () {
            i = i >= len ? 0 : ++i;
            setAnnouncemnt(i);
        }, rotationDelay);
    }
    function setAnnouncemnt() {
        try {
            title.html(/*i + 1+ ".  " + */d[i].Title);
            copy.html(d[i].Copy);
            path.html(d[i].Path);
            action.html(d[i].Link);
            action.attr("href", d[i].Link);
        } catch (e) {
        }
    }
    hoverPause.mouseover(function () {
        try {
            if (btnPause.is(":visible")) {
                btnPause.hide();
                btnPlay.show();
            }
            clearInterval(scrollText);
        } catch (e) {
            alert(e);
        }
    });
    
    hoverPause.mouseleave(function () {

        playBackRotations();

    });

    btnPause.click(function () {

        btnPause.hide();
        btnPlay.show();
        clearInterval(scrollText);

    });

    btnPlay.click(function () {

        playBackRotations();

    });

    function playBackRotations() {
        btnPlay.hide();
        btnPause.show();
        clearInterval(scrollText);
        i = i >= len ? 0 : ++i;
        setAnnouncemnt();
        rotateAnnouncements();

    }

    function toggleVisibility() {
        if (btnPlay.is(":visible")) {
            btnPlay.hide();
            btnPause.show();
        }
    }

});





