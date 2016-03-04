var atlas = atlas || {};

atlas = (function () {

    function setupMenu() {

        $(".menu li").click(function (event) {

            var targetButton = $(event.target);

            //Special - responsive menu
            if (targetButton.hasClass("mo-menu")) {

                //Toggle menu
                var menu = $("ul.menu");
                if (menu.hasClass("showmenu")) {
                    menu.removeClass("showmenu")
                }
                else {
                    menu.addClass("showmenu");
                }

                return;
            }

            if (!targetButton.hasClass("mo-sel")) {
            
                $(".menu li.sel").removeClass("sel");

                targetButton.addClass("sel");
            }


            if (targetButton.hasClass("mo-home")) {

                //Navigate to home page
                navToPage("Home");
            }
            else if (targetButton.hasClass("mo-status")) {

                //Navigate to status page
                navToPage("Status");
            }
            else if (targetButton.hasClass("mo-about")) {

                //Navigate to about page
                navToPage("About");
            }
            else if (targetButton.hasClass("mo-contact")) {

                //Navigate to contact page
                navToPage("Contact");
            }

            //Special - for responsive
            if ($("ul.menu").hasClass("showmenu")) {
                $("ul.menu").removeClass("showmenu");
            }
        });
    }

    function navToPage(pageName) {

        $.ajax({
            url: "http://localhost:51515/Page/" + pageName,
            cache: false,
            success: loadPage,
            error: errorHandler
        });
    }

    function errorHandler(ex) {

        alert(ex.responseText);
    }

    function loadPage(content) {

        //Clear previous KO bindings
        ko.cleanNode($(".guts")[0]);

        activePageClass = null;

        $(".guts").addClass("fade-out");

        setTimeout(function () {

            $(".guts").html(content);

            $(".guts").removeClass("fade-out");

            //Check if the loaded page has a view model
            if (activePageClass != null) {

                ko.applyBindings(activePageClass.viewModel, $(".guts")[0]);

                activePageClass.methods.onLoaded();
            }
        }, 250);
       

    }

    var activePageClass = null;

    function setPageClass(pageClass) {

        activePageClass = pageClass;
    }

    return {

        //Public methods
        setupMenu: setupMenu,

        setPageClass: setPageClass
    }

})();


$(document).ready(function () {

    atlas.setupMenu();
});