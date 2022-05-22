
$(document).ready(function () {

    // Send an AJAX request for Region data
    $.getJSON('api/OtherGets/GetsalesPerson')
        .done(function (data) {
            let salesPersonArray = data;
            let salesPersonSelectElement = document.getElementById("personSelect");
            salesPersonArray.forEach(function (value) {
                salesPersonSelectElement.appendChild(new Option(value.lastName, value.salesPersonId));
            });
        });


    $.getJSON('api/othergets/GetStore')
        .done(function (data) {
            let StoreArray = data;
            let StoreSelectElement = document.getElementById("storeSelect");
            StoreArray.forEach(function (value) {
                StoreSelectElement.appendChild(new Option(value.city, value.storeId));
            });
        });


    $.getJSON('api/OtherGets/GetCd')
        .done(function (data) {
            let CdArray = data;
            let CdArraysalesPersonSelectElement = document.getElementById("cdSelect");
            CdArray.forEach(function (value) {
                CdArraysalesPersonSelectElement.appendChild(new Option(value.cdname, value.cdId));
            });
        });


    $.getJSON('api/othergets/GetStore')
        .done(function (data) {
            let StoreArray = data;
            let StoreSelectElement = document.getElementById("storeSelect2");
            StoreArray.forEach(function (value) {
                StoreSelectElement.appendChild(new Option(value.city, value.storeId));
            });
        });
});

function addData() {

    let selectSalesPerson = document.getElementById('personSelect');
    let salesPersonValue = selectSalesPerson.options[selectSalesPerson.selectedIndex].value;

    let selectstore = document.getElementById('storeSelect');
    let salesStoreValue = selectstore.options[selectstore.selectedIndex].value;

    let selectcd = document.getElementById('cdSelect');
    let salesCdValue = selectcd.options[selectcd.selectedIndex].value;

    let typedpPice = document.getElementById('howmuch').value;


    console.log(salesPersonValue);
    console.log(salesStoreValue);
    console.log(salesCdValue);
    console.log(typedpPice);


    let newData = new Data(salesPersonValue, salesStoreValue, salesCdValue, typedpPice);

    $.ajax({
        url: "api/Orders",
        type: "POST",
        data: JSON.stringify(newData),
        contentType: "application/json; charset=utf-8",

        success: function (result) {
            alert(result + "One Order was added")
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Status: " + textStatus); alert("Error: " + errorThrown);
        }
    });
    
}


function StoreData() {
    let selectstore = document.getElementById('storeSelect2');
    let salesStoreValue = selectstore.options[selectstore.selectedIndex].value;

    console.log(salesStoreValue);

    $.getJSON('api/Orders')
        .done(function (data) {
            let OrderArray = data
            let sum = 0;
            //OrderArray.forEach(element => console.log(element["storeID"]));
            
            OrderArray.forEach((element) => {
                if (element["storeID"] == salesStoreValue) {
                    sum += element["pricePaid"];
                }
            });

            console.log(sum);


            var a = document.getElementById("description");
            a.innerHTML = "That Store Sold $" + sum

        });

}



let Data = function (pPersonID, pStoreID, pCdID, pPricePaid) {
    this.SalesPersonId = pPersonID;
    this.StoreId = pStoreID;
    this.CdId = pCdID;
    this.PricePaid = pPricePaid;
}