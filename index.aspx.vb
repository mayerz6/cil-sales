Imports System
Imports System.IO
Imports System.Text

Imports System.Net.Http
Imports System.Net.Http.Headers
Imports OpenQA.Selenium
Imports OpenQA.Selenium.IE
Imports OpenQA.Selenium.Edge
Imports OpenQA.Selenium.Chrome

Imports System.Web
Imports System.Threading.Tasks
Imports System.Web.HttpRequest
Imports System.Windows.Forms

Imports System.Data.SqlClient
Imports System.Data


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

        ' Instantiate an instance of the Chrome browser
        Dim chromeOptions As ChromeOptions = New ChromeOptions()
        chromeOptions.AddArguments("--headless")

        Dim driver As IWebDriver = New ChromeDriver(chromeOptions)
        '  Navigate to the webpage we want to scrap
        driver.Navigate().GoToUrl("https://www.candrugfrontend.com/analysis/Login.aspx")

        ' Store the elements we wish to interact with as public variables
        Dim usrInput As IWebElement = driver.FindElement(By.Name("username"))
        Dim usrPwd As IWebElement = driver.FindElement(By.Name("password"))
        Dim btnSubmit As IWebElement = driver.FindElement(By.Name("Imagebutton1"))

        ' Send login credentials to the login form
        usrInput.SendKeys("larrym")
        usrPwd.SendKeys("ad364e")

        btnSubmit.Click()

        ' ################################################################################
        '               User has successfully logged into the website.
        ' ################################################################################

        ' Begin engagement with the site after SUCCESSFUL login
        Dim startDate As IWebElement = driver.FindElement(By.Name("tbStartDate"))
        Dim endDate As IWebElement = driver.FindElement(By.Name("tbEndDate"))
        Dim btnGenerate As IWebElement = driver.FindElement(By.Name("btnGenerate"))

        ' Dim todayDate As String = Date.Now.ToString("MM/dd/yyyy")
        Dim todayDate As String = "02/01/2020"
        startDate.Clear()
        endDate.Clear()

        startDate.SendKeys(todayDate)
        endDate.SendKeys(todayDate)


        btnGenerate.Click()

        ' #############################################################################################
        ' User has successfully queried the site based on requested date range.
        ' #############################################################################################


        ' Dim resultGrid As IWebElement = driver.FindElement(By.Id("PanelGeneral"))
        '  Dim resultGrid As IList(Of IWebElement) = driver.FindElement(By.Id("PanelGeneral"))

        ' Instantiation of the CUSTOM data type meant to store the scrapped as an ARRAY of these grouped metrics
        ' Each "orderData" entry will record;

        ' # of invoiced orders per day
        ' # of sales orders per day
        ' # of new web orders (placed) per day
        ' # of return web orders (placed) per day

        Dim metrics(9) As orderData

        ' ################################# BMD Orders ################################# 
        ' ##############################################################################

        Dim ordersBMD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[3]/td[2]"))
        Dim sordersBMD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[3]/td[6]"))
        Dim nwordersBMD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[3]/td[8]"))
        Dim rwordersBMD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[3]/td[9]"))

        ' Tests for EMPTY cells returned from DATAVIEW table using the TENARY operator
        Dim iOrders_BMD As Integer = If(ordersBMD.Text = " ", 0, Convert.ToInt32(ordersBMD.Text))
        Dim sOrders_BMD As Integer = If(sordersBMD.Text = " ", 0, Convert.ToInt32(sordersBMD.Text))
        Dim nwOrders_BMD As Integer = If(nwordersBMD.Text = " ", 0, Convert.ToInt32(nwordersBMD.Text))
        Dim rwOrders_BMD As Integer = If(rwordersBMD.Text = " ", 0, Convert.ToInt32(rwordersBMD.Text))


        metrics(4).invoices = iOrders_BMD
        metrics(4).sales = sOrders_BMD
        metrics(4).new_web = nwOrders_BMD
        metrics(4).return_web = rwOrders_BMD


        ' ################################# BSD Orders ################################# 
        ' ################################################################################

        Dim ordersBSD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[4]/td[2]"))
        Dim sordersBSD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[4]/td[6]"))
        Dim nwordersBSD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[4]/td[8]"))
        Dim rwordersBSD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[4]/td[9]"))


        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_BSD As Integer = If(ordersBSD.Text = " ", 0, Convert.ToInt32(ordersBSD.Text))
        Dim sOrders_BSD As Integer = If(sordersBSD.Text = " ", 0, Convert.ToInt32(sordersBSD.Text))
        Dim nwOrders_BSD As Integer = If(nwordersBSD.Text = " ", 0, Convert.ToInt32(nwordersBSD.Text))
        Dim rwOrders_BSD As Integer = If(rwordersBSD.Text = " ", 0, Convert.ToInt32(rwordersBSD.Text))

        metrics(5).invoices = iOrders_BSD
        metrics(5).sales = sOrders_BSD
        metrics(5).new_web = nwOrders_BSD
        metrics(5).return_web = rwOrders_BSD


        ' ################################# Candrug Orders ################################# 
        ' ################################################################################

        Dim ordersCDG As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[5]/td[2]"))
        Dim sordersCDG As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[5]/td[6]"))
        Dim nwordersCDG As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[5]/td[8]"))
        Dim rwordersCDG As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[5]/td[9]"))

        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_CDG As Integer = If(ordersCDG.Text = " ", 0, Convert.ToInt32(ordersCDG.Text))
        Dim sOrders_CDG As Integer = If(sordersCDG.Text = " ", 0, Convert.ToInt32(sordersCDG.Text))
        Dim nwOrders_CDG As Integer = If(nwordersCDG.Text = " ", 0, Convert.ToInt32(nwordersCDG.Text))
        Dim rwOrders_CDG As Integer = If(rwordersCDG.Text = " ", 0, Convert.ToInt32(rwordersCDG.Text))

        metrics(6).invoices = iOrders_CDG
        metrics(6).sales = sOrders_CDG
        metrics(6).new_web = nwOrders_CDG
        metrics(6).return_web = rwOrders_CDG

        ' ################################# CDO Orders ################################# 
        ' ################################################################################

        Dim ordersCDO As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[6]/td[2]"))
        Dim sordersCDO As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[6]/td[6]"))
        Dim nwordersCDO As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[6]/td[8]"))
        Dim rwordersCDO As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[6]/td[9]"))


        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_CDO As Integer = If(ordersCDO.Text = " ", 0, Convert.ToInt32(ordersCDO.Text))
        Dim sOrders_CDO As Integer = If(sordersCDO.Text = " ", 0, Convert.ToInt32(sordersCDO.Text))
        Dim nwOrders_CDO As Integer = If(nwordersCDO.Text = " ", 0, Convert.ToInt32(nwordersCDO.Text))
        Dim rwOrders_CDO As Integer = If(rwordersCDO.Text = " ", 0, Convert.ToInt32(rwordersCDO.Text))

        metrics(3).invoices = iOrders_CDO
        metrics(3).sales = sOrders_CDO
        metrics(3).new_web = nwOrders_CDO
        metrics(3).return_web = rwOrders_CDO

        ' ################################# CPK Orders ################################# 
        ' ################################################################################

        Dim ordersCPK As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[7]/td[2]"))
        Dim sordersCPK As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[7]/td[6]"))
        Dim nwordersCPK As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[7]/td[8]"))
        Dim rwordersCPK As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[7]/td[9]"))

        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_CPK As Integer = If(ordersCPK.Text = " ", 0, Convert.ToInt32(ordersCPK.Text))
        Dim sOrders_CPK As Integer = If(sordersCPK.Text = " ", 0, Convert.ToInt32(sordersCPK.Text))
        Dim nwOrders_CPK As Integer = If(nwordersCPK.Text = " ", 0, Convert.ToInt32(nwordersCPK.Text))
        Dim rwOrders_CPK As Integer = If(rwordersCPK.Text = " ", 0, Convert.ToInt32(rwordersCPK.Text))

        metrics(2).invoices = iOrders_CPK
        metrics(2).sales = sOrders_CPK
        metrics(2).new_web = nwOrders_CPK
        metrics(2).return_web = rwOrders_CPK

        ' ################################# CPO Orders ################################# 
        ' ################################################################################

        Dim ordersCPO As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[8]/td[2]"))
        Dim sordersCPO As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[8]/td[6]"))
        Dim nwordersCPO As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[8]/td[8]"))
        Dim rwordersCPO As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[8]/td[9]"))

        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_CPO As Integer = If(ordersCPO.Text = " ", 0, Convert.ToInt32(ordersCPO.Text))
        Dim sOrders_CPO As Integer = If(sordersCPO.Text = " ", 0, Convert.ToInt32(sordersCPO.Text))
        Dim nwOrders_CPO As Integer = If(nwordersCPO.Text = " ", 0, Convert.ToInt32(nwordersCPO.Text))
        Dim rwOrders_CPO As Integer = If(rwordersCPO.Text = " ", 0, Convert.ToInt32(rwordersCPO.Text))

        metrics(0).invoices = iOrders_CPO
        metrics(0).sales = sOrders_CPO
        metrics(0).new_web = nwOrders_CPO
        metrics(0).return_web = rwOrders_CPO

        ' ################################# CPW Orders ################################# 
        ' ################################################################################

        Dim ordersCPW As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[9]/td[2]"))
        Dim sordersCPW As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[9]/td[6]"))
        Dim nwordersCPW As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[9]/td[8]"))
        Dim rwordersCPW As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[9]/td[9]"))

        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_CPW As Integer = If(ordersCPW.Text = " ", 0, Convert.ToInt32(ordersCPW.Text))
        Dim sOrders_CPW As Integer = If(sordersCPW.Text = " ", 0, Convert.ToInt32(sordersCPW.Text))
        Dim nwOrders_CPW As Integer = If(nwordersCPW.Text = " ", 0, Convert.ToInt32(nwordersCPW.Text))
        Dim rwOrders_CPW As Integer = If(rwordersCPW.Text = " ", 0, Convert.ToInt32(rwordersCPW.Text))

        metrics(1).invoices = iOrders_CPW
        metrics(1).sales = sOrders_CPW
        metrics(1).new_web = nwOrders_CPW
        metrics(1).return_web = rwOrders_CPW

        ' ################################# GDD Orders ################################# 
        ' ################################################################################

        Dim ordersGDD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[10]/td[2]"))
        Dim sordersGDD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[10]/td[6]"))
        Dim nwordersGDD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[10]/td[8]"))
        Dim rwordersGDD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[10]/td[9]"))

        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_GDD As Integer = If(ordersGDD.Text = " ", 0, Convert.ToInt32(ordersGDD.Text))
        Dim sOrders_GDD As Integer = If(sordersGDD.Text = " ", 0, Convert.ToInt32(sordersGDD.Text))
        Dim nwOrders_GDD As Integer = If(nwordersGDD.Text = " ", 0, Convert.ToInt32(nwordersGDD.Text))
        Dim rwOrders_GDD As Integer = If(rwordersGDD.Text = " ", 0, Convert.ToInt32(rwordersGDD.Text))


        metrics(7).invoices = iOrders_GDD
        metrics(7).sales = sOrders_GDD
        metrics(7).new_web = nwOrders_GDD
        metrics(7).return_web = rwOrders_GDD

        ' ################################# Medisave Orders ################################# 
        ' ################################################################################

        Dim ordersMED As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[11]/td[2]"))
        Dim sordersMED As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[11]/td[6]"))
        Dim nwordersMED As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[11]/td[8]"))
        Dim rwordersMED As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[11]/td[9]"))


        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_MED As Integer = If(ordersMED.Text = " ", 0, Convert.ToInt32(ordersMED.Text))
        Dim sOrders_MED As Integer = If(sordersMED.Text = " ", 0, Convert.ToInt32(sordersMED.Text))
        Dim nwOrders_MED As Integer = If(nwordersMED.Text = " ", 0, Convert.ToInt32(nwordersMED.Text))
        Dim rwOrders_MED As Integer = If(rwordersMED.Text = " ", 0, Convert.ToInt32(rwordersMED.Text))


        metrics(9).invoices = iOrders_MED
        metrics(9).sales = sOrders_MED
        metrics(9).new_web = nwOrders_MED
        metrics(9).return_web = rwOrders_MED

        ' ################################# MOC Orders ################################# 
        ' ################################################################################

        Dim ordersMOC As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[12]/td[2]"))
        Dim sordersMOC As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[12]/td[6]"))
        Dim nwordersMOC As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[12]/td[8]"))
        Dim rwordersMOC As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[12]/td[9]"))

        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_MOC As Integer = If(ordersMOC.Text = " ", 0, Convert.ToInt32(ordersMOC.Text))
        Dim sOrders_MOC As Integer = If(sordersMOC.Text = " ", 0, Convert.ToInt32(sordersMOC.Text))
        Dim nwOrders_MOC As Integer = If(nwordersMOC.Text = " ", 0, Convert.ToInt32(nwordersMOC.Text))
        Dim rwOrders_MOC As Integer = If(rwordersMOC.Text = " ", 0, Convert.ToInt32(rwordersMOC.Text))


        metrics(8).invoices = iOrders_MOC
        metrics(8).sales = sOrders_MOC
        metrics(8).new_web = nwOrders_MOC
        metrics(8).return_web = rwOrders_MOC


        ' Define the locations of TOTAL Revenue and TOTAL Processed Orders within the TABLE

        Dim orderTotal As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[13]/td[2]"))
        Dim revenueTotal As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[13]/td[3]"))

        driver.Close()
        driver.Quit()

        Dim valStr As String = revenueTotal.Text
        valStr = valStr.Remove(0, 1)
        Dim iOrder_TOTAL As Integer = If(orderTotal.Text = " ", 0, Convert.ToInt32(orderTotal.Text))

        livedata.InnerHtml += "<br><b>CPO</b> Orders Processed: " + iOrders_CPO.ToString()
        livedata.InnerHtml += "<br><b>CPW</b> Orders Processed: " + iOrders_CPW.ToString()
        livedata.InnerHtml += "<br><b>CPK</b> Orders Processed: " + iOrders_CPK.ToString()
        livedata.InnerHtml += "<br><b>CDO</b> Orders Processed: " + iOrders_CDO.ToString()
        livedata.InnerHtml += "<br><b>BMD</b> Orders Processed: " + iOrders_BMD.ToString()
        livedata.InnerHtml += "<br><b>BSD</b> Orders Processed: " + iOrders_BSD.ToString()
        livedata.InnerHtml += "<br><b>Candrug</b> Orders Processed: " + iOrders_CDG.ToString()
        livedata.InnerHtml += "<br><b>GDD</b> Orders Processed: " + iOrders_GDD.ToString()
        livedata.InnerHtml += "<br><b>Medisave</b> Orders Processed: " + iOrders_MED.ToString()
        livedata.InnerHtml += "<br><b>MOC</b> Orders Processed: " + iOrders_MOC.ToString()
        livedata.InnerHtml += "<hr>"


        ' Using the tenary OPERATOR to parse the string representing TOTAL ORDERS & REVENUE as a VALUE of type INTEGER & DOUBLE respectively.
        Dim iOrderTotals As Integer = If(orderTotal.Text = " ", 0, Convert.ToInt32(orderTotal.Text))
        Dim revDoubler As Double = If(revenueTotal.Text <> " ", revenueTotal.Text, 0)

        livedata.InnerHtml += "<br><h4>Total Orders Processed: " + iOrderTotals.ToString() + "</h4>"
        livedata.InnerHtml += "<br><h4>Total Revenue Earnings: $" + revDoubler.ToString() + "</h4>"

        '    '  Dim valStr As String = revenueTotal.Text
        '    ' Remove the "$" sign from the string representing TOTAL order revenue.
        '    ' valStr = valStr.Remove(0, 1)


        ' ########################################################################################################## 
        ' Here we will inject the DAILY ORDER value within an HTML tag so the Chart.JS library can plot the graph based on this value
        orderMetrics.InnerHtml = iOrderTotals
        ' ########################################################################################################## 

        ' ################################# Store retrieved values within DATABASE ################################# 
        ' ########################################################################################################## 

        Dim sqlConn As New SqlConnection
        Dim sqlCmd As New SqlCommand
        Dim sdrData As SqlDataReader
        '  Dim sb As StringBuilder
        Dim dt As New DataTable
        Dim sqlDataAdapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim mFD As String = monthString(todayDate)
        Dim cM As String = monthName(todayDate)
        Dim tdStr As DateTime = DateTime.ParseExact(todayDate, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture)
        todayDate = tdStr.ToString("yyyy-MM-dd")


        Dim count As Integer = 1
        Dim total_orders As Integer = 0
        Dim annual_orders As Integer = 0


        ' Instantiation of DB connection string
        sqlConn.ConnectionString =
            "server=MAYERZ-S940;" _
            & "database=cil-sales-metrics;" _
            & "uid = mayerz; pwd=M@y3rZT#ch;"

        sqlConn.Open()

        ' Test for the existence of a record with a DATE which matches today's date.
        sqlCmd.CommandText = "SELECT COUNT(*) AS 'RESULTS' FROM [cil-sales-metrics].[dbo].[doMetrics] WHERE [date] = '" & todayDate & "'"
        sqlCmd.Connection = sqlConn
        sdrData = sqlCmd.ExecuteReader()

        While sdrData.Read()
            count = sdrData("RESULTS")
        End While
        sdrData.Close()
        ' If we have previously entered order metrics for today's date then UPDATE those values based on the query below. 
        If (count <> 0) Then



            For i As Integer = 0 To 9 Step +1

                ' Definition of SQL statement to INSERT records within DB after successful scraping of site
                sqlCmd.CommandText = "UPDATE [cil-sales-metrics].[dbo].[doMetrics] SET [daily_iorders] = '" & metrics(i).invoices & "', " _
                & "[daily_nworders] = '" & metrics(i).new_web & "', " _
                & "[daily_rworders] = '" & metrics(i).return_web & "', " _
                & "[daily_sorders] = '" & metrics(i).sales & "' " _
                & "WHERE [date] =  '" & todayDate & "' AND [account] = '" & i & "'"

                ' Make connection to DB and execute SQL commands
                sqlCmd.Connection = sqlConn
                sqlCmd.ExecuteNonQuery()

            Next i

            sqlCmd.CommandText = "EXECUTE addMonthlyTotals @currentDate='" & todayDate & "', @monthFD='" & mFD & "', @currentMonth='" & cM & "'"
            sqlCmd.Connection = sqlConn
            sqlCmd.ExecuteNonQuery()
            sqlConn.Close()

            ' If we haven't previously entered order metrics for today's date then INSERT new values based on the query below.
        Else

            For i As Integer = 0 To 9 Step +1

                '     sqlResults.InnerText = "There were " & count & "records found!!!!"
                'Definition of SQL statement to INSERT records within DB after successful scraping of site
                sqlCmd.CommandText = "INSERT into [cil-sales-metrics].[dbo].[doMetrics] " _
                & "([daily_iorders], [daily_nworders], [daily_rworders], [daily_sorders], [account], [date]) " _
                & "values('" & metrics(i).invoices & "', '" & metrics(i).new_web & "', '" & metrics(i).return_web & "', '" & metrics(i).sales & "', '" & i & "', '" & todayDate & "')"

                ' Make connection to DB and execute SQL commands
                sqlCmd.Connection = sqlConn
                sqlCmd.ExecuteNonQuery()

            Next i

            sqlCmd.CommandText = "EXECUTE addMonthlyTotals @currentDate='" & todayDate & "', @monthFD='" & mFD & "', @currentMonth='" & cM & "'"
            sqlCmd.Connection = sqlConn
            sqlCmd.ExecuteNonQuery()
            sqlConn.Close()

        End If


        sqlConn.Open()

        ' Retrieve the latest TOTAL orders processed for the current month.
        sqlCmd.CommandText = "EXECUTE getMonthlyTotals @currentMonth='" & cM & "'"
        sqlCmd.Connection = sqlConn
        sdrData = sqlCmd.ExecuteReader()

        ' The TOTAL monthly order is returned based on the results of the stored procedure.
        While sdrData.Read()
            '   If Not IsDBNull(sdrData("tdi")) Then
            total_orders = If(IsDBNull(sdrData("tdi")), 0, Convert.ToInt32(sdrData("tdi")))
        End While
        sdrData.Close()
        sqlConn.Close()

        cM = 2020
        sqlConn.Open()


        ' Retrieve the latest TOTAL orders processed for the current month.
        sqlCmd.CommandText = "EXECUTE getAnnualTotals @currentMonth='" & cM & "'"
        sqlCmd.Connection = sqlConn
        sdrData = sqlCmd.ExecuteReader()

        ' The TOTAL monthly order is returned based on the results of the stored procedure.
        While sdrData.Read()
            '   If Not IsDBNull(sdrData("tdi")) Then
            annual_orders = If(IsDBNull(sdrData("tdi")), 0, Convert.ToInt32(sdrData("tdi")))
        End While
        sdrData.Close()
        sqlConn.Close()

        orderMetrics.InnerHtml = total_orders
        orderMetricTotals.InnerText = annual_orders


        ' Inject this value as part of the web page returned to the user.
        livedata.InnerHtml += "<br><h4>Total Orders Processed: " + total_orders.ToString() + "</h4>"
        livetotals.InnerHtml += "<b id='metHead_2'>Anuual Order Metrics</b>"
        livetotals.InnerHtml += "<br>Total Orders Processed <b>[2020]</b> : " + annual_orders.ToString() + ""
        livetotals.InnerHtml += "<br>Total Orders Processed <b>[2019]</b> : 285129"
        livetotals.InnerHtml += "<br>Total Orders Processed <b>[2018]</b> : 288450"
        metrics = Nothing

    End Sub


    Function monthString(ByVal dateStr As String) As String

        'Definition of a STRING array based on the date passed to this function.
        ' Create an ARRAY based on the today's date by SPLITTING the text based on the existence of the "-" character.

        ' Date is expected to be of the format "yyyy-MM-dd"
        Dim month As String() = dateStr.Split(New Char() {"/"c})
        ' SPLIT function allows used to convert "MM/dd/yyyy" to { [0]="MM", [1]="dd", [2]="yyyy" }
        Select Case month(0)

            Case "01"
                Return "2020-01-01"
            Case "02"
                Return "2020-02-01"
            Case "03"
                Return "2020-03-01"
            Case "04"
                Return "2020-04-01"
            Case "05"
                Return "2020-05-01"
            Case "06"
                Return "2020-06-01"
            Case "07"
                Return "2020-07-01"
            Case "08"
                Return "2020-08-01"
            Case "09"
                Return "2020-09-01"
            Case "10"
                Return "2020-10-01"
            Case "11"
                Return "2020-11-01"
            Case "12"
                Return "2020-12-01"
            Case Else
                Return "NAM"

        End Select



    End Function


    Function monthName(ByVal dateStr As String) As String

        'Definition of a STRING array based on the date passed to this function.
        ' Create an ARRAY based on the today's date by SPLITTING the text based on the existence of the "-" character.

        Dim month As String() = dateStr.Split(New Char() {"/"c})

        ' SPLIT function allows used to convert "MM/dd/yyyy" to { [0]="MM", [1]="dd", [2]="yyyy" }
        Select Case month(0)

            Case "01"
                Return "2020-01"
            Case "02"
                Return "2020-02"
            Case "03"
                Return "2020-03"
            Case "04"
                Return "2020-04"
            Case "05"
                Return "2020-05"
            Case "06"
                Return "2020-06"
            Case "07"
                Return "2020-07"
            Case "08"
                Return "2020-08"
            Case "09"
                Return "2020-09"
            Case "10"
                Return "2020-10"
            Case "11"
                Return "2020-11"
            Case "12"
                Return "2020-12"
            Case Else
                Return "NAM"

        End Select


    End Function


End Class