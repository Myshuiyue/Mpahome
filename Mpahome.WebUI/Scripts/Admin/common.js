/*
名称：公共函数体 
*/

var webroot = "/"; //总路径

//str.trim();
//删除左右两端的空格
String.prototype.trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, "");
}
//删除左边的空格
String.prototype.ltrim = function () {
    return this.replace(/(^\s*)/g, "");
}
//删除右边的空格
String.prototype.rtrim = function () {
    return this.replace(/(\s*$)/g, "");
}

String.prototype.Trim = function () {
    var m = this.match(/^\s*(\S+(\s+\S+)*)\s*/);
    return (m == null) ? "" : m[1];
}

String.prototype.isMobile = function () {
    return (/^(13[0-9]|14[0-9]|15[0|3|6|7|8|9]|18[0|2|5|6|8|9])\d{8}$/.test(this.Trim()));
}

String.prototype.isTel = function () {
    //"兼容格式: 国家代码(2到3位)-区号(2到3位)-电话号码(7到8位)-分机号(3位)"           
    return (/^(([0\+]\d{2,3}-)?(0\d{2,3})-)?(\d{7,8})(-(\d{3,}))?/.test(this.Trim()));
}

String.prototype.isZipCode = function () {
    return (/^[0-9]{6}$/.test(this.Trim()));
}
String.prototype.isQQ = function () {
    return (/^[1-9]*[1-9][0-9]*$/.test(this.Trim()));
}
String.prototype.isEmail = function () {
    return (/^[a-z0-9]+([._\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,20}[a-z0-9]+$/.test(this.Trim()));
}
//只能包括中文字、英文字母、数字和下划线
String.prototype.isString = function () {
    return (/^[\u0391-\uFFE5\w]+$/.test(this.Trim()));
}

var common = {
    //break word [breakWord("test_div", 37);]
    breakWord: function (controller, intLen) {
        var obj = document.getElementById(controller);
        var strContent = obj.innerHTML;
        var strTemp = "";
        while (strContent.length > intLen) {
            strTemp += strContent.substr(0, intLen) + "<br>";
            strContent = strContent.substr(intLen, strContent.length);
        }
        strTemp += "<br>" + strContent;
        obj.innerHTML = strTemp;
    },
    loadBeforeSend: function (div) {
        $("#" + div).html('<img src="' + webroot + 'images/loading.gif" />');
    },
    //回车事件
    enterEvent: function (divcontrol, buttoncontrol) {
        $("#" + divcontrol).keyup(function (event) {
            event = (event) ? event : ((window.event) ? window.event : "") //兼容IE和Firefox获得keyBoardEvent对象
            var key = event.keyCode ? event.keyCode : event.which; //兼容IE和Firefox获得keyBoardEvent对象的键值
            if (key == 13) {
                $("#" + buttoncontrol).click();
            }
        });
    },
    //提示信息
    showErrorMsg: function (message, contorl, flag) {
        if (flag) {
            $("#" + contorl).html(message);
            $("#" + contorl).css("display", "block");
        } else {
            $("#" + contorl).html(message);
            $("#" + contorl).css("display", "none");
        }
    },
    //是否是IE
    isIE: function () {
        if (window.navigator.userAgent.toLowerCase().indexOf("msie") >= 1)
            return true;
        else
            return false;
    },
    //用户名格式验证
    IsUserName: function (value) {
        return /^\w+$/.test(value);
    },
    copy_url: function (url, title) {
        var clipBoardContent = "";
        clipBoardContent += title; //获取标题    
        if (clipBoardContent != "")
            clipBoardContent += "\n";
        clipBoardContent += url; //获取地址   
        if (window.clipboardData) {
            window.clipboardData.setData("Text", clipBoardContent);
        } else if (window.netscape) {
            netscape.security.PrivilegeManager.enablePrivilege('UniversalXPConnect');
            var clip = Components.classes['@mozilla.org/widget/clipboard;1'].createInstance(Components.interfaces.nsIClipboard);
            if (!clip) return;
            var trans = Components.classes['@mozilla.org/widget/transferable;1'].createInstance(Components.interfaces.nsITransferable);
            if (!trans) return;
            trans.addDataFlavor('text/unicode');
            var str = new Object();
            var len = new Object();
            var str = Components.classes["@mozilla.org/supports-string;1"].createInstance(Components.interfaces.nsISupportsString);
            var copytext = clipBoardContent;
            str.data = copytext;
            trans.setTransferData("text/unicode", str, copytext.length * 2);
            var clipid = Components.interfaces.nsIClipboard;
            if (!clip) return false;
            clip.setData(trans, null, clipid.kGlobalClipboard);
        }
        alert("复制成功,您可以发送给你的好友啦!");
    },
    judgeStrLen: function (sString) {
        var sStr, iCount, i, strTemp;

        iCount = 0;
        sStr = sString.split("");
        for (i = 0; i < sStr.length; i++) {
            strTemp = escape(sStr[i]);
            if (strTemp.indexOf("%u", 0) == -1) // 表示是汉字
            {
                iCount = iCount + 1;
            }
            else {
                iCount = iCount + 2;
            }
        }
        return iCount;
    },
    josn2str: function (o) {
        if (o == undefined) {
            return "";
        }
        var r = [];
        if (typeof o == "string") return "\"" + o.replace(/([\"\\])/g, "\\$1").replace(/(\n)/g, "\\n").replace(/(\r)/g, "\\r").replace(/(\t)/g, "\\t") + "\"";
        if (typeof o == "object") {
            if (!o.sort) {
                for (var i in o)
                    r.push("\"" + i + "\":" + common.josn2str(o[i]));
                if (!!document.all && !/^\n?function\s*toString\(\)\s*\{\n?\s*\[native code\]\n?\s*\}\n?\s*$/.test(o.toString)) {
                    r.push("toString:" + o.toString.toString());
                }
                r = "{" + r.join() + "}"
            } else {
                for (var i = 0; i < o.length; i++)
                    r.push(common.josn2str(o[i]))
                r = "[" + r.join() + "]";
            }
            return r;
        }
        return o.toString().replace(/\"\:/g, '":""');
    },
    //classid：图片父标签样式, coustw:判断宽, w:赋值宽, cousth:判断高, h:赋值高
    loadPic: function (classid, coustw, w, cousth, h) {
        $("." + classid).find("img").each(function () {
            var oImg = new Image();
            oImg.src = $(this).attr("src");
            var _img = $(this);
            if (oImg.complete) {
                if (coustw > 0 && parseInt(oImg.width) > coustw) {
                    _img.css("width", w + "px");
                }
                if (cousth > 0 && parseInt(oImg.height) > cousth) {
                    _img.css("height", h + "px");
                }
            } else {
                oImg.onload = function () {
                    if (coustw > 0 && parseInt(oImg.width) > coustw) {
                        _img.css("width", w + "px");
                    }
                    if (cousth > 0 && parseInt(oImg.height) > cousth) {
                        _img.css("height", h + "px");
                    }
                };
                oImg.onerror = function () {
                    //window.alert('图片加载失败:' + url);
                };
            }
        });
    }
};


var cookie = {
    set: function (name, value)//两个参数，一个是cookie的名子，一个是值
    {
        var Days = 30; //此 cookie 将被保存 30 天
        var exp = new Date(); //new Date("December 31, 9998");
        exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
        document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString();
    },
    get: function (name)//读取cookies函数        
    {
        var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
        if (arr != null) return unescape(arr[2]); return null;

    },
    del: function (name)//删除cookie
    {
        var exp = new Date();
        exp.setTime(exp.getTime() - 1);
        var cval = getCookie(name);
        if (cval != null) document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString();
    }
}

