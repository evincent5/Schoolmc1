function callingTimeChanged() {
    if ($("#ddlCallingTime option:selected").val() == 3) {
        $("#LatestTime").show();
    }
    else {
        $("#LatestTime").hide();
    }
}

$(document).ready(function () {
    var maxLength = 20;
    $("#txtComment").keyup(function () {
        var textLength = $("#txtComment").val().length;
        var textLeft = maxLength - textLength;
        $("#lblTextRemaining").text(textLeft + " characters remaining");
    });
    //$("#btnSubmit").click(function () {
    //    showSubmittedValues();
    //});

})




function showSubmittedValues() {
    $("#ddlState option:selected").text();
    $("#ddlCallingTime option:selected").text();

    var chks = document.getElementsByName('checkBoxes');
    var chks = $('[name="checkBoxes"]');

    var str = "";
    for (var i = 0; i < chks.length; i++) {
        if (chks[i].checked == true) {
            str += $(chks[i]).next().text() + " ";


        }
    }
    var LatestTimeString = "";
    if ($("#ddlCallingTime").val() == 3) {

        LatestTimeString += " at " + $('#txtLatestTime').val();
    }

    var values = "The user has submitted the following values..." + $('#txtFirstName').val() +
       " " + $('#txtLastName').val() + "\n" + "Phone Number: " +
       $('#txtPhoneNumber').val() + '\n' + "Address: " +
       $('#txtAddress').val() + ', ' + $('#txtCity').val() +
       ',' + $("#ddlState option:selected").text() + '\n' + "The user has chosen to call in the " +
        $("#ddlCallingTime option:selected").text() + LatestTimeString + '\n'
        + "The courses enrolled for are " + str;

    alert(values);
    $("div.clear")[4].css("font-size", 20);
    $("#lblFirstName").parent().parent().siblings();

}
