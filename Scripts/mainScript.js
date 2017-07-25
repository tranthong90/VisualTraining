var selectedConditions = [];
var selectedConditionIds = [];
$(function () { // will trigger when the document is ready
    $('.datepicker').datepicker({
        format: "dd/mm/yyyy"
    }); //Initialise any date pickers

    $('#browser').filterTable({ filterExpression: 'filterTableFindAll' });

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
        var buttonId = $(this).attr("id");
        var diagnosisId = $(this).attr("data-diagnosisid");
        //do action before move to the next tab
        if(buttonId === "btnStep1"){
         //   SavePatientInfo(moveToNextTab, diagnosisId);
            moveToNextTab();
        } else if (buttonId === "btnStep2") {
            SaveConditions(moveToNextTab, diagnosisId);
        }
       

    });
    $(".prev-step").click(function (e) {

        var $active = $('.wizard .nav-tabs li.active');
        prevTab($active);

    });

});

function moveToNextTab() {
    var $active = $('.wizard .nav-tabs li.active');
    $active.next().removeClass('disabled');
    nextTab($active);
}

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
    if (myClass != undefined && myClass != null && myClass.indexOf("isSelected") !== -1) //&& myClass.indexOf("hasActivity") == -1 && myClass.indexOf("isNotSelected") == -1)
    {

        $(this).attr("class", "isNotSelected");
        //alert(myId);
        $('#selected' + myId + '').remove();
        var index = selectedConditions.indexOf(html);
        selectedConditions.splice(index, 1);
        selectedConditionIds.splice(index, 1);
        //   $(this).removeClass("isSelected");


    } else {

        selectedConditions.push(html);
        selectedConditionIds.push(myId);
        $("#selectedList").append('<li id="selected' + myId + '">' + html + '</li>');
        $(this).addClass("isSelected");
        //   alert(myClass);
      
    }
});


function SavePatientInfo(callback,diagnosisId) {
    //save the patient name
    var Optometrist = $("#Optometrist").val();
    var PatientName = $("#PatientName").val();
    var DOB = $("#DOB").val();
    var NumberOfSession = $("#NumberOfSession").val();

    $.get("http://localhost:27948/Home/SavePatientDetail", { patientName: PatientName, optometrist: Optometrist, dob: DOB, numberOfSession: NumberOfSession, diagnosisId: diagnosisId }, callback);
    
};

function SaveConditions(callback, diagnosisId) {
    var selectedCondition = {
        DiagnosisId: diagnosisId,
        SelectedConditions: selectedConditionIds
    }

    $.post("http://localhost:27948/Home/SaveConditions", selectedCondition, callback);

};
