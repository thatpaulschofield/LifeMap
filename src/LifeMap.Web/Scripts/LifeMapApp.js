// define the application
// options we pass in are copied on to the instance
LifeMapApp = new Backbone.Marionette.Application(
    {  }
);

// add a region to the app
LifeMapApp.MainRegion = Backbone.Marionette.RegionManager.extend({
    el: "#mainRegion"
});

LifeMapApp.addRegions({ mainRegion: LifeMapApp.MainRegion });

LifeMapApp.bind("initialize:after", function () {
    if (Backbone.history) {
        Backbone.history.start();
    }
});

