
const searchButton = document.getElementById('search-button');
const searchInput = document.getElementById('search-input');
searchButton.addEventListener('click', () => {
    const inputValue = searchInput.value;
    
    var href = "/ordersearch?search=" + searchName;
    alert(href);
    searchButton.href = href;
    searchButton.click;
    
});



// Execute a function when the user releases a key on the keyboard
searchInput.addEventListener("keyup", function (event) {
    // Number 13 is the "Enter" key on the keyboard
    if (event.keyCode === 13) {
    // Cancel the default action, if needed
    event.preventDefault();
        // Trigger the button element with a click
        document.getElementById("myBtn").click();
    }
});
