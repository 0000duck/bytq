(global["webpackJsonp"]=global["webpackJsonp"]||[]).push([["pages/Detail/InDetail"],{"2e29":function(t,n,e){"use strict";var o=e("599f"),i=e.n(o);i.a},"4cc7":function(t,n,e){"use strict";e.r(n);var o=e("f014"),i=e.n(o);for(var a in o)"default"!==a&&function(t){e.d(n,t,(function(){return o[t]}))}(a);n["default"]=i.a},"599f":function(t,n,e){},"66f4":function(t,n,e){"use strict";e.d(n,"b",(function(){return i})),e.d(n,"c",(function(){return a})),e.d(n,"a",(function(){return o}));var o={uniNavBar:function(){return e.e("components/uni-nav-bar/uni-nav-bar").then(e.bind(null,"9f0d"))},uniSteps:function(){return e.e("components/uni-steps/uni-steps").then(e.bind(null,"67c5"))},uniSegmentedControl:function(){return e.e("components/uni-segmented-control/uni-segmented-control").then(e.bind(null,"8185"))},uniCollapse:function(){return e.e("components/uni-collapse/uni-collapse").then(e.bind(null,"54c5"))},uniCollapseItem:function(){return e.e("components/uni-collapse-item/uni-collapse-item").then(e.bind(null,"ca61"))},uniList:function(){return e.e("components/uni-list/uni-list").then(e.bind(null,"82e2"))},uniListItem:function(){return e.e("components/uni-list-item/uni-list-item").then(e.bind(null,"c19e"))},uniPopup:function(){return Promise.all([e.e("common/vendor"),e.e("components/uni-popup/uni-popup")]).then(e.bind(null,"ff31"))}},i=function(){var t=this,n=t.$createElement;t._self._c},a=[]},"688f":function(t,n,e){"use strict";(function(t){e("588f");o(e("66fd"));var n=o(e("a487"));function o(t){return t&&t.__esModule?t:{default:t}}t(n.default)}).call(this,e("8adf")["createPage"])},a487:function(t,n,e){"use strict";e.r(n);var o=e("66f4"),i=e("4cc7");for(var a in i)"default"!==a&&function(t){e.d(n,t,(function(){return i[t]}))}(a);e("2e29");var c,s=e("f0c5"),u=Object(s["a"])(i["default"],o["b"],o["c"],!1,null,"7d276b38",null,!1,o["a"],c);n["default"]=u.exports},f014:function(t,n,e){"use strict";(function(t){Object.defineProperty(n,"__esModule",{value:!0}),n.default=void 0;var o,i=function(){e.e("components/uni-collapse/uni-collapse").then(function(){return resolve(e("54c5"))}.bind(null,e)).catch(e.oe)},a=function(){e.e("components/uni-collapse-item/uni-collapse-item").then(function(){return resolve(e("ca61"))}.bind(null,e)).catch(e.oe)},c=function(){Promise.all([e.e("common/vendor"),e.e("components/uni-popup/uni-popup")]).then(function(){return resolve(e("ff31"))}.bind(null,e)).catch(e.oe)},s=function(){e.e("components/uni-popup/uni-popup-message").then(function(){return resolve(e("9bf6"))}.bind(null,e)).catch(e.oe)},u=function(){e.e("components/uni-popup/uni-popup-dialog").then(function(){return resolve(e("4a32"))}.bind(null,e)).catch(e.oe)},l={components:{uniCollapse:i,uniCollapseItem:a,uniPopup:c,uniPopupMessage:s,uniPopupDialog:u},onLoad:function(t){this.$data.stackid=t.Stock_Activity_Id,this.getList()},data:function(){return o=t.getStorageSync("userInfo").ApiToken,{message:"",active:0,listMenu:[{title:"修改数量"},{title:"修改批次"},{title:"审核提交"}],btnName:"提交",items:["基本明细","批次明细","扫码明细"],current:0,content:"",opername:"增加",stackid:"",dataType:getApp().globalData.SelType,operid:1,AcQtyIndex:0,AcQty:0,basiclist:[],batchlist:[],scanlist:[],maindata:{},barcode:"RK1-10101002-20201201",listData:[]}},methods:{onClickItem:function(t){this.current!==t.currentIndex&&(this.current=t.currentIndex)},changeState:function(){1==this.$data.operid?(this.$data.opername="删除",this.$data.operid=0):(this.$data.opername="增加",this.$data.operid=1)},getList:function(){var n=this;console.log(o),t.request({url:"http://192.168.1.26:5001/StockActivityIn/GetForm",data:{orderId:this.$data.stackid},method:"GET",success:function(t){200==t.statusCode&&(console.log(t),n.maindata=t.data.Data,n.basiclist=t.data.Data.StockDetailList,n.batchlist=t.data.Data.StockRecordList,n.scanlist=t.data.Data.StockScanList,t.data.Data.Is_Check?n.btnName="撤销":n.btnName="提交",console.log(n.basiclist),console.log(n.batchlist),console.log(n.scanlist))},fail:function(t,n){console.log("fail"+JSON.stringify(t))}})},openMesPuop:function(t){0==this.$data.active?(console.log(t),this.$data.AcQtyIndex=t,this.$data.AcQty=this.$data.maindata.StockDetailList[t].Qty,this.$refs.dialogInput.open()):(this.message="不能修改明细数量",this.$refs.popupMessage.open())},PriBarCode:function(){var n=this,e=this.$data.barcode;console.log(e),console.log(this.$data.maindata.Stock_Activity_Id),t.request({url:"http://192.168.1.26:5001/StockActivityIn/SaveScan",data:{OperTypeId:this.$data.operid,Stock_Activity_Id:this.$data.maindata.Stock_Activity_Id,BarCode:e,Token:o},method:"GET",success:function(t){200==t.statusCode&&(console.log(t),0==t.data.Data.Tag||n.getList())},fail:function(t,n){console.log("fail"+JSON.stringify(t))}})},dialogInputConfirm:function(n,e){/(^[1-9]\d*$)/.test(e)?(this.$data.maindata.StockDetailList[this.$data.AcQtyIndex].Qty=e,this.$data.basiclist[this.$data.AcQtyIndex].Qty=e,console.log(this.$data.AcQtyIndex),console.log(this.$data.basiclist),n()):(t.showLoading({title:"输入的内容不是数字"}),setTimeout((function(){t.hideLoading()}),1e3))},SaveForm:function(){console.log("111");var n=this.$data.maindata;n.Token=o,console.log(n),t.request({url:"http://192.168.1.26:5001/StockActivityIn/SaveForm",data:n,method:"POST",success:function(t){200==t.statusCode&&console.log(t)},fail:function(t,n){console.log("fail"+JSON.stringify(t))}})},openPopup:function(){this.maindata.Is_Check?this.content="确定撤回单据号为【"+this.maindata.Stock_Activity_No+"】的申请吗？":this.content="确定提交单据号为【"+this.maindata.Stock_Activity_No+"】的申请吗？",this.$refs.popupDialog.open()},dialogConfirm:function(n,e){var i=this;console.log("点击确认"),n(),t.request({url:"http://192.168.1.26:5001/StockActivityIn/StockActivityInApprove",data:{Stock_Activity_Id:this.$data.stackid,Is_forward:!0,Token:o},method:"GET",success:function(t){200==t.statusCode&&(console.log(t),"1"==t.data.Tag&&i.getList())},fail:function(t,n){console.log("fail"+JSON.stringify(t))}})},dialogClose:function(t){t()}}};n.default=l}).call(this,e("8adf")["default"])}},[["688f","common/runtime","common/vendor"]]]);