<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="cil_metrics.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CIL Sales Metrics</title>
        <link rel="shortcut icon" href="./assets/img/favicon.png" />
      <meta http-equiv="refresh" content="900" />
    <link rel="stylesheet" href="./assets/css/bootstrap.css" />
  
  <link rel="stylesheet" href="./assets/css/Chart.min.css" /> 
  <link rel="stylesheet" href="./assets/css/styles.css" />

</head>
<body>
   
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
          
             
        <!-- GROUPED CONTENT -->
     <div class="accordion" id="accordionExample">
  <div class="card">
    <div class="card-header" id="headingOne">
      <h2 class="mb-0">
        <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
          Live Order Metrics
        </button>
      </h2>
    </div>

    <div id="collapseOne" class="collapse show" aria-labelledby="headingOne" data-parent="#accordionExample">
      <div class="card-body">
       <canvas style="width:692px; height:486px;" id="myChart"></canvas>
             <p runat="server" id="livedata"></p>
      </div>
    </div>
  </div>
  <div class="card">
    <div class="card-header" id="headingTwo">
      <h2 class="mb-0">
        <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
         Total Annual Metrics
        </button>
      </h2>
    </div>
    <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionExample">
      <div class="card-body">
         <canvas style="width:692px; height:486px;" id="myChart_2"></canvas>
           <p runat="server" id="livetotals"></p>
      </div>
    </div>
  </div>
  <div class="card">
    <div class="card-header" id="headingThree">
      <h2 class="mb-0">
        <button class="btn btn-link collapsed" type="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
          Monthly Order Comparisons
        </button>
      </h2>
    </div>
    <div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordionExample">
      <div class="card-body">
         <canvas style="width:692px; height:486px;" id="myChart_3"></canvas>
          <p>The chart above illustrates the total orders processed each month over the last (4) four years.</p>
      </div>
    </div>
  </div>
</div>
        <!-- GROUPED CONTENT -->

         


    <span runat="server" id="orderMetrics"></span>
    <span runat="server" id="orderMetricTotals"></span>
          
  
    <br />

        </div>
        <div class="content-3"></div>
     <div class="container">
    <footer id="copyright">
         <b> &copy; Copyright Candrug International Ltd. </b>
        <br />All Rights Reserved. <%: DateTime.UtcNow.Year %>

      </footer>
         
         </div>
            <script src="./assets/js/Chart.bundle.min.js"></script>
      <!--      <script src="./assets/js/Chart.min.js"></script>   
            <script src="./assets/js/bootstrap.js"></script>   -->
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
            <script src="./assets/js/main.js"></script>
       
</body>
</html>
