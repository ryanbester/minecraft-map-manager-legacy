Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports MinecraftMapManager.Data

Namespace UI.Controls
    Public Class VersionBackgroundWorker
        Private Dim _versions As Collection(Of DataVersions.VersionInfo)
        Private Dim _dataVersion As Integer
        Public Dim VersionString As String

        Private Dim _versionLabel As Label
        Private Dim _dataVersionControl As NumericUpDown

        <Category("Data Version"),
            Description("The label to display the client version name")>
        Public Property VersionLabel As Label
            Get
                Return _versionLabel
            End Get
            Set
                _versionLabel = value
            End Set
        End Property
        
        <Category("Data Version"),
            Description("The control that is used to set the data version")>
        Public Property DataVersionControl As NumericUpDown
            Get
                Return _dataVersionControl
            End Get
            Set
                _dataVersionControl = value
            End Set

        End Property

        Protected Overrides Sub OnDoWork(e As DoWorkEventArgs)
            if _dataVersionControl IsNot Nothing
                _dataVersion = _dataVersionControl.Value
            End If
            
            DataVersions.GetDataVersions()
            _versions = DataVersions.GetDataVersionInfo(_dataVersion)
            MyBase.OnDoWork(e)
        End Sub

        Protected Overrides Sub OnRunWorkerCompleted(e As RunWorkerCompletedEventArgs)
            If _versions Is Nothing Then
                VersionString = "Invalid DataVersion"
            Else
                VersionString = ""
                Dim i = 0
                For Each versionInfo In _versions
                    If i > 0 Then
                        VersionString += ", "
                    End If
                    VersionString += versionInfo.ClientVersion
                    i += 1
                Next
            End If

            If _versionLabel IsNot Nothing
                _versionLabel.Text = VersionString
            End If
            MyBase.OnRunWorkerCompleted(e)
        End Sub
    End Class
End NameSpace