var app = new Vue({
    el: '#app',
    data: {
        searchCategories: "Products",
        searchString: "",
        productOrderSubmitBtn: null,
        cartItemCount: 0,
        btnDisableSubmit: []
    },
    methods: {
        updateSearchCategories: function (event) {
            this.searchCategories = event.target.value;
        },
        triggerSearchQuery: function (el) {
            if (el.value.length < 2 || this.searchCategories == "") {
                return;
            }

            $.ajax(
                {
                    type: "POST", //HTTP POST Method
                    url: "/Home/GetQuery", // Controller/View
                    data: {
                        searchString: el.value,
                        searchCategories: app.searchCategories,
                    }
                }).done(function (data) {

                    var a, b, i, val = el.value;
                    /*close any already open lists of autocompleted values*/
                    app.closeAllLists();

                    a = document.createElement("DIV");
                    a.setAttribute("id", this.id + "autocomplete-list");
                    a.setAttribute("class", "autocomplete-items");

                    el.parentNode.appendChild(a);

                    for (i = 0; i < data.length; i++) {
                        b = document.createElement("DIV");
                        b.innerHTML = data[i]
                        b.innerHTML += "<input type='hidden' value='" + data[i] + "'>";
                        b.addEventListener("click", function (e) {
                            /*insert the value for the autocomplete text field:*/
                            el.value = this.getElementsByTagName("input")[0].value;
                            //app.searchString = el.value;
                            /*close the list of autocompleted values,
                            (or any other open lists of autocompleted values:*/
                            app.closeAllLists();
                        });
                        a.appendChild(b);
                    }
                });
        },
        closeAllLists: function (elmnt) {
            /*close all autocomplete lists in the document,
            except the one passed as an argument:*/
            var x = document.getElementsByClassName("autocomplete-items");
            for (var i = 0; i < x.length; i++) {
                if (elmnt != x[i]) {
                    x[i].parentNode.removeChild(x[i]);
                }
            }
        },
        submitSearchQuery: function () {
            $('#insertForm').html('<form action="/Home/StartQuery" name="searchQuery" style="display:none;"><input type="text" name="searchString" value="' + this.searchString + '" /><input type="text" name="searchCategories" value="' + this.searchCategories + '" /></form>');

            document.forms['searchQuery'].submit();
        },
        cardOrderAdded: function (data) {
            //console.log(data.responseJSON)

            var ribbonEl = this.productOrderSubmitBtn.parentElement.parentElement.lastChild.previousElementSibling
            if (!data.responseJSON.isSuccess) {
                ribbonEl.classList.remove("bg-success")
                ribbonEl.classList.add("bg-danger")
                ribbonEl.innerHTML = data.responseJSON.message[0]
                this.productOrderSubmitBtn.disabled = false;
                this.productOrderSubmitBtn.innerHTML = "Add To Cart";
            } else {
                this.getCurrentCartCount()
                setTimeout(this.reenableSubmit, 2000)
                ribbonEl.classList.remove("bg-danger")
                ribbonEl.classList.add("bg-success")
                ribbonEl.innerHTML = data.responseJSON.message[0]
                this.loadCart();
                setTimeout(() => { ribbonEl.innerHTML = "", ribbonEl.classList.remove("bg-success") }, 2000)
            }
        },
        detailsOrderAdded: function (data) {
            var ribbonEl = this.productOrderSubmitBtn.parentElement.parentElement.lastChild.previousElementSibling

            ribbonEl.classList.add("alert")
            if (!data.responseJSON.isSuccess) {
                ribbonEl.classList.remove("alert-success")
                ribbonEl.classList.add("alert-danger")
                ribbonEl.innerHTML = data.responseJSON.message[0]
                this.productOrderSubmitBtn.disabled = false;
                this.productOrderSubmitBtn.innerHTML = "Add To Cart";
            } else {
                this.getCurrentCartCount()
                setTimeout(this.reenableSubmit, 2000)
                ribbonEl.classList.remove("alert-danger")
                ribbonEl.classList.add("alert-success")
                ribbonEl.innerHTML = data.responseJSON.message[0]
                this.loadCart();
                setTimeout(() => { ribbonEl.innerHTML = ""; ribbonEl.classList.remove("alert") }, 2000)
            }
        },
        orderFormSubmitBtn: function (el) {
            this.productOrderSubmitBtn = el;
            console.log(el)
        },
        getCurrentCartCount: function () {
            $.ajax(
                {
                    type: "POST", //HTTP POST Method
                    url: "/Order/GetCurrentCartCount", // Controller/View
                    data: {
                    }
                }).done(function (data) {
                    app.cartItemCount = data
                });
        },
        disableSubmit: function () {
            this.productOrderSubmitBtn.disabled = true;
            this.productOrderSubmitBtn.innerHTML = "Added";
            this.btnDisableSubmit.push(this.productOrderSubmitBtn)
        },
        reenableSubmit: function () {
            //this.productOrderSubmitBtn.disabled = false;
            //this.productOrderSubmitBtn.innerHTML = "Add To Cart";
            for (i = 0; i < this.btnDisableSubmit.length; i++) {
                this.btnDisableSubmit[i].disabled = false;
                this.btnDisableSubmit[i].innerHTML = "Add to Cart";
            }
        },
        loadCart: function () {
            $.ajax(
                {
                    type: "POST", //HTTP POST Method
                    url: "/Order/LoadCart", // Controller/View
                    data: {
                    }
                }).done(function (data) {
                    $("#cartModalContent").html(data)
                });
        },
        removeItem: function (orderDetailsID) {
            $.ajax(
                {
                    type: "POST", //HTTP POST Method
                    url: "/Order/RemoveItem", // Controller/View
                    data: {
                        orderDetailsID: orderDetailsID
                    }
                }).done(function (data) {
                    console.log(data)
                    if (data.isSuccess) {
                        document.getElementById("cartItem" + orderDetailsID).remove();
                        var newPrice = data.message[0].split('.')
                        document.getElementById("cartTotalPriceN").innerHTML = newPrice[0]
                        document.getElementById("cartTotalPriceD").innerHTML = newPrice[1]
                        app.cartItemCount--;

                        if (app.cartItemCount == 0) {
                            var cartCheckoutBtn = document.getElementById("cartCheckoutBtn")
                            cartCheckoutBtn.classList.add("disabled")
                        }

                        var orderSummaryEl = document.getElementById("orderSummary")
                        if (orderSummaryEl) {
                            app.updateOrderSummary();
                        }
                    }
                });
        },
        updateItemQuantity: function (orderDetailsID, quantity) {
            if (quantity < 1) {
                quantity = 1;
                document.getElementById("cartItemQuantity" + orderDetailsID).value = 1;
            }

            $.ajax(
                {
                    type: "POST", //HTTP POST Method
                    url: "/Order/UpdateItemQuantity", // Controller/View
                    data: {
                        orderDetailsID: orderDetailsID,
                        quantity: quantity
                    }
                }).done(function (data) {
                    var newCartTotalPrice = data.message[0].split('.')
                    document.getElementById("cartTotalPriceN").innerHTML = newCartTotalPrice[0]
                    document.getElementById("cartTotalPriceD").innerHTML = newCartTotalPrice[1]

                    var newProductTotalPrice = data.message[1].split('.')
                    document.getElementById("productTotalPriceN" + orderDetailsID).innerHTML = newProductTotalPrice[0]
                    document.getElementById("productTotalPriceD" + orderDetailsID).innerHTML = newProductTotalPrice[1]

                    var orderSummaryEl = document.getElementById("orderSummary")
                    if (orderSummaryEl && data.isSuccess) {
                        app.updateOrderSummary();
                    }

                    if (!data.isSuccess) {
                        var cartErrorElement = document.getElementById("cartItemError" + orderDetailsID)
                        cartErrorElement.innerHTML = data.message[2]
                        document.getElementById("cartItemQuantity" + orderDetailsID).value = data.message[3]
                        setTimeout(() => { cartErrorElement.innerHTML = "" }, 3000)
                    }
                });
        },
        updateOrderSummary: function () {
            $.ajax(
                {
                    type: "POST", //HTTP POST Method
                    url: "/Checkout/UpdateOrderSummary", // Controller/View
                    data: {
                    }
                }).done(function (data) {
                    console.log(data);
                    $("#orderSummary").html(data)
                });
        }
    },
    mounted: function () {
        this.getCurrentCartCount()
        this.loadCart();
    }
})