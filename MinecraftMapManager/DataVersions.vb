Imports System.Collections.ObjectModel
Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Public Class DataVersions
    Structure VersionInfo
        Dim DataVersion As String
        Dim ClientVersion As String
        Dim ProtocolVersion As String
    End Structure

    Public Shared Dim dataVersions = New List(Of VersionInfo)

    Public Shared Function GetDataVersions() As List(Of VersionInfo)
        If dataVersions.Count > 0
            Return dataVersions
        End If

        Dim assembly = Reflection.Assembly.GetExecutingAssembly()
        Dim path = "DataVersions.csv"
        Using stream As New StreamReader(assembly.GetManifestResourceStream("MinecraftMapManager." + path))
            Using reader = New TextFieldParser(stream)
                reader.TextFieldType = FieldType.Delimited
                reader.SetDelimiters(",")

                Dim currentRow As String()
                While Not reader.EndOfData
                    Try
                        currentRow = reader.ReadFields()
                        Dim versionInfo = New VersionInfo
                        versionInfo.DataVersion = currentRow(0)
                        versionInfo.ClientVersion = currentRow(1)
                        versionInfo.ProtocolVersion = currentRow(2)
                        dataVersions.Add(versionInfo)
                    Catch ex As MalformedLineException

                    End Try
                End While
            End Using
        End Using

        Return dataVersions
    End Function

    Public Shared Function GetDataVersionInfo(dataVersion As String) As Collection(Of VersionInfo)
        If dataVersions.Count < 1
            Return Nothing
        End If

        Dim foundVersions = New Collection(Of VersionInfo)

        For i As Integer = dataVersions.Count - 1 To 0 Step - 1
            if dataVersions(i).DataVersion = dataVersion
                foundVersions.Add(dataVersions(i))
            End If
        Next

        If foundVersions.Count < 1
            Return Nothing
        End If

        Return foundVersions
    End Function
End Class