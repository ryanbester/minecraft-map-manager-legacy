Imports System.Runtime.CompilerServices
Imports fNbt

Namespace Data

    Module NbtExtensions
        <Extension()>
        Public Sub SetValue(ByVal nbtCompound As NbtCompound, value As NbtTag)
            nbtCompound.Remove(value.Name)
            nbtCompound.Add(value)
        End Sub
    End Module
End NameSpace