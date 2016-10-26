
$(document).ready(function () {
    $("#mainMenu  li").removeClass("active");
    var url = window.location;
    var lastPart = url.toString().split("/").pop();
    if (url.href.indexOf("NonInCarcerated") > 0 || url.href.indexOf("InCarcerated") > 0) {
        $(".clemency").addClass("active");
    } else {
        switch (lastPart) {
            case "About":
                $(".information").addClass("active");
                break;
            case "Contact":
                $(".contact").addClass("active");
                break;
            case "Faq":
                $(".information").addClass("active");
                break;
            case "Privacy":
                $(".information").addClass("active");
                break;
            case "FormSelect":
                $(".clemency").addClass("active");
                break;
            case "Login":
                $(".Accounts").addClass("active");
                break;
            case "Registration":
                $(".Accounts").addClass("active");
                break;
            case "":
                $(".home").addClass("active");
                break;
            case "home":
                $(".home").addClass("active");
                break;
            case "NonInCarcerated":
                $(".clemency").addClass("active");
                break;
            case "Incarcerated":
                $(".clemency").addClass("active");
                break;
        }
    }

});
