var selectedConditions = [];
$(function () { // will trigger when the document is ready
    $('.datepicker').datepicker({
        format: "dd/mm/yyyy"
    }); //Initialise any date pickers


    //Initialize tooltips
    $('.nav-tabs > li a[title]').tooltip();

    //Wizard
    $('a[data-toggle="tab"]').on('show.bs.tab', function (e) {

        var $target = $(e.target);

        if ($target.parent().hasClass('disabled')) {
            return false;
        }
    });

    $(".next-step").click(function (e) {

        var $active = $('.wizard .nav-tabs li.active');
        $active.next().removeClass('disabled');
        nextTab($active);

    });
    $(".prev-step").click(function (e) {

        var $active = $('.wizard .nav-tabs li.active');
        prevTab($active);

    });

});

function nextTab(elem) {
    $(elem).next().find('a[data-toggle="tab"]').click();
}
function prevTab(elem) {
    $(elem).prev().find('a[data-toggle="tab"]').click();
}

$("#container").on("click", "a", function (event) {
    event.preventDefault();
    //   alert(event);
    var myClass = $(this).attr("class");
    var myId = $(this).attr("id");
    //alert(myClass);
    var html = $(this).html();
    if (myClass == undefined || myClass == null || myClass === "hasActivity" || myClass === "isNotSelected") {

        selectedConditions.push(html);
        $("#selectedList").append('<li id="selected' + myId + '">' + html + '</li>');
        $(this).addClass("isSelected");
        //   alert(myClass);
    } else {
        $(this).attr("class", "isNotSelected");
        //alert(myId);
        $('#selected' + myId + '').remove();
        selectedConditions.eq(html).remove();
        //   $(this).removeClass("isSelected");
      
    }
});
