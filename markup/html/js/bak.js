
function CBak(){

	var self = this;

	this.data;
	this.index = [];
	this.filter;


	// save
	this.save = function(){
		/* save */
	};

	// load
	this.load = function(){
		/* load */
	};

	this.indexAll = function (_child) {
	    if (_child) {
	        for (var i = 0; i < _child.length; ++i) {
	            self.index[_child[i].Id] = _child[i];
	            self.indexAll(_child[i].Children);
	        }
	    }
	}

	// load struct
	this.loadStruct = function (_cfg) {
		
		if( typeof RUBRICS == 'object' ){

			self.data = RUBRICS;
			self.indexAll(self.data);

			if (typeof _cfg.load == 'function')
				_cfg.load();

		} else {
			$.ajax({
				  url: '/Rubric/GetRubricList'
				, type: 'post'
				, data: {}
				, dataType: 'json'
				, success: function( _data ){

					self.data = _data;
					self.indexAll(self.data);

					if( typeof _cfg.load == 'function' )
						_cfg.load();
				}
			});
		}

	};

	this.getRubric = function (_id) {
		var res = self.index[_id];

		//if( typeof res == 'undefined' )
			//console.log( 'Bad rubric index: ' + _id );

		return res;
	}

	/* data */
	// get section
	this.getSection  = function( _id ){
/*		for(var i=0; i<this.data.length; i++ )
			if( _id == this.data[i].Id )
				return this.data[i];*/
	};


	// get category
	this.getCategory = function(){
	};


	/* filter */
	this.set_1 = function(){ /**/ };
	this.set_2 = function(){ /**/ };
	this.set_3 = function(){ /**/ };
};


