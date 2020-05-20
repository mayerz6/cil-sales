Imports System.Data.SqlClient
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome

Public Class connection

    ' Definition of the DB CLASS Properties
    Dim sqlConn As New SqlConnection
    Dim sqlCmd As New SqlCommand

    Function getInstance() As SqlConnection

        If (sqlConn.State <> ConnectionState.Open) Then
            dbConnect()
            sqlConn.Close()
            sqlConn.Open()
        End If

        Return sqlConn
    End Function


    Function dbConnect()

        ' Configure the settings necessary to interact with the DB
        sqlConn.ConnectionString = "server=MAYERZ-S940;" _
                & "database=cil-sales-metrics;" _
                & "uid=mayerz; pwd=M@y3rZT#ch;"

        Return Nothing

    End Function

End Class
