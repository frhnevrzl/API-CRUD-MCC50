$(document).ready(function () {
    $('#tablePerson').DataTable({
        ajax: {
            url: 'https://localhost:44303/home/getsemuadata/',
            dataSrc: ''
        },
        columns: [
            {
                "data": null, "sortable": true,
                "render": function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": 'nik'
            },
            {
                "render": function (data, type, row) {
                    return row['firstName'];
                }
            },
            {
                "render": function (data, type, row) {
                    return row['lastName'];
                }
            },
            {
                "data": 'phone'
            },
            {
                "data": 'degree'
            },
            {
                "data": 'gpa'
            },
            {
                "data": 'universityId'
            },
            {
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-danger" onclick="deleted('${row['nik']}')">Delete</button > `
                }
            },
            {
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-info" onclick="get('${row['nik']}')" data-toggle="modal" data-target="#modalUpdate">Update</button > `
                }
            }
        ]
    });
});

function Insert() {

    bootstrapValidate('#inputFirstName', 'required');
    bootstrapValidate('#inputLastName', 'required');
    bootstrapValidate('#inputPhone', 'required');
    bootstrapValidate('#inputBirthdate', 'required');
    bootstrapValidate('#inputSalary', 'required');
    bootstrapValidate('#inputEmail', 'required');
    bootstrapValidate('#inputPassword', 'required');
    bootstrapValidate('#inputDegree', 'required');
    bootstrapValidate('#inputGpa', 'required');
    bootstrapValidate('#inputUniversityId', 'required');

    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    obj.FirstName = $("#inputFirstName").val();
    obj.LastName = $("#inputLastName").val();
    obj.Phone = parseInt($("#inputPhone").val());
    obj.BirthDate = $("#inputBirthdate").val();
    obj.Salary = parseInt($("#inputSalary").val());
    obj.Email = $("#inputEmail").val();
    obj.Password = $("#inputPassword").val();
    obj.Degree = $("#inputDegree").val();
    obj.GPA = parseInt($("#inputGpa").val());
    obj.UniversityId = parseInt($("#inputUniversityId").val());

    $.ajax({
        url: 'https://localhost:44323/API/person/getprofile/',
        type: "GET",
        headers: {
            'Accept': 'application/json',
            'Content-Type' : 'application/json'
        },
        contentType: 'application/json',
        success: function (e) {
            if (e.some(e => e.email == obj.Email)) {
                Swal.fire({
                    title: 'Error!',
                    text: 'Email Duplicated',
                    icon: 'error',
                    confirmButtonText: 'Back'
                })
                return false;
            }
            else {
                return true;
            }
        }
    })
    
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        url: 'https://localhost:44323/API/person/register',
        type: "POST",
            headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(obj)
    }).done((result) => {
            $('#tablePerson').DataTable().ajax.reload();
        Swal.fire({
            title: 'Success!',
            text: 'You Have Been Registered',
            icon: 'success',
            confirmButtonText: 'Next'
        })
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Failed To Register',
            text: 'Email Duplicated',
            icon: 'error',
            confirmButtonText: 'Back'
        })
            //alert("Gagal");
            console.log(error);
        })
}

function deleted(stringnik) {
    $.ajax({
        url: 'https://localhost:44323/API/person/deleteprofile/' + stringnik,
        type : "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
    }).done((result) => {
        $('#tablePerson').DataTable().ajax.reload();
        Swal.fire({
            title: 'Success!',
            text: 'Data Has Been Deleted',
            icon: 'success',
            confirmButtonText: 'Next'
        })
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Data Cannot Deleted',
            icon: 'Error',
            confirmButtonText: 'Next'
        })
    });
}

function get(stringnik) {
    $.ajax({
        url: 'https://localhost:44303/home/getbyid/' + stringnik,
        dataSrc: ''
    }).done((result) => {
        $('#Nik').val(result.nik);
        $('#FirstName').val(result.firstName);
        $('#LastName').val(result.lastName);
        $('#Phone').val(result.phone);
        var today = new Date(result.birthDate);
        console.log(result.birthDate);
        var dd = String(today.getDate()).padStart(2, '0');
        var mm = String(today.getMonth()).padStart(2, '0');
        var yyyy = today.getFullYear();
        today = yyyy + '-' + mm + '-' + dd;
        console.log(today);
        $('#Birthdate').val(today);
        $('#Salary').val(result.salary);
        $('#Email').val(result.email);
        $('#Password').val(result.password);
        $('#Degree').val(result.degree);
        $('#Gpa').val(result.gpa);
        $('#UniversityId').val(result.universityId);
    }).fail((error) => {
        console.log(error);
    });
}

function Update() {
    var obj = new Object();
    obj.NIK = $('#Nik').val();
    obj.FirstName = $("#FirstName").val();
    obj.LastName = $("#LastName").val();
    obj.Phone = parseInt($("#Phone").val());
    obj.BirthDate = $("#Birthdate").val();
    obj.Salary = ($("#Salary").val());
    obj.Email = $("#Email").val();
    obj.Password = $("#Password").val();
    obj.Degree = $("#Degree").val();
    obj.GPA = parseInt($("#Gpa").val());
    obj.UniversityId = parseInt($("#UniversityId").val());

    $.ajax({
        url: 'https://localhost:44323/API/person/updateprofile/',
        type: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(obj)
    }).done((result) => {
        $('#tablePerson').DataTable().ajax.reload();
        Swal.fire({
            title: 'Success!',
            text: 'Your Data Has Been Updated',
            icon: 'success',
            confirmButtonText: 'Next'
        })
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Failed To Update',
            icon: 'error',
            confirmButtonText: 'Back'
        })
        //alert("Gagal");
        console.log(error);
    })
}