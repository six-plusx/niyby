// pages/qaddbooks/qaddbooks.js
const api = require('../../utils/api.js');

Page({

  /**
   * 页面的初始数据
   */
  data: {
    id: '',//id
    state:'',//状态
    popErrorMsg: ''
  },

  //确认预约
  closing1: function () {
    wx.showToast({
      title: '预约成功',
      icon: 'success',
      duration: 1000
    })

    //1秒后跳转
    setTimeout(function () {
      wx.reLaunch({
        url: '../zappointment/appointment',
      })
    }, 1000)
    wx.switchTab({
      url: '../zappointment/appointment',
    })
  },

  //确认购买
  closing2: function () {
    wx.showToast({
      title: '购买成功',
      icon: 'success',
      duration: 1000
    })

    //1秒后跳转
    setTimeout(function () {
      wx.reLaunch({
        url: '../sbuy/buy',
      })
    }, 1000)
    wx.switchTab({
      url: '../sbuy/buy',
    })
  },

  //错误提示方法
  ohShitfadeOut() {
    var fadeOutTimeout = setTimeout(() => {
      this.setData({ popErrorMsg: '' });
      clearTimeout(fadeOutTimeout);
    }, 3000);
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    this.data.id = parseInt(options.id);
    console.log("传递进来的(要结算的图书)ID：" + this.data.id);
    this.data.state = parseInt(options.state);
    console.log("传递进来的(要结算的图书)状态：" + this.data.state);

    var that = this;
    wx.request({
      url: api.API_HOST + '/Zappointment/GetBooksById?id=' + this.data.id,
      method: 'get',
      success: function (res) {
        that.setData({
          hasList: true,
          carts: res.data
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

  // 跳转到确定录入图书页面
  closing3:function(){
  }
})