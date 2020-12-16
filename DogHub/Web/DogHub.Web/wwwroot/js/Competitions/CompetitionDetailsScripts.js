function displayFunc() {
    var dataToDisplay = document.querySelector('#winnersDetails');
    var openDatabtn = document.querySelector('#detailsBtn');
    var closeDataBtn = document.querySelector('#closeData');

    openDatabtn.style.display = "block";

    if (openDatabtn.style.display === "block") {
        openDatabtn.style.display = 'none';
        dataToDisplay.style.display = 'block';
    }

    closeDataBtn.addEventListener("click", () => {
        openDatabtn.style.display = 'block';
        dataToDisplay.style.display = 'none';
    })
}
