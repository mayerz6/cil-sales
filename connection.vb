Imports System.Data.SqlClient
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome

Public Class connection

    ' Definition of the DB CLASS property.
    Dim sqlConn As New SqlConnection
    Dim sqlCmd As New SqlCommand

    Function dbConnect() As SqlConnection

        '  If IsNothing(sqlConn) Then
        sqlConn.ConnectionString = "server=MAYERZ-S940;" _
                & "database=cil-sales-metrics;" _
                & "uid=mayerz; pwd=M@y3rZT#ch;"
            sqlConn.Open()
        '  End If

        Return sqlConn

    End Function

End Class
