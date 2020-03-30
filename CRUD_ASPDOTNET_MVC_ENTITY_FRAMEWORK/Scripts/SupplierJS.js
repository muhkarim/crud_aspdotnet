/*
$(document).ready(function () {
    $('#example').datatable({
        "ajax": loaddatasupplier(),
      "responsive": true
    });
  
    $('[data-toogle="tooltip"]').tooltip();
});

function loaddatasupplier() {
    $.ajax({
        url: "suppliers/loaddatasupplier()",
        type: "get",
        contenttype: "application/json;charset=utf-8",
        datatype: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, supplier) {
                html += '<tr>';
                html += '<td>' + supplier.name + '<td>';
                html += '<td><button type="button" class="btn btn-warning" id="update" onclick="return getbyid(' + supplier.id + ')"> edit </button>';
                html += '<button type="button" class="btn btn-danger" id="delete" onclick="return delete(' + supplier.id + ')"> delete </button> </td>';
                html += '</tr>';
                html += '</tr>';
                html += '</tr>';
            });
            $('.supplierbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responsetext);
        }
    });
}
*/