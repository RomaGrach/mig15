mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
    console.log(""); // it Is possible to get something out
  },

  SaveExtern: function(date) {
    var dateString = UTF8ToString(date);
    var myobj = JSON.parse(dateString);
    player.setData(myobj);
  },

  LoadExtern: function() {
    player.getData().then(_date => {
        const myJSON = JSON.stringify(_date);
        myGameInstance.SendMessage('Progress', 'SetPlayerInfoYandex', myJSON);
    });
  },
  ShowAdv : function(){
        ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
            myGameInstance.SendMessage('Progress', 'StopAdv');
            console.Log ("__----------- closed-----------");
          // some action after close
        },
        onError: function(error) {
          // some action on error
        }
    }
    })
    },



});