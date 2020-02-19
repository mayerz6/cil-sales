Imports System.Net
Imports System.Threading.Tasks
Imports System.Web.HttpRequest
Imports System
Imports System.IO
Imports System.Text

Public Class index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Scrape()
    End Sub

    Private Sub Scrape()

        Try

            Dim postData As String = ""


            postData += "https%3A%2F%2Fwww.candrugfrontend.com%2Fanalysis%2FLogin.aspx"
            postData += "&username=larrym"
            postData += "&password=ad364e"
            postData += "&__VIEWSTATE=/wEPDwUJLTM5MTgyNTA4ZBgBBR5"
            postData += "fX0NvbnRyb2xzUmVxdWlyZVBvc3R"
            postData += "CYWNrS2V5X18WAQUMSW1hZ2VidXR0"
            postData += "b24xKyITxiLQM2Qu58C14u0NUADyP"
            postData += "NeM5NjwWfWWJ3Q6a5c="

            Dim tempCookie As New CookieContainer
            Dim encoding As New UTF8Encoding
            Dim data As Byte() = encoding.GetBytes(postData)


            ' Store the site scraped as a variable
            Dim strURL As String = "https://www.candrugfrontend.com/analysis/Login.aspx"
            ' Any scraped information store as a variable
            Dim strOutput As String = ""
            Dim loginCookie As CookieContainer

            ' Instantiate an instance of the WebResponse CLASS to record the returned data from the scraped site.
            Dim wrResponse As WebResponse
            ' Instantiate an instance of the WebRequest CLASS to retrieve the contents of the site.
            '  Dim wrRequest As WebRequest = HttpWebRequest.Create(strURL)
            Dim wrRequest As HttpWebRequest = DirectCast(WebRequest.Create(strURL), HttpWebRequest)

            wrRequest.Method = "POST"
            wrRequest.KeepAlive = True
            wrRequest.ContentType = "application/x-www-form-urlencoded"
            wrRequest.Referer = "https://www.candrugfrontend.com/analysis/Login.aspx"

            wrRequest.ContentLength = data.Length
            wrRequest.CookieContainer = tempCookie
            wrRequest.UserAgent = "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.2309.372 Safari/537.36"
            wrRequest.ContentLength = data.Length

            Dim postReq As Stream = wrRequest.GetRequestStream()
            postReq.Write(data, 0, data.Length)
            postReq.Close()

            Dim postRes As HttpWebResponse
            postRes = DirectCast(wrRequest.GetResponse(), HttpWebResponse)
            tempCookie.Add(postRes.Cookies)
            loginCookie = tempCookie


            Dim postReqReader As New StreamReader(postRes.GetResponseStream())

            Dim thepage As String = postReqReader.ReadToEnd
            livedata.InnerHtml = thepage

            '  Using pt = wrRequest.GetRequestStream()
            '       pt.Write(data, 0, data.Length)
            '   End Using

            '    wrResponse = wrRequest.GetResponse()

            ' Dim wrResponse2 As WebResponse
            '  Dim wrRequest2 As WebRequest = HttpWebRequest.Create(strURL)

            ' wrResponse2 = wrRequest.GetResponse()
            ' Dim responseString As New StreamReader(wrResponse.GetResponseStream()).ReadToEnd()

            '   Using sr As New StreamReader(postRes.GetResponseStream())
            '  strOutput = sr.ReadToEnd()
            ' livedata.InnerHtml = strOutput
            ' End Using

        Catch ex As Exception
            Console.WriteLine(ex.Message, "Error scrapping site content!")
        End Try


    End Sub


End Class