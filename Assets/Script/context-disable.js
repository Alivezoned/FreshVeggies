// Author: Alivezoned.com - Dhruv Kumar

$(document).bind("contextmenu", function (event) {
    
    // Avoiding Default Context Menu
    event.preventDefault();
    
    // Show contextmenu
    $(".custom-menu").finish().toggle(90).
    
    // In the right position of the mouse pointer
    css({
        top: event.pageY + "px",
        left: event.pageX + "px"
    });
});


// If Document Is Left Clicked Anywhere, Disable the Context Menu
$(document).bind("mousedown", function (e) {
    
    // If the clicked element is not the menu
    if (!$(e.target).parents(".custom-menu").length > 0) {
        
        // Hide it
        $(".custom-menu").hide(100);
    }
});
