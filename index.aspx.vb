Imports System
Imports System.IO
Imports System.Text


Imports System.Web
Imports System.Threading.Tasks
Imports System.Web.HttpRequest
Imports System.Windows.Forms

Imports cil_metrics.metrics

Public Class index
    Inherits System.Web.UI.Page

    ' Custom data type meant to store the scraped metrics for analysis
    Structure orderData
        Dim invoices As Integer
        Dim sales As Integer
        Dim new_web As Integer
        Dim return_web As Integer
    End Structure

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fetchSiteData()
    End Sub

    ' MUST create a CLASS to record instances of database connections.

    Private Sub fetchSiteData()

        Dim site As New metrics

        site.UserLogin()
        site.RetrieveMetrics()
        site.RetrieveTotals()


        site.CPO_fetchData()
        site.CPW_fetchData()
        site.CPK_fetchData()
        site.CDO_fetchData()
        site.BMD_fetchData()
        site.BSD_fetchData()
        site.CDG_fetchData()
        site.GDD_fetchData()
        site.MOC_fetchData()
        site.MED_fetchData()


        livedata.InnerHtml += "<br><b>CPO</b> Orders Processed: " + site.returnDO_CPO()
        livedata.InnerHtml += "<br><b>CPW</b> Orders Processed: " + site.returnDO_CPW()
        livedata.InnerHtml += "<br><b>CPK</b> Orders Processed: " + site.returnDO_CPK()
        livedata.InnerHtml += "<br><b>CDO</b> Orders Processed: " + site.returnDO_CDO()
        livedata.InnerHtml += "<br><b>BMD</b> Orders Processed: " + site.returnDO_BMD()
        livedata.InnerHtml += "<br><b>BSD</b> Orders Processed: " + site.returnDO_BSD()
        livedata.InnerHtml += "<br><b>Candrug</b> Orders Processed: " + site.returnDO_CDG()
        livedata.InnerHtml += "<br><b>GDD</b> Orders Processed: " + site.returnDO_GDD()
        livedata.InnerHtml += "<br><b>Medisave</b> Orders Processed: " + site.returnDO_MED()
        livedata.InnerHtml += "<br><b>MOC</b> Orders Processed: " + site.returnDO_MOC()
        livedata.InnerHtml += "<hr>"



        livedata.InnerHtml += "<br><h4>Total Orders Processed: " + site.GetTotalOrders() + "</h4>"
        livedata.InnerHtml += "<br><h4>Total Revenue Earnings: $" + site.GetTotalRevenue() + "</h4>"

        '    '  Dim valStr As String = revenueTotal.Text
        '    ' Remove the "$" sign from the string representing TOTAL order revenue.
        '    ' valStr = valStr.Remove(0, 1)

        site.insertMetrics()
        site.getMetrics()
        ' ########################################################################################################## 
        ' Here we will inject the DAILY ORDER value within an HTML tag so the Chart.JS library can plot the graph based on this value
        orderMetrics.InnerHtml = site.GetTotalOrders()
        orderMetricTotals.InnerHtml = site.returnAnnualOrders()
        ' ########################################################################################################## 

        site.CloseDriver()


        ' Inject this value as part of the web page returned to the user.

        livetotals.InnerHtml += "<b id='metHead_2'>Anuual Order Metrics</b>"
        livetotals.InnerHtml += "<br>Total Orders Processed <b>[2020]</b> : " + site.returnAnnualOrders() + ""
        livetotals.InnerHtml += "<br>Total Orders Processed <b>[2019]</b> : 285129"
        livetotals.InnerHtml += "<br>Total Orders Processed <b>[2018]</b> : 288450"

        ' ################################# Store retrieved values within DATABASE ################################# 
        ' ########################################################################################################## 


    End Sub


End Class