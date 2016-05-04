Imports Emgu.CV

Module OCR
    'Public Function PreProcessImg(ByVal Src As Bitmap, ByVal value As Integer) As Image(Of Emgu.CV.Structure.Gray, Byte)
    '    Using img As Image(Of Emgu.CV.Structure.Gray, Byte) = New Image(Of Emgu.CV.Structure.Gray, Byte)(Src)
    '        Using imgBinary As Image(Of Emgu.CV.Structure.Gray, Byte) = img.ThresholdBinary(New Emgu.CV.Structure.Gray(100), New Emgu.CV.Structure.Gray(255))
    '            Using threshholdAdjust As Image(Of Emgu.CV.Structure.Gray, Byte) = imgBinary.ThresholdAdaptive(New Emgu.CV.Structure.Gray(255), Emgu.CV.CvEnum.AdaptiveThresholdType.MeanC, Emgu.CV.CvEnum.ThresholdType.Binary, 17, New Emgu.CV.Structure.Gray(2))
    '                'Emgu.CV.CvInvoke.Erode(threshholdAdjust, threshholdAdjust, Nothing, New Point(-1, -1), value, Emgu.CV.CvEnum.BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue)
    '                'Emgu.CV.CvInvoke.Dilate(threshholdAdjust, threshholdAdjust, Nothing, New Point(-1, -1), value, Emgu.CV.CvEnum.BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue)
    '                Return threshholdAdjust
    '            End Using
    '        End Using
    '    End Using
    'End Function

    'Public Function ReadOCR(ByVal cropSrc As Image(Of Emgu.CV.Structure.Gray, Byte)) As String
    '    Dim ocrChar() As Emgu.CV.OCR.Tesseract.Character
    '    Dim _ocr As Emgu.CV.OCR.Tesseract
    '    Dim s As New System.Text.StringBuilder

    '    _ocr = New Emgu.CV.OCR.Tesseract("", "eng", Emgu.CV.OCR.OcrEngineMode.TesseractCubeCombined)
    '    _ocr.SetVariable("tessedit_char_whitelist", "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopkrstuvwxyz")
    '    _ocr.Recognize(cropSrc)

    '    ocrChar = _ocr.GetCharacters

    '    For i = 0 To ocrChar.Length - 1
    '        s.Append(ocrChar(i).Text)
    '    Next i
    '    Return s.ToString
    'End Function

    Public Function ReadCharacter(ByVal Src As Bitmap) As String
        Dim _ocr As Emgu.CV.OCR.Tesseract
        Dim s As New System.Text.StringBuilder
        Dim ocrChar() As Emgu.CV.OCR.Tesseract.Character
        Using img As Image(Of Emgu.CV.Structure.Gray, Byte) = New Image(Of Emgu.CV.Structure.Gray, Byte)(Src)
            Using imgBinary As Image(Of Emgu.CV.Structure.Gray, Byte) = img.ThresholdBinary(New Emgu.CV.Structure.Gray(100), New Emgu.CV.Structure.Gray(255))
                Using threshholdAdjust As Image(Of Emgu.CV.Structure.Gray, Byte) = imgBinary.ThresholdAdaptive(New Emgu.CV.Structure.Gray(255), Emgu.CV.CvEnum.AdaptiveThresholdType.MeanC, Emgu.CV.CvEnum.ThresholdType.Binary, 17, New Emgu.CV.Structure.Gray(2))
                    'Emgu.CV.CvInvoke.Erode(threshholdAdjust, threshholdAdjust, Nothing, New Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue)
                    'Emgu.CV.CvInvoke.Dilate(threshholdAdjust, threshholdAdjust, Nothing, New Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue)
                    _ocr = New Emgu.CV.OCR.Tesseract("", "eng", Emgu.CV.OCR.OcrEngineMode.TesseractCubeCombined)
                    _ocr.SetVariable("tessedit_char_whitelist", "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopkrstuvwxyz")
                    _ocr.Recognize(threshholdAdjust)

                    ocrChar = _ocr.GetCharacters

                    For i = 0 To ocrChar.Length - 1
                        s.Append(ocrChar(i).Text)
                    Next i
                    Return s.ToString
                    'Return threshholdAdjust.ToBitmap
                End Using
            End Using
        End Using
    End Function

End Module
