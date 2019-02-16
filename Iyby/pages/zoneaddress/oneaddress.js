// pages/zoneaddress/oneaddress.js
const api = require('../../utils/api.js');

Page({

  /**
   * 页面的初始数据
   */
  data: {
    id:0,
    region: ['', '', ''],//省市区，默认值
    inputsite: '',//地址
    inputperson: '',//联系人
    inputphone: '',//联系电话
    switchloc:true,
    popErrorMsg: ''
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    this.data.id = parseInt(options.id);
    console.log("传递进来的(要查询的收货地址)ID：" + this.data.id);
    var that = this;
    wx.request({
      url: api.API_HOST + '/ZAddress/GetOneAddresses?id=' + this.data.id,
      method: 'get',
      success: function (res) {
        that.setData({
          hasList: true,
          carts: res.data
        })
        // this.setData({
        //   region : res.data[0].Area,
        //   inputsite : res.data[0].Loction,
        //   inputperson : res.data[0].Consignee,
        //   inputphone : res.data[0].Photo
        //  })
        // this.data.region = res.data[0].Area,
        //   this.data.inputsite = res.data[0].Loction,
        //   this.data.inputperson = res.data[0].Consignee,
        //   this.data.inputphone = res.data[0].Photo

        // console.log("：" + res.data[0].Area),
        //   console.log("：" + res.data[0].Loction),
        //   console.log("：" + res.data[0].Loction),
        //   console.log("：" + res.data[0].Photo)
      }
    })
  },

  // 省市区--显示选择的路径
  bindRegionChange: function (e) {
    this.setData({
      region: e.detail.value
    })
  },

  // 详细地址
  bindsite: function (e) {
    this.data.inputsite = e.detail.value;
  },

  // 联系人
  bindperson(e) {
    this.data.inputperson = e.detail.value;
  },

  // 联系电话
  bindphone(e) {
    this.data.inputphone = e.detail.value;
  },

  // 默认的状态
  switchChange: function (e) {
    this.data.switchloc = e.detail.value;
  },

  // 表单取值
  formSubmit: function (e) {
    // 地址
    this.data.region = e.detail.value.blockdz;
    // 详细地址
    this.data.inputsite = e.detail.value.inputxxdz;
    // 联系人
    this.data.inputperson = e.detail.value.inputlxr;
    // 电话
    this.data.inputphone = e.detail.value.inputlxdh;
    // 默认
    this.data.switchloc = e.detail.value.delivery_is_default;    
  },

  // 保存按钮
  bindbtn: function (e) {
    console.log("详细地址" + this.data.inputsite)
    if (this.data.inputsite == '') {
      setTimeout(() => {
        this.setData(
          { popErrorMsg: "请输入详细地址 " }
        );
        this.ohShitfadeOut();
      }, 100)
      return;
    }

    console.log("联系人：" + this.data.inputperson)
    if (this.data.inputperson == '') {
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
      if (phoneVar == false) {
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
      url: api.API_HOST + '/ZAddress/UpdateAddresses',
      method: 'GET',
      data: {
        id: this.data.id,
        area: this.data.region,
        loction: this.data.inputsite,
        consignee: this.data.inputperson,
        photo: this.data.inputphone,
        defaultLoc: this.data.switchloc,
      },
      success: function (res) {
        if (res = 1) {
          wx.showToast({
            title: '修改成功',
            icon: 'success',
            duration: 1000
          })
        }
        else {
          wx.showToast({
            title: '修改失败',
            icon: 'fail',
            duration: 1000
          })
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

  // 删除方法
  delbtn(e) {
    wx.showModal({
      title: '提示',
      content: '确定要删除么？',
      success:function(sm){
        if(sm.confirm){
          //用户点击了确定
          var that = this;
          wx.request({
            url: api.API_HOST + '/ZAddress/DeleteAddresses?id=' + e.currentTarget.dataset.aid,
            method: 'GET',
            success: function (res) {
              if (res = 1) {
                wx.showToast({
                  title: '删除成功',
                  icon: 'success',
                  duration: 1000
                })
              }
              else {
                wx.showToast({
                  title: '删除失败',
                  icon: 'fail',
                  duration: 1000
                })
              }
            }
          })

          //1秒后跳转
          setTimeout(function () {
            wx.reLaunch({
              url: '../zsite/site',
            })
          }, 1000)
        }
        else if (sm.cancel){
          // 用户点击了取消
          return;
        }
      }
    })    
  },

  ohShitfadeOut() {
    var fadeOutTimeout = setTimeout(() => {
      this.setData({ popErrorMsg: '' });
      clearTimeout(fadeOutTimeout);
    }, 3000);
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