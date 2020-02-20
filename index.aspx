<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="cil_metrics.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CIL Site Scraper</title>
        <link rel="stylesheet" href="./assets/css/styles.css" />
</head>
<body>
    <h2>CIL Online Metrics</h2>

    <!-- 
   <form id="usrForm1" runat="server">
        <span></span>
    </form>
   -->
    <!--  -->
        <p runat="server" id="livedata"></p>
        <br />

      <b>URL:</b>  <span id="content" runat="server"></span>
</body>
</html>
