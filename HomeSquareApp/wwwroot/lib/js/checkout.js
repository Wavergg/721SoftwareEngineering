const steps = Array.from(document.querySelectorAll('form .step'));
const nextBtn = document.querySelectorAll('form .next-btn');
const prevBtn = document.querySelectorAll('form .prev-btn');
const form = document.querySelector('form');
const progressBarCheckout = document.getElementById('progressCheckout');
const progressBarCheckoutPrompt = document.getElementById('progressBarCheckoutPrompt');
var deliveryOptionsRadio = document.checkoutForm.deliveryOptions;


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