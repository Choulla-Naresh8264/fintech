import Ember from 'ember';

export default Ember.Route.extend({
  activate: function () {
      $(document).attr('title', 'FinTech - Transaction list');
  },
  model: function () {
      return this.store.findAll('transaction');
  },
  actions: {
    newTransaction: function(){
      var transaction = this.store.createRecord('Transaction');
      this.transitionTo('transactions.details', transaction);
    },
    deleteTransaction: function(transaction){
      transaction.destroyRecord();
      this.transitionTo('transactions');
    },
    exportTransactions: function(){

    },
  }
});
