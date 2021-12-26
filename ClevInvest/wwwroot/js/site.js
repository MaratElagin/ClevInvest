//password show

$('modal-body').on('click', '.password-control', function(){
    if ($('.password').attr('type') == 'password'){
        $(this).addClass('view');
        $('.password').attr('type', 'text');
    } else {
        $(this).removeClass('view');
        $('#password-input').attr('type', 'password');
    }
    return false;
});