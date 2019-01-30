var Rock = (function () { 'use strict';

function recompute ( state, newState, oldState, isInitial ) {
	if ( isInitial || ( 'rock' in newState && differs( state.rock, oldState.rock ) ) || ( 'firstdata' in newState && differs( state.firstdata, oldState.firstdata ) ) ) {
		state.listrock = newState.listrock = template.computed.listrock( state.rock, state.firstdata );
	}

	if ( isInitial || ( 'listrock' in newState && differs( state.listrock, oldState.listrock ) ) || ( 'list' in newState && differs( state.list, oldState.list ) ) ) {
		state.selected = newState.selected = template.computed.selected( state.listrock, state.list );
	}
}

var template = (function () {
	return {
		data () {																					//default component data
			return {
				firstdata: '',
				name: '',
				location: '',
        date: '',
				rock: [],
			};
		},

		computed: {           														//computed an object literal provided by svelte
			selected: ( listrock, list ) => {								//arrow function to show the list output
				return listrock[list];
			},

			listrock ( rock, firstdata ) {
				if ( !firstdata ) return rock;

				return rock.filter( geo => {								//arrow function to show the way result will come out
					const name = `${geo.name}, ${geo.location}, ${geo.date}`;
					return ( firstdata );
				});
			}
		},

		oncreate () {																		//oncreate() one of the hooks to provide control logic in svelte
			this.observe( 'selected', selected => {				// other one ondestroy().
				if ( selected ) this.set( selected );
			});
		},

		methods: {																			//custom methods provided by svelte, also can use our own.

//adds functionality for creating new rock data
			create () {
				const { name, location, date, rock } = this.get();		//creates a constant to the list
				rock.push({ name, location, date });		//used push() method to add one data endo of the list
				this.set({
					rock,
					name: '',
					location: '',
          date: '',
					list: rock.length + 1									//adds 1 data to the length of list
				});
			},
//adds functionality for updating rock data.
			update () {
				const { name, location, date, selected, rock } = this.get(); //creates a constant
				selected.name = name;		//selects the rock name
				selected.location = location;  //select the location name
        selected.date = date;  //select the date
				this.set({ rock, selected });
			},
//adds functionality for removing rock data. can remove existing data
			remove () {
				const {rock, selected, list } = this.get();		//selects the data to be removed
				const index = rock.indexOf( selected );		//indexed to the selected data
				rock.splice( index, 1 );		//used splice() method to remove existing data
				this.set({
					rock,
					name: '',
					location: '',
          date: '',
					list: Math.min( list, rock.length - 1 )	//used math.min() method to removes 1 data from the list at a time
				});
			}
		}
	};
}());

function add_css () {
	var style = createElement( 'style' );
	style.id = "svelte-1538030160-style";
	style.textContent = "\n\t*[svelte-1538030160], [svelte-1538030160] * {\n\t\tfont-family: serif;\n\t\tfont-size: 25px;\n\t}\n";
	appendNode( style, document.head );
}

function create_main_fragment ( state, component ) {
	var input_updating = false, input_1_updating = false, input_2_updating = false, button_disabled_value, button_1_disabled_value, button_2_disabled_value, select_updating = false;

	var h1 = createElement( 'h1' );
	setAttribute( h1, 'svelte-1538030160', '' );
	appendNode( createText( "Rock collection app" ), h1 );
	var text_1 = createText( "\n\n\n" );
	var label = createElement( 'label' );
	setAttribute( label, 'svelte-1538030160', '' );
	var input = createElement( 'input' );
	appendNode( input, label );
	input.placeholder = "Name of the rock";

	function input_input_handler () {
		input_updating = true;
		component._set({ name: input.value });
		input_updating = false;
	}

	addEventListener( input, 'input', input_input_handler );

	input.value = state.name;

	var text_2 = createText( "\n" );
	var label_1 = createElement( 'label' );
	setAttribute( label_1, 'svelte-1538030160', '' );
	var input_1 = createElement( 'input' );
	appendNode( input_1, label_1 );
	input_1.placeholder = "Found location";

	function input_1_input_handler () {
		input_1_updating = true;
		component._set({ location: input_1.value });
		input_1_updating = false;
	}

	addEventListener( input_1, 'input', input_1_input_handler );

	input_1.value = state.location;

	var text_3 = createText( "\n" );
	var label_2 = createElement( 'label' );
	setAttribute( label_2, 'svelte-1538030160', '' );
	var input_2 = createElement( 'input' );
	appendNode( input_2, label_2 );
	input_2.placeholder = "Found Date";

	function input_2_input_handler () {
		input_2_updating = true;
		component._set({ date: input_2.value });
		input_2_updating = false;
	}

	addEventListener( input_2, 'input', input_2_input_handler );

	input_2.value = state.date;

	var text_4 = createText( "\n\n\n" );
	var div = createElement( 'div' );
	setAttribute( div, 'svelte-1538030160', '' );
	div.className = "buttons";
	var button = createElement( 'button' );
	appendNode( button, div );
	button.disabled = button_disabled_value = !state.name || !state.location || !state.date;

	function click_handler ( event ) {
		component.create();
	}

	addEventListener( button, 'click', click_handler );
	appendNode( createText( "Add" ), button );
	appendNode( createText( "\n\t" ), div );
	var button_1 = createElement( 'button' );
	appendNode( button_1, div );
	button_1.disabled = button_1_disabled_value = !state.name || !state.location || !state.date || !state.selected;

	function click_handler_1 ( event ) {
		component.update();
	}

	addEventListener( button_1, 'click', click_handler_1 );
	appendNode( createText( "Update" ), button_1 );
	appendNode( createText( "\n\t" ), div );
	var button_2 = createElement( 'button' );
	appendNode( button_2, div );
	button_2.disabled = button_2_disabled_value = !state.selected;

	function click_handler_2 ( event ) {
		component.remove();
	}

	addEventListener( button_2, 'click', click_handler_2 );
	appendNode( createText( "Remove" ), button_2 );
	var text_10 = createText( "\n\n\n" );
	var select = createElement( 'select' );
	setAttribute( select, 'svelte-1538030160', '' );
	var each_block_value = state.listrock;

	var each_block_iterations = [];

	for ( var i = 0; i < each_block_value.length; i += 1 ) {
		each_block_iterations[i] = create_each_block( state, each_block_value, each_block_value[i], i, component );
		each_block_iterations[i].mount( select, null );
	}

	select.size = "15";

	function select_change_handler () {
		select_updating = true;
		var selectedOption = select.querySelector(':checked') || select.options[0];
		component._set({ list: selectedOption && selectedOption.__value });
		select_updating = false;
	}

	addEventListener( select, 'change', select_change_handler );

	var value = state.list;
	for ( var i = 0; i < select.options.length; i += 1 ) {
		var option = select.options[i];

		if ( option.__value === value ) {
			option.selected = true;
			break;
		}
	}

	return {
		mount: function ( target, anchor ) {
			insertNode( h1, target, anchor );
			insertNode( text_1, target, anchor );
			insertNode( label, target, anchor );
			insertNode( text_2, target, anchor );
			insertNode( label_1, target, anchor );
			insertNode( text_3, target, anchor );
			insertNode( label_2, target, anchor );
			insertNode( text_4, target, anchor );
			insertNode( div, target, anchor );
			insertNode( text_10, target, anchor );
			insertNode( select, target, anchor );
		},

		update: function ( changed, state ) {
			if ( !input_updating ) {
				input.value = state.name;
			}

			if ( !input_1_updating ) {
				input_1.value = state.location;
			}

			if ( !input_2_updating ) {
				input_2.value = state.date;
			}

			if ( button_disabled_value !== ( button_disabled_value = !state.name || !state.location || !state.date ) ) {
				button.disabled = button_disabled_value;
			}

			if ( button_1_disabled_value !== ( button_1_disabled_value = !state.name || !state.location || !state.date || !state.selected ) ) {
				button_1.disabled = button_1_disabled_value;
			}

			if ( button_2_disabled_value !== ( button_2_disabled_value = !state.selected ) ) {
				button_2.disabled = button_2_disabled_value;
			}

			var each_block_value = state.listrock;

			if ( 'listrock' in changed ) {
				for ( var i = 0; i < each_block_value.length; i += 1 ) {
					if ( each_block_iterations[i] ) {
						each_block_iterations[i].update( changed, state, each_block_value, each_block_value[i], i );
					} else {
						each_block_iterations[i] = create_each_block( state, each_block_value, each_block_value[i], i, component );
						each_block_iterations[i].mount( select, null );
					}
				}

				destroyEach( each_block_iterations, true, each_block_value.length );
				each_block_iterations.length = each_block_value.length;
			}

			if ( !select_updating ) {
				var value = state.list;
				for ( var i = 0; i < select.options.length; i += 1 ) {
					var option = select.options[i];

					if ( option.__value === value ) {
						option.selected = true;
						break;
					}
				}
			}
		},

		destroy: function ( detach ) {
			removeEventListener( input, 'input', input_input_handler );
			removeEventListener( input_1, 'input', input_1_input_handler );
			removeEventListener( input_2, 'input', input_2_input_handler );
			removeEventListener( button, 'click', click_handler );
			removeEventListener( button_1, 'click', click_handler_1 );
			removeEventListener( button_2, 'click', click_handler_2 );

			destroyEach( each_block_iterations, false, 0 );

			removeEventListener( select, 'change', select_change_handler );

			if ( detach ) {
				detachNode( h1 );
				detachNode( text_1 );
				detachNode( label );
				detachNode( text_2 );
				detachNode( label_1 );
				detachNode( text_3 );
				detachNode( label_2 );
				detachNode( text_4 );
				detachNode( div );
				detachNode( text_10 );
				detachNode( select );
			}
		}
	};
}

function create_each_block ( state, each_block_value, geo, list, component ) {
	var option_value_value, text_value, text_2_value, text_4_value;

	var option = createElement( 'option' );
	option.__value = option_value_value = list;
	option.value = option.__value;
	var text = createText( text_value = geo.name );
	appendNode( text, option );
	appendNode( createText( ", " ), option );
	var text_2 = createText( text_2_value = geo.location );
	appendNode( text_2, option );
	appendNode( createText( ", " ), option );
	var text_4 = createText( text_4_value = geo.date );
	appendNode( text_4, option );

	return {
		mount: function ( target, anchor ) {
			insertNode( option, target, anchor );
		},

		update: function ( changed, state, each_block_value, geo, list ) {
			if ( option_value_value !== ( option_value_value = list ) ) {
				option.__value = option_value_value;
			}

			option.value = option.__value;

			if ( text_value !== ( text_value = geo.name ) ) {
				text.data = text_value;
			}

			if ( text_2_value !== ( text_2_value = geo.location ) ) {
				text_2.data = text_2_value;
			}

			if ( text_4_value !== ( text_4_value = geo.date ) ) {
				text_4.data = text_4_value;
			}
		},

		destroy: function ( detach ) {
			if ( detach ) {
				detachNode( option );
			}
		}
	};
}

function Rock ( options ) {
	options = options || {};
	this._state = assign( template.data(), options.data );
	recompute( this._state, this._state, {}, true );

	this._observers = {
		pre: Object.create( null ),
		post: Object.create( null )
	};

	this._handlers = Object.create( null );

	this._root = options._root || this;
	this._yield = options._yield;

	this._torndown = false;
	if ( !document.getElementById( "svelte-1538030160-style" ) ) add_css();

	this._fragment = create_main_fragment( this._state, this );
	if ( options.target ) this._fragment.mount( options.target, null );

	if ( options._root ) {
		options._root._renderHooks.push( template.oncreate.bind( this ) );
	} else {
		template.oncreate.call( this );
	}
}

assign( Rock.prototype, template.methods, {
 	get: get,
 	fire: fire,
 	observe: observe,
 	on: on,
 	set: set,
 	_flush: _flush
 });

Rock.prototype._set = function _set ( newState ) {
	var oldState = this._state;
	this._state = assign( {}, oldState, newState );
	recompute( this._state, newState, oldState, false )
	dispatchObservers( this, this._observers.pre, newState, oldState );
	this._fragment.update( newState, this._state );
	dispatchObservers( this, this._observers.post, newState, oldState );
};

Rock.prototype.teardown = Rock.prototype.destroy = function destroy ( detach ) {
	this.fire( 'destroy' );

	this._fragment.destroy( detach !== false );
	this._fragment = null;

	this._state = {};
	this._torndown = true;
};

function createElement ( name ) {
	return document.createElement( name );
}

function insertNode ( node, target, anchor ) {
	target.insertBefore( node, anchor );
}

function setAttribute ( node, attribute, value ) {
	node.setAttribute( attribute, value );
}

function detachNode ( node ) {
	node.parentNode.removeChild( node );
}

function createText ( data ) {
	return document.createTextNode( data );
}

function appendNode ( node, target ) {
	target.appendChild( node );
}

function addEventListener ( node, event, handler ) {
	node.addEventListener( event, handler, false );
}

function removeEventListener ( node, event, handler ) {
	node.removeEventListener( event, handler, false );
}

function destroyEach ( iterations, detach, start ) {
	for ( var i = start; i < iterations.length; i += 1 ) {
		if ( iterations[i] ) iterations[i].destroy( detach );
	}
}

function differs ( a, b ) {
	return ( a !== b ) || ( a && ( typeof a === 'object' ) || ( typeof a === 'function' ) );
}

function assign ( target ) {
	for ( var i = 1; i < arguments.length; i += 1 ) {
		var source = arguments[i];
		for ( var k in source ) target[k] = source[k];
	}

	return target;
}

function dispatchObservers ( component, group, newState, oldState ) {
	for ( var key in group ) {
		if ( !( key in newState ) ) continue;

		var newValue = newState[ key ];
		var oldValue = oldState[ key ];

		if ( differs( newValue, oldValue ) ) {
			var callbacks = group[ key ];
			if ( !callbacks ) continue;

			for ( var i = 0; i < callbacks.length; i += 1 ) {
				var callback = callbacks[i];
				if ( callback.__calling ) continue;

				callback.__calling = true;
				callback.call( component, newValue, oldValue );
				callback.__calling = false;
			}
		}
	}
}

function get ( key ) {
	return key ? this._state[ key ] : this._state;
}

function fire ( eventName, data ) {
	var handlers = eventName in this._handlers && this._handlers[ eventName ].slice();
	if ( !handlers ) return;

	for ( var i = 0; i < handlers.length; i += 1 ) {
		handlers[i].call( this, data );
	}
}

function observe ( key, callback, options ) {
	var group = ( options && options.defer ) ? this._observers.post : this._observers.pre;

	( group[ key ] || ( group[ key ] = [] ) ).push( callback );

	if ( !options || options.init !== false ) {
		callback.__calling = true;
		callback.call( this, this._state[ key ] );
		callback.__calling = false;
	}

	return {
		cancel: function () {
			var index = group[ key ].indexOf( callback );
			if ( ~index ) group[ key ].splice( index, 1 );
		}
	};
}

function on ( eventName, handler ) {
	if ( eventName === 'teardown' ) return this.on( 'destroy', handler );

	var handlers = this._handlers[ eventName ] || ( this._handlers[ eventName ] = [] );
	handlers.push( handler );

	return {
		cancel: function () {
			var index = handlers.indexOf( handler );
			if ( ~index ) handlers.splice( index, 1 );
		}
	};
}

function set ( newState ) {
	this._set( assign( {}, newState ) );
	this._root._flush();
}

function _flush () {
	if ( !this._renderHooks ) return;

	while ( this._renderHooks.length ) {
		this._renderHooks.pop()();
	}
}

return Rock;

}());