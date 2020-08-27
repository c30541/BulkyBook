﻿var dataTable;

$(document).ready( function(){
    loadDataTable();
})

function loadDataTable() {
    dataTable = $("#tblData").dataTable({
        "ajax": { "url": "/Admin/CoverType/GetAll"},
        "columns": [
            {
                "data": "name", "width": "80%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center d-flex justify-content-around">
                            <a href="/Admin/CoverType/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                <i class="fas fa-edit"></i>
                            </a>
                            <a onclick=Delete("/Admin/CoverType/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                <i class="fas fa-trash-alt"></i>
                            </a>
                            </div>
                            `;
                },
                "width": "20%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore the data!",
        type: "warning",
        button: true,
        showCancelButton: true,
        cancelButtonColor: '#d33',
        dangerMode: true,
    }).then((whileDelete) => {
        if (whileDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message)
                        $("#tblData").DataTable().ajax.reload();
                    }
                    else
                        toastr.error(data.message)
                }
            })
        }
    })
}