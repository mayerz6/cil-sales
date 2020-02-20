Imports System.Net
Imports System.Threading.Tasks
Imports System.Web.HttpRequest
Imports System
Imports System.IO
Imports System.Text

Public Class index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' fetchContent()
        ' postContent()
        Scrap_4()
    End Sub


    Private Sub fetchContent()

        Dim URL_1 As String = "https://www.candrugfrontend.com/analysis/Login.aspx?"
        URL_1 += "__EVENTTARGET="
        URL_1 += "&__EVENTARGUMENT="
        URL_1 += "&__VIEWSTATE=%2FwEPDwUJLTM5MTgyNTA4D2QWBAIBDw8WAh4EVGV4dAUcVXNlciBuY"
        URL_1 += "W1lIG9yIHBhc3N3b3JkIGVycm9yLmRkAgMPZBYCAgEPDxYCHwAFBmxhc"
        URL_1 += "nJ5bWRkGAEFHl9fQ29udHJvbHNSZXF1aXJlUG9zdEJhY2tLZXlfXxYBBQ"
        URL_1 += "xJbWFnZWJ1dHRvbjEEoMwgGTo4TXAF%2.0Fmi4nPIWw%2Fq1zdqgWkFokzukPW%2.0FX0Q%3D%3D"
        URL_1 += "&__VIEWSTATEGENERATOR=7013DD5C"
        URL_1 += "&__EVENTVALIDATION=%2FwEdAASBQuORhJmbPJ3yot7Apj8FKhoCyVdJtLIis5AgYZ%2FRYe4sciJO3Hoc68"
        URL_1 += "xTFtZGQEigHWxeGMVV9FZeLIVAhNhI91qHKvs0yubJEhGvttQFUl4%2Fex1nQiPDrCsweLI%2FliU%3D"
        URL_1 += "&username=larrym"
        URL_1 += "&password=ad364e"
        URL_1 += "&Imagebutton1.x=47&Imagebutton1.y=10"

        ' Any scraped information store as a variable
        Dim strOutput As String = ""

        ' Instantiate an instance of the WebRequest CLASS to retrieve the contents of the site.

        ' OPTION 1 - Request to fetch the initial login page from the site.
        Dim wrRequest As HttpWebRequest = DirectCast(WebRequest.Create(URL_1), HttpWebRequest)

        ' OPTION 2 - Request to fetch the initial login page from the site.
        ' Dim wrRequest As WebRequest = HttpWebRequest.Create(URL_1)

        ' Instantiate an instance of the WebResponse CLASS to record the returned data from the scraped site.
        Dim wrResponse As WebResponse
        wrResponse = DirectCast(wrRequest.GetResponse(), HttpWebResponse)

        ' Read the returned content via a STREAM then return this content to the page.
        Using sr As New StreamReader(wrResponse.GetResponseStream())
            strOutput = sr.ReadToEnd()
            livedata.InnerText = strOutput

        End Using

    End Sub

    Private Sub postContent()

        Dim URL_0 As String = "https://www.candrugfrontend.com/analysis/Login.aspx"
        Dim rWLCookies As HttpWebRequest = DirectCast(WebRequest.Create(URL_0), HttpWebRequest)
        Dim loginCookie As CookieCollection = New CookieCollection()
        rWLCookies.CookieContainer = New CookieContainer()
        rWLCookies.Method = "POST"

        ' Store the site scraped as a variable
        Dim strURL As String = "https://www.candrugfrontend.com/analysis/DataQuery.aspx"
        Dim postData As String = ""


        postData += "&__VIEWSTATE=/wEPDwUJLTM5MTgyNTA4ZBgBBR5"
        postData += "fX0NvbnRyb2xzUmVxdWlyZVBvc3R"
        postData += "CYWNrS2V5X18WAQUMSW1hZ2VidXR0"
        postData += "b24xKyITxiLQM2Qu58C14u0NUADyP"
        postData += "NeM5NjwWfWWJ3Q6a5c="
        postData += "&__VIEWSTATEGENERATOR=7013DD5C"
        postData += "&__EVENTVALIDATION=/wEdAASK+oP"
        postData += "BobEmqhMCWLYzXLmnKhoCyVdJtLIis5"
        postData += "AgYZ/RYe4sciJO3Hoc68xTFtZGQEigH"
        postData += "WxeGMVV9FZeLIVAhNhIvG5zkZePmXhq"
        postData += "G7NYdumCWQguqZRH+AnoZBhEN50A/Xc="
        postData += "username=larrym"
        postData += "&password=ad364e"


        Dim tempCookie As New CookieCollection
        Dim encoding As New UTF8Encoding
        Dim data As Byte() = encoding.GetBytes(postData)
        ' Any scraped information store as a variable

        ' Request to fetch the initial login page from the site.
        Dim wrRequest As HttpWebRequest = DirectCast(WebRequest.Create(strURL), HttpWebRequest)

        wrRequest.Method = "POST"
        wrRequest.KeepAlive = True
        wrRequest.Credentials = New NetworkCredential("larrym", "ad364e")
        wrRequest.AllowWriteStreamBuffering = True
        wrRequest.ContentType = "application/x-www-form-urlencoded"
        wrRequest.Referer = "https://www.candrugfrontend.com/analysis/DataQuery.aspx"
        wrRequest.AllowAutoRedirect = True
        wrRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"
        wrRequest.Headers.Add("Accept-Language: en-us,en;q=0.5")
        wrRequest.Headers.Add("Accept-Encoding: gzip,deflate")
        wrRequest.Headers.Add("Accept-Charset: ISO-8859-1,utf-8;q=0.7,*;q=0.7")
        wrRequest.KeepAlive = True
        wrRequest.UserAgent = "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.2309.372 Safari/537.36"

        wrRequest.ContentLength = data.Length

        '  wrRequest.CookieContainer = tempCookie
        ' Dim postReq As New StreamWriter(wrRequest.GetRequestStream())

        Using postReq As New StreamWriter(wrRequest.GetRequestStream())
            ' postReq.Write(data, 0, data.Length)
            postReq.Write(postData)
            '    postReq.Close()
        End Using



        Dim postRes As HttpWebResponse = wrRequest.GetResponse()
        wrRequest = WebRequest.Create(strURL)

        wrRequest.CookieContainer = New CookieContainer()
        wrRequest.CookieContainer.Add(postRes.Cookies)

        Dim httpRes2 As HttpWebResponse = DirectCast(wrRequest.GetResponse(), HttpWebResponse)

        postRes = DirectCast(wrRequest.GetResponse(), HttpWebResponse)
        tempCookie.Add(postRes.Cookies)
        loginCookie = tempCookie


        Dim postReqReader As New StreamReader(httpRes2.GetResponseStream())

        Dim thepage As String = postReqReader.ReadToEnd

        livedata.InnerHtml = thepage
        content.InnerText = data.Length

    End Sub

    Private Sub Scrape()

        Try

            Dim URL_0 As String = "https://www.candrugfrontend.com/analysis/Login.aspx?PAGE=DataQuery.aspx"
            Dim URL As String = "https://www.candrugfrontend.com/analysis/DataQuery.aspx"

            Dim postData As String = ""
            postData += "?__EVENTTARGET="
            postData += "&__EVENTARGUMENT="
            '     postData += "&__VIEWSTATE=%2FwEPDwUJLTM5MTgyNTA4D2QWBAIBDw8WAh4EVGV4dAUcVXNlciBuY"
            '    postData += "W1lIG9yIHBhc3N3b3JkIGVycm9yLmRkAgMPZBYCAgEPDxYCHwAFBmxhc"
            '   postData += "nJ5bWRkGAEFHl9fQ29udHJvbHNSZXF1aXJlUG9zdEJhY2tLZXlfXxYBBQ"
            '  postData += "xJbWFnZWJ1dHRvbjEEoMwgGTo4TXAF%2.0Fmi4nPIWw%2Fq1zdqgWkFokzukPW%2.0FX0Q%3D%3D"
            postData += "&__VIEWSTATEGENERATOR=7013DD5C"
            '   postData += "&__EVENTVALIDATION=%2FwEdAASBQuORhJmbPJ3yot7Apj8FKhoCyVdJtLIis5AgYZ%2FRYe4sciJO3Hoc68"
            '  postData += "xTFtZGQEigHWxeGMVV9FZeLIVAhNhI91qHKvs0yubJEhGvttQFUl4%2Fex1nQiPDrCsweLI%2FliU%3D"

            postData += "&username=larrym"
            postData += "&password=ad364e"
            '            postData += "&Imagebutton1.x=47&Imagebutton1.y=10"

            '   "https://www.candrugfrontend.com/analysis/Login.aspx?__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE=%2FwEPDwUJLTM5MTgyNTA4D2QWBAIBDw8WAh4EVGV4dAUcVXNlciBuYW1lIG9yIHBhc3N3b3JkIGVycm9yLmRkAgMPZBYCAgEPDxYCHwAFBmxhcnJ5bWRkGAEFHl9fQ29udHJvbHNSZXF1aXJlUG9zdEJhY2tLZXlfXxYBBQxJbWFnZWJ1dHRvbjEEoMwgGTo4TXAF%2Fmi4nPIWw%2Fq1zdqgWkFokzukPW%2FX0Q%3D%3D&__VIEWSTATEGENERATOR=7013DD5C&__EVENTVALIDATION=%2FwEdAASBQuORhJmbPJ3yot7Apj8FKhoCyVdJtLIis5AgYZ%2FRYe4sciJO3Hoc68xTFtZGQEigHWxeGMVV9FZeLIVAhNhI91qHKvs0yubJEhGvttQFUl4%2Fex1nQiPDrCsweLI%2FliU%3D&username=larrym&password=ad364e&Imagebutton1.x=47&Imagebutton1.y=10"

            content.InnerText = URL_0 + postData

            Dim tempCookies As New CookieContainer
            Dim encoding As New UTF8Encoding
            Dim byteData As Byte() = encoding.GetBytes(postData)

            Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create(URL_0), HttpWebRequest)
            postReq.Method = "GET"
            postReq.KeepAlive = True
            postReq.CookieContainer = tempCookies
            postReq.ContentType = "application/x-www-form-urlencoded"
            postReq.Referer = URL
            postReq.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; ru; rv:1.9.2.3) Gecko/20100401 Firefox/4.0 (.NET CLR 3.5.30729)"
            postReq.ContentLength = byteData.Length

            Dim postreqstream As Stream = postReq.GetRequestStream()
            postreqstream.Write(byteData, 0, byteData.Length)
            postreqstream.Close()
            Dim postresponse As HttpWebResponse

            postresponse = DirectCast(postReq.GetResponse(), HttpWebResponse)
            tempCookies.Add(postresponse.Cookies)
            Dim logincookie As CookieContainer
            logincookie = tempCookies
            Dim postreqreader As New StreamReader(postresponse.GetResponseStream())

            Dim thepage As String = postreqreader.ReadToEnd

            livedata.InnerHtml = thepage


        Catch ex As Exception
            Console.WriteLine(ex.Message, "Error scrapping site content!")
        End Try


    End Sub

    Private Sub Scrap_4()

        ' Dim wrRequest As WebRequest = HttpWebRequest.Create(URL_1)
        Dim postReq As WebRequest = WebRequest.Create("https://www.candrugfrontend.com/analysis/Login.aspx")
        postReq.Credentials = CredentialCache.DefaultCredentials
        postReq.Method = "POST"
        Dim postStr As String = "username=larrym&password=ad364e"
        Dim byteData = Encoding.UTF8.GetBytes(postStr)





        Using streamReq As New StreamReader(postReq.GetRequestStream())
            ' streamReq.Write(byteData, 0, byteData.Length)
            '  Using reader As StreamReader = New StreamReader(streamReq)
            Dim pageData As String = streamReq.ReadToEnd()
            livedata.InnerHtml = pageData

        End Using



    End Sub


End Class