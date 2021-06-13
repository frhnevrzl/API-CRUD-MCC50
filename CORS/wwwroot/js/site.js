//////var judul = document.getElementById('title');
//////judul.style.color = 'salmon';
//////judul.style.backgroundColor = 'lawngreen';

/*const { error } = require("jquery");*/

////tag p merupakan array jd harus di define index saat pemanggilan
////var p = document.getElementsByTagName('p');
////for (var i = 0; i < p.length; i++) {
////    p[i].style.color = 'aquamarine';
////    p[i].style.backgroundColor = 'blue';
////}

//// class link jg merupakan array (HTML Collection)
////var p1 = document.getElementsByClassName('link');
////p1[0].style.color = 'red';

////query selector mengikuti pemanggilan identifier css selector
////jika terdapat duplikasi id maka menggunakan contoh : section#b #a
////var p2 = document.querySelector('.paragraf4');
////p2.style.color = 'grey';
////p2.style.backgroundColor = 'white';

////var item1 = document.getElementById('item1');
////item1.onclick = function () {
////    //item1.innerHTML = "ini dari javascript";
////    item1.style.color = 'blue';
////}
////item1.addEventListener('mouseover', function () {
////    item1.innerHTML = "Mouse Ada";
////    item1.style.backgroundColor = 'lightblue';
////});
////item1.addEventListener('mouseleave', function () {
////    item1.innerHTML = "Mouse Pergi";
////    item1.style.backgroundColor = 'white';
////});

////var p2 = document.getElementById('p2');
////var p1 = document.getElementById('p1');

////var tombol = document.getElementById('tombol');
////tombol.addEventListener('click', function () {
////    p2.innerHTML = 'Ganti Dari JS';
////    p2.style.backgroundColor = 'lawngreen';
////    p1.style.color = 'aquamarine';
////    console.log(tombol);
////});

////$(document).ready(function () {
////    $('#tombol').click(function () {
////        $('#p1').css('background-color','salmon');
////    });
////});

////const animals = [
////    { name: "Jerry", species: "Cat", class: { name: "Mammalia" } },
////    { name: "Bambang", species: "Hamster", class: { name: "Mammalia" } },
////    { name: "Julien", species: "Spider", class: { name: "Chordrata" } },
////    { name: "Susan", species: "Dog", class: { name: "Mammalia" } },
////    { name: "Gary", species: "Snail", class: { name: "Invertebrata" } },
////    { name: "Ronald", species: "Dog", class: { name: "Mammalia" } },
////    { name: "Merry", species: "Cat", class: { name: "Mammalia" } },
////    { name: "Shifu", species: "Dog", class: { name: "Mammalia" } },
////];

////const onlyCat = [];
////for (var i = 0; i < animals.length; i++) {
////    if (animals[i].species == 'Cat') {
////        onlyCat.push(animals[i]);
////    }
////}

////const onlyDog = animals.filter(animal => animal.species == 'Dog');

////let nonmamalia = [];

////for (var i = 0; i < animals.length; i++) {
////    if (animals[i].class.name != 'Mammalia') {
////        animals[i].class.name = 'Non-Mammalia';
////        nonmamalia.push(animals[i]);
////    }
////}

////for (var i = 0; i < nonmamalia.length; i++) {
////    if (nonmamalia[i].class.name != 'Mammalia') {
////        nonmamalia[i].class.name = 'Non-Mamalia';
////    }
////}

////console.log(nonmamalia[1].class.name);
////console.log(animals);

////console.log(onlyCat);
////console.log(onlyDog);
////console.log(animals);
/*console.log(animals[0].class);*/

$.ajax({
    url: 'https://swapi.dev/api/people/'
}).done((result) => {
    text = "";
    //console.log(result.results);
    $.each(result.results, function (key, val) {
        text += `<tr>
                <td>${val.name}</td>
                <td>${val.height} cm</td>
                <td>${val.gender}</td>
                <td><button type="button" class="btn btn-primary" onclick="detail('${val.url}')" data-toggle="modal" data-target="#modalSW">
                    Details
                    </button></td>
                </tr>`;
    });
    $('#tableSW').html(text);
}).fail((error) => {
    console.log(error);
});

function detail(stringurl) {
    let split = stringurl.split('/');
    $.ajax({
        url: 'https://swapi.dev/api/people/' + split[5] + '/'
    }).done((result) => {
        text2 = "";
        //console.log(result.results);
        text2 += `
                        <tr>
                        <td>Name : ${result.name}, </td> 
                        <tr>
                        <tr>
                        <td>Hair Color : ${result.hair_color}, </td> 
                        <tr>
                        <td>Mass : ${result.mass} kg, </td>
                        </tr>
                        <tr>
                        <td>Skin Color : ${result.skin_color}, </td>
                        </tr>`
        $('#modalStar').html(text2);
    }).fail((error) => {
        console.log(error);
    });
}