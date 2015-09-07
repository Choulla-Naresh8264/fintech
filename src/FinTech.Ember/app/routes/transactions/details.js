import Ember from 'ember';
export default Ember.Route.extend({
  activate: function () {
      $(document).attr('title', 'FinTech - Transaction details');
  },
  model: function (params) {
      return this.store.find('transaction', params.id);
  }
});
