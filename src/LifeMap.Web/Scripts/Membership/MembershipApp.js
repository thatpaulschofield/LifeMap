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

    Membership.ConfirmEmailView = Backbone.View.extend({
        initialize: function () {
            this.model.save();
        },

        render: function () {
            var template = $("#membership-confirm-email");
            var html = template.tmpl();
            $(this.el).html(html);
            Backbone.ModelBinding.bind(this);
        }
    });

    Membership.ConfirmEmailModel = Backbone.Model.extend({
        Id: "",
        registrationId: "",
        confirmationId: "",
        url: "/Membership/registration/confirmEmail"
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

    Membership.confirmEmail = function (registrationId, confirmationId) {
        var confirmEmailView = new Membership.ConfirmEmailView({ model: new LifeMapApp.MembershipApp.ConfirmEmailModel({ registrationId: registrationId, confirmationId: confirmationId} ) });
        LifeMapApp.mainRegion.show(confirmEmailView);
    };

    return Membership;
}
)(LifeMapApp, Backbone);
