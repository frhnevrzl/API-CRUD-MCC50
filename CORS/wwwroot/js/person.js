$(document).ready(function () {
    $('#tablePerson').DataTable({
        ajax: {
            url: 'https://localhost:44323/API/person/getprofile/',
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
                "data": 'birthDate'
            },
            {
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-primary" onclick="detail('${row['nik'] }')" data-toggle="modal" data-target="#modalPerson">Detail</button > `
                }
            },
            {
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-danger" onclick="deleted('${row['nik']}')" data-toggle="modal" data-target="#modalPerson">Delete</button >`
                }
            }
        ]
    });
});

function detail(stringnik) {
    $.ajax({
        url: 'https://localhost:44323/API/person/getprofilebyid/' + stringnik,
        dataSrc: ''
        //async : false
    }).done((result) => {
        //console.log(result);
        text2 = `<h3 class="text-center">Hi, ${result.firstName}</h3>
                  <p>NIK : ${result.nik}</p>
                  <p>Salary : Rp. ${result.salary}</p>
                  <p>Phone : ${result.phone}</p>
                  <p>email : ${result.email}</p>
                  <p>University ID : ${result.universityId}</p>
                    `;
        $('#bodyMPerson').html(text2);
    }).fail((error) => {
        console.log(error);
    });
}

function Insert() {
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
            alert("Sukses");
            console.log(result);
        }).fail((error) => {
            alert("Gagal");
            console.log(error);
        })
    var x = document.forms["formPersonReg"]["inputFirstName"].value;
    if (x == "") {
        alert("You Must Filled Out All Required Items");
        return false;
    }

    //if (obj.FirstName == '' || obj.LastName == '' || obj.Phone == '' || obj.BirthDate == '' || obj.Salary == '' ||obj.Email == '' || obj.Password == '' || obj.Degree == '' || obj.GPA =='' || obj.UniversityId =='') {
    //    alert("You Must Filled Out All Required Items");
    //}


}

function Validasi() {

}

function deleted(stringnik) {
    $.ajax({
        url: 'https://localhost:44323/API/person/getprofilebyid/' + stringnik,
        dataSrc: ''
        //async : false
    }).done((result) => {
        console.log(result);
        text2 = `<h3 class="text-center">Data Berhasil Dihapus</h3>`;
        $('#bodyMPerson').html(text2);
    }).fail((error) => {
        console.log(error);
    });
}

