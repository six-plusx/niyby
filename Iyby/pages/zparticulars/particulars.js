// pages/zparticulars/particulars.js
const api = require('../../utils/api.js');

Page({

  /**
   * 页面的初始数据
   */
  data: {

    showtab: 0,  //顶部选项卡索引
    showtabtype: '', //选中类型
    tabnav: {},  //顶部选项卡数据
    testdata1: [], //数据列表
    testdata2: [], //数据列表
    testdata3: [], //数据列表
    startx: 0,  //开始的位置x
    endx: 0, //结束的位置x
    critical: 100, //触发切换标签的临界值
    marginleft: 0,  //滑动距离
    typeid: 0,//选中类型
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    this.setData({
      tabnav: {
        tabnum: 3,
        tabitem: [
          {
            "id": 1,
            "type": "A",
            "text": "目录"
          },
          {
            "id": 2,
            "type": "B",
            "text": "内容简介"
          },
          {
            "id": 3,
            "type": "C",
            "text": "图书评价"
          },
        ]
      },
    })
    this.fetchTabData(0);


    var id = parseInt(options.id);
    console.log("传递进来的(要查询的预约图书)ID：" + id);
    var that=this;
    wx.getStorage({
      key: 'token',
      success: function(res) {
        wx.request({
          url: api.API_HOST + '/Zappointment/GetBooksById?id=' + id,
          method: 'get',
          header: {
            'content-type': 'application/json',
            'Authorization': 'BasicAuth ' + res.data
          },
          success: function (res) {
            that.setData({
              hasList: true,
              carts: res.data
            })
          }
        })
      },
    })    
  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {

  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {

  },




  fetchData: function (typeid) {  //查询数据
    const newquestions = [];
    for (let i = 0; i < 20; i++) {
      newquestions.push({
        "id": i + 1,
        "type": typeid,
        "text": "服务名称适用品类服务实施详情服务期限服务生效时间摔碰管修一年笔记本本服务有效期内，如客户的数码摄照产品在正常使用过程中由于不慎将产品坠落、挤压、碰撞，而产生的硬件故障，本服务将免费提供硬件维修或更换，使产品重新恢复正常运行。12个月购机满30天后开始生效摔碰管修两年笔记本、数码相机、摄像机、手机、小数码"
      })
    }
    return newquestions
  },
  fetchTabData: function (i) {
    console.log(Number(i));
    switch (Number(i)) {
      case 0:
        this.setData({
          testdata1: this.fetchData('A')
        })
        break;
      case 1:
        this.setData({
          testdata2: this.fetchData('B')
        })
        break;
      case 2:
        this.setData({
          testdata3: this.fetchData('C')
        })
        break;
      default:
        return;
    }
  },
  fetchTabData: function (i) {
    this.data.typeid = Number(i);//将类别id放到全局变量
    console.log(this.data.typeid); //输出要查询的类别id
    testdata1: this.fetchData(this.data.typeid);
  },
  setTab: function (e) { //设置选项卡选中索引
    const edata = e.currentTarget.dataset;
    this.setData({
      showtab: Number(edata.tabindex),
      showtabtype: edata.type
    })
    this.fetchTabData(edata.tabindex);
  },
  scrollTouchstart: function (e) {
    let px = e.touches[0].pageX;
    this.setData({
      startx: px
    })
  },
  scrollTouchmove: function (e) {
    let px = e.touches[0].pageX;
    let d = this.data;
    this.setData({
      endx: px,
    })
    if (px - d.startx < d.critical && px - d.startx > -d.critical) {
      this.setData({
        marginleft: px - d.startx
      })
    }
  },
  scrollTouchend: function (e) {
    let d = this.data;
    if (d.endx - d.startx > d.critical && d.showtab > 0) {
      this.setData({
        showtab: d.showtab - 1,
      })
      // this.fetchTabData(d.showtab-1);
    } else if (d.endx - d.startx < -d.critical && d.showtab < this.data.tabnav.tabnum - 1) {
      this.setData({
        showtab: d.showtab + 1,
      })
    }
    this.fetchTabData(d.showtab);
    this.setData({
      startx: 0,
      endx: 0,
      marginleft: 0
    })
  },

    //吸附事件
  onPageScroll: function (e) {
    var that = this
    that.setData({
      scrollTop: e.scrollTop
    })
  },

  // 进入结算界面--开始预约
  closing1:function(e){
    wx.navigateTo({
      url: '../zclosing/closing?id=' + e.currentTarget.dataset.aid+'&state='+1
    })
  },
   // 进入结算界面--开始购买
  closing2: function (e) {
    wx.navigateTo({
      url: '../zclosing/closing?id=' + e.currentTarget.dataset.aid + '&state=' + 2
    })
  },
   // 进入结算界面--开始上架
  closing3: function (e) {
    wx.navigateTo({
      url: '../zclosing/closing'
    })
  }
})