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

        usrInput.SendKeys("<username>")
        usrPwd.SendKeys("<password>")


        btnSubmit.Click()

        ' Begin engagement with the site after SUCCESSFUL login
        Dim startDate As IWebElement = driver.FindElement(By.Name("tbStartDate"))
        Dim endDate As IWebElement = driver.FindElement(By.Name("tbEndDate"))
        Dim btnGenerate As IWebElement = driver.FindElement(By.Name("btnGenerate"))

        Dim todayDate As String = Date.Now.ToString("MM/dd/yyyy")

        startDate.Clear()
        endDate.Clear()

        startDate.SendKeys("03/01/2020")
        endDate.SendKeys(todayDate)

        btnGenerate.Click()

        ' Dim resultGrid As IWebElement = driver.FindElement(By.Id("PanelGeneral"))
        '  Dim resultGrid As IList(Of IWebElement) = driver.FindElement(By.Id("PanelGeneral"))

        ' Define the locations of TOTAL Revenue and TOTAL Processed Orders within the TABLE

        Dim orderTotal As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[13]/td[2]"))
        Dim revenueTotal As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[13]/td[3]"))
        Dim ordersBMD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[3]/td[2]"))
        Dim ordersBSD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[4]/td[2]"))
        Dim ordersCDG As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[5]/td[2]"))
        Dim ordersCDO As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[6]/td[2]"))
        Dim ordersCPK As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[7]/td[2]"))
        Dim ordersCPO As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[8]/td[2]"))
        Dim ordersCPW As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[9]/td[2]"))
        Dim ordersGDD As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[10]/td[2]"))
        Dim ordersMED As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[11]/td[2]"))
        Dim ordersMOC As IWebElement = driver.FindElement(By.XPath("//*[@id='dgDataQuery']/tbody/tr[12]/td[2]"))

        '  Dim rowTD As IWebElement


        ' livedata.InnerHtml = orderTotal.Text
        '  livedata.InnerHtml = "Total Orders Processed: " + orderTotal.Text + "<br> Total Revenue Earnings: " + revenueTotal.Text
        '  livedata.InnerHtml = "<br>"
        livedata.InnerHtml += "<br><b>CPO</b> Orders Processed: " + ordersCPO.Text
        livedata.InnerHtml += "<br><b>CPW</b> Orders Processed: " + ordersCPW.Text
        livedata.InnerHtml += "<br><b>CPK</b> Orders Processed: " + ordersCPK.Text
        livedata.InnerHtml += "<br><b>CDO</b> Orders Processed: " + ordersCDO.Text
        livedata.InnerHtml += "<br><b>BMD</b> Orders Processed: " + ordersBMD.Text
        livedata.InnerHtml += "<br><b>BSD</b> Orders Processed: " + ordersBSD.Text
        livedata.InnerHtml += "<br><b>Candrug</b> Orders Processed: " + ordersCDG.Text
        livedata.InnerHtml += "<br><b>GDD</b> Orders Processed: " + ordersGDD.Text
        livedata.InnerHtml += "<br><b>Medisave</b> Orders Processed: " + ordersMED.Text
        livedata.InnerHtml += "<br><b>MOC</b> Orders Processed: " + ordersMOC.Text
        livedata.InnerHtml += "<hr>"
        livedata.InnerHtml += "<br><h4>Total Orders Processed: " + orderTotal.Text + "</h4>"
        '  For Each row As IWebElement In resultGrid

        ' startDate.Clear()
        ' endDate.Clear()
        orderMetrics.InnerHtml = Convert.ToInt32(orderTotal.Text)
        'If (row.TagName.Equals("td")) Then
        '   tdElements = row.Text
        'End If
        driver.Close()
        driver.Quit()


    End Sub

End Class