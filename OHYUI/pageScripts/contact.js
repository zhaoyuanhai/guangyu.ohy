$(function () {
    $("#contact>.contactBox").click(function () {
        $("#contact").addClass("move");
        $(".bg-color").show();
        return false;
    });

    $(".info,.qq,.code").click(function () {
        if (!$("#contact").hasClass("move"))
            return;
        if (!$(".contactBox").hasClass("model1"))
            $(".contactBox").addClass("model1");
        else {
            if (!$(".contactBox").hasClass("model2"))
                $(".contactBox").addClass("model2");
            else {
                $(".contactBox").addClass("model3");
                setTimeout(function () {
                    $(".contactBox").removeClass("model1");
                    $(".contactBox").removeClass("model2");
                    $(".contactBox").removeClass("model3");
                }, 300);
            }
        }
        return false;
    });

    $(document).click(function () {
        if (!$("#contact").hasClass("move")) {
            return;
        }

        $(".bg-color").hide();
        $("#contact").animate({
            opacity: 0
        }, 300, function () {
            $("#contact").removeClass("move");
            $(".contactBox").removeClass("model1");
            $(".contactBox").removeClass("model2");
            $(".contactBox").removeClass("model3");
            $("#contact").animate({
                opacity: 1
            }, 300);
        });
    });
});