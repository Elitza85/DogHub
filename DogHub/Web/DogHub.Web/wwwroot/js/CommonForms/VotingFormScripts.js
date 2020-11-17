function DisplayVideo() {
    var videoBlock = document.querySelector("#videoBlock");
    var closeBtn = document.querySelector("#closeBtn");

    if (videoBlock.style.display == 'none') {
        videoBlock.style.display = "block";
        closeBtn.style.display = "block";
    }

    closeBtn.addEventListener("click", () => {
        videoBlock.style.display = "none";
        closeBtn.style.display = "none";
    })
}

function calc() {
    var component = document.querySelector("#votingForm")
    var elements = component.querySelectorAll(".rating-star");
    var result = document.querySelector("#selected-rating");
    var total = 0;
    for (var i = 0; i < elements.length; i++) {
        var currentElements = elements[i];
        var inputs = currentElements.querySelectorAll("input[type=radio]")
        for (var y = 0; y < inputs.length; y++) {
            if (inputs[y].checked) {
                total += parseInt(inputs[y].value)
                result.textContent = total;
            }
        }
    }
};