﻿$l.ready(function () {
    $('.input-group.date').datepicker({
        format: 'dd.mm.yyyy',
        startDate: '-1d',
        startView: 'year',
        todayBtn: true,
        todayHighlight: true,
        weekStart: 1
    });

    var formLogin = $l('#form-login');
    if (formLogin !== null) {
        $l.dom.setEvent(
            formLogin,
            'submit',
            function () {
                var fieldEmail = $l('#login-email', formLogin);
                var fieldPassword = $l('#login-password', formLogin);

                $l.ajax.postJson(
                    $l.baseLocation + 'api/gate/login',
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
    }

    var searchForm = $l('#search-form');
    if (searchForm !== null) {
        $l.dom.setEvent(
            searchForm,
            'submit',
            function () {
                var searchBox = $l('input[name=\'q\']', searchForm);

                if (searchBox !== null && searchBox.value.trim().length === 0) {
                    searchBox.focus();
                    return false;
                }
            }
        );
    }

    var logout = $l('#logout');
    if (logout !== null) {
        $l.dom.setEvent(
            logout,
            'click',
            function () {
                $l.ajax.postJson(
                    $l.baseLocation + 'api/gate/logout',
                    {},
                    function (x) {
                        location.href = './';
                    }
                );

                return false;
            }
        );
    }
});
