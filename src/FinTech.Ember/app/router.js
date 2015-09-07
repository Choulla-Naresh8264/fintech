import Ember from 'ember';
import config from './config/environment';

var Router = Ember.Router.extend({
  location: config.locationType
});

Router.map(function() {
    this.route("transactions", function() {
      this.route("details", { path: ':id' });
    });

    this.route('not-found', { path: '/*path' });
});

export default Router;
