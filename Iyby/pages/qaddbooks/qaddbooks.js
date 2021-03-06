// pages/qaddbooks/qaddbooks.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    booknames: '',//书名
    authors: '',//作者
    prices: '',//价格
    messages: '',//出版社
    nums: '',//录入数量
    catalogues: '',//图书目录、
    states: '',//图书状态
       popErrorMsg: ''
  },

  // 书名
  bookname(e) {
    this.data.booknames = e.detail.value;
  },

  // 作者
  author(e) {
    this.data.authors = e.detail.value;
  },

  // 价格
  price(e) {
    this.data.prices = e.detail.value;
  },

  // 出版社
  message(e) {
    this.data.messages = e.detail.value;
  },

  // 录入数量
  num(e) {
    this.data.nums = e.detail.value;
  },

  //图书目录
  catalogue(e) {
    this.data.catalogues = e.detail.value;
  },

  // 图书状态
  state(e) {
    this.data.states = e.detail.value;
  },

//确认录入
  addBook:function(){
    //书名
    console.log("书名" + this.data.booknames)
    if (this.data.booknames == '') {
      setTimeout(() => {
        this.setData(
          { popErrorMsg: "请输入书名" }
        );
        this.ohShitfadeOut();
      }, 100)
      return;
    }

//作者
    if (this.data.authors == '') {
      setTimeout(() => {
        this.setData(
          { popErrorMsg: "请输入作者" }
        );
        this.ohShitfadeOut();
      }, 100)
      return;
    }
//价格
    if (this.data.prices == '') {
      setTimeout(() => {
        this.setData(
          { popErrorMsg: "请输入价格" }
        );
        this.ohShitfadeOut();
      }, 100)
      return;
    }
//出版社
    if (this.data.messages == '') {
      setTimeout(() => {
        this.setData(
          { popErrorMsg: "请输入出版社" }
        );
        this.ohShitfadeOut();
      }, 100)
      return;
    }
//录入数量
    if (this.data.nums == '') {
      setTimeout(() => {
        this.setData(
          { popErrorMsg: "请输入数量" }
        );
        this.ohShitfadeOut();
      }, 100)
      return;
    }
//图书目录
    if (this.data.catalogues == '') {
      setTimeout(() => {
        this.setData(
          { popErrorMsg: "请输入图书目录" }
        );
        this.ohShitfadeOut();
      }, 100)
      return;
    }

    var that = this;
    wx.request({
      url: 'http://localhost:49590/api/AddBooks/AddBooks',
      data: {
        booksname: this.data.BooksName,
        author: this.data.Author,
        price: this.data.Price,
        message: this.data.Message,
        enternum: this.data.EnterNum,
        catalogue: this.data.Catalogue,
        state: this.data.State,
      },
      method: 'GET',
      success: function (res) {
        if (res = 1) {
          wx.showToast({
            title: '成功',
            icon: 'success',
            duration: 1000
          })
        }
        else {
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
        url: '../qstartentering/startentering',
      })
    }, 1000)
    wx.switchTab({
      url: '../qstartentering/startentering',
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