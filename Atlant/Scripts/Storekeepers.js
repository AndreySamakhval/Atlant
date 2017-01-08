$(document).ready(function () {
    $('#btnAddStorekeeper').click(function () {
        $('#modDialog').modal('show');
    });
    storekeeper.get();
});

storekeeper = {
    get: function () {
        $('#modDialog').modal('hide');
        $.ajax({
            type: 'Get',
            url: '/api/storekeeper',
            asynch: false,
            success: function (output, status, xhr) {
                storekeeper.rennder(output);
            },
            error: function () {
                alert('Error deleting details');
            }
        });
    },
    rennder: function (output) {        
        $('.trTable').remove();
        $('#addStorekeeperTmpl').tmpl(output).appendTo('#tableStore');
        $('.linkDelete').click(function () {
            storekeeper.deleteStore($(this).attr('id'))
        })
    },
    deleteStore: function (id) {
        $.ajax({
            type: 'Delete',
            url: '/api/storekeeper/' + id,           
            success: function (output, status, xhr) {
                storekeeper.get();
            },
            error: function () {
                alert('Error deleting storekeeper');
            }
        });
    }
}