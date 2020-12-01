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


// When the user clicks on div, open the popup
//function popUpDataWindow() {

//    var popup = document.getElementById("myPopup");
//    popup.classList.toggle("show");
//}

//function buildDomElement(name, points, dogId) {

//    var pEl = document.createElement('p');
//    //pEl.setAttribute("id", "popUpWindow"); if it works

//    var divEl = document.createElement('div');
//    divEl.setAttribute("class", "popup");
//    divEl.setAttribute("onclick", "popUpDataWindow()");

//    var aNameEl = document.createElement("a");
//    aNameEl.setAttribute("id", "dogName");
//    aNameEl.textContent = name;

//    var spanEl = document.createElement("span");
//    spanEl.setAttribute("class", "popuptext");
//    spanEl.setAttribute("id", "myPopup");

//    var innerP = document.createElement("p");
//    innerP.setAttribute("id", "totalPoints");
//    innerP.textContent = "Total Points in the Competition: " + points;

//    var aDogProfileEl = document.createElement("a");
//    aDogProfileEl.setAttribute("href", "/Dogs/DogProfile?id=" + dogId);
//    aDogProfileEl.textContent = "Review Dog Profile";

//    var closeSignP = document.createElement("p");
//    closeSignP.setAttribute("id", "closePopUpX");

//    var iIconEl = document.createElement("i");
//    iIconEl.setAttribute("class", "fas fa-times");

//    closeSignP.appendChild(iIconEl);
//    spanEl.appendChild(innerP);
//    spanEl.appendChild(aDogProfileEl);
//    spanEl.appendChild(closeSignP);
//    divEl.appendChild(aNameEl);
//    divEl.appendChild(spanEl);
//    pEl.appendChild(divEl);

//    //<p>
//    //    <div class="popup" onclick="popUpDataWindow()">
//    //        <a id="dogName">Kassy</a>
//    //        <span class="popuptext" id="myPopup">
//    //            <p id="totalPoints">Total Points in the Competition: 200</p>
//    //            <a href="/Dogs/DogProfile?id=1">Review Dog Profile</a>
//    //            <p id="closePopUpX">
//    //                <i class="fas fa-times"></i>
//    //            </p>

//    //        </span>
//    //    </div>
//    //</p>
//}
