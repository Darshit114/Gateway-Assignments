$(document).ready(function ()
{
    $('#registerFormId').validate({
        errorClass: 'help-block animation-slideDown',
        errorElement: 'div',
        errorPlacement: function (error, e) {
            e.parents('.form-group > div').append(error);
        },
        highlight: function (e) {

            $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
            $(e).closest('.help-block').remove();
        }, 
        success: function (e) {
            e.closest('.form-group').removeClass('has-success has-error');
            e.closest('.help-block').remove();
        },
        rules: {
            'FirstName': {
                required: true,
                minlength: 3,
                maxlength: 50
            },
            'LastName': {
                required: true,
                minlength: 3,
                maxlength: 50
            },
            'Age': {
                required: true,
            },
            'Email': {
                required: true,
                email: true
            },

            'Password': {
                required: true,
                minlength: 6
            },

            'ConfirmPassword': {
                required: true,
                equalTo: '#Password'
            }
        },
        messages: {
            'FirstName': 'Please enter firstname',

            'LastName': 'Please enter lastname',

            'Age': 'Please enter your age',

            'Email': 'Please enter valid email address',

            'Password': {
                required: 'Please provide a password',
                minlength: 'Your password must be at least 6 characters long'
            },

            'ConfirmPassword': {
                required: 'Please provide a password',
                minlength: 'Your password must be at least 6 characters long',
                equalTo: 'Please enter the same password as above'
            }
        }  
    });

    $('#FileUpload').change(function ()
    {
        // Get uploaded file extension
        var extension = $(this).val().split('.').pop().toLowerCase();

        // Array with the file extensions that client wish to upload
        var validFileExtensions = ['png', 'jpg', 'jpeg'];

        // Check file extension in the array.if -1 that means the file extension is not in the list. 
        if ($.inArray(extension, validFileExtensions) == -1) {
            $('#spnDocMsg').text("Sorry!! Upload only jpg, jpeg, png file").show();

            // Clear fileupload control selected file
            $(this).replaceWith($(this).val('').clone(true));

            //Disable Submit Button
            $('#btnSubmit').prop('disabled', true);

        } 
    });
});