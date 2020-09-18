Imports fNbt

Namespace Data
    Public Class MapFile
        Implements IDatFile

        Private Const DefaultDataVersion = 1343

        Public Const Version20w21a = 2554
        Public Const Version19w02a = 1921

        Private ReadOnly Dim _fileName As String
        Private Dim _nbtFile As NbtFile

        Public Dim MapColours As Byte()

        Public Dim DataVersion As Integer
        Public Dim CompressionType As NbtCompression

        Public Dim Scale As Integer
        Public Dim Dimension As SByte
        Public Dim Tracking As Boolean
        Public Dim UnlimitedTracking As Boolean
        Public Dim Locked As Boolean

        Public Dim X As Integer
        Public Dim Z As Integer

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

                Dim dataTag = _nbtFile.RootTag.Get (Of NbtCompound)("data")
                MapColours = dataTag("colors").ByteArrayValue

                Scale = dataTag("scale").IntValue

                If DataVersion >= Version20w21a
                    Dimension = ConvertDimensionToByte(dataTag("dimension").StringValue) ' Dimension as string
                Else
                    Dimension = Convert.ToSByte(dataTag("dimension").IntValue) ' Dimension as byte
                End If

                Tracking = Convert.ToBoolean(dataTag("trackingPosition").IntValue)
                UnlimitedTracking = Convert.ToBoolean(dataTag("unlimitedTracking").IntValue)

                If DataVersion >= Version19w02a
                    Locked = Convert.ToBoolean(dataTag("locked").IntValue)
                Else
                    Locked = False
                End If

                X = dataTag("xCenter").IntValue
                Z = dataTag("zCenter").IntValue
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Private Function ConvertDimensionToByte(strDim As String) As SByte
            Select Case strDim
                case "minecraft:overworld"
                    Return 0
                case "minecraft:the_nether"
                    Return - 1
                case "minecraft:the_end"
                    Return 1
            End Select

            Return 0
        End Function

        Private Function ConvertDimensionToString(byteDim As SByte) As String
            Select Case byteDim
                case 0
                    return "minecraft:overworld"
                case - 1
                    Return "minecraft:the_nether"
                Case 1
                    Return "minecraft:the_end"
            End Select

            Return "minecraft:overworld"
        End Function

        Public Sub SaveData(fileName As String) Implements IDatFile.SaveData
            Try
                _nbtFile.RootTag.SetValue(New NbtInt("DataVersion", DataVersion))
                Dim dataTag = _nbtFile.RootTag.Get (Of NbtCompound)("data")

                dataTag.SetValue(New NbtInt("DataVersion", DataVersion))

                dataTag.SetValue(New NbtByteArray("colors", MapColours))

                dataTag.SetValue(New NbtByte("scale", Scale))

                If DataVersion >= Version20w21a
                    dataTag.SetValue(New NbtString("dimension", ConvertDimensionToString(Dimension)))
                Else
                    dataTag.SetValue(New NbtByte("dimension", Dimension))
                End If

                dataTag.SetValue(New NbtByte("trackingPosition", Tracking))
                dataTag.SetValue(New NbtByte("unlimitedTracking", UnlimitedTracking))

                If DataVersion >= Version19w02a
                    dataTag.SetValue(New NbtByte("locked", Locked))
                Else
                    dataTag.Remove("locked")
                End If

                dataTag.SetValue(New NbtInt("xCenter", X))
                dataTag.SetValue(New NbtInt("zCenter", Z))

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