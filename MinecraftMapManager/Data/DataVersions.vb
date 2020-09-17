Imports System.Collections.ObjectModel
Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Namespace Data

    Public Class DataVersions
        Structure VersionInfo
            Dim DataVersion As String
            Dim ClientVersion As String
            Dim ProtocolVersion As String
        End Structure

        Public Shared dataVersions = New List(Of VersionInfo)

        ''' <summary>
        ''' Gets a list of data versions from the DataVersions.csv file.
        ''' </summary>
        ''' <returns>A list of <c>VersionInfo</c> structures.</returns>
        Public Shared Function GetDataVersions() As List(Of VersionInfo)
            If dataVersions.Count > 0 Then
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

        ''' <summary>
        ''' Gets a <c>VersionInfo</c> structure for the data version.
        ''' </summary>
        ''' <param name="dataVersion">The data version to find.</param>
        ''' <returns>The <c>VersionInfo</c> structure.</returns>
        Public Shared Function GetDataVersionInfo(dataVersion As String) As Collection(Of VersionInfo)
            If dataVersions.Count < 1 Then
                Return Nothing
            End If

            Dim foundVersions = New Collection(Of VersionInfo)

            For i As Integer = dataVersions.Count - 1 To 0 Step -1
                If dataVersions(i).DataVersion = dataVersion Then
                    foundVersions.Add(dataVersions(i))
                End If
            Next

            If foundVersions.Count < 1 Then
                Return Nothing
            End If

            Return foundVersions
        End Function
    End Class
End NameSpace