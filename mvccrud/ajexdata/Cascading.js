$(document).ready(function () {



    $("#btncancle").click(function () {
        window.location.href = "/employeedata/displayemp/";
    });
    $("#Birthdate").datepicker();

    $('#input-container').bValidator();

    var urlParams = new URLSearchParams(window.location.search);
    if (urlParams.has('empId')) {
        var id = urlParams.get('empId')
        Editdata(id);
    } else {
        GetCountry();
    }

    $("#Country_id").change(function () {
        var countryId = $("#Country_id").val();
        GetState(countryId);
    });

    $("#State_id").change(function () {
        var stateId = $("#State_id").val();
        GetCity(stateId);
    });


    $("#btnclick").click(function () {

        if ($('#input-container').data('bValidator').validate()) {
            $('#input-container').bValidator(null, 'myinstance');
            $('#input-container').data("bValidators").bvalidator.validate();
            $('#input-container').data("bValidators").myinstance.validate();

            var arrhobbies = $("#Hobbies").val();
            var hobbies = arrhobbies.join(",");

            var files = $("#Photo").get(0).files;
            var fileData = new FormData();
            for (var i = 0; i < files.length; i++) {
                fileData.append("#Photo", files[i]);
            }

            var obj =
            {
                "Empid": $("#Empid").val(),
                "Firstname": $("#Firstname").val(),
                "Lastname": $("#Lastname").val(),
                "Gender": $("#Gender").val(),
                "Email": $("#Email").val(),
                "Marial_Status": $("#Marial_Status").val(),
                "Birthdate": $("#Birthdate").val(),
                "Hobbies": hobbies,
                "Salary": $("#Salary").val(),
                "Address": $("#Address").val(),
                "Country_id": $("#Country_id").val(),
                "State_id": $("#State_id").val(),
                "City_id": $("#City_id").val(),
                "Zipcode": $("#Zipcode").val(),
                "Password": $("#Password").val()
            }


            $.ajax({
                type: 'post',
                url: '/employeedata/Insertemp',
                data: obj,
                success: function (data) {
                    uploadFile(fileData, data[1].Value)
                    window.location.href = "/employeedata/displayemp/";
                }, error: function (err) {
                    alert(err);
                }
            });

        }



    });
        
    function uploadFile(formData, id) {
        $.ajax({
            type: 'post',
            url: '/Employeedata/UploadFiles/' + id,
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {

                window.location.href = "/employeedata/displayemp/";
            }, error: function (err) {
                alert(err);
            }
        });
    }
});

function passwordFormat(password) {
    regex = new RegExp(/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$/);
    if (regex.test(password))
        return true;
    return false;
}


function Editdata(id) {
    $.ajax({
        type: "Get",
        url: "/employeedata/Editemp/" + id,
        datatype: 'json',
        success: function (data) {
            var arrhobbies = $("#Hobbies").val(data.Hobbies);
            var hobbies = arrhobbies.join(",");

            $('#Empid').val(data.Empid);
            $("#Firstname").val(data.Firstname);
            $("#Lastname").val(data.Lastname);
            $("#Gender").val(data.Gender);
            $("#Email").val(data.Email);
            $("#Marial_Status").val(data.Marial_Status);
            var birthdate = new Date(parseInt(data.Birthdate.substr(6)));
            birthdate = birthdate.getMonth() + '/' + birthdate.getDate() + '/' + birthdate.getFullYear();
            $("#Birthdate").val(birthdate);
            $("#Hobbies") = hobbies;
            //$("#Hobbies").val(data.Hobbies);
            $("#Photo").val(data.file);
            $("#Salary").val(data.Salary);
            $("#Address").val(data.Address);
            $("#Country_id").val(data.Country_id);
            $("#State_id").val(data.State_id);
            $("#City_id").val(data.City_id);
            $("#Zipcode").val(data.Zipcode);
            $("#Password").val(data.Password);

            GetCountry(function () {
                $("#Country_id").val(data.Country_id);
            });

            GetState(data.Country_id, function () {
                $("#State_id").val(data.State_id);
            });

            GetCity(data.State_id, function () {
                $("#City_id").val(data.City_id);
            });

        }, error: function (err) {
            alert(err);
        }
    });
}


function GetCountry(callBack) {
    $.ajax({
        type: 'Get',
        url: '/Employeedata/getcountry/',
        success: function (data) {
            $("#Country_id").empty();
            $("#Country_id").append('<option value="0">--select country--</option>');
            $.each(data, function (key, value) {
                $("#Country_id").append("<option value='" + value.Value + "'>" + value.Text + "</option>");
            });
            if (callBack != null)
                callBack();
        }, error: function (err) {
            alert(err);
        }
    });
}

function GetState(countryId, callBack) {
    $.ajax({
        type: 'Get',
        url: '/Employeedata/getstate/' + countryId,
        success: function (data) {
            $("#State_id").empty();
            $("#State_id").append('<option value="0">--select state--</option>');
            $.each(data, function (key, value) {
                $("#State_id").append("<option value='" + value.State_id + "'>" + value.State_name + "</option>");
            });

            if (callBack != null)
                callBack();
        }, error: function (err) {
            alert(err);
        }
    });
}

function GetCity(stateId, callBack) {
    $.ajax({
        type: 'Get',
        url: '/Employeedata/getcity/' + stateId,
        success: function (data) {
            $("#City_id").empty();
            $("#City_id").append('<option value="0">--select state--</option>');
            $.each(data, function (key, value) {
                $("#City_id").append("<option value='" + value.City_id + "'>" + value.City_name + "</option>");
            });
            if (callBack != null)
                callBack();
        }, error: function (err) {
            alert(err);
        }
    });
}

