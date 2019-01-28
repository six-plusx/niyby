// pages/address/address.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    region: ['北京市', '北京市', '东城区'],//省市区，默认值
    inputsite: '',//地址
    inputperson: '',//联系人
    inputphone: ''//联系电话
  },

  // 省市区--显示选择的路径
  bindRegionChange: function (e) {
    this.setData({
      region: e.detail.value
    })
  },

  // 详细地址
  bindsite(e) {
    this.setData({
      inputsite: e.detail.value
    })
  },

  // 联系人
  bindperson(e) {
    this.setData({
      inputperson: e.detail.value
    })
  },

  // 联系电话
  bindphone(e) {
    this.setData({
      inputphone: e.detail.value
    })
  },

  // 保存按钮
  bindbtn: function () {
    console.log('开始保存');
    if (inputperson == '') {
      wx.showToast({
        title: '请输入联系人',
        duration: 2000
      })
      return;
    }
    if (inputphone == '') {
      wx.showToast({
        title: '请输入手机号码',
        duration: 2000
      })
      return;
    } 
    else {
      var reg = new RegExp('^(13[0-9]|14[579]|15[0-3,5-9]|16[6]|17[0135678]|18[0-9]|19[89])\\d{8}$');
      var phoneVar = reg.test(inputphone);     // 得到的值为布尔型
      if (phoneVar) {
        wx.showToast({
          title: '手机格式不对',
          duration: 2000
        })
        return;
      }
    }

    if (inputsite == '') {
      wx.showToast({
        title: '请输入详细地址',
        duration: 2000
      })
      return;
    }
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