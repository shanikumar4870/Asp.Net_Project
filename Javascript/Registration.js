var ID = 0;
$(document).ready(function () {
    ShowRegistrationData();
    BindState();
    $("#btn").click(function () {
        InsertUpdateRegistration();
        return false;
    })
    $("#txtState").change(function () {
        BindCityMaster($("#txtState").val());
    })
})
function BindState() {
    $.post("../Master/BindState/", {}, function (data) {
        if (data.Grridview != "") {
            $("#txtState").html(data.Grridview)
        }
    })
}
function BindCityMaster(Statecode) {
    $.post("../Master/BindCityMaster/", { Statecode: Statecode },
        function (data) {
            if (data.GridCity != "") {
                $("#txtCity").html(data.GridCity);
            }
        })
}
function InsertUpdateRegistration() {
    $.post("../Master/InsertUpdateRegistration/", {ID:ID,
        Name: $("#txtName").val(),
        Statename: $("#txtState").val(),
        Cityname: $("#txtCity").val(),
        Regdate: $("#txtRegdate").val(),
    }, function (data) {

        if (data.Message != "") {
            alert(data.Message);
            window.location.reload(true);
            ShowRegistrationData();
        }
    })
}
function ShowRegistrationData() {
    $.post("../Master/ShowRegistrationData/", {}, function (data) {
        if (data.Gridview != "") {
            $("#Grid").html(data.Gridview);
        }
    })
}

function Delete(ID) {
    alert("hello", "Message", "success");
}
