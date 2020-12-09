var btnsSection = document.querySelector("#optionsBtns");
var acceptBtn = document.querySelector("#acceptBtn");
var rejectBtn = document.querySelector("#rejectBtn");
var approvedArea = document.querySelector("#approvedArea");

acceptBtn.addEventListener("click", () => {
    btnsSection.style.display == "none";
    approvedArea.style.display = "block";
})