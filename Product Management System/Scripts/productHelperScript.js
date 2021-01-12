
$(document).ready(

    $("#productRegister").submit(function (event) {
        event.preventDefault();
    }),

    $("#productSubmit").on('click', function () {

        var data = new FormData();

        var smallImg = $("#smallImg").get(0).files;
        var largeImg = $("#largeImg").get(0).files;

       
        var name = $("#name").val();
        var category = $("#category").val();
        var price = $("#price").val();
        var quantity = $("#quantity").val();
        var shortText = $("#shortText").val();
        var longText = $("#longText").val();

       

        // Adding the content of uploaded image content to the form data collecion
        if (smallImg.length > 0 && largeImg.length > 0) {

            data.append("SmallImg", smallImg[0]);
            data.append("LargeImg", largeImg[0]);
        }

        data.append("Name", name);
        data.append("Category", category);
        data.append("Price", price);
        data.append("Quantity", quantity);
        data.append("ShortText", shortText);
        data.append("LongText", longText); 

        $.ajax({
            type: 'POST',
            url: 'http://localhost:59086/api/v1/products/AddProduct',
            contentType: false,
            processData: false,
            data: data,
            dataType: 'json',
            success: function (response, jqXHR) {

                alert("Product Updated Successfully!!!");
                window.location.href = '/Home';
            },
            error: function (err) {
                console.log(err);
            }
        })

    })

);