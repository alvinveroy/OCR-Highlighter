Imports Emgu.CV

Module OCR
    Public Function PreProcessImg(ByVal Src As Bitmap) As Image(Of [Structure].Gray, Byte)
        Try
            Dim img As Image(Of [Structure].Gray, Byte) = New Image(Of [Structure].Gray, Byte)(Src)
            Dim imgBinary As Image(Of [Structure].Gray, Byte) = img.ThresholdBinary(New [Structure].Gray(100), New [Structure].Gray(255))
            Dim threshholdAdjust As Image(Of [Structure].Gray, Byte) = imgBinary.ThresholdAdaptive(New [Structure].Gray(255), CvEnum.AdaptiveThresholdType.MeanC, CvEnum.ThresholdType.Binary, 17, New [Structure].Gray(2))
            Return threshholdAdjust
        Catch
        End Try
#Disable Warning BC42105 ' Function doesn't return a value on all code paths
    End Function
#Enable Warning BC42105 ' Function doesn't return a value on all code paths

    Public Function Erode(ByVal Src As Bitmap, ByVal value As Integer) As Image(Of [Structure].Gray, Byte)
        Try
            Dim imgErode As Image(Of [Structure].Gray, Byte) = New Image(Of [Structure].Gray, Byte)(Src)
            CvInvoke.Erode(imgErode, imgErode, Nothing, New Point(-1, -1), value, CvEnum.BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue)
            Return imgErode
        Catch
        End Try
    End Function

    Public Function Dilate(ByVal Src As Bitmap, ByVal value As Integer) As Image(Of [Structure].Gray, Byte)
        Try
            Dim imgDilate As Image(Of [Structure].Gray, Byte) = New Image(Of [Structure].Gray, Byte)(Src)
            CvInvoke.Dilate(imgDilate, imgDilate, Nothing, New Point(-1, -1), value, CvEnum.BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue)
            Return imgDilate
        Catch
        End Try
    End Function

    Public Function ReadOCR(ByVal cropSrc As Image(Of Emgu.CV.Structure.Gray, Byte)) As String
        Dim ocrChar() As Emgu.CV.OCR.Tesseract.Character
        Dim _ocr As Emgu.CV.OCR.Tesseract
        Dim s As New System.Text.StringBuilder

        _ocr = New Emgu.CV.OCR.Tesseract("", "eng", Emgu.CV.OCR.OcrEngineMode.TesseractCubeCombined)
        _ocr.SetVariable("tessedit_char_whitelist", "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopkrstuvwxyz")

        Try
            _ocr.Recognize(cropSrc)
        Catch
        End Try

        ocrChar = _ocr.GetCharacters
        If ocrChar.Length = 0 Then
            Return Nothing
        Else
            For i = 0 To ocrChar.Length - 1
                s.Append(ocrChar(i).Text)
            Next i
            Return s.ToString
        End If
    End Function

End Module
