//用于MVC参数适配JavaScript闭包函数  
/* 
使用方式如下： 
$.ajax({ 
url: "@Url.Action("AjaxTest")", 
data: mvcParamMatch(sendData),//在此转换json格式，用于mvc参数提交 
dataType: "json", 
type: "post", 
success:function(result) { 
alert(result.Message); 
} 
}); 
*/
var mvcParamMatch = (function () {
    var MvcParameterAdaptive = {};
    //验证是否为数组  
    MvcParameterAdaptive.isArray = Function.isArray || function (o) {
        return typeof o === "object" &&
                Object.prototype.toString.call(o) === "[object Array]";
    };

    //验证是否为字典  
    MvcParameterAdaptive.isDictionary = Function.isDictionary || function (o, prop, propNames) {
        if (prop == "" || propNames == "") { return false; }
        var propStr = "," + prop + ",";
        var propNamesList = "," + propNames + ",";
        return typeof o === "object" && propNamesList.indexOf(propStr) > -1;
    };

    //将数组转换为对象  
    MvcParameterAdaptive.convertArrayToObject = function (/*数组名*/arrName, /*字典名称集合*/dicNames, /*待转换的数组*/array, /*转换后存放的对象，不用输入*/saveOjb) {
        var obj = saveOjb || {};

        function func(name, diclist, arr) {
            for (var i in arr) {
                if (!MvcParameterAdaptive.isArray(arr[i]) && typeof arr[i] === "object") {
                    for (var j in arr[i]) {
                        if (MvcParameterAdaptive.isArray(arr[i][j])) {
                            func(name + "[" + i + "]." + j, diclist, arr[i][j]);
                        }
                        else if (MvcParameterAdaptive.isDictionary(arr[i][j], j, diclist)) {
                            MvcParameterAdaptive.convertDictionaryToObject(name + "[" + i + "]." + j + ".", diclist, arr[i][j], obj);
                        }
                        else if (typeof arr[i][j] === "object") {
                            MvcParameterAdaptive.convertObject(name + "[" + i + "]." + j + ".", diclist, arr[i][j], obj);
                        } else {
                            obj[name + "[" + i + "]." + j] = arr[i][j];
                        }
                    }
                } else {
                    obj[name + "[" + i + "]"] = arr[i];
                }
            }
        }

        func(arrName, dicNames, array);

        return obj;
    };

    //将字典转换为对象  
    MvcParameterAdaptive.convertDictionaryToObject = function (/*字典名*/dicName, /*字典名称集合*/dicNames, /*待转换的字典*/dictionary, /*转换后存放的对象，不用输入*/saveOjb) {
        var obj = saveOjb || {};

        function func(name, diclist, dic) {
            var couter = 0;
            for (var i in dic) {
                obj[name + "[" + couter + "].Key"] = i;
                if (!MvcParameterAdaptive.isArray(dic[i]) && typeof dic[i] === "object") {
                    for (var j in dic[i]) {
                        if (MvcParameterAdaptive.isArray(dic[i][j])) {
                            func(name + "[" + couter + "].Value." + j, diclist, dic[i][j]);
                        }
                        else if (MvcParameterAdaptive.isDictionary(dic[i][j], j, diclist)) {
                            MvcParameterAdaptive.convertDictionaryToObject(name + "[" + couter + "].Value." + j + ".", diclist, tobj[i], obj);
                        }
                        else if (typeof dic[i][j] === "object") {
                            MvcParameterAdaptive.convertObject(name + "[" + couter + "].Value." + j + ".", dic[i][j], obj);
                        } else {
                            obj[name + "[" + couter + "].Value." + j] = dic[i][j];
                        }
                    }
                } else {
                    obj[name + "[" + couter + "].Value"] = dic[i];
                }
                couter++;
            }
        }

        func(dicName, dicNames, dictionary);

        return obj;
    };


    //转换对象  
    MvcParameterAdaptive.convertObject = function (/*对象名*/objName, /*字典名称集合*/dicNames, /*待转换的对象*/turnObj, /*转换后存放的对象，不用输入*/saveOjb) {
        var obj = saveOjb || {};

        function func(name, diclist, tobj) {
            for (var i in tobj) {
                if (MvcParameterAdaptive.isArray(tobj[i])) {
                    MvcParameterAdaptive.convertArrayToObject(i, diclist, tobj[i], obj);
                }
                else if (MvcParameterAdaptive.isDictionary(tobj[i], i, diclist)) {
                    MvcParameterAdaptive.convertDictionaryToObject(i, diclist, tobj[i], obj);
                }
                else if (typeof tobj[i] === "object") {
                    func(name + i + ".", diclist, tobj[i]);
                } else {
                    obj[name + i] = tobj[i];
                }
            }
        }

        func(objName, dicNames, turnObj);
        return obj;
    };

    return function (json, arrName, dicNames) {
        arrName = arrName || "";
        dicNames = dicNames || "";
        if (typeof json !== "object") throw new Error("请传入json对象");
        if (MvcParameterAdaptive.isArray(json) && !arrName) throw new Error("请指定数组名，对应Action中数组参数名称！");
        if (MvcParameterAdaptive.isDictionary(json, arrName, dicNames) && !arrName) throw new Error("请指定字典名，对应Action中字典参数名称！");
        if (MvcParameterAdaptive.isArray(json)) {
            return MvcParameterAdaptive.convertArrayToObject(arrName, dicNames, json);
        }
        if (MvcParameterAdaptive.isDictionary(json, arrName, dicNames)) {
            return MvcParameterAdaptive.convertDictionaryToObject(arrName, dicNames, json);
        }

        return MvcParameterAdaptive.convertObject("", dicNames, json);
    };
})();  