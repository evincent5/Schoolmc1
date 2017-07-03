
/// <reference path="jquery-1.10.2.js" />

$(function () {
    $("#btnSubmit").mouseover(function () {
        $("#btnSubmit").css("backgroundColor", "red");
    });
    $("#btnSubmit").mouseout(function () {
        $("#btnSubmit").css("backgroundColor", "grey");
    });
});