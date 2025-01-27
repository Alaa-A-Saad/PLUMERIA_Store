
var get_id;
function showmassage(id)
{
    get_id = id;
    $('#del').modal('show');
}


function confirm_delete()
{
    window.location.href ="DeletProductsCate?id=" + get_id 
}

function confirm_delete1()
{
    $.ajax({
        url: 'DeletProductsCate',
        type: "get",
        data: { id: get_id },

        success: function (result) {
            const Toast = Swal.mixin({
                toast: true,
                position: "top-end",
                showConfirmButton: false,
                timer: 3000,
                timerProgressBar: true,
                didOpen: (toast) => {
                    toast.onmouseenter = Swal.stopTimer;
                    toast.onmouseleave = Swal.resumeTimer;
                }
            });
            Toast.fire({ 
                icon: "success",
                title: "تم الحذف بنجاح"
            });
            $("#catogconta").html(result)
        }
    });
}

