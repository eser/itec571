$l.ready(function () {
    $('.input-group.date').datepicker({
        format: 'dd.mm.yyyy',
        startDate: '-1d',
        startView: 'year',
        todayBtn: true,
        todayHighlight: true,
        weekStart: 1
    });

    var formLogin = $l('#formLogin');
    $l.dom.setEvent(
        formLogin,
        'submit',
        function () {
            var fieldEmail = $l('#loginEmail', formLogin);
            var fieldPassword = $l('#loginPassword', formLogin);

            $l.ajax.postJson(
                $l.baseLocation + 'api/login',
                {
                    email: fieldEmail.value,
                    password: fieldPassword.value
                },
                function (x) {
                    if (x.success) {
                        location.href = './';
                        return;
                    }

                    $l.ui.msgbox(5, x.reason);
                }
            );

            return false;
        }
    );
});
