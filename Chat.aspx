<%@ Page Title="Chat" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Chat.aspx.cs" Inherits="Chat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script src="Scripts/jquery.signalR-0.5.2.min.js" type="text/javascript"></script>
    <script src="signalr/hubs" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            var chat = $.connection.chat;
            chat.addMessage = function (message) {
                $('#messages').append('<li>' + message + '');
                $("#messages li").last().stop().css("background-color", "#FFFF00").animate({ backgroundColor: "#FFFFFF" }, 3000); 
            };

            $("#broadcast").click(function () {
                var msg = $('#msg');
                chat.send(msg.val());
                msg.val('');
                msg.focus();
                
                return false;
            });

            $.connection.hub.start();
            $("#dialog").dialog({ title: 'Chat', width: 600 });



        });
    </script>
    <div id="dialog">
        <input id="msg" />
        <input id="broadcast" type="submit" value="OK" />
        <ul id="messages">
        </ul>
    </div>
</asp:Content>
