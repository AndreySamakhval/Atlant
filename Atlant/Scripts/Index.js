$(document).ready(function () {
    
    $.datepicker.setDefaults($.datepicker.regional['ru']);

    $('#DateAdded').datepicker({
        showAnim:"fadeIn",
    });

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
            }
        })
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