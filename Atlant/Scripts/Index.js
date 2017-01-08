$(document).ready(function () {    
    $.datepicker.setDefaults($.datepicker.regional['ru']);
    $('#DateAdded').datepicker({
        showAnim:"fadeIn",
    });
    $('#btnSearch').click(function () {
        details.search();
    })
    Storekeeper.Get();
});

details = {
    getAll: function () {
        $.ajax({
            type: 'GET',
            url: '/api/Detail',           
            asynch: false,
            success: function (output, status, xhr) {
                details.rennderDetails(output);               
            },
            error: function () {
                alert('Error getting details');
            }
        });
    },
    rennderDetails: function (output) {
        $('.trTable').remove();
        $('#addDetailsTmpl').tmpl(output).appendTo('#tableDetails');
        $('.tdSc').each(function () {
            if ($(this).attr('sc') == 'true') {
                $(this).append('<i class="fa fa-check"></i>');
            };
        });
        $('.linkDelete').click(function () {
            details.deleteDet($(this).attr('id'))
        })
    },
    deleteDet: function (id) {
        $.ajax({
            type: 'Delete',
            url: '/api/detail/'+id,
            asynch: false,
            success: function (output, status, xhr) {
                details.getAll();
            },
            error: function () {
                alert('Error deleting details');
            }
        });
    },
    search: function () {
        var code = $('#inputSearch').val();
        if (code == '') {
            $('#errorSearch').text('Введите номенклатурный код');
            return false;
        } else {
            $('#errorSearch').text('');
            $('#inputSearch').val('');
            $.ajax({
                type: 'Post',
                url: '/home/search',
                asynch: false,
                data:({codeSearch:code}),
                success: function (output, status, xhr) {                    
                    details.rennderDetails(output);
                    $('#btnclearResult').show();
                    $('#btnclearResult').click(function () {
                        $('#btnclearResult').hide();
                        details.getAll();
                    })
                },
                error: function () {
                    $('#errorSearch').text('');
                    $('#errorSearch').text('Деталь не найдена');
                }
            });
        }
    }
}
Storekeeper = {
    Get: function () {
        $.ajax({
            type: 'GET',
            url: '/api/storekeeper',
            asynch: false,
            success: function (output, status, xhr) {
                Storekeeper.rennder(output);
                details.getAll();
            },
            error: function () {
                details.getAll();
                alert('Error getting details');
            }
        });
    },
    rennder: function (output) {
        $('#addStorekeeperTmpl').tmpl(output).appendTo('#selectStorekeeper');
    }
}