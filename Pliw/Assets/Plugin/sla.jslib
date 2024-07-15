mergeInto(LibraryManager.library, {
    getWidth: function () {
        return window.innerWidth;
    },

    getHeight: function () {
        return window.innerHeight;
    },

    saveGame: function (score, bestscore, allClicks, allLost) {
        localStorage.setItem("score", score.toString());
        localStorage.setItem("bestscore", bestscore.toString());
        localStorage.setItem("allClicks", allClicks.toString());
        localStorage.setItem("allLost", allLost.toString());
    },

    loadBestscore: function () {
        let bestscore = localStorage.getItem("bestscore");

        if (bestscore == null) return;
        
        return Number(bestscore);
    },

    loadAllClicks: function () {
        let allClicks = localStorage.getItem("allClicks");

        if (allClicks == null) return;
        
        return Number(allClicks);
    },

    loadAllLost: function () {
        let allLost = localStorage.getItem("allLost");
        
        if (allLost == null) return;
        
        return Number(allLost);
    }
});