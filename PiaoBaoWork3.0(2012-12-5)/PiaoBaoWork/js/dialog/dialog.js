
//////////////////////////////////dialog.js////////////////////////////////////////////////////
if (!Array.prototype.push) {
    Array.prototype.push = function () {
        var B = this.length;
        for (var A = 0; A < arguments.length; A++) {
            this[B + A] = arguments[A]
        }
        return this.length
    }
}

function G() {
    var C = new Array();
    for (var B = 0; B < arguments.length; B++) {
        var A = arguments[B];
        if (typeof A == "string") {
            A = document.getElementById(A)
        }
        if (arguments.length == 1) {
            return A
        }
        C.push(A)
    }
    return C
}

Function.prototype.bind = function (B) {
    var A = this;
    return function () {
        A.apply(B, arguments)
    }
};

Function.prototype.bindAsEventListener = function (B) {
    var A = this;
    return function (C) {
        A.call(B, C || window.event)
    }
};

Object.extend = function (A, B) {
    for (property in B) {
        A[property] = B[property]
    }
    return A
};

if (!window.Event) {
    var Event = new Object()
}

Object.extend(Event,
{
    observers: false,
    element: function (A) {
        return A.target || A.srcElement
    },
    isLeftClick: function (A) {
        return (((A.which) && (A.which == 1)) || ((A.button) && (A.button == 1)))
    },
    pointerX: function (A) {
        return A.pageX || (A.clientX + (document.documentElement.scrollLeft || document.body.scrollLeft))
    },
    pointerY: function (A) {
        return A.pageY || (A.clientY + (document.documentElement.scrollTop || document.body.scrollTop))
    },
    stop: function (A) {
        if (A.preventDefault) {
            A.preventDefault();
            A.stopPropagation()
        }
        else {
            A.returnValue = false;
            A.cancelBubble = true
        }
    },
    findElement: function (C, B) {
        var A = Event.element(C);
        while (A.parentNode && (!A.tagName || (A.tagName.toUpperCase() != B.toUpperCase()))) {
            A = A.parentNode
        }
        return A
    },
    _observeAndCache: function (D, C, B, A) {
        if (!this.observers) {
            this.observers = []
        }
        if (D!=null&& D.addEventListener) {
            this.observers.push([D, C, B, A]);
            D.addEventListener(C, B, A)
        }
        else {
            if (D != null && D.attachEvent) {
                this.observers.push([D, C, B, A]);
                D.attachEvent("on" + C, B)
            }
        }
    },
    unloadCache: function () {
        if (!Event.observers) {
            return
        }
        for (var A = 0; A < Event.observers.length; A++) {
            Event.stopObserving.apply(this, Event.observers[A]);
            Event.observers[A][0] = null
        }
        Event.observers = false
    },
    observe: function (D, C, B, A) {
        var D = G(D);
        A = A || false;
        if (C == "keypress" && (navigator.appVersion.match(/Konqueror|Safari|KHTML/) || D.attachEvent)) {
            C = "keydown"
        }
        this._observeAndCache(D, C, B, A)
    },
    stopObserving: function (D, C, B, A) {
        var D = G(D);
        A = A || false;
        if (C == "keypress" && (navigator.appVersion.match(/Konqueror|Safari|KHTML/) || D.detachEvent)) {
            C = "keydown"
        }
        if (D != null && D.removeEventListener) {
            D.removeEventListener(C, B, A)
        }
        else {
            if (D != null && D.detachEvent) {
                D.detachEvent("on" + C, B)
            }
        }
    }
});

Event.observe(window, "unload", Event.unloadCache, false);

var Class = function () {
    var A = function () {
        this.initialize.apply(this, arguments)
    };
    for (i = 0; i < arguments.length; i++) {
        superClass = arguments[i];
        for (member in superClass.prototype) {
            A.prototype[member] = superClass.prototype[member]
        }
    }
    A.child = function () {
        return new Class(this)
    };
    A.extend = function (B) {
        for (property in B) {
            A.prototype[property] = B[property]
        }
    };
    return A
};

function space(A) {
    if (A == "begin") {
        var B = document.getElementById("ft");
        if (typeof (B) != "undefined" && B != null) {
            B.id = "ft_popup"
        }
        B = document.getElementById("usrbar");
        if (typeof (B) != "undefined" && B != null) {
            B.id = "usrbar_popup"
        }
    }
    else {
        if (A == "end") {
            var B = document.getElementById("ft_popup");
            if (typeof (B) != "undefined" && B != null) {
                B.id = "ft"
            }
            B = document.getElementById("usrbar_popup");
            if (typeof (B) != "undefined" && B != null) {
                B.id = "usrbar"
            }
        }
    }
}

var Popup = new Class();
Popup.prototype =
{
    iframeIdName: "ifr_popup",
    initialize: function (A) {
        this.config = Object.extend(
        {
            contentType: 1,
            isHaveTitle: true,
            scrollType: "yes",
            isBackgroundCanClick: false,
            isSupportDraging: true,
            isShowShadow: false,
            isReloadOnClose: true,
            width: 400,
            height: 300,
            left: 0,
            top: 0
        }, A || {});

        this.info =
        {
            shadowWidth: 4,
            title: "",
            contentUrl: "",
            contentHtml: "",
            callBack: null,
            parameter: null,
            confirmCon: "",
            alertCon: "",
            someHiddenTag: "", //"select,object,embed",
            someDisabledBtn: "",
            someHiddenEle: "",
            overlay: 0,
            coverOpacity: 40,
            position: 0
        };

        this.color =
        {
            cColor: "white",
            bColor: "white",
            tColor: "#2E6BA9", //title EEF5CC//表头背景色
            wColor: "white",
            tbColor: "#2E6BA9"//border 82B324 表头字体颜色
        };

        this.dropClass = null;
        this.someToHidden = [];
        this.someToDisabled = [];
        if (!this.config.isHaveTitle) {
            this.config.isSupportDraging = false
        }

        this.Tag = []; //存储数据
        this.iniBuild()
    },
    setContent: function (A, B) {
        if (B != "") {
            switch (A) {
                case "width": this.config.width = B; break;
                case "height": this.config.height = B; break;
                case "title": this.info.title = B; break;
                case "contentUrl": this.info.contentUrl = B; break;
                case "contentHtml": this.info.contentHtml = B; break;
                case "callBack": this.info.callBack = B; break;
                case "parameter": this.info.parameter = B; break;
                case "confirmCon": this.info.confirmCon = B; break;
                case "alertCon": this.info.alertCon = B; break;
                case "someHiddenTag": this.info.someHiddenTag = B; break;
                case "someHiddenEle": this.info.someHiddenEle = B; break;
                case "someDisabledBtn": this.info.someDisabledBtn = B; break;
                case "overlay": this.info.overlay = B;
                case "position": this.info.position = B;
                case "left": this.config.left = B;
                case "top": this.config.top = B;
            }
        }
    },
    iniBuild: function () {
        G("dialogCase") ? G("dialogCase").parentNode.removeChild(G("dialogCase")) : function () { };
        var A = document.createElement("span");
        A.id = "dialogCase";
        if (document.body != null) {
            document.body.appendChild(A)
        } else {
            alert(" document.body找不到方法iniBuild() 调用方法用在body中");
        }
    },
    build: function () {
        var A = 10001 + this.info.overlay * 10;
        var B = A + 2;
        this.iframeIdName = "ifr_popup" + this.info.overlay;
        var D = "../../js/dialog/"; // http://img.baidu.com/hi/img/";/////////////////////////////////图片文件夹路径url    http://img.baidu.com/hi/img/dialogclose2.gif
        var F = '<input type="image" id="dialogBoxClose" src="' + D + 'dialogclose2.gif" border="0" width="16" height="16" align="absmiddle" title="关闭"/>'; //可以扩展
        var H = "filter: alpha(opacity=" + this.info.coverOpacity + ");opacity:" + this.info.coverOpacity / 100 + ";";
        var C = '<div id="dialogBoxBG" style="position:absolute;top:0px;left:0px;width:100%;height:100%;z-index:' + A + ";" + H + "background-color:" + this.color.cColor + ';display:none;"></div>';
        var E = '<div id="dialogBox" style="border:0;display:none;z-index:' + B + ";position:relative;width:" + this.config.width + 'px;"><table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="' + this.color.bColor + '" style="border:1px solid ' + this.color.tbColor + '">';
        if (this.config.isHaveTitle) {
            E += '<tr height="24" bgcolor="' + this.color.tColor + '"><td><table style="-moz-user-select:none;height:24px; border-bottom:1px solid ' + this.color.tbColor + ';text-align: left;" width="100%" border="0" cellpadding="0" cellspacing="0" ><tr><td width="6" height="24"></td><td id="dialogBoxTitle" style="color:' + this.color.wColor + ';font-size:14px;font-weight:bold;">' + this.info.title + '&nbsp;</td><td id="dialogClose" width="20" align="right" valign="middle">' + F + '</td><td width="6"></td></tr></table></td></tr>'
        }
        else {
            E += '<tr height="10"><td align="right">' + F + "</td></tr>"
        }
        E += '<tr style="height:' + this.config.height + 'px" valign="top"><td id="dialogBody" style="position:relative;"></td></tr></table></div><div id="dialogBoxShadow" style="display:none;z-index:' + A + ';"></div>';
        if (!this.config.isBackgroundCanClick) {
            G("dialogCase").innerHTML = C + E;
            G("dialogBoxBG").style.height = document.body.scrollHeight
        }
        else {
            G("dialogCase").innerHTML = E
        }
        Event.observe(G("dialogBoxClose"), "click", this.reset.bindAsEventListener(this), false);
        if (this.config.isSupportDraging) {
            dropClass = new Dragdrop(this.config.width, this.config.height, this.info.shadowWidth, this.config.isSupportDraging, this.config.contentType);
            G("dialogBoxTitle").style.cursor = "move"
        }
        this.lastBuild()
    },
    lastBuild: function () {
        var B = '<div style="width:100%;height:100%;text-align:center;"><div style="margin:20px 20px 0 20px;font-size:14px;line-height:16px;color:#000000;">' + this.info.confirmCon + '</div><div style="margin:20px;"><input id="dialogOk" type="button" value="  确定  "/>&nbsp;<input id="dialogCancel" type="button" value="  取消  "/></div></div>';
        var E = '<div style="width:100%;height:100%;text-align:center;"><div style="margin:20px 20px 0 20px;font-size:14px;line-height:16px;color:#000000;">' + this.info.alertCon + '</div><div style="margin:20px;"><input id="dialogYES" type="button" value="  确定  "/></div></div>';
        var A = 10001 + this.info.overlay * 10;
        var D = A + 4;
        if (this.config.contentType == 1) {
            var C = "<iframe width='100%' style='height:" + this.config.height + "px' name='" + this.iframeIdName + "' id='" + this.iframeIdName + "' src='" + this.info.contentUrl + "' frameborder='0' scrolling='" + this.config.scrollType + "'></iframe>";
            var F = "<div id='iframeBG' style='position:absolute;top:0px;left:0px;width:1px;height:1px;z-index:" + D + ";filter: alpha(opacity=00);opacity:0.00;background-color:#ffffff;'><div>";
            G("dialogBody").innerHTML = C + F
        }
        else {
            if (this.config.contentType == 2) {
                G("dialogBody").innerHTML = this.info.contentHtml
            }
            else {
                if (this.config.contentType == 3) {
                    G("dialogBody").innerHTML = B;
                    Event.observe(G("dialogOk"), "click", this.forCallback.bindAsEventListener(this), false);
                    Event.observe(G("dialogCancel"), "click", this.close.bindAsEventListener(this), false)
                } else {
                    if (this.config.contentType == 4) {
                        G("dialogBody").innerHTML = E;
                        Event.observe(G("dialogYES"), "click", this.close.bindAsEventListener(this), false)
                    }
                }
            }
        }
    },
    reBuild: function () {
        G("dialogBody").height = G("dialogBody").clientHeight;
        this.lastBuild()
    },
    show: function () {
        this.hiddenSome();
        this.middle();
        if (this.config.isShowShadow) {
            this.shadow()
        }
    },
    forCallback: function () {
        return this.info.callBack(this.info.parameter)
    },
    shadow: function () {
        var A = G("dialogBoxShadow");
        var B = G("dialogBox");
        A.style["position"] = "absolute";
        A.style["background"] = "#000";
        A.style["display"] = "";
        A.style["opacity"] = "0.2";
        A.style["filter"] = "alpha(opacity=20)";
        if (this.info.position == 0) {
            A.style["top"] = B.offsetTop + this.info.shadowWidth;
            A.style["left"] = B.offsetLeft + this.info.shadowWidth;
        } else if (this.info.position == 1) {
            A.style["top"] = this.config.top;
            A.style["left"] = B.offsetLeft + this.info.shadowWidth; // this.config.left;
        }
        A.style["width"] = B.offsetWidth;
        A.style["height"] = B.offsetHeight
    },
    middle: function () {
        if (!this.config.isBackgroundCanClick) {
            G("dialogBoxBG").style.display = "";
        }
        var F = G("dialogBox");
        F.style["position"] = "absolute";
        F.style["display"] = "";
        var C = document.body.clientWidth;
        var E = document.body.clientHeight;
        var B = document.body.scrollTop;
        var D = (document.body.clientWidth / 2) - (F.offsetWidth / 2);
        var H = -80 + (E / 2 + B) - (F.offsetHeight / 2);
        var A = H > 0 ? H : (E / 2 + B) - (F.offsetHeight / 2);
        if (A < 1) { A = "20" }
        if (D < 1) { D = "20" }
        if (this.info.position == 0) {
            F.style["left"] = D;
            F.style["top"] = A;
        } else if (this.info.position == 1) {
            F.style["left"] = D; //this.config.left;
            F.style["top"] = this.config.top;
        }
    },
    reset: function () {
        if (this.config.isReloadOnClose) {
            top.location.reload()
        }
        this.close()
    },
    close: function () {
        G("dialogBox").style.display = "none";
        if (!this.config.isBackgroundCanClick) {
            G("dialogBoxBG").style.display = "none"
        }
        if (this.config.isShowShadow) {
            G("dialogBoxShadow").style.display = "none"
        }
        G("dialogBody").innerHTML = "";
        this.showSome()
    },
    hiddenSome: function () {
        var A = this.info.someHiddenTag.split(",");
        if (A.length == 1 && A[0] == "") {
            A.length = 0
        }
        for (var B = 0; B < A.length; B++) {
            this.hiddenTag(A[B])
        }
        var C = this.info.someHiddenEle.split(",");
        if (C.length == 1 && C[0] == "") {
            C.length = 0
        }
        for (var B = 0; B < C.length; B++) {
            this.hiddenEle(C[B])
        }
        var C = this.info.someDisabledBtn.split(",");
        if (C.length == 1 && C[0] == "") {
            C.length = 0
        }
        for (var B = 0; B < C.length; B++) {
            this.disabledBtn(C[B])
        }
        space("begin")
    },
    disabledBtn: function (B) {
        var A = document.getElementById(B);
        if (typeof (A) != "undefined" && A != null && A.disabled == false) {
            A.disabled = true;
            this.someToDisabled.push(A)
        }
    },
    hiddenTag: function (B) {
        var C = document.getElementsByTagName(B);
        if (C != null) {
            for (var A = 0; A < C.length; A++) {
                if (C[A].style.display != "none" && C[A].style.visibility != "hidden") {
                    C[A].style.visibility = "hidden";
                    this.someToHidden.push(C[A])
                }
            }
        }
    },
    hiddenEle: function (B) {
        var A = document.getElementById(B);
        if (typeof (A) != "undefined" && A != null) {
            A.style.visibility = "hidden";
            this.someToHidden.push(A)
        }
    },
    showSome: function () {
        for (var A = 0; A < this.someToHidden.length; A++) {
            this.someToHidden[A].style.visibility = "visible"
        }
        for (var A = 0; A < this.someToDisabled.length; A++) {
            this.someToDisabled[A].disabled = false
        }
        space("end")
    }
};


var Dragdrop = new Class();

Dragdrop.prototype =
{
    initialize: function (C, B, A, D, E) {
        this.dragData = null;
        this.dragDataIn = null;
        this.backData = null;
        this.width = C;
        this.height = B;
        this.shadowWidth = A;
        this.showShadow = D;
        this.contentType = E;
        this.IsDraging = false;
        this.oObj = G("dialogBox");
        Event.observe(G("dialogBoxTitle"), "mousedown", this.moveStart.bindAsEventListener(this), false)
    },
    moveStart: function (A) {
        this.IsDraging = true; if (this.contentType == 1) {
            G("iframeBG").style.display = "";
            G("iframeBG").style.width = this.width;
            G("iframeBG").style.height = this.height
        }
        Event.observe(document, "mousemove", this.mousemove.bindAsEventListener(this), false);
        Event.observe(document, "mouseup", this.mouseup.bindAsEventListener(this), false);
        Event.observe(document, "selectstart", this.returnFalse, false);
        this.dragData =
        {
            x: Event.pointerX(A),
            y: Event.pointerY(A)
        };
        this.backData =
        {
            x: parseInt(this.oObj.style.left),
            y: parseInt(this.oObj.style.top)
        }
    },
    mousemove: function (A) {
        if (!this.IsDraging) {
            return
        }
        var C = Event.pointerX(A) - this.dragData.x + parseInt(this.oObj.style.left);
        var B = Event.pointerY(A) - this.dragData.y + parseInt(this.oObj.style.top);
        if (this.dragData.y < parseInt(this.oObj.style.top)) {
            B = B - 12;
        }
        else {
            if (this.dragData.y > parseInt(this.oObj.style.top) + 25) {
                B = B + 12;
            }
        }
        this.oObj.style.left = C;
        this.oObj.style.top = B;
        if (this.showShadow) {
            G("dialogBoxShadow").style.left = C + this.shadowWidth;
            G("dialogBoxShadow").style.top = B + this.shadowWidth
        }
        this.dragData =
        {
            x: Event.pointerX(A),
            y: Event.pointerY(A)
        };
        document.body.style.cursor = "move"
    },
    mouseup: function (C) {
        if (!this.IsDraging) {
            return;
        }
        if (this.contentType == 1) {
            G("iframeBG").style.display = "none"
        }
        document.onmousemove = null;
        document.onmouseup = null;
        var B = Event.pointerX(C) - (document.documentElement.scrollLeft || document.body.scrollLeft);
        var A = Event.pointerY(C) - (document.documentElement.scrollTop || document.body.scrollTop);
        if (B < 1 || A < 1 || B > document.body.clientWidth || A > document.body.clientHeight) {
            this.oObj.style.left = this.backData.x;
            this.oObj.style.top = this.backData.y;
            if (this.showShadow) {
                G("dialogBoxShadow").style.left = this.backData.x + this.shadowWidth;
                G("dialogBoxShadow").style.top = this.backData.y + this.shadowWidth
            }
        }
        this.IsDraging = false;
        document.body.style.cursor = "";
        Event.stopObserving(document, "selectstart", this.returnFalse, false)
    },
    returnFalse: function () {
        return false
    }
};
