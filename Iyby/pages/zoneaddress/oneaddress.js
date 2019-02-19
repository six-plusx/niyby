// pages/zoneaddress/oneaddress.js
const api = require('../../utils/api.js');

Page({

  /**
   * 页面的初始数据
   */
  data: {
    id:0,
    region: ['', '', ''],//省市区，默认值
    popErrorMsg: ''
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    this.data.id = parseInt(options.id);
    var i=this.data.id;
    console.log("传递进来的(要查询的收货地址)ID：" + this.data.id);
    var that = this;
    wx.getStorage({
      key: 'token',
      success: function (res) {
        wx.request({
          url: api.API_HOST + '/ZAddress/GetAddressesByid?id=' +i,
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
          title: '提示',
          content: '请登录后使用',
          success: function (sm) {
            if (sm.confirm) {//确定登录

            }
            else {
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

  // 省市区--显示选择的路径
  bindRegionChange: function (e) {
    this.setData({
      region: e.detail.value
    })
  },

  // 保存按钮
  formSubmit: function (e) {
    // 地址
    var region
    if (this.data.region == ',,') {
      region = e.currentTarget.dataset.dizi;//获取显示界面的Id值
      console.log('旧'+region);
    }
    else {
      region = this.data.region;
      console.log('新'+region);
    }
    // 详细地址
    var inputsite = e.detail.value.inputxxdz;
    // 联系人
    var inputperson = e.detail.value.inputlxr;
    // 电话
    var inputphone = e.detail.value.inputlxdh;
    // 默认
    var switchloc = e.detail.value.delivery_is_default;  
    
    console.log("详细地址" + inputsite)
    if (inputsite == '') {
      setTimeout(() => {
        this.setData(
          { popErrorMsg: "请输入详细地址 " }
        );
        this.ohShitfadeOut();
      }, 100)
      return;
    }

    console.log("联系人：" + inputperson)
    if (inputperson == '') {
      setTimeout(() => {
        this.setData(
          { popErrorMsg: "请输入联系人" }
        );
        this.ohShitfadeOut();
      }, 100)
      return;
    }

    console.log("手机号：" + inputphone)
    if (inputphone == '') {
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
      var phoneVar = reg.test(inputphone);     // 得到的值为布尔型
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
    console.log('验证通过');
    var i = this.data.id;

    var that = this;
    wx.getStorage({ // 从微信的缓存中通过key取值
      key:'token',
      success:function(res){ 
        wx.request({
          url: api.API_HOST + '/ZAddress/Update',
          method: 'GET',
          data: {
            id: i,
            area: region,
            loction: inputsite,
            consignee: inputperson,
            photo: inputphone,
            defaultLoc: switchloc,
          },
          header: { // 执行request函数之前先包头
            'content-type': 'application/json',
            'Authorization': 'BasicAuth ' + res.data
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
      }
    })
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
          wx.getStorage({
            key: 'token',
            success: function(res) {
              wx.request({
                url: api.API_HOST + '/ZAddress/Delete?id=' + e.currentTarget.dataset.aid,
                method: 'GET',
                header: {
                  'content-type': 'application/json',
                  'Authorization': 'BasicAuth ' + res.data
                },
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
            },
          })          
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