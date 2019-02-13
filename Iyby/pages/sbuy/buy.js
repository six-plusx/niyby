// pages/appointment/appointment.js
Page({

  /**
   * 页面的初始数据
   */
  data: {

  },

  //加载界面数据begin
  onShow: function (options) {
    var that = this;
    wx.getStorage({
      key: 'username',
      success: function (res) {

        wx.getStorage({
          key: 'token',
          success: function (data) {
            wx.request({
              url: 'http://localhost:49590/api/Sappointment/GetClassifications',
              method: 'GET',
              header: {
                'content-type': 'application/json',
                'Authorization': 'BasicAuth ' + data.data
              },
              success: function (res) {
                console.log(res)
                that.setData({
                  hasList: true,
                  carts: res.data
                })
              }
            })
          }
        })
      },
      fail: function (res) { },
      complete: function (res) { },
    }),
      this.getTotalPrice();
  },

  //输入查询信息
  inputChange() {

  },

  //查询
  queryBooks: function () {

  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {

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