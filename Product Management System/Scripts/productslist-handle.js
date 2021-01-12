
$(document).ready(function () {

    $("#deleteAll").on('click', function () {

        var list = [];

        $("#productList input[type=checkbox]:checked").each(function (i) {
            list[i] = $(this).val();
            
        });

        var data = { list : list }

        $.ajax({
            type: 'POST',
            url: 'http://localhost:59086/api/v1/products/DeleteMultiple',
            contentType: 'application/json;charset=utf-8',
            processData: false,
            data: JSON.stringify(data),
            success: function (response, jqXHR) {

                console.log(response);
            },
            error: function (err) {
                console.log(err);
            }

        })
    })

    
});