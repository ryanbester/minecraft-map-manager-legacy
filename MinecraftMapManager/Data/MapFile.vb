Imports fNbt

Namespace Data
    Public Class MapFile
        Implements IDatFile
        
        Private Const DefaultDataVersion = 1343
        
        Private ReadOnly Dim _fileName As String
        Private Dim _nbtFile As NbtFile

        Public Dim DataVersion As Integer
        Public Dim MapBitmap As Bitmap
        
        Public Dim CompressionType As NbtCompression

        Public Sub New(fileName As String)
            _fileName = fileName
        End Sub

        Public Sub LoadData() Implements IDatFile.LoadData
            Try
                _nbtFile = New NbtFile()
                _nbtFile.LoadFromFile(_fileName)
                
                CompressionType = _nbtFile.FileCompression

                Dim dataVersionTag = _nbtFile.RootTag("DataVersion")
                If dataVersionTag Is Nothing Then
                    DataVersion = DefaultDataVersion
                Else
                    DataVersion = dataVersionTag.IntValue
                End If
                
                MapBitmap = MapColours.CreateBitmapFromMap(_nbtFile)
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub SaveData(fileName As String) Implements IDatFile.SaveData
            Try
                _nbtFile.SaveToFile(fileName, CompressionType)
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub SaveData() Implements IDatFile.SaveData
            Try
                SaveData(_nbtFile.FileName)
            Catch ex As Exception
                Throw
            End Try
        End Sub
    End Class
End NameSpace