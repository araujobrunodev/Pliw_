mergeInto(LibraryManager.library, {
    getWidth: function () {
        return window.innerWidth;
    },

    getHeight: function () {
        return window.innerHeight;
    },

    getScreen: function () {
        let canva = document.getElementById("unity-canvas");

        canva.style.width = "100%";
        canva.style.height = "100%";
        document.body.style.overflow = "hidden";
        
        console.log("change canvas's size");
    }
});