
Namespace Data
    Public Class MapImage
        Public Dim Image As Bitmap
        Public Dim RawImage As Bitmap

        ' Whether to show an outline where the image will be placed. False if the image has been converted.
        Public Dim RenderPreview As Boolean = True

        Public Dim X As Integer
        Public Dim Y As Integer
        Public Dim Width As Integer
        Public Dim Height As Integer

        Public Function AddImage() As Bitmap
            Using openFileDialog = New OpenFileDialog()
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                openFileDialog.Filter =
                    "Image files (*.bmp;*.emf;*.exif;*.gif;*.ico;*.jpg;*.jpeg;*.png;*.tiff;*.tif;*.wmf)|*.bmp;*.emf;*.exif;*.gif;*.ico;*.jpg;*.jpeg;*.png;*.tiff;*.tif;*.wmf|All files (*.*)|*.*"
                openFileDialog.Title = "Open Image"

                If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    RawImage = New Bitmap(openFileDialog.FileName)
                    RenderPreview = True
                    Return RawImage
                End If

                Return Nothing
            End Using
        End Function
        
        Public Function ProcessImage() As Bitmap
            Return Image
        End Function
    End Class
End NameSpace