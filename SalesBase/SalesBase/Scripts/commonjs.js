var popUp = {
    initPopupWindow: function (options) {
        var defaultOptions = {
            id: "popup",
            width: 800,
            height: 530,
            modal: true,
            autoOpen: true,
            draggable: false,
            resizable: false,
            title: "Popup title"
        };
        options = $.extend(defaultOptions, options);
        var popup = $("#" + options.id);
        if (!popup.length) {
            $("body").append('<div id="' + options.id + '"></div>');
            popup = $("#" + options.id);
        }
        //popup.load(options.url);
        //var urlBase = location.href.substring(0, location.href.lastIndexOf("/") + 1);
        //var url = urlBase + options.url;
        //popup.html('<iframe border=0 width="100%" height ="100%" frameborder="0" src="' + url + '"> </iframe>');

        $.ajax({
            url: options.url,
            type: "POST",
            dataType: "json",
            data: options.data,
            success: function (data) {
                popup.html('<div style ="padding: 10px">' + data.view +'</div>');
            },
            error: function (xhr, textStatus, errorThrown) {
                //alert(textStatus);
            }
        });
        popup.dialog({
            title: options.title,
            modal: options.modal,
            autoOpen: options.autoOpen,
            height: options.height,
            width: options.width,
            resizable: options.resizable
        });
        return popup;
    }
}