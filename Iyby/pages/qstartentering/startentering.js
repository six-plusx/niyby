// pages/startentering/startentering.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    EwmsChecked:false,
    continuousChecked:true

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

  },

//连续录入
  continuousInput: function (e) {
    var that = this;
    console.log(e.detail.value);
    if (e.detail.value == true) {
      that.setData({
        EwmsChecked: false,
        continuousChecked: true
      })
    }
    else {
      that.setData({
        EwmsChecked: true,
        continuousChecked: false
      })
    }
  },

//扫码录入
  EwmsInput:function(e){
    var that=this;
    if (e.detail.value==true){
      that.setData({
        EwmsChecked: true,
        continuousChecked: false
      })
    }
    else{
      that.setData({
        EwmsChecked: false,
        continuousChecked: true
      })
    }
    
  },

})














