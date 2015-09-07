import DS from 'ember-data';

export default DS.Model.extend({
  timestamp: DS.attr('date'),
  amount: DS.attr('number'),
  fromAddress: DS.attr('string'),
  toAddress: DS.attr('string'),
});
