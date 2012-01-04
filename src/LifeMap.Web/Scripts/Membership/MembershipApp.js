// define the application
// options we pass in are copied on to the instance
LifeMapApp.MembershipApp = (function (LifeMapApp, Backbone) {
    var Membership = {};

    Membership.StartRegistrationView = Backbone.View.extend({
        initialize: function () {
            this.model.fetch();
        },

        render: function () {
            var template = $("#membership-start-registration");
            var html = template.tmpl();
            $(this.el).html(html);
            Backbone.ModelBinding.bind(this);
        },

        events: {
            "click #membership-start-registration-submit": "onSubmit"
        },

        onSubmit: function () {
            this.model.save();
//            LifeMapApp.navigate("");
        }
    });

    Membership.StartRegistrationModel = Backbone.Model.extend({
        FirstName: "",
        LastName: "",
        Id: "",
        url: "/Membership/registrations/start"
    });

    Membership.HeaderLink = Backbone.Model.extend({
        defaults: {
            Url: "",
            Description: ""
        }
    });


    Membership.HeaderView = Backbone.Marionette.ItemView.extend({
        render: function () {
            $(this.el).html(this.template(this.model.toJSON()));
            return this;
        }
    });

    Membership.HeadersView = Backbone.Marionette.CollectionView.extend({
        itemView: Membership.HeaderView
    });

    Membership.HeaderLinks = Backbone.Collection.extend({
        model: Membership.HeaderLink,
        url: "/FacebookAuthentication/FacebookAuthenticationHeader/"
    });

    Membership.register = function () {
        var registrationView = new Membership.StartRegistrationView({ model: new LifeMapApp.MembershipApp.StartRegistrationModel() });
        LifeMapApp.mainRegion.show(registrationView);
    };


    return Membership;
}
)(LifeMapApp, Backbone);



//// define some functionality for the app
//(function (MembershipApp, Backbone) {


//    
//    
//    
//    // a view to render into the region
//    var LoginView = Backbone.View.extend({
//        render: function () {
//        },

//        logIn: function () {
//            if (getParameterByName('code')) {
//                $.ajax({
//                        url: 'http://localhost/FacebookAuthentication/registrations/' + getParameterByName('registrationId')

//                    }
//                    );
//            }
//            else {
//                window.location = "https://www.facebook.com/dialog/oauth?client_id=149734561800297&redirect_uri=http://localhost/LifeMap.Web/&scope=read_stream,user_interests,user_education_history,user_birthday,user_about_me,user_activities,offline_access";
//            }
//        }
//    });

//    // an initializer to run this functional area 
//    // when the app starts up
//    MembershipApp.addInitializer(function () {
////        var loginView = new LoginView();
////        MembershipApp.mainRegion.show(loginView);
////        loginView.logIn();

////        var headerLinks = new HeaderLinks();
////        var headersView = new HeadersView({
////                model: headerLinks
////            });
////        MembershipApp.headerRegion.show(headersView);
////        headerLinks.fetch();
//    });



//})(MembershipApp, Backbone);

//function getParameterByName(name) {

//    var match = RegExp('[?&]' + name + '=([^&]*)')
//                    .exec(window.location.search);

//    return match && decodeURIComponent(match[1].replace(/\+/g, ' '));

//}