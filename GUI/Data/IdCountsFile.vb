Imports fNbt

Namespace Data
    Public Class IdCountsFile
        Implements IDatFile

        Private ReadOnly Dim _fileName As String
        Private Dim _nbtFile As NbtFile

        Public Dim MapId As Integer
        Public Dim DataVersion As Integer
        
        Public Dim CompressionType As NbtCompression


        Public Sub New(fileName As String)
            _fileName = fileName
        End Sub

        Public Sub CreateNew() Implements IDatFile.CreateNew
            Dim rootTag = new NbtCompound("")
            Dim dataTag = New NbtCompound("data")

            rootTag.SetValue(dataTag)
            _nbtFile = New NbtFile(rootTag)
            
            CompressionType = NbtCompression.None
        End Sub

        Public Sub LoadData() Implements IDatFile.LoadData
            Try
                _nbtFile = New NbtFile()
                _nbtFile.LoadFromFile(_fileName)
                
                CompressionType = _nbtFile.FileCompression

                DataVersion = _nbtFile.RootTag("DataVersion").IntValue
                MapId = _nbtFile.RootTag.Get (Of NbtCompound)("data")("map").IntValue
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Public Sub SaveData(fileName As String) Implements IDatFile.SaveData
            Try
                _nbtFile.RootTag.SetValue(New NbtInt("DataVersion", DataVersion))
                Dim dataTag = _nbtFile.RootTag.Get (Of NbtCompound)("data")
                dataTag.SetValue(New NbtInt("map", MapId))

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