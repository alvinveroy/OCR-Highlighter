Module ProcessImage
    Public FineTuneImg As Bitmap
    Public Declare Function BitBlt Lib "gdi32.dll" (ByVal hdcDest As IntPtr, ByVal xDest As Integer, ByVal yDest As Integer, ByVal wDest As Integer, ByVal hDest As Integer, ByVal hdcSource As IntPtr, ByVal xSrc As Integer, ByVal ySrc As Integer, ByVal rop As CopyPixelOperation) As Boolean
    Public Function CaptureSelected(ByVal rect As Rectangle) As Bitmap

        Dim captureBitmap As New Bitmap(rect.Width, rect.Height, Imaging.PixelFormat.Format32bppArgb)
        Dim captureRectangle As Rectangle = Screen.AllScreens(0).Bounds
        Dim captureGraphics As Graphics = Graphics.FromImage(captureBitmap)
        captureGraphics.CopyFromScreen(rect.Left, rect.Top, 0, 0, captureRectangle.Size)
        If captureBitmap.Height < 100 Then
            Return ScaleImage(captureBitmap, captureBitmap.Height * 5, captureBitmap.Width * 5)
        Else
            Return captureBitmap
        End If
        captureBitmap.Dispose()
        captureGraphics.Dispose()
    End Function

    Public Function ScaleImage(ByVal OldImage As Image, ByVal TargetHeight As Integer, ByVal TargetWidth As Integer) As Bitmap
        Dim NewHeight As Integer = TargetHeight
        Dim NewWidth As Integer = NewHeight / OldImage.Height * OldImage.Width

        If NewWidth > TargetWidth Then
            NewWidth = TargetWidth
            NewHeight = NewWidth / OldImage.Width * OldImage.Height
        End If

        Return New Bitmap(OldImage, NewWidth, NewHeight)
    End Function

End Module