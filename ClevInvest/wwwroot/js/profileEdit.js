//Стартовые значения формы
$(function () {
    $('#editPForm').find(':input').each(function (i, elem) {
        var input = $(elem);
        input.data('initialState', input.val());
    });
});

function edit() {
    $('.custom-file').removeClass("d-none");
    $('#editProfile').hide();
    $('.accountInput').removeClass("accountInput");
    $('#saveChanges').removeClass("d-none");
    $('#fileUpload').removeClass("d-none");
    $('#cancel').removeClass("d-none");
}

function cancelEdit() {
    $('.custom-file').addClass("d-none");
    $('#editProfile').show();
    $('#saveChanges').addClass("d-none");
    $('#cancel').addClass("d-none");
    $('#editPForm input').addClass("accountInput")
    $('.custom-file-label').html("")

    
}

$(document).ready(function (){
    $('.custom-file-input').on("change", function (){
        var fileName = $(this).val().split("\\").pop();
        $(this).next('.custom-file-label').html(fileName);
    })
})

function save() {
    $('#editProfile').show()
    $('#saveChanges').addClass("d-none");
    $('#cancel').addClass("d-none");
    $('#editPForm input').addClass("accountInput")
    $('#editPForm').find(':input').each(function (i, elem) {
        var input = $(elem);
    });
}