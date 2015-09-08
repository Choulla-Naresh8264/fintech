import Ember from 'ember';
export default Ember.Route.extend({
  activate: function () {
      $(document).attr('title', 'FinTech - Transaction details');
  },
  model: function (params) {
    if(params.id==="null"){
      this.transitionTo('transactions');
      return;
    }
    return this.store.find('transaction', params.id);
  },
  actions:{
    lookupTransaction: function(model){
      var controller = this.controller;
      var transactionId = model.get("transactionId");

      $.get("/api/btc/"+transactionId, function(result) {
        var t = result.transaction;
        model.set("amount",t.amount);
        model.set("timestamp",t.timestamp);
        model.set("fromAddress",t.fromAddress);
        model.set("toAddress",t.toAddress);
        controller.set("canSave", true);
      }, 'json');
    },
    saveTransaction: function(){
      var model = this.controller.get("model");
      var self = this;

      model.save().then(function(){
        self.transitionTo('transactions.index');
      });
    }
  }
});
