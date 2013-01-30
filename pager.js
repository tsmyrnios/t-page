$(function () {
    $(".beginning-button").click(function () { $.page($(this), function (pi, pgi, ps, pgs, pc, pgc, rc) { return 0; }); });
    $(".previous-group-button").click(function () { $.page($(this), function (pi, pgi, ps, pgs, pc, pgc, rc) { return Math.max(0, pgs - 1) * pgs; }); });
    $(".previous-button").click(function () { $.page($(this), function (pi, pgi, ps, pgs, pc, pgc, rc) { return Math.max(0, pi - 1); }); });
    $(".page-button").click(function () {
        var index = parseInt($(this).attr("data-page-index"));
        $.page($(this), function (pi, pgi, ps, pgs, pc, pgc, rc) { return index; });
    });
    $(".next-button").click(function () { $.page($(this), function (pi, pgi, ps, pgs, pc, pgc, rc) { return pi + 1; }); });
    $(".next-group-button").click(function () { $.page($(this), function (pi, pgi, ps, pgs, pc, pgc, rc) { return Math.min(Math.max(0, pgc - 1), pgi + 1) * pgs; }); });
    $(".end-button").click(function () { $.page($(this), function (pi, pgi, ps, pgs, pc, pgc, rc) { return pc - 1; }); });

    $.page = function (button, pageIndexFunction) {
        var submit = button.siblings(".pager-submit-button");
        var index = button.siblings(".page-index");
        var pi = parseInt(index.val());
        var ps = parseInt(button.siblings(".page-size").val());
        var pgs = parseInt(button.siblings(".page-group-size").val());
        var rc = parseInt(button.siblings(".total-row-count").val());

        var pc = (rc == 0 || ps == 0) ? 0 : Math.ceil(rc / ps);
        var pgc = (pc == 0 || pgs == 0) ? 0 : Math.ceil(pc / pgs);
        var pgi = (pi == 0 || pgs == 0) ? 0 : Math.floor(pi / pgs);

        index.val(String(pageIndexFunction(pi, pgi, ps, pgs, pc, pgc, rc)));
        submit.trigger("click");
    };
});