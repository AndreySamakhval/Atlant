$(document).ready(function () {
    details.getAll();
    $('#DateAdded').datepicker();

});

details = {
    getAll: function () {

        $.ajax({
            type: 'GET',
            url: '/api/Detail',           
            //asynch: true,
            success: function (output, status, xhr) {
                details.rennderDetails(output);
               
            },
            error: function () {
                alert('Error getting details');
            }
        });
    },
    rennderDetails: function (output) {
        $('#addDetailsTmpl').tmpl(output).appendTo('#tableDetails');
    }
}