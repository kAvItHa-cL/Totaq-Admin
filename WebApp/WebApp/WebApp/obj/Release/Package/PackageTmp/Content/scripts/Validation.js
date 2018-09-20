function validate(EmailId) {

    var reg = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (reg.test(email) == false) {
        swal(reg.test(email))
        return false;
    }
}