// pages/address/address.js
const api = require('../../utils/api.js');

Page({

  /**
   * 页面的初始数据
   */
  data: {
    region: ['北京市', '北京市', '东城区'],//省市区，默认值
    inputsite: '',//地址
    inputperson: '',//联系人
    inputphone: '',//联系电话
    switchloc:true,//是否选中
    popErrorMsg:''//错误提示信息
  },

  // 省市区--显示选择的路径
  bindRegionChange: function (e) {
    this.setData({
      region: e.detail.value
    })
  },

  // 详细地址
  bindsite:function(e) {
    this.data.inputsite = e.detail.value;
  },

  // 联系人
  bindperson(e) {
    this.data.inputperson=e.detail.value;
  },

  // 联系电话
  bindphone(e) {
    this.data.inputphone=e.detail.value;
  },

  // 默认的状态
  switchChange:function(e){
    this.data.switchloc=e.detail.value;
  },

  // 保存按钮
  bindbtn: function (e) {
    console.log("详细地址" + this.data.inputsite)
    if (this.data.inputsite == '') {
      setTimeout(() => {
        this.setData(
          { popErrorMsg: "请输入详细地址" }
        );
        this.ohShitfadeOut();
      }, 100)
      return;
    }

    console.log("联系人：" + this.data.inputperson)
    if (this.data.inputperson =='') {
      setTimeout(() => {
        console.log("联系人：" + this.data.inputperson)
          this.setData(
            { popErrorMsg: "请输入联系人" }
          );
          this.ohShitfadeOut();
      }, 100)
      return;
    }

    console.log("手机号：" + this.data.inputphone)
    if (this.data.inputphone == '') {
      setTimeout(() => {
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
      var phoneVar = reg.test(this.data.inputphone);     // 得到的值为布尔型
      if (phoneVar==false) {
        setTimeout(() => {
          this.setData(
            { popErrorMsg: "手机号格式不正确" }
          );
          this.ohShitfadeOut();
        }, 100)
        return;
      }
    }
    console.log('验证结束');

    var that = this;
    wx.request({
      url: api.API_HOST + '/ZAddress/Add',
      method: 'GET',
      data:{
        area: this.data.region,
        loction: this.data.inputsite,
        consignee: this.data.inputperson,
        photo: this.data.inputphone,
        defaultLoc: this.data.switchloc,
      },
      success: function (res) {
        if(res=1)
        {
          wx.showToast({
            title: '成功',
            icon: 'success',
            duration: 1000
          })
        }
        else
        {
          wx.showToast({
            title: '保存失败',
            icon: 'fail',
            duration: 1000
          })
          return;
        }        
      }
    })

   

    //1秒后跳转
    setTimeout(function () {
      wx.reLaunch({
        url: '../zsite/site',
      })
    }, 1000)
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