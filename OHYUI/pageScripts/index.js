jQuery.validator.addMethod("isMobile", function (value, element) {
    var length = value.length;
    var mobile = /^(13[0-9]{9})|(18[0-9]{9})|(14[0-9]{9})|(17[0-9]{9})|(15[0-9]{9})$/;
    return this.optional(element) || (length == 11 && mobile.test(value));
}, "请正确填写您的手机号码");

$.extend($.validator.messages, {
    required: "这是必填字段",
    remote: "请修正此字段",
    email: "请输入有效的电子邮件地址",
    url: "请输入有效的网址",
    date: "请输入有效的日期",
    dateISO: "请输入有效的日期 (YYYY-MM-DD)",
    number: "请输入有效的数字",
    digits: "只能输入数字",
    creditcard: "请输入有效的信用卡号码",
    equalTo: "你的输入不相同",
    extension: "请输入有效的后缀",
    maxlength: $.validator.format("最多可以输入 {0} 个字符"),
    minlength: $.validator.format("最少要输入 {0} 个字符"),
    rangelength: $.validator.format("请输入长度在 {0} 到 {1} 之间的字符串"),
    range: $.validator.format("请输入范围在 {0} 到 {1} 之间的数值"),
    max: $.validator.format("请输入不大于 {0} 的数值"),
    min: $.validator.format("请输入不小于 {0} 的数值")
});

$(function () {
    $(".typeimg").hover(function () {
        var index = $(this).data("index");
        $(this).attr("src", "/images/classification/" + index + "." + index + ".png");
    }, function () {
        var index = $(this).data("index");
        $(this).attr("src", "/images/classification/" + index + ".png");
    });

    //轮播图
    $('.slideBox').slideBox({
        hideBottomBar: true,
        easing: "linear",//swing
        direction: "left",//top
        delay: 5,
        //width: "100%",
        height: "100%"
    });

    //公司简介变化
    (function () {
        var index = 0;
        var items = $(".info>div")
        var length = items.length;
        setInterval(function () {
            index++;
            items.removeClass("active");
            $(items[index]).addClass("active");
            if (index == length - 1)
                index = -1;
        }, 4000);
    })();

    //语言切换
    $(".language").click(function () {
        //$(".lang").addClass("active");
        //if ($(".lang").text() == 'language') {

        //} else {

        //}

        //var value = $(this).data("value");

        var value = cookie.getCookie("language") == "0" ? "1" : "0";

        cookie.delCookie("language");
        var language = cookie.setCookie("language", value);
        location.reload();

        return false;
    });

    //表单验证
    (function () {
        $("#myform").validate({
            submitHandler: function (from) {
                var t = layer.load(1, { shade: [0.1, '#808080'] });
                var data = $(from).serialize();
                $.post($(from).attr("action"), data, function (result) {
                    layer.close(t);
                    layer.alert("数据已添加");
                    $(from)[0].reset();
                }, "json");
                return false;
            }
        });
    })();

    $(document).click(function () {
        $(".lang").removeClass("active");
    });
});