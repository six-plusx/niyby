// pages/show/show.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    name: ''
  },

  // 详细地址
  bindname: function (e) {
    this.data.name = e.detail.value;
  },

  //查询
  queryBooks: function (e) {
    var that = this;
    wx.request({
      url: 'http://localhost:49590/api/Search/GetSumBooksSelects',
      data: { names: this.data.name },
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
    var that = this;
    wx.request({
      url: 'http://localhost:49590/api/Search/GetBooksSelects',
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

  }
})