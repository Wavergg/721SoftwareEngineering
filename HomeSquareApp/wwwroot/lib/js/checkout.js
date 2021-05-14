const steps = Array.from(document.querySelectorAll('form .step'));
const nextBtn = document.querySelectorAll('form .next-btn');
const prevBtn = document.querySelectorAll('form .prev-btn');
const form = document.querySelector('form');
const progressBarCheckout = document.getElementById('progressCheckout');
const progressBarCheckoutPrompt = document.getElementById('progressBarCheckoutPrompt');
var deliveryOptionsRadio = document.checkoutForm.deliveryOptions;
var deliveryAddressEl = document.getElementById("DeliveryAddress");
var deliveryAddressStoredVal = deliveryAddressEl.value;

var validateDetailsElements = document.getElementsByClassName("validateDetails");

deliveryOptionsRadio.forEach(radio => {
    radio.addEventListener('change', (e) => {
        if (radio.id == "pickup") {
            document.getElementById('DeliveryInfo').classList.add('d-none')
        } else {
            document.getElementById('DeliveryInfo').classList.remove('d-none')
        }
    })
})

nextBtn.forEach(button => {
    button.addEventListener('click', (e) => {
        changeStep('next');
    })
})

prevBtn.forEach(button => {
    button.addEventListener('click', (e) => {
        changeStep('prev');
    })
})

function changeStep(btn) {
    let index = 0;
    const active = document.querySelector('form .active');
    index = steps.indexOf(active);
    steps[index].classList.remove('active');
    if (btn === 'next') {
        index++;
    } else {
        index--;
    }

    progressBarCheckoutPrompt.innerHTML = `${index + 1}/${steps.length}`;
    progressBarCheckout.style.width = `${(index + 1) * 50}%`;


    steps[index].classList.add('active');
    window.scrollTo({
        top: 0,
        behavior: 'smooth'
    });
}


var input = $('input[name = creditCardNumber]');
input.on('keypress', function () {
    limitLength(this, 18)

    var key = event.keyCode || event.charCode;

    if (key == 8 || key == 46) {
        return;
    } else {
        formatCreditCard(this)
    }
});

function limitLength(el,limit) {
    if (el.value.length > limit) {
        el.value = el.value.substr(0, el.value.length - 1)
    }
}

function formatCreditCard(el) {
    
    var index = el.value.lastIndexOf('-');
    var creditCardValue = el.value.substr(index + 1);

    if (creditCardValue.length === 4 && el.value.length < 16)
        el.value = el.value + '-';
}

function updateDeliveryAddress(el) {
    if (el.value == "Pickup") {
        deliveryAddressEl.value = "PICKUP"
    } else {
        deliveryAddressEl.value = deliveryAddressStoredVal;
    }
}

//HANDLE SIGNUP AJAX JSON DATA THAT ARE RETURNED FROM CONTROLLER
function checkoutReturned(data) {
    if (data.responseJSON.isSuccess) {
        window.location.href = data.responseJSON.urlRedirect;
    } else {
        //Create UL ELEMENT AND POPULATE IT BASED ON ERROR RETURNED
        var list = document.createElement('ul');
        for (var i = 0; i < data.responseJSON.message.length; i++) {
            // Create the list item:
            var item = document.createElement('li');

            // Set its contents:
            item.appendChild(document.createTextNode(data.responseJSON.message[i]));
            
            // Add it to the list:
            list.appendChild(item);
        }
        //CLEAR PREVIOUS ERROR SUMMARY
        document.getElementById("errorCheckoutSummary").innerHTML = "";
        //REPOPULATE THE SUMMARY With list above
        document.getElementById("errorCheckoutSummary").appendChild(list);

        app.updateOrderSummary();
        app.getCurrentCartCount();
        app.loadCart();
    }
    //reenable user clicking
}