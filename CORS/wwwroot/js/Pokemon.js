$(document).ready(function () {
    $('#tablePoke').DataTable({
        ajax: {
            url: 'https://pokeapi.co/api/v2/pokemon/',
            dataSrc: 'results'
        },
        columns: [
            {
                "data": null, "sortable": true,
                "render": function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "render": function(data, type, row) {
                    return row['name'];
                }
            },
            {
                "render": function(data, type, row) {
                    return row['url'];
                }
            },
            {
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-primary" onclick="detail('${row['url'] }')" data-toggle="modal" data-target="#modalPoke">Detail</button >`
                }
            }
        ]

    });
});

function detail(stringurl) {
    $.ajax({
        url:stringurl
    }).done((result) => {
        //console.log(result.results);
        text2 = `<h3 class="text-center">${result.name}</h3>
                  <img src="${result.sprites.front_default}" class="border rounded-circle rounded mx-auto d-block" width="250px" height="250px"></img>
                  <p>PokeID : ${result.id}</p>
                  <p>Base Experience : ${result.base_experience}</p>
                  <p>Height : ${result.height} ft</p>
                  <p>Weight : ${result.weight} kg</p>
                    `;                
    $('#bodyModal').html(text2);
    }).fail((error) => {
        console.log(error);
    });
}