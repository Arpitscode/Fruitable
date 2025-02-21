$(document).ready(function () {
    var i = 0;
    var arrpn = [], arrppic = [], arrpdisc = [], arrpp = [], arrpd = [];
    $(".ad").click(function () {
        var t = $(this).text().trim();
        var num = $(this).attr("id");
        var x = num.substring(num.lastIndexOf('n') + 1);
        // alert(x);
        var pname, price, pdis, pic;
        pname = $("#pn" + x).text();
        price = $("#pp" + x).text();
        pd = $("#pd" + x).text()
        pdis = $("#pds" + x).text();
        pic = $("#pimg" + x).attr("src");
        // alert(pname+" "+price+" "+pdis+" "+pic);
        if (t == "Add Product") {
            swal("Product Added into Cart", "Product Added SuccessFully", "success");
            i++;
            $(this).text("Remove Product");
            $(this).addClass("btn-danger");

            arrpn.push(pname);
            arrppic.push(pic);
            arrpdisc.push(pdis);
            arrpp.push(price);
            arrpd.push(pd);
        }
        else {
            swal("Product Remove From Cart", "Product Remove SuccessFully", "warning");
            i--;
            $(this).text("Add Product");
            $(this).removeClass("btn-danger");
            $(this).addClass("btn-primary");
            // remove element from an array
            arrpn = $.grep(arrpn, function (value) {
                return value !== pname;
            })
            arrpp = $.grep(arrpp, function (value) {
                return value !== price;
            })
            arrppic = $.grep(arrppic, function (value) {
                return value !== pic;
            })
            arrpdisc = $.grep(arrpdisc, function (value) {
                return value !== pdis;
            })
            arrpd = $.grep(arrpd, function (value) {
                return value !== pd;
            })
        }
        // alert(arrpn)
        // alert(i)
        $("#cart").text(i);
    })
    //cart check value
    $("#cart").click(function () {
        var n = parseInt($(this).text());
        if (n > 0) {
            // swal("Product Added into Cart","Product Added SuccessFully","success");
            window.location.href = "welcome.html?apn=" + arrpn + "&app=" + arrpp + "&apic=" + arrppic + "&apdsc=" + arrpdisc + "&apd=" + arrpd;
        }
        else {
            swal("Cart is Empty", "Please add Any Product", "Error");
        }
    })
})