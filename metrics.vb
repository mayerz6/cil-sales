Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium
Imports System.Data.SqlClient

Imports cil_metrics.connection

' Custom data type meant to store the scraped metrics for analysis



Public Class metrics

    Public Structure orderData
        Dim invoices As Integer
        Dim sales As Integer
        Dim new_web As Integer
        Dim return_web As Integer
    End Structure

    Dim driver As IWebDriver

    Dim usrInput As IWebElement
    Dim usrPwd As IWebElement
    Dim btnSubmit As IWebElement


    Dim startDate As IWebElement
    Dim endDate As IWebElement
    Dim btnGenerate As IWebElement

    Dim orderTotal As IWebElement
    Dim revenueTotal As IWebElement

    ' ################################# BMD Orders ################################# 
    Dim ordersBMD As IWebElement
    Dim sordersBMD As IWebElement
    Dim nwordersBMD As IWebElement
    Dim rwordersBMD As IWebElement

    ' ################################# BSD Orders ################################# 
    Dim ordersBSD As IWebElement
    Dim sordersBSD As IWebElement 
    Dim nwordersBSD As IWebElement
    Dim rwordersBSD As IWebElement

    ' ################################# CPO Orders ################################# 
    Dim ordersCPO As IWebElement
    Dim sordersCPO As IWebElement 
    Dim nwordersCPO As IWebElement
    Dim rwordersCPO As IWebElement

    ' ################################# CPW Orders ################################# 
    Dim ordersCPW As IWebElement
    Dim sordersCPW As IWebElement 
    Dim nwordersCPW As IWebElement
    Dim rwordersCPW As IWebElement

    ' ################################# CPK Orders ################################# 
    Dim ordersCPK As IWebElement
    Dim sordersCPK As IWebElement 
    Dim nwordersCPK As IWebElement
    Dim rwordersCPK As IWebElement

    ' ################################# CDO Orders ################################# 
    Dim ordersCDO As IWebElement
    Dim sordersCDO As IWebElement 
    Dim nwordersCDO As IWebElement
    Dim rwordersCDO As IWebElement

    ' ################################# Candrug Orders ################################# 
    Dim ordersCDG As IWebElement
    Dim sordersCDG As IWebElement 
    Dim nwordersCDG As IWebElement
    Dim rwordersCDG As IWebElement

    ' ################################# GDD Orders ################################# 
    Dim ordersGDD As IWebElement
    Dim sordersGDD As IWebElement 
    Dim nwordersGDD As IWebElement
    Dim rwordersGDD As IWebElement

    ' ################################# MOC Orders ################################# 
    Dim ordersMOC As IWebElement
    Dim sordersMOC As IWebElement 
    Dim nwordersMOC As IWebElement
    Dim rwordersMOC As IWebElement

    ' ################################# Medisave Orders ################################# 
    Dim ordersMED As IWebElement
    Dim sordersMED As IWebElement 
    Dim nwordersMED As IWebElement
    Dim rwordersMED As IWebElement

    Dim t_Date As String
    Dim Url As String

    Dim total_orders As Integer = 0
    Dim total_revenue As Double = 0.0
    Dim annual_orders As Integer = 0

    Dim metrics(9) As orderData

    ' Constructor function
    Sub New()

        ' Instantiate an instance of the Chrome browser
        Dim chromeOptions As ChromeOptions = New ChromeOptions()
        chromeOptions.AddArguments("--headless")

        Url = "https://www.candrugfrontend.com/analysis/Login.aspx"
        driver = New ChromeDriver(chromeOptions)
        '  Navigate to the webpage we want to scrap
        driver.Navigate().GoToUrl(Url)

    End Sub

    Sub UserLogin()


        ' Store the elements we wish to interact with as public variables
        usrInput = driver.FindElement(By.Name("username"))
        usrPwd = driver.FindElement(By.Name("password"))
        btnSubmit = driver.FindElement(By.Name("Imagebutton1"))

        ' Send login credentials to the login form
        usrInput.SendKeys("larrym")
        usrPwd.SendKeys("ad364e")

        btnSubmit.Click()


    End Sub

    ' Function used to return the CURRENT date
    Function TodaysDate() As String
        Return t_Date
    End Function

    Sub RetrieveMetrics()

        ' ################################################################################
        '               User has successfully logged into the website.
        ' ################################################################################

        ' Begin engagement with the site after SUCCESSFUL login
        startDate = driver.FindElement(By.Name("tbStartDate"))
        endDate = driver.FindElement(By.Name("tbEndDate"))
        btnGenerate = driver.FindElement(By.Name("btnGenerate"))

        Me.t_Date = Date.Now.ToString("MM/dd/yyyy")
        '  Me.t_Date = "01/07/2020"

        startDate.Clear()
        endDate.Clear()

        startDate.SendKeys(t_Date)
        endDate.SendKeys(t_Date)


        btnGenerate.Click()

    End Sub

    Function ReturnDriver() As IWebDriver
        Return driver
    End Function

    Sub CloseDriver()
        driver.Close()
        driver.Quit()
    End Sub


    Sub RetrieveTotals()

        ' Define the locations of TOTAL Revenue and TOTAL Processed Orders within the TABLE
        Me.orderTotal = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[13]/td[2]"))
        Me.revenueTotal = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[13]/td[3]"))

    End Sub

    Function GetTotalOrders() As String
        Dim orTo As String = Me.orderTotal.Text
        Me.total_orders = If(orTo = " ", 0, Convert.ToInt32(orTo))
        Return Me.total_orders.ToString()
    End Function

    Function GetTotalRevenue() As String
        Dim revTo As String = Me.revenueTotal.Text
        Me.total_revenue = If(revTo <> " ", revTo, 0)
        Return Me.total_revenue.ToString()
    End Function

    Function returnTotalOrders() As String
        Return Me.total_orders.ToString()
    End Function


    Function returnAnnualOrders() As String
        Return Me.annual_orders.ToString()
    End Function


    Sub CPO_fetchData()

        ' ################################# CPO Orders ################################# 
        ' ################################################################################

        ordersCPO = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[8]/td[2]"))
        sordersCPO = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[8]/td[6]"))
        nwordersCPO = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[8]/td[8]"))
        rwordersCPO = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[8]/td[9]"))

        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_CPO As Integer = If(ordersCPO.Text = " ", 0, Convert.ToInt32(ordersCPO.Text))
        Dim sOrders_CPO As Integer = If(sordersCPO.Text = " ", 0, Convert.ToInt32(sordersCPO.Text))
        Dim nwOrders_CPO As Integer = If(nwordersCPO.Text = " ", 0, Convert.ToInt32(nwordersCPO.Text))
        Dim rwOrders_CPO As Integer = If(rwordersCPO.Text = " ", 0, Convert.ToInt32(rwordersCPO.Text))

        metrics(0).invoices = iOrders_CPO
        metrics(0).sales = sOrders_CPO
        metrics(0).new_web = nwOrders_CPO
        metrics(0).return_web = rwOrders_CPO

    End Sub

    Function returnDO_CPO() As String
        Return Me.metrics(0).invoices.ToString()
    End Function

    Sub CPW_fetchData()

        ' ################################# CPW Orders ################################# 
        ' ################################################################################

        ordersCPW = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[9]/td[2]"))
        sordersCPW = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[9]/td[6]"))
        nwordersCPW = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[9]/td[8]"))
        rwordersCPW = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[9]/td[9]"))

        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_CPW As Integer = If(ordersCPW.Text = " ", 0, Convert.ToInt32(ordersCPW.Text))
        Dim sOrders_CPW As Integer = If(sordersCPW.Text = " ", 0, Convert.ToInt32(sordersCPW.Text))
        Dim nwOrders_CPW As Integer = If(nwordersCPW.Text = " ", 0, Convert.ToInt32(nwordersCPW.Text))
        Dim rwOrders_CPW As Integer = If(rwordersCPW.Text = " ", 0, Convert.ToInt32(rwordersCPW.Text))

        metrics(1).invoices = iOrders_CPW
        metrics(1).sales = sOrders_CPW
        metrics(1).new_web = nwOrders_CPW
        metrics(1).return_web = rwOrders_CPW

    End Sub

    Function returnDO_CPW() As String
        Return Me.metrics(1).invoices.ToString()
    End Function

    Sub CPK_fetchData()

        ' ################################# CPK Orders ################################# 
        ' ################################################################################

        ordersCPK = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[7]/td[2]"))
        sordersCPK = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[7]/td[6]"))
        nwordersCPK = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[7]/td[8]"))
        rwordersCPK = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[7]/td[9]"))

        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_CPK As Integer = If(ordersCPK.Text = " ", 0, Convert.ToInt32(ordersCPK.Text))
        Dim sOrders_CPK As Integer = If(sordersCPK.Text = " ", 0, Convert.ToInt32(sordersCPK.Text))
        Dim nwOrders_CPK As Integer = If(nwordersCPK.Text = " ", 0, Convert.ToInt32(nwordersCPK.Text))
        Dim rwOrders_CPK As Integer = If(rwordersCPK.Text = " ", 0, Convert.ToInt32(rwordersCPK.Text))

        metrics(2).invoices = iOrders_CPK
        metrics(2).sales = sOrders_CPK
        metrics(2).new_web = nwOrders_CPK
        metrics(2).return_web = rwOrders_CPK

    End Sub

    Function returnDO_CPK() As String
        Return Me.metrics(2).invoices.ToString()
    End Function

    Sub CDO_fetchData()

        ' ################################# CDO Orders ################################# 
        ' ################################################################################

        ordersCDO = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[6]/td[2]"))
        sordersCDO = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[6]/td[6]"))
        nwordersCDO = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[6]/td[8]"))
        rwordersCDO = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[6]/td[9]"))


        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_CDO As Integer = If(ordersCDO.Text = " ", 0, Convert.ToInt32(ordersCDO.Text))
        Dim sOrders_CDO As Integer = If(sordersCDO.Text = " ", 0, Convert.ToInt32(sordersCDO.Text))
        Dim nwOrders_CDO As Integer = If(nwordersCDO.Text = " ", 0, Convert.ToInt32(nwordersCDO.Text))
        Dim rwOrders_CDO As Integer = If(rwordersCDO.Text = " ", 0, Convert.ToInt32(rwordersCDO.Text))

        metrics(3).invoices = iOrders_CDO
        metrics(3).sales = sOrders_CDO
        metrics(3).new_web = nwOrders_CDO
        metrics(3).return_web = rwOrders_CDO

    End Sub

    Function returnDO_CDO() As String
        Return Me.metrics(3).invoices.ToString()
    End Function

    Sub BMD_fetchData()

        ' ################################# BMD Orders ################################# 
        ' ##############################################################################

        ordersBMD = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[3]/td[2]"))
        sordersBMD = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[3]/td[6]"))
        nwordersBMD = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[3]/td[8]"))
        rwordersBMD = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[3]/td[9]"))

        ' Tests for EMPTY cells returned from DATAVIEW table using the TENARY operator

        Dim iOrders_BMD As Integer = If(ordersBMD.Text = " ", 0, Convert.ToInt32(ordersBMD.Text))
        Dim sOrders_BMD As Integer = If(sordersBMD.Text = " ", 0, Convert.ToInt32(sordersBMD.Text))
        Dim nwOrders_BMD As Integer = If(nwordersBMD.Text = " ", 0, Convert.ToInt32(nwordersBMD.Text))
        Dim rwOrders_BMD As Integer = If(rwordersBMD.Text = " ", 0, Convert.ToInt32(rwordersBMD.Text))


        metrics(4).invoices = iOrders_BMD
        metrics(4).sales = sOrders_BMD
        metrics(4).new_web = nwOrders_BMD
        metrics(4).return_web = rwOrders_BMD

    End Sub

    Function returnDO_BMD() As String
        Return Me.metrics(4).invoices.ToString()
    End Function
    Sub BSD_fetchData()

        ' ################################# BSD Orders ################################# 
        ' ################################################################################

        ordersBSD = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[4]/td[2]"))
        sordersBSD = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[4]/td[6]"))
        nwordersBSD = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[4]/td[8]"))
        rwordersBSD = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[4]/td[9]"))


        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_BSD As Integer = If(ordersBSD.Text = " ", 0, Convert.ToInt32(ordersBSD.Text))
        Dim sOrders_BSD As Integer = If(sordersBSD.Text = " ", 0, Convert.ToInt32(sordersBSD.Text))
        Dim nwOrders_BSD As Integer = If(nwordersBSD.Text = " ", 0, Convert.ToInt32(nwordersBSD.Text))
        Dim rwOrders_BSD As Integer = If(rwordersBSD.Text = " ", 0, Convert.ToInt32(rwordersBSD.Text))

        metrics(5).invoices = iOrders_BSD
        metrics(5).sales = sOrders_BSD
        metrics(5).new_web = nwOrders_BSD
        metrics(5).return_web = rwOrders_BSD

    End Sub

    Function returnDO_BSD() As String
        Return Me.metrics(5).invoices.ToString()
    End Function

    Sub CDG_fetchData()

        ' ################################# Candrug Orders ################################# 
        ' ################################################################################

        ordersCDG = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[5]/td[2]"))
        sordersCDG = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[5]/td[6]"))
        nwordersCDG = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[5]/td[8]"))
        rwordersCDG = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[5]/td[9]"))

        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_CDG As Integer = If(ordersCDG.Text = " ", 0, Convert.ToInt32(ordersCDG.Text))
        Dim sOrders_CDG As Integer = If(sordersCDG.Text = " ", 0, Convert.ToInt32(sordersCDG.Text))
        Dim nwOrders_CDG As Integer = If(nwordersCDG.Text = " ", 0, Convert.ToInt32(nwordersCDG.Text))
        Dim rwOrders_CDG As Integer = If(rwordersCDG.Text = " ", 0, Convert.ToInt32(rwordersCDG.Text))

        metrics(6).invoices = iOrders_CDG
        metrics(6).sales = sOrders_CDG
        metrics(6).new_web = nwOrders_CDG
        metrics(6).return_web = rwOrders_CDG

    End Sub

    Function returnDO_CDG() As String
        Return Me.metrics(6).invoices.ToString()
    End Function
    Sub GDD_fetchData()

        ' ################################# GDD Orders ################################# 
        ' ################################################################################

        ordersGDD = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[10]/td[2]"))
        sordersGDD = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[10]/td[6]"))
        nwordersGDD = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[10]/td[8]"))
        rwordersGDD = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[10]/td[9]"))

        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_GDD As Integer = If(ordersGDD.Text = " ", 0, Convert.ToInt32(ordersGDD.Text))
        Dim sOrders_GDD As Integer = If(sordersGDD.Text = " ", 0, Convert.ToInt32(sordersGDD.Text))
        Dim nwOrders_GDD As Integer = If(nwordersGDD.Text = " ", 0, Convert.ToInt32(nwordersGDD.Text))
        Dim rwOrders_GDD As Integer = If(rwordersGDD.Text = " ", 0, Convert.ToInt32(rwordersGDD.Text))


        metrics(7).invoices = iOrders_GDD
        metrics(7).sales = sOrders_GDD
        metrics(7).new_web = nwOrders_GDD
        metrics(7).return_web = rwOrders_GDD

    End Sub

    Function returnDO_GDD() As String
        Return Me.metrics(7).invoices.ToString()
    End Function
    Sub MOC_fetchData()

        ' ################################# MOC Orders ################################# 
        ' ################################################################################

        ordersMOC = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[12]/td[2]"))
        sordersMOC = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[12]/td[6]"))
        nwordersMOC = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[12]/td[8]"))
        rwordersMOC = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[12]/td[9]"))

        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_MOC As Integer = If(ordersMOC.Text = " ", 0, Convert.ToInt32(ordersMOC.Text))
        Dim sOrders_MOC As Integer = If(sordersMOC.Text = " ", 0, Convert.ToInt32(sordersMOC.Text))
        Dim nwOrders_MOC As Integer = If(nwordersMOC.Text = " ", 0, Convert.ToInt32(nwordersMOC.Text))
        Dim rwOrders_MOC As Integer = If(rwordersMOC.Text = " ", 0, Convert.ToInt32(rwordersMOC.Text))


        metrics(8).invoices = iOrders_MOC
        metrics(8).sales = sOrders_MOC
        metrics(8).new_web = nwOrders_MOC
        metrics(8).return_web = rwOrders_MOC


    End Sub

    Function returnDO_MOC() As String
        Return Me.metrics(8).invoices.ToString()
    End Function
    Sub MED_fetchData()

        ' ################################# Medisave Orders ################################# 
        ' ################################################################################

        ordersMED = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[11]/td[2]"))
        sordersMED = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[11]/td[6]"))
        nwordersMED = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[11]/td[8]"))
        rwordersMED = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[11]/td[9]"))


        ' Tests for EMPTY cells returned from DATAVIEW table
        Dim iOrders_MED As Integer = If(ordersMED.Text = " ", 0, Convert.ToInt32(ordersMED.Text))
        Dim sOrders_MED As Integer = If(sordersMED.Text = " ", 0, Convert.ToInt32(sordersMED.Text))
        Dim nwOrders_MED As Integer = If(nwordersMED.Text = " ", 0, Convert.ToInt32(nwordersMED.Text))
        Dim rwOrders_MED As Integer = If(rwordersMED.Text = " ", 0, Convert.ToInt32(rwordersMED.Text))


        metrics(9).invoices = iOrders_MED
        metrics(9).sales = sOrders_MED
        metrics(9).new_web = nwOrders_MED
        metrics(9).return_web = rwOrders_MED

    End Sub
    Function returnDO_MED() As String
        Return Me.metrics(9).invoices.ToString()
    End Function


    Sub getMetrics()


        Dim sqlConn As New SqlConnection
        Dim sqlCmd As New SqlCommand
        Dim sdrData As SqlDataReader
        '  Dim sb As StringBuilder
        Dim dt As New DataTable
        Dim sqlDataAdapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim mFD As String = monthString(Me.t_Date)
        Dim cM As String = monthName(Me.t_Date)
        Dim tdStr As DateTime = DateTime.ParseExact(Me.t_Date, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture)

        Dim todayDate As String = tdStr.ToString("yyyy-MM-dd")

        ' Instantiate an instance of the DB connection CLASS for our ability to communicate with our SQL server.
        Dim txCon As New connection

        ' sqlCmd.Connection = sqlConn
        sqlCmd.Connection = txCon.getInstance()


        ' Retrieve the latest TOTAL orders processed for the current month.
        sqlCmd.CommandText = "EXECUTE getMonthlyTotals @currentMonth='" & cM & "'"
        '  sqlCmd.Connection = txCon.dbConnect()
        sdrData = sqlCmd.ExecuteReader()

        ' The TOTAL monthly order is returned based on the results of the stored procedure.
        While sdrData.Read()
            '   If Not IsDBNull(sdrData("tdi")) Then
            Me.total_orders = If(IsDBNull(sdrData("tdi")), 0, Convert.ToInt32(sdrData("tdi")))
        End While
        sdrData.Close()
        ' sqlConn.Close()

        cM = 2020
        ' sqlConn.Open()


        ' Retrieve the latest TOTAL orders processed for the current month.
        sqlCmd.CommandText = "EXECUTE getAnnualTotals @currentMonth='" & cM & "'"
        ' sqlCmd.Connection = txCon.dbConnect()
        sdrData = sqlCmd.ExecuteReader()

        ' The TOTAL monthly order is returned based on the results of the stored procedure.
        While sdrData.Read()
            '   If Not IsDBNull(sdrData("tdi")) Then
            Me.annual_orders = If(IsDBNull(sdrData("tdi")), 0, Convert.ToInt32(sdrData("tdi")))
        End While
        sdrData.Close()
        txCon.closeInstance()

    End Sub


    Sub insertMetrics()


        Dim sqlConn As New SqlConnection
        Dim sqlCmd As New SqlCommand
        Dim sdrData As SqlDataReader
        '  Dim sb As StringBuilder
        Dim dt As New DataTable
        Dim sqlDataAdapter As New SqlDataAdapter
        Dim ds As New DataSet
        Dim mFD As String = monthString(Me.t_Date)
        Dim cM As String = monthName(Me.t_Date)
        Dim tdStr As DateTime = DateTime.ParseExact(Me.t_Date, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture)

        Dim todayDate As String = tdStr.ToString("yyyy-MM-dd")

        ' Instantiate an instance of the DB connection CLASS for our ability to communicate with our SQL server.
        Dim txCon As New connection

        Dim count As Integer = 1


        ' sqlCmd.Connection = sqlConn
        sqlCmd.Connection = txCon.getInstance()

        ' Test for the existence of a record with a DATE which matches today's date.
        sqlCmd.CommandText = "SELECT COUNT(*) AS 'RESULTS' FROM [cil-sales-metrics].[dbo].[doMetrics] WHERE [date] = '" & todayDate & "'"
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
                & "[daily_nworders] = '" & Me.metrics(i).new_web & "', " _
                & "[daily_rworders] = '" & Me.metrics(i).return_web & "', " _
                & "[daily_sorders] = '" & Me.metrics(i).sales & "' " _
                & "WHERE [date] =  '" & todayDate & "' AND [account] = '" & i & "'"

                ' Make connection to DB and execute SQL commands
                '   sqlCmd.Connection = txCon.dbConnect()
                sqlCmd.ExecuteNonQuery()

            Next i

            sqlCmd.CommandText = "EXECUTE addMonthlyTotals @currentDate='" & todayDate & "', @monthFD='" & mFD & "', @currentMonth='" & cM & "'"
            '  sqlCmd.Connection = txCon.dbConnect()
            sqlCmd.ExecuteNonQuery()
            ' sqlConn.Close()

            ' If we haven't previously entered order metrics for today's date then INSERT new values based on the query below.
        Else

            For i As Integer = 0 To 9 Step +1

                '     sqlResults.InnerText = "There were " & count & "records found!!!!"
                'Definition of SQL statement to INSERT records within DB after successful scraping of site
                sqlCmd.CommandText = "INSERT into [cil-sales-metrics].[dbo].[doMetrics] " _
                & "([daily_iorders], [daily_nworders], [daily_rworders], [daily_sorders], [account], [date]) " _
                & "values('" & metrics(i).invoices & "', '" & metrics(i).new_web & "', '" & metrics(i).return_web & "', '" & metrics(i).sales & "', '" & i & "', '" & todayDate & "')"

                ' Make connection to DB and execute SQL commands
                '  sqlCmd.Connection = txCon.dbConnect()
                sqlCmd.ExecuteNonQuery()

            Next i

            sqlCmd.CommandText = "EXECUTE addMonthlyTotals @currentDate='" & todayDate & "', @monthFD='" & mFD & "', @currentMonth='" & cM & "'"
            '  sqlCmd.Connection = txCon.dbConnect()
            sqlCmd.ExecuteNonQuery()
            '  sqlConn.Close()

        End If

        txCon.closeInstance()

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
