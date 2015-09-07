import Ember from 'ember';
/* global moment */

function fDate(date) {
  if(date!==null){
      return moment(date,["YYYY-MM-DDTHH:mm:ss.SSZ"]).format('lll');
  }
  return "N/A";
}

export default Ember.HTMLBars.makeBoundHelper(fDate);
