Imports fNbt

Namespace Data
    Public Interface IDatFile
        Sub CreateNew()
        Sub LoadData()

        Sub SaveData(fileName As String)
        Sub SaveData()
    End Interface
End NameSpace