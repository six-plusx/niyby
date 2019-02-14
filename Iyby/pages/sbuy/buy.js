// pages/appointment/appointment.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    name: '',

    showtab: 0,  //顶部选项卡索引
    showtabtype: '', //选中类型
    tabnav: {},  //顶部选项卡数据
    testdataall: [],  //所有数据
    testdata1: [], //数据列表
    testdata2: [], //数据列表
    testdata3: [], //数据列表
    testdata4: [], //数据列表
    testdata5: [], //数据列表
    startx: 0,  //开始的位置x
    endx: 0, //结束的位置x
    critical: 100, //触发切换标签的临界值
    marginleft: 0,  //滑动距离
    typeid: 0,//选中类型
  },

  // 详细地址
  bindname: function (e) {
    this.data.name = e.detail.value;
  },

  //查询
  queryBooks: function (e) {
    var that = this;
    wx.request({
      url: 'http://localhost:49590/api/Sappointment/GetSumBooksSelects',
      data: {
        names: this.data.name,
        typeid: this.data.typeid,
      },
      method: 'GET',
      success: function (res) {
        that.setData({
          hasList: true,
          carts: res.data
        })
      }
    })
  },

  navigatordetails: function (e) {
    var id = e.currentTarget.dataset.aid;//获取显示界面的Id值
    wx.navigateTo({
      url: '../zparticulars/particulars?id=' + e.currentTarget.dataset.aid
    })
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    this.setData({
      tabnav: {
        tabnum: 5,
        tabitem: [
          {
            "id": 1,
            "type": "A",
            "text": "教育类"
          },
          {
            "id": 2,
            "type": "B",
            "text": "文学类"
          },
          {
            "id": 3,
            "type": "C",
            "text": "科学类"
          },
          {
            "id": 4,
            "type": "D",
            "text": "历史类"
          },
          {
            "id": 5,
            "type": "E",
            "text": "小说类"
          },
        ]
      },
    })
    this.fetchTabData(0);


    var that = this;
    wx.request({
      url: 'http://localhost:49590/api/Sappointment/GetBooksSelects',
      method: 'GET',
      success: function (allres) {
        that.setData({
          hasList: true,
          carts: allres.data
        })
      }
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




  fetchData: function (typeid) {  //查询数据
    var that = this;
    wx.request({
      url: 'http://localhost:49590/api/Sappointment/GetSumBooksSelects',
      data: {
        names: this.data.name,
        typeid: typeid,
      },
      method: 'GET',
      success: function (res) {
        that.setData({
          hasList: true,
          carts: res.data
        })
      }
    })
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

})