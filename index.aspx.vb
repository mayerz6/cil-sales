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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fetchSiteData()
    End Sub

    Private Sub fetchSiteData()

        ' Instantiate an instance of the Chrome browser

        Dim chromeOptions As ChromeOptions = New ChromeOptions()
        chromeOptions.AddArguments("--headless")

        Dim driver As IWebDriver = New ChromeDriver(chromeOptions)
        '  Navigate to the webpage we want to scrap
        driver.Navigate().GoToUrl("https://www.candrugfrontend.com/analysis/Login.aspx")

        '  System.Threading.Thread.Sleep(4000)

        ' Store the elements we wish to interact with as public variables
        Dim usrInput As IWebElement = driver.FindElement(By.Name("username"))
        Dim usrPwd As IWebElement = driver.FindElement(By.Name("password"))
        Dim btnSubmit As IWebElement = driver.FindElement(By.Name("Imagebutton1"))

        ' usrInput.Click()
        ' usrPwd.Click()
        ' usrInput.Clear()
        ' usrPwd.Clear()

        usrInput.SendKeys("larrym")
        usrPwd.SendKeys("ad364e")


        btnSubmit.Click()

        ' Begin engagement with the site after SUCCESSFUL login
        Dim startDate As IWebElement = driver.FindElement(By.Name("tbStartDate"))
        Dim endDate As IWebElement = driver.FindElement(By.Name("tbEndDate"))
        Dim btnGenerate As IWebElement = driver.FindElement(By.Name("btnGenerate"))

        '  Dim todayDate As String = Date.Now.ToString("MM/dd/yyyy")
        Dim todayDate As String = "01/14/2020"
        startDate.Clear()
        endDate.Clear()

        startDate.SendKeys(todayDate)
        endDate.SendKeys(todayDate)

        btnGenerate.Click()

        ' Dim resultGrid As IWebElement = driver.FindElement(By.Id("PanelGeneral"))
        '  Dim resultGrid As IList(Of IWebElement) = driver.FindElement(By.Id("PanelGeneral"))

        ' Define the locations of TOTAL Revenue and TOTAL Processed Orders within the TABLE

        Dim orderTotal As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[13]/td[2]"))
        Dim revenueTotal As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[13]/td[3]"))


        ' ################################# BMD Orders ################################# 
        ' ################################################################################

        Dim ordersBMD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[3]/td[2]"))
        Dim sordersBMD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[3]/td[6]"))
        Dim nwordersBMD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[3]/td[8]"))
        Dim rwordersBMD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[3]/td[9]"))

        ' Dim iOrders_BMD As Integer = zeroTest(ordersBMD.Text)
        Dim iOrders_BMD As Integer = If(ordersBMD.Text = " ", 0, Convert.ToInt32(ordersBMD.Text))

        ' Dim sOrders_BMD As Integer = zeroTest(sordersBMD.Text)
        Dim sOrders_BMD As Integer = If(sordersBMD.Text = " ", 0, Convert.ToInt32(sordersBMD.Text))

        '  Dim nwOrders_BMD As Integer = nwordersBMD.Text
        Dim nwOrders_BMD As Integer = If(nwordersBMD.Text = " ", 0, Convert.ToInt32(nwordersBMD.Text))

        ' Dim rwOrders_BMD As Integer = zeroTest(rwordersBMD.Text)
        Dim rwOrders_BMD As Integer = If(rwordersBMD.Text = " ", 0, Convert.ToInt32(rwordersBMD.Text))


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



        ' ################################# CPK Orders ################################# 
        ' ################################################################################

        Dim ordersCPK As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[7]/td[2]"))
        Dim sordersCPK As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[7]/td[6]"))
        Dim nwordersCPK As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[7]/td[8]"))
        Dim rwordersCPK As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[7]/td[9]"))

        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_CPK As Integer = If(ordersCPK.Text = " ", 0, Convert.ToInt32(ordersCDO.Text))
        Dim sOrders_CPK As Integer = If(sordersCPK.Text = " ", 0, Convert.ToInt32(sordersCPK.Text))
        Dim nwOrders_CPK As Integer = If(nwordersCPK.Text = " ", 0, Convert.ToInt32(nwordersCPK.Text))
        Dim rwOrders_CPK As Integer = If(rwordersCPK.Text = " ", 0, Convert.ToInt32(rwordersCPK.Text))



        ' CPO Order Metrics
        Dim ordersCPO As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[8]/td[2]"))
        Dim sordersCPO As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[8]/td[6]"))
        Dim nwordersCPO As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[8]/td[8]"))
        Dim rwordersCPO As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[8]/td[9]"))

        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_CPO As Integer = If(ordersCPO.Text = " ", 0, Convert.ToInt32(ordersCPO.Text))
        Dim sOrders_CPO As Integer = If(sordersCPO.Text = " ", 0, Convert.ToInt32(sordersCPO.Text))
        Dim nwOrders_CPO As Integer = If(nwordersCPO.Text = " ", 0, Convert.ToInt32(nwordersCPO.Text))
        Dim rwOrders_CPO As Integer = If(rwordersCPO.Text = " ", 0, Convert.ToInt32(rwordersCPO.Text))



        ' CPW Order Metrics
        Dim ordersCPW As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[9]/td[2]"))
        Dim sordersCPW As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[9]/td[6]"))
        Dim nwordersCPW As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[9]/td[8]"))
        Dim rwordersCPW As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[9]/td[9]"))

        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_CPW As Integer = If(ordersCPW.Text = " ", 0, Convert.ToInt32(ordersCPW.Text))
        Dim sOrders_CPW As Integer = If(sordersCPW.Text = " ", 0, Convert.ToInt32(sordersCPW.Text))
        Dim nwOrders_CPW As Integer = If(nwordersCPW.Text = " ", 0, Convert.ToInt32(nwordersCPW.Text))
        Dim rwOrders_CPW As Integer = If(rwordersCPW.Text = " ", 0, Convert.ToInt32(rwordersCPW.Text))


        ' GDD Order Metrics
        Dim ordersGDD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[10]/td[2]"))
        Dim sordersGDD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[10]/td[6]"))
        Dim nwordersGDD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[10]/td[8]"))
        Dim rwordersGDD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[10]/td[9]"))

        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_GDD As Integer = If(ordersGDD.Text = " ", 0, Convert.ToInt32(ordersGDD.Text))
        Dim sOrders_GDD As Integer = If(sordersGDD.Text = " ", 0, Convert.ToInt32(sordersGDD.Text))
        Dim nwOrders_GDD As Integer = If(nwordersGDD.Text = " ", 0, Convert.ToInt32(nwordersGDD.Text))
        Dim rwOrders_GDD As Integer = If(rwordersGDD.Text = " ", 0, Convert.ToInt32(rwordersGDD.Text))


        ' Medisave Order Metrics
        Dim ordersMED As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[11]/td[2]"))
        Dim sordersMED As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[11]/td[6]"))
        Dim nwordersMED As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[11]/td[8]"))
        Dim rwordersMED As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[11]/td[9]"))


        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_MED As Integer = If(ordersMED.Text = " ", 0, Convert.ToInt32(ordersMED.Text))
        Dim sOrders_MED As Integer = If(sordersMED.Text = " ", 0, Convert.ToInt32(sordersMED.Text))
        Dim nwOrders_MED As Integer = If(nwordersMED.Text = " ", 0, Convert.ToInt32(nwordersMED.Text))
        Dim rwOrders_MED As Integer = If(rwordersMED.Text = " ", 0, Convert.ToInt32(rwordersMED.Text))



        ' MOC Order Metrics
        Dim ordersMOC As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[12]/td[2]"))
        Dim sordersMOC As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[12]/td[6]"))
        Dim nwordersMOC As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[12]/td[8]"))
        Dim rwordersMOC As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[12]/td[9]"))

        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_MOC As Integer = If(ordersMOC.Text = " ", 0, Convert.ToInt32(ordersMOC.Text))
        Dim sOrders_MOC As Integer = If(sordersMOC.Text = " ", 0, Convert.ToInt32(sordersMOC.Text))
        Dim nwOrders_MOC As Integer = If(nwordersMOC.Text = " ", 0, Convert.ToInt32(nwordersMOC.Text))
        Dim rwOrders_MOC As Integer = If(rwordersMOC.Text = " ", 0, Convert.ToInt32(rwordersMOC.Text))


        ' livedata.InnerHtml = orderTotal.Text
        '  livedata.InnerHtml = "Total Orders Processed: " + orderTotal.Text + "<br> Total Revenue Earnings: " + revenueTotal.Text
        '  livedata.InnerHtml = "<br>"
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
        livedata.InnerHtml += "<br><h4>Total Orders Processed: " + orderTotal.Text + "</h4>"
        '  For Each row As IWebElement In resultGrid

        ' startDate.Clear()
        ' endDate.Clear()
        Dim iOrderTotals As Integer = Convert.ToInt32(orderTotal.Text)
        orderMetrics.InnerHtml = iOrderTotals

        'If (row.TagName.Equals("td")) Then
        '   tdElements = row.Text
        'End If


        Dim sqlConn As New SqlConnection
        Dim sqlCmd As New SqlCommand
        Dim sdrData As SqlDataReader
        '  Dim sb As StringBuilder
        Dim dt As New DataTable
        Dim sqlDataAdapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim revTotal As Double
        Dim valStr As String


        Dim count As Integer

        valStr = revenueTotal.Text
        valStr = valStr.Remove(0, 1)
        revTotal = valStr


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

        ' #########################################################################################
        ' This BLOCK determines whether today's DATE marks the first day of the current month.
        ' #########################################################################################

        ' Record the current date [TODAY'S DATE]
        Dim strDate As String = Date.Now.ToString("yyyy-MM-dd")
        '  Dim monthArray As String()

        'monthArray = strDate.Split(New Char() {"-"c})

        If (monthFDCheck(strDate)) Then
            dbFeedback.InnerText += "This is the FIRST day of the month of "
            dbFeedback.InnerText += monthName(strDate)
        Else
            dbFeedback.InnerText = "This is NOT the FIRST day of the month of "
            dbFeedback.InnerText += monthName(strDate)
        End If

        If (count <> 0) Then

            ' Definition of SQL statement to INSERT records within DB after successful scraping of site
            sqlCmd.CommandText = "UPDATE [cil-sales-metrics].[dbo].[doMetrics] SET " _
                                    & "[daily_iorders] = '" & iOrders_BMD & "', " _
                                    & "[daily_nworders] = '" & nwOrders_BMD & "', " _
                                    & "[daily_rworders] = '" & rwOrders_BMD & "', " _
                                    & "[daily_sorders] = '" & sOrders_BMD & "' " _
                                    & "WHERE [date] =  '" & todayDate & "'"

            ''    ' Make connection to DB and execute SQL commands
            sqlCmd.Connection = sqlConn
            sqlCmd.ExecuteNonQuery()

            sqlConn.Close()

        Else


            ' Definition of SQL statement to INSERT records within DB after successful scraping of site
            sqlCmd.CommandText = "INSERT into [cil-sales-metrics].[dbo].[doMetrics] " _
                                & "([daily_iorders], [daily_nworders], [daily_rworders], [daily_sorders], [account], [date]) " _
                                & "values( '" & iOrders_BMD & "', '" & nwOrders_BMD & "', '" & rwOrders_BMD & "', '" & sOrders_BMD & "', '5', '" & todayDate & "')"

            ' Make connection to DB and execute SQL commands
            sqlCmd.Connection = sqlConn
            sqlCmd.ExecuteNonQuery()





            sqlConn.Close()

        End If



        driver.Close()
        driver.Quit()


    End Sub

    ' Simple FUNCTION meant to determine which cells contain NO information.
    Function zeroTest(ByVal orderStr As String) As Integer
        If String.IsNullOrEmpty(orderStr) Then
            Return 0
        Else
            Return Convert.ToInt32(orderStr)
        End If
    End Function


    Function monthFDCheck(ByVal dateStr As String) As Boolean

        'Definition of a STRING array based on the date passed to this function.
        ' Create an ARRAY based on the today's date by SPLITTING the text based on the existence of the "-" character.

        ' Date is expected to be of the format "yyyy-MM-dd"
        Dim month As String() = dateStr.Split(New Char() {"-"c})

        ' Test for the FIRST day of the month
        If month(2) = "01" Then
            Return True
        Else
            Return False
        End If

    End Function

    Function monthName(ByVal dateStr As String) As String

        'Definition of a STRING array based on the date passed to this function.
        ' Create an ARRAY based on the today's date by SPLITTING the text based on the existence of the "-" character.

        Dim month As String() = dateStr.Split(New Char() {"-"c})

        ' SPLIT function allows used to convert "yyyy-MM-dd" to { [0]="yyyy", [1]="MM", [2]="dd" }
        Select Case month(1)

            Case "01"
                Return "January"
            Case "02"
                Return "February"
            Case "03"
                Return "March"
            Case "04"
                Return "April"
            Case "05"
                Return "May"
            Case "06"
                Return "June"
            Case "07"
                Return "July"
            Case "08"
                Return "August"
            Case "09"
                Return "September"
            Case "10"
                Return "October"
            Case "11"
                Return "November"
            Case "12"
                Return "December"
            Case Else
                Return "NAM"

        End Select


    End Function


End Class