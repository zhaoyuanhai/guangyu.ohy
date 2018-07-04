$(function () {
    var width = window.innerWidth;
    var height = window.innerHeight;
    var cw = 250;
    var ch = 156;
    var m = false;

    $("#info,#qq,#code").css({
        top: height / 2 - ch / 2,
        left: width,
        display: "block"
    }).click(false);

    $("#contact").click(function () {
        $(this).css("background", "none");
        $(".bg-color").show();
        var x = true;
        $("#info,#qq,#code").animate({
            left: width / 2 - cw / 2,
        }, 300, function () {
            if (x) {
                x = false;
                var left = parseInt($(this).css("left").split('px')[0]);
                $("#qq").animate({
                    left: left - cw - 40
                }, 100);
                $("#code").animate({
                    left: left + cw + 40
                }, 100);
            }
        });

        m = true;
        return false;
    });

    $(document).click(function () {
        if (m) {
            $(".bg-color").hide();
            $("#info,#qq,#code").animate({
                left: width / 2 - cw / 2,
                top: height / 2 - ch / 2
            }, 100, function () {
                $("#info,#qq,#code").animate({
                    left: width
                }, 100, function () {
                    $("#contact").css({ backgroundImage: "url(/Content/ie/images/us.png)" });
                    m = false;
                });
            });
        }
    });

    move($("#info")[0]);
    move($("#qq")[0]);
    move($("#code")[0]);
});

function move(oDiv) {
    var disX = 0;
    var disY = 0;

    //封装一个函数用于获取鼠标坐标
    function getPos(ev) {
        var scrollTop = document.documentElement.scrollTop || document.body.scrollTop;
        var scrollLeft = document.documentElement.scrollLeft || document.body.scrollLeft;

        return { x: ev.clientX + scrollLeft, y: ev.clientY + scrollTop };
    }

    oDiv.onmousedown = function (ev) {
        var oEvent = ev || event;
        var pos = getPos(oEvent);  //这样就可以获取鼠标坐标，比如pos.x表示鼠标横坐标

        disX = pos.x - oDiv.offsetLeft;
        disY = pos.y - oDiv.offsetTop;

        document.onmousemove = function (ev)
           /*由于要防止鼠标滑动太快跑出div，这里应该用document.
           因为触发onmousemove时要重新获取鼠标的坐标，不能使用父函数上的pos.x和pos.y，所以必须写var oEvent=ev||event;var pos=getPos(oEvent);*/ {
            var oEvent = ev || event;
            var pos = getPos(oEvent);

            //防止div跑出可视框
            var l = pos.x - disX;
            var t = pos.y - disY;
            if (l < 0) {
                l = 0;
            }
            else if (l > document.documentElement.clientWidth - oDiv.offsetWidth) {
                l = document.documentElement.clientWidth - oDiv.offsetWidth;
            }

            if (t < 0) {
                t = 0;
            }
            else if (t > document.documentElement.clientHeight - oDiv.offsetHeight) {
                t = document.documentElement.clientHeight - oDiv.offsetHeight;
            }

            oDiv.style.left = l + 'px';
            oDiv.style.top = t + 'px';
        }

        document.onmouseup = function (ev) {
            document.onmousemove = null; //将move清除
            document.onmouseup = null;
            return false;
        }

        return false;  //火狐的bug，要阻止默认事件
    }
}