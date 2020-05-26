Imports System.Data.SqlClient
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome

Public Class connection

    ' Definition of the DB CLASS Properties
    Private sqlConn As New SqlConnection
    Dim sqlCmd As New SqlCommand

    Public Function getInstance() As SqlConnection

        If (sqlConn.State <> ConnectionState.Open) Then
            dbConnect()
            Console.WriteLine("Connected!!!")
            Me.sqlConn.Close()
            Me.sqlConn.Open()
        End If

        Return Me.sqlConn

    End Function

    Public Function closeInstance()
        Me.sqlConn.Close()
        Return Nothing
    End Function


    Public Function dbConnect()

        ' Configure the settings necessary to interact with the DB
        sqlConn.ConnectionString = "server=MAYERZ-S940;" _
                & "database=cil-sales-metrics;" _
                & "uid=mayerz; pwd=M@y3rZT#ch;"

        Return Nothing

    End Function

End Class
