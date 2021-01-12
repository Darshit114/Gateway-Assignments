
$(document).ready(

    $("#loginForm").submit(function (event) {
        event.preventDefault();
    }),

    $("#loginBtn").on('click', function () {

        var user = {
            Email: $("#email").val(),
            Password: $("#pswd").val()
        }

        var _user;
        var statusCode;

        $.ajax({
            type: 'POST',
            headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
            url: 'http://localhost:59086/api/v1/auth/admin',
            contentType: 'application/json;charset=UTF-8',
            data: JSON.stringify(user),
            dataType: 'json',
            success: function (data, jqXHR) {
                
                  _user = data.admin; 
            },
            statusCode: function (code) {
                statusCode = code;
                console.log(statusCode);
            },
            error: function (err) {
                
                alert("Usernam or password invalid!!!!");
                location.reload();
            }
        }).then(function () {

            if (_user != undefined) {

                $.ajax({
                    type: 'POST',
                    url: 'http://localhost:59086/Home/AjaxMethod',
                    contentType: 'application/json;charset=UTF-8',
                    data: JSON.stringify(_user),
                    dataType: 'json',
                    async: false,
                    success: function (response, textStatus, jqXHR) {
                        
                        window.location.href = '/Home';
                    },
                    error: function (err) {
                        console.log(err);
                    }
                })

            } else {
                
                console.log("Undefined!!!");
            }

        }) 
    }),

    $("#logout").on('click', function () {

        $.ajax({
            type: 'GET',
            url: 'http://localhost:59086/Home/ClearSession',
            contentType: 'application/json;charset=UTF-8',
            dataType: 'json',
            async: false,
            success: function (response, textStatus, jqXHR) {

                if (response) {

                    localStorage.clear();

                    window.location.href = '/Home/Login';
                }
            },
            error: function (err) {
                console.log(err);
            }
        })       
 
        
    })
);

