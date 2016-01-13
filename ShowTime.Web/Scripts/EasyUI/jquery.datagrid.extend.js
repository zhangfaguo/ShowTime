/**
* 扩展view，当点击linkbutton时阻止默认点击行为
*/
var dlsecview = $.extend({}, $.fn.datagrid.defaults.view, {
    bindEvents: function (target) {
        var state = $.data(target, 'datagrid');
        var dc = state.dc;
        var opts = state.options;
        var body = dc.body1.add(dc.body2);
        var clickHandler = ($.data(body[0], 'events') || $._data(body[0], 'events')).click[0].handler;
        body.unbind('click').bind('click', function (e) {
            var tt = $(e.target);
            var tr = tt.closest('tr.datagrid-row');
            if (!tr.length) { return; }
            if (tt.hasClass('l-btn-text') || tt.hasClass('l-btn-icon')) {

            } else {
                clickHandler(e);
            }
            e.stopPropagation();
        });
    },
    onBeforeRender: function (target) {
        var that = this;
        setTimeout(function () {
            that.bindEvents(target);
        }, 0);
    }
});
/**
* 扩展view，可以取消单选
*/
var singleview = $.extend({}, $.fn.datagrid.defaults.view, {
    bindEvents: function (target) {
        var state = $.data(target, 'datagrid');
        var dc = state.dc;
        var opts = state.options;
        var body = dc.body1.add(dc.body2);
        var clickHandler = ($.data(body[0], 'events') || $._data(body[0], 'events')).click[0].handler;
        body.unbind('click').bind('click', function (e) {
            var tt = $(e.target);
            var tr = tt.closest('tr.datagrid-row');
            if (!tr.length) { return; }
            if (tr.hasClass('datagrid-row-selected')) {
                $(target).datagrid('clearSelections');
            } else {
                clickHandler(e);
            }
            e.stopPropagation();
        });
    },
    onBeforeRender: function (target) {
        var that = this;
        setTimeout(function () {
            that.bindEvents(target);
        }, 0);
    }
});

/**
* 扩展view，阻止所有点击行为
*/
var dsecview = $.extend({}, $.fn.datagrid.defaults.view, {
    bindEvents: function (target) {
        var state = $.data(target, 'datagrid');
        var dc = state.dc;
        var body = dc.body1.add(dc.body2);
        body.unbind('click');
    },
    onBeforeRender: function (target) {
        var that = this;
        setTimeout(function () {
            that.bindEvents(target);
        }, 0);
    }
});