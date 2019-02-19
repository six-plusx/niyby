//app.js
const api = require('utils/api.js');

  App({
    onLaunch: function () {
      wx.getSystemInfo({
        success: function (res) {
          this.globalData.window_width = res.windowWidth;
          this.globalData.window_height = res.windowHeight;
        }.bind(this)
      });
      wx.login({
        success: function (res) {
          console.log(res.code)
          if (res.code) {
            wx.request({
              url: api.API_HOST + '/ZAddress/Login',
              data: {
                code: res.code
              },
              success: function (res) {
                var set = wx.setStorage({
                  key: 'token',
                  data: res.data.session_key,
                  success: function (res) {

                  },
                  fail: function (res) { },
                  complete: function (res) { },
                })
                console.log(res)
              }
            })
          }
          /*
          wx.getUserInfo({
            success: function (res) {
             console.log(res)
             var set=wx.setStorage({
               key: 'username',
               data: res.userInfo.nickName,
               success: function(res) {
                 
               },
               fail: function(res) {
                 wx.showModal({
                   title: '提示',
                   content: '拒绝授权可能会影响部分功能使用，请设置授权',
                   confirmText: '去设置',
                   success:res=>{
                     if(res.confirm)
                     {
                        wx.openSetting({
                          
                        })
                     }
                   }
                 })
               },
               complete: function(res) {},
             })
            }
          })*/
        }
      })
    },

    globalData: {
      nickName: "",
      window_width: 0,
      window_height: 0
    }
  })
