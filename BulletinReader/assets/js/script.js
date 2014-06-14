$(function () {
    $('.input-group.date').datepicker({
        format: 'dd.mm.yyyy',
        startDate: '-1d',
        startView: 'year',
        todayBtn: true,
        todayHighlight: true,
        weekStart: 1
    });
});
