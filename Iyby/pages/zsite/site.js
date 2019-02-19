// pages/site/site.js
const api = require('../../utils/api.js');

Page({

  /**
   * 页面的初始数据
   */
  data: {

  },

  // 详情
  navigatordetails: function (e) {
    var id = e.currentTarget.dataset.aid;//获取显示界面的Id值
    wx.navigateTo({
      url: '../zoneaddress/oneaddress?id=' + e.currentTarget.dataset.aid
    })
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    var that = this;
    wx.getStorage({
      key: 'token',
      success: function (res) {
        wx.request({
          url: api.API_HOST + '/ZAddress/GetAllAddresses',
          method: 'GET',
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
      fail: function (res) {
        console.log('没有登录，请登录');
        wx.showModal({
          title:'提示',
          content:'请登录后使用',
          success:function(sm){
            if(sm.confirm){//确定登录

            }
            else{
              wx.reLaunch({
                url: '../zindex/index',
              })
            }
          }
        })
      },
      complete: function (res) { },
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