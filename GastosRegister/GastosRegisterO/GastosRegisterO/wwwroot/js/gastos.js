

var dataTable;

$(document).ready(function () {

    cargarDataTable();
});

function cargarDataTable() {

    dataTable = $("#gastostable").DataTable({

        "ajax": {
            "url": "/home/GetAll",
            "type": "GET",
            "datatype":"json"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "asunto", "width": "30%" },
            { "data": "fechaHora", "width": "10%" },
            { "data": "imagen", "width": "20%" },
            { "data": "costo", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
<a href="/home/edit/${data}"class="btn btn-primary text-white" style="cursor:pointer; width:100px;">
<i class="far fa-edit"></i>
Edit
</a>
&nbsp;
<a onclick=Delete("/home/Delete/${data}") class="btn btn-Danger text-white" style="cursor:pointer; width:120px;">
<i class="far fa-trash-alt"></i>
Delete
</a>
</div>`;
                },"width":"60%"




            }

            

        ]



    });
} function Delete(url) {
    swal({
        title: "Esta seguro de borrar?",
        text: "Este contenido no se puede recuperar!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, borrar!",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }

        })
    })


}