(global["webpackJsonp"]=global["webpackJsonp"]||[]).push([["pages/main/perform","components/uni-nav-bar/uni-nav-bar"],{"178c":function(t,n,e){"use strict";(function(t){Object.defineProperty(n,"__esModule",{value:!0}),n.default=void 0;var i=function(){e.e("components/uni-status-bar/uni-status-bar").then(function(){return resolve(e("0a58"))}.bind(null,e)).catch(e.oe)},o=function(){Promise.all([e.e("common/vendor"),e.e("components/uni-icons/uni-icons")]).then(function(){return resolve(e("fd44"))}.bind(null,e)).catch(e.oe)},u={name:"UniNavBar",components:{uniStatusBar:i,uniIcons:o},props:{title:{type:String,default:""},leftText:{type:String,default:""},rightText:{type:String,default:""},leftIcon:{type:String,default:""},leftImage:{type:String,default:""},rightIcon:{type:String,default:""},fixed:{type:[Boolean,String],default:!1},color:{type:String,default:"#000000"},backgroundColor:{type:String,default:"#FFFFFF"},statusBar:{type:[Boolean,String],default:!1},shadow:{type:[String,Boolean],default:!1},border:{type:[String,Boolean],default:!0}},mounted:function(){t.report&&""!==this.title&&t.report("title",this.title)},methods:{onClickLeft:function(){this.$emit("clickLeft")},onClickRight:function(){this.$emit("clickRight")}}};n.default=u}).call(this,e("8adf")["default"])},"1b17":function(t,n,e){"use strict";e.r(n);var i=e("d162"),o=e("4e58");for(var u in o)"default"!==u&&function(t){e.d(n,t,(function(){return o[t]}))}(u);var a,c=e("f0c5"),r=Object(c["a"])(o["default"],i["b"],i["c"],!1,null,null,null,!1,i["a"],a);n["default"]=r.exports},2751:function(t,n,e){"use strict";e.r(n);var i=e("178c"),o=e.n(i);for(var u in i)"default"!==u&&function(t){e.d(n,t,(function(){return i[t]}))}(u);n["default"]=o.a},"3e31":function(t,n,e){"use strict";e.d(n,"b",(function(){return o})),e.d(n,"c",(function(){return u})),e.d(n,"a",(function(){return i}));var i={uniStatusBar:function(){return e.e("components/uni-status-bar/uni-status-bar").then(e.bind(null,"0a58"))},uniIcons:function(){return Promise.all([e.e("common/vendor"),e.e("components/uni-icons/uni-icons")]).then(e.bind(null,"fd44"))}},o=function(){var t=this,n=t.$createElement;t._self._c},u=[]},"4e58":function(t,n,e){"use strict";e.r(n);var i=e("a646"),o=e.n(i);for(var u in i)"default"!==u&&function(t){e.d(n,t,(function(){return i[t]}))}(u);n["default"]=o.a},6054:function(t,n,e){},"79c1":function(t,n,e){"use strict";var i=e("6054"),o=e.n(i);o.a},"9b28":function(t,n,e){"use strict";(function(t){e("588f");i(e("66fd"));var n=i(e("1b17"));function i(t){return t&&t.__esModule?t:{default:t}}t(n.default)}).call(this,e("8adf")["createPage"])},"9f0d":function(t,n,e){"use strict";e.r(n);var i=e("3e31"),o=e("2751");for(var u in o)"default"!==u&&function(t){e.d(n,t,(function(){return o[t]}))}(u);e("79c1");var a,c=e("f0c5"),r=Object(c["a"])(o["default"],i["b"],i["c"],!1,null,"04c6c021",null,!1,i["a"],a);n["default"]=r.exports},a646:function(t,n,e){"use strict";(function(t){Object.defineProperty(n,"__esModule",{value:!0}),n.default=void 0;i(e("9f0d"));function i(t){return t&&t.__esModule?t:{default:t}}var o,u=function(){e.e("components/uni-pagination/uni-pagination").then(function(){return resolve(e("eb91"))}.bind(null,e)).catch(e.oe)},a=function(){e.e("components/uni-drawer/uni-drawer").then(function(){return resolve(e("cc26"))}.bind(null,e)).catch(e.oe)},c=function(){Promise.all([e.e("common/vendor"),e.e("components/uni-popup/uni-popup")]).then(function(){return resolve(e("ff31"))}.bind(null,e)).catch(e.oe)},r=function(){e.e("components/uni-popup/uni-popup-message").then(function(){return resolve(e("9bf6"))}.bind(null,e)).catch(e.oe)},l=function(){e.e("components/uni-popup/uni-popup-dialog").then(function(){return resolve(e("4a32"))}.bind(null,e)).catch(e.oe)},s={components:{uniDrawer:a,uniPagination:u,uniPopup:c,uniPopupMessage:r,uniPopupDialog:l},onLoad:function(){this.getList()},onShow:function(){this.getList()},data:function(){return o=t.getStorageSync("userInfo").ApiToken,{dataType:getApp().globalData.SelType,current:1,total:50,pageSize:10,listData:[]}},methods:{getList:function(){var n=this;console.log(o),"2"==this.$data.dataType||"4"==this.$data.dataType?t.request({url:"http://192.168.1.26:5001/StockActivityIn/GetStockActivityInList",data:{IsFinish:!0,Token:o},method:"GET",success:function(t){if(200==t.statusCode){console.log("IN"),console.log(t);var e=n.setTime(t.data.Data);n.listData=e,n.total=n.listData.length,console.log(n.listData)}},fail:function(t,n){console.log("fail"+JSON.stringify(t))}}):t.request({url:"http://192.168.1.26:5001/StockActivityOut/GetStockActivityOutList",data:{IsFinish:!0,Token:o},method:"GET",success:function(t){if(200==t.statusCode){console.log("Out"),console.log(t);var e=n.setTime(t.data.Data);n.listData=e,n.total=n.listData.length,console.log(n.listData)}},fail:function(t,n){console.log("fail"+JSON.stringify(t))}})},setTime:function(t){var n=[];return t.forEach((function(t){n.push({Stock_Activity_Id:t.Stock_Activity_Id,Stock_Activity_No:t.Stock_Activity_No,Bill_No:t.Bill_No,Bill_note:t.Warehouse_Name+" "+t.Bill_Type_Name+" "+t.Stock_Activity_Date})})),n},format:function(t){var n=this.parse(t),e=Date.now()-n.getTime();if(e<this.UNITS["天"])return this.humanize(e);var i=function(t){return t<10?"0"+t:t};return n.getFullYear()+"/"+i(n.getMonth()+1)+"/"+i(n.getDate())+"-"+i(n.getHours())+":"+i(n.getMinutes())},parse:function(t){var n=t.split(/[^0-9]/);return new Date(n[0],n[1]-1,n[2],n[3],n[4],n[5])},change:function(t){console.log(t),this.current=t.current},OpenDetail:function(n){t.navigateTo({url:"../Detail/Detail?Stock_Activity_Id="+n})}}};n.default=s}).call(this,e("8adf")["default"])},d162:function(t,n,e){"use strict";e.d(n,"b",(function(){return o})),e.d(n,"c",(function(){return u})),e.d(n,"a",(function(){return i}));var i={uniNavBar:function(){return Promise.resolve().then(e.bind(null,"9f0d"))},uniList:function(){return e.e("components/uni-list/uni-list").then(e.bind(null,"82e2"))},uniListItem:function(){return e.e("components/uni-list-item/uni-list-item").then(e.bind(null,"c19e"))},uniPagination:function(){return e.e("components/uni-pagination/uni-pagination").then(e.bind(null,"eb91"))}},o=function(){var t=this,n=t.$createElement;t._self._c},u=[]}},[["9b28","common/runtime","common/vendor"]]]);