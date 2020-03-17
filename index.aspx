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

  <div class="container">
        <br />
        <br />
    <h2 id="currentDate" runat="server">CIL Order Metrics - <%: DateTime.Now.ToString("dddd MMMM d, yyyy") %></h2>

    <div id="banner">Up to date statistics for the <b>month of <%: DateTime.Now.ToString("MMMM") %></b></div>
       <br />
        <span id="content" runat="server"></span>
        <br />
            <canvas style="width:692px; height:486px;" id="myChart"></canvas>
                 <p runat="server" id="livedata"></p>


     
    <span runat="server" style="visibility:hidden;" id="orderMetrics"></span>
    <span runat="server" id="todayDate2"></span>
          
  
    <br />


 

        </div>
        
      
            <script src="./assets/js/Chart.bundle.min.js"></script>
      <!--      <script src="./assets/js/Chart.min.js"></script>
            <script src="./assets/js/bootstrap.js"></script>      -->
            <script src="./assets/js/main.js"></script>
       
</body>
</html>
