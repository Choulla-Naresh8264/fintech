import Ember from 'ember';
import pagedArray from 'ember-cli-pagination/computed/paged-array';
export default Ember.Controller.extend({
  idFilter: '',
  queryParams: ["page", "perPage"],
  page: 1,
  perPage: 10,
  pagedContent: pagedArray('filteredContent', {pageBinding: "page", perPageBinding: "perPage"}),
  totalPagesBinding: "pagedContent.totalPages",

  sortProperties: ['timestamp'],
  sortAscending: true,

  filteredContent: function(){
    this.set("page",1);

    var filter = this.get('idFilter');
    var rx = new RegExp(filter, 'gi');

    if(this.get('content')===null){ return []; }
    return this.get('content').filter(function(el) {
      return el!==null && el.get('id')!==null && el.get('id').match(rx);
    });
  }.property('content', 'idFilter',"content.@each")
});
