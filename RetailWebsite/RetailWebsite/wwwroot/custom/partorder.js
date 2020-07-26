//partList

var updateQuantity = function (e, partId) {
    var value = e.value;
    var index;
    for (index = 0; index < partList.length; ++index) {
        if (partList[index].partId == partId) {
            partList[index].quantity = parseInt(value);
            index = partList.length;
        }
    }
};

var confirmOrder = function () {
    var data = { Parts: partList, OrderId: orderRef, Email: email, productId: productId };

    $.ajax({
        url: '/PartsApi/ConfirmPartsOrder',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(data),
        success: function () {
            window.location.href = "/";
        },
        error: function () {
            alert('Error placing parts order');
        }
    });
}