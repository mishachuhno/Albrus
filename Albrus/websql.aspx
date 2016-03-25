<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="websql.aspx.cs" Inherits="Albrus.websql" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://code.jquery.com/jquery-2.2.1.min.js"></script>
    <%--<script src="Scripts/websqlDB.js"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
    <div id="bodyWrapper"></div>
<script>
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "http://10.13.15.72/api/PriceCheckerError.aspx/GetAllDevice",
                contentType: "application/json; charset=utf-8",
                //data: JSON.stringify({ taskIdDash: 4, taskName: "blabla 4", taskInform: "taskInform inform", taskPosition: 2, taskDataStart: "2016-02-17 12:54:54", taskDataEnd: "2016-04-17 12:54:54" }), // '{dashIdProject: "1"}',
                //data:"",
                //data: JSON.stringify({}),
                dataType: "json",
                success: function (html) {
                    alert('bingo');
                    console.log(html);
                }
            });
            //$.ajax({
            //    type: "POST",
            //    url: "http://10.13.15.72/api/PriceCheckerError.aspx/NewDeviceMessage",
            //    contentType: "application/json; charset=utf-8",
            //    //data: JSON.stringify({ taskIdDash: 4, taskName: "blabla 4", taskInform: "taskInform inform", taskPosition: 2, taskDataStart: "2016-02-17 12:54:54", taskDataEnd: "2016-04-17 12:54:54" }), // '{dashIdProject: "1"}',
            //    data: JSON.stringify({ ipAdress: "13.13.13.13", idDevice: "ijus", dataError: "2016-02-17 12:54:54", error:"oiajndfkna" }),
            //    dataType: "json",
            //    success: function (html) {
            //        alert('bingo');
            //        console.log(html);
            //    }
            //});
        });
    </script>
</body>
</html>
