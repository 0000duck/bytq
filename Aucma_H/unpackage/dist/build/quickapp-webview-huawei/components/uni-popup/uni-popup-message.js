(global["webpackJsonp"]=global["webpackJsonp"]||[]).push([["components/uni-popup/uni-popup-message"],{"01c6":function(t,e,n){"use strict";n.r(e);var u=n("89ca"),i=n.n(u);for(var o in u)"default"!==o&&function(t){n.d(e,t,(function(){return u[t]}))}(o);e["default"]=i.a},"3cbb":function(t,e,n){"use strict";var u=n("8d13"),i=n.n(u);i.a},"89ca":function(t,e,n){"use strict";Object.defineProperty(e,"__esModule",{value:!0}),e.default=void 0;var u={name:"UniPopupMessage",props:{type:{type:String,default:"success"},message:{type:String,default:""},duration:{type:Number,default:3e3}},inject:["popup"],data:function(){return{}},created:function(){this.popup.childrenMsg=this},methods:{open:function(){var t=this;0!==this.duration&&(clearTimeout(this.popuptimer),this.popuptimer=setTimeout((function(){t.popup.close()}),this.duration))},close:function(){clearTimeout(this.popuptimer)}}};e.default=u},"8d13":function(t,e,n){},"9bf6":function(t,e,n){"use strict";n.r(e);var u=n("e1a1"),i=n("01c6");for(var o in i)"default"!==o&&function(t){n.d(e,t,(function(){return i[t]}))}(o);n("3cbb");var r,c=n("f0c5"),a=Object(c["a"])(i["default"],u["b"],u["c"],!1,null,"b67d2952",null,!1,u["a"],r);e["default"]=a.exports},e1a1:function(t,e,n){"use strict";var u;n.d(e,"b",(function(){return i})),n.d(e,"c",(function(){return o})),n.d(e,"a",(function(){return u}));var i=function(){var t=this,e=t.$createElement;t._self._c},o=[]}}]);
;(global["webpackJsonp"] = global["webpackJsonp"] || []).push([
    'components/uni-popup/uni-popup-message-create-component',
    {
        'components/uni-popup/uni-popup-message-create-component':(function(module, exports, __webpack_require__){
            __webpack_require__('8adf')['createComponent'](__webpack_require__("9bf6"))
        })
    },
    [['components/uni-popup/uni-popup-message-create-component']]
]);
