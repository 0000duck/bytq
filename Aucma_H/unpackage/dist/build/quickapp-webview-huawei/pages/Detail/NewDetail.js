(global["webpackJsonp"]=global["webpackJsonp"]||[]).push([["pages/Detail/NewDetail"],{1318:function(t,n,i){"use strict";(function(t){Object.defineProperty(n,"__esModule",{value:!0}),n.default=void 0;var e,o=function(){i.e("components/uni-collapse/uni-collapse").then(function(){return resolve(i("54c5"))}.bind(null,i)).catch(i.oe)},a=function(){i.e("components/uni-collapse-item/uni-collapse-item").then(function(){return resolve(i("ca61"))}.bind(null,i)).catch(i.oe)},c=function(){Promise.all([i.e("common/vendor"),i.e("components/uni-popup/uni-popup")]).then(function(){return resolve(i("ff31"))}.bind(null,i)).catch(i.oe)},s=function(){i.e("components/uni-popup/uni-popup-message").then(function(){return resolve(i("9bf6"))}.bind(null,i)).catch(i.oe)},u=function(){i.e("components/uni-popup/uni-popup-dialog").then(function(){return resolve(i("4a32"))}.bind(null,i)).catch(i.oe)},l={components:{uniCollapse:o,uniCollapseItem:a,uniPopup:c,uniPopupMessage:s,uniPopupDialog:u},onLoad:function(t){this.$data.stackid=t.Stock_Activity_Id,this.getList()},data:function(){return e=t.getStorageSync("userInfo").ApiToken,{message:"",active:0,listMenu:[{title:"修改数量"},{title:"修改批次"},{title:"审核提交"}],btnName:"提交",items:["基本明细","批次明细","扫码明细"],current:0,content:"",opername:"增加",stackid:"",dataType:getApp().globalData.SelType,operid:1,AcQtyIndex:0,AcQty:0,basiclist:[],batchlist:[],scanlist:[],maindata:{},barcode:"RK1-10101002-20201201",listData:[]}},methods:{SaveNumber:function(){var n=this,i=this.$data.maindata;i.Token=e,t.request({url:"http://192.168.1.26:5001/StockActivityIn/SaveForm",data:i,method:"POST",success:function(t){200==t.statusCode&&(console.log(t),n.active+=1)},fail:function(t,n){console.log("fail"+JSON.stringify(t))}})},BackStep:function(){this.active-=1},SaveBatch:function(){},onClickItem:function(t){this.current!==t.currentIndex&&(this.current=t.currentIndex)},changeState:function(){1==this.$data.operid?(this.$data.opername="删除",this.$data.operid=0):(this.$data.opername="增加",this.$data.operid=1)},getList:function(){var n=this;console.log(e),t.request({url:"http://192.168.1.26:5001/StockActivityIn/GetForm",data:{orderId:this.$data.stackid},method:"GET",success:function(t){200==t.statusCode&&(console.log(t),n.maindata=t.data.Data,n.basiclist=t.data.Data.StockDetailList,n.batchlist=t.data.Data.StockRecordList,n.scanlist=t.data.Data.StockScanList,t.data.Data.Is_Check?n.btnName="撤销":n.btnName="提交",console.log(n.basiclist),console.log(n.batchlist),console.log(n.scanlist))},fail:function(t,n){console.log("fail"+JSON.stringify(t))}})},openMesPuop:function(t){0==this.$data.active?(console.log(t),this.$data.AcQtyIndex=t,this.$data.AcQty=this.$data.maindata.StockDetailList[t].Qty,this.$refs.dialogInput.open()):(this.message="不能修改明细数量",this.$refs.popupMessage.open())},PriBarCode:function(){var n=this,i=this.$data.barcode;console.log(i),console.log(this.$data.maindata.Stock_Activity_Id),t.request({url:"http://192.168.1.26:5001/StockActivityIn/SaveScan",data:{OperTypeId:this.$data.operid,Stock_Activity_Id:this.$data.maindata.Stock_Activity_Id,BarCode:i,Token:e},method:"GET",success:function(t){200==t.statusCode&&(console.log(t),0==t.data.Data.Tag||n.getList())},fail:function(t,n){console.log("fail"+JSON.stringify(t))}})},dialogInputConfirm:function(n,i){/(^[1-9]\d*$)/.test(i)?(this.$data.maindata.StockDetailList[this.$data.AcQtyIndex].Qty=i,this.$data.basiclist[this.$data.AcQtyIndex].Qty=i,console.log(this.$data.AcQtyIndex),console.log(this.$data.basiclist),n()):(t.showLoading({title:"输入的内容不是数字"}),setTimeout((function(){t.hideLoading()}),1e3))},SaveForm:function(){console.log("111");var n=this.$data.maindata;n.Token=e,console.log(n),t.request({url:"http://192.168.1.26:5001/StockActivityIn/SaveForm",data:n,method:"POST",success:function(t){200==t.statusCode&&console.log(t)},fail:function(t,n){console.log("fail"+JSON.stringify(t))}})},openPopup:function(){this.maindata.Is_Check?this.content="确定撤回单据号为【"+this.maindata.Stock_Activity_No+"】的申请吗？":this.content="确定提交单据号为【"+this.maindata.Stock_Activity_No+"】的申请吗？",this.$refs.popupDialog.open()},dialogConfirm:function(n,i){var o=this;console.log("点击确认"),n(),t.request({url:"http://192.168.1.26:5001/StockActivityIn/StockActivityInApprove",data:{Stock_Activity_Id:this.$data.stackid,Is_forward:!0,Token:e},method:"GET",success:function(t){200==t.statusCode&&(console.log(t),"1"==t.data.Tag&&o.getList())},fail:function(t,n){console.log("fail"+JSON.stringify(t))}})},dialogClose:function(t){t()},BackAC:function(){this.active<=this.listMenu.length-1&&(this.active-=1)},NextAC:function(){this.active<this.listMenu.length-1&&(this.active+=1)}}};n.default=l}).call(this,i("8adf")["default"])},"3cba":function(t,n,i){"use strict";i.r(n);var e=i("f15d"),o=i("4bc0");for(var a in o)"default"!==a&&function(t){i.d(n,t,(function(){return o[t]}))}(a);i("7c09");var c,s=i("f0c5"),u=Object(s["a"])(o["default"],e["b"],e["c"],!1,null,"f492e7d2",null,!1,e["a"],c);n["default"]=u.exports},"4bc0":function(t,n,i){"use strict";i.r(n);var e=i("1318"),o=i.n(e);for(var a in e)"default"!==a&&function(t){i.d(n,t,(function(){return e[t]}))}(a);n["default"]=o.a},"7c09":function(t,n,i){"use strict";var e=i("c5c3"),o=i.n(e);o.a},bc7a:function(t,n,i){"use strict";(function(t){i("588f");e(i("66fd"));var n=e(i("3cba"));function e(t){return t&&t.__esModule?t:{default:t}}t(n.default)}).call(this,i("8adf")["createPage"])},c5c3:function(t,n,i){},f15d:function(t,n,i){"use strict";i.d(n,"b",(function(){return o})),i.d(n,"c",(function(){return a})),i.d(n,"a",(function(){return e}));var e={uniNavBar:function(){return i.e("components/uni-nav-bar/uni-nav-bar").then(i.bind(null,"9f0d"))},uniSteps:function(){return i.e("components/uni-steps/uni-steps").then(i.bind(null,"67c5"))},uniCollapse:function(){return i.e("components/uni-collapse/uni-collapse").then(i.bind(null,"54c5"))},uniCollapseItem:function(){return i.e("components/uni-collapse-item/uni-collapse-item").then(i.bind(null,"ca61"))},uniList:function(){return i.e("components/uni-list/uni-list").then(i.bind(null,"82e2"))},uniListItem:function(){return i.e("components/uni-list-item/uni-list-item").then(i.bind(null,"c19e"))},uniPopup:function(){return Promise.all([i.e("common/vendor"),i.e("components/uni-popup/uni-popup")]).then(i.bind(null,"ff31"))}},o=function(){var t=this,n=t.$createElement;t._self._c},a=[]}},[["bc7a","common/runtime","common/vendor"]]]);