// pages/address/address.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    region: ['北京市', '北京市', '东城区'],//省市区，默认值
    inputsite: '',//地址
    inputperson: '',//联系人
    inputphone: '',//联系电话
    popErrorMsg:''
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
  bindbtn: function (e) {
    if (this.inputsite == undefined) {
      setTimeout(() => {
        console.log("详细地址" + this.inputsite)
        this.setData(
          { popErrorMsg: "请输入详细地址" }
        );
        this.ohShitfadeOut();
      }, 100)
      return;
    }

    if (this.inputperson ==undefined) {
      setTimeout(() => {
        console.log("联系人：" + this.inputperson)
          this.setData(
            { popErrorMsg: "请输入联系人" }
          );
          this.ohShitfadeOut();
      }, 100)
      return;
    }

    if (this.inputphone == undefined) {
      setTimeout(() => {
        console.log("手机号：" + this.inputphone) 
        this.setData(
          { popErrorMsg: "请输入手机号码" }
        );
        this.ohShitfadeOut();
        return;
      }, 100)
      return;
    }
    else {
      var reg = new RegExp('^(13[0-9]|14[579]|15[0-3,5-9]|16[6]|17[0135678]|18[0-9]|19[89])\\d{8}$');
      var phoneVar = reg.test(this.inputphone);     // 得到的值为布尔型
      if (phoneVar==true) {
        setTimeout(() => {
          console.log("手机号格式不正确") 
          this.setData(
            { popErrorMsg: "手机号格式不正确" }
          );
          this.ohShitfadeOut();
        }, 100)
        return;
      }
    }

    console.log('验证结束');
  },

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