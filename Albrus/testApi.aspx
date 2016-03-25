<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testApi.aspx.cs" Inherits="Albrus.testApi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://code.jquery.com/jquery-2.2.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
    <%--<input id="ttt" /><br />--%>
    <%--<button type="button" id="myButton" data-loading-text="Loading..." class="btn btn-primary" autocomplete="off">
        push
    </button>--%>
    <script>
        $(document).ready(function () {
            function GetLogs() {
                $.ajax({
                    type: "POST",
                    url: "http://10.13.15.72/api/PriceCheckerError.aspx/GetAllDevice",
                    contentType: "application/json; charset=utf-8",
                    //data: JSON.stringify({ taskIdDash: 4, taskName: "blabla 4", taskInform: "taskInform inform", taskPosition: 2, taskDataStart: "2016-02-17 12:54:54", taskDataEnd: "2016-04-17 12:54:54" }), // '{dashIdProject: "1"}',
                    data: JSON.stringify({ ipAdress: "13.13.13.13", idDevice: "kolya", dataError: "2016-02-24 12:54:54", error: "{khbaskhbdcak:hyvghyv}" }),
                    dataType: "json",
                    success: function (html) {
                        //alert('bingo');
                        console.log(html);
                    }
                });
            } GetLogs();
            
            function () {
                $.ajax({
                    type: "POST",
                    url: "http://10.13.15.72/api/PriceCheckerError.aspx/NewDeviceMessage",
                    contentType: "application/json; charset=utf-8",
                    //data: JSON.stringify({ taskIdDash: 4, taskName: "blabla 4", taskInform: "taskInform inform", taskPosition: 2, taskDataStart: "2016-02-17 12:54:54", taskDataEnd: "2016-04-17 12:54:54" }), // '{dashIdProject: "1"}',
                    data: JSON.stringify({ ipAdress: "13.13.13.13", idDevice: "kolya", dataError: "2016-02-24 12:54:54", error: "{khbaskhbdcak:hyvghyv}" }),
                    dataType: "json",
                    success: function (html) {
                        //alert('bingo');
                        console.log(html);
                    }
                });
            } GetLogs();
            //$.ajax({
            //    type: "POST",
            //    url: "http://10.13.15.72/api/Albrus.aspx/DashGetAll",
            //    contentType: "application/json; charset=utf-8",
            //    data: JSON.stringify({ dashIdProject: 2 }), // '{dashIdProject: "1"}',
            //    dataType: "json",
            //    success: function (html) {
            //        alert('bingo');
            //        console.log(html);
            //    }
            //});
            //$.ajax({
            //    type: "POST",
            //    url: "http://10.13.15.72/api/Albrus.aspx/GetAllDevice",
            //    contentType: "application/json; charset=utf-8",
            //    //data: JSON.stringify({ dashIdProject: 2 }), // '{dashIdProject: "1"}',
            //    data: '',
            //    dataType: "json",
            //    success: function (html) {
            //        alert('opa opa opapa');
            //        console.log(html);
            //    }
            //});
        });
    </script>
</body>
</html>