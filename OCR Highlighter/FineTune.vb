Public Class FineTune
    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer
    Private ProcessIMG As Bitmap

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
    End Sub

    Private Sub Form_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PictureBox1.MouseDown

        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub Form_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PictureBox1.MouseUp

        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub Form_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PictureBox1.MouseMove

        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub FineTune_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim rect As New Rectangle(0, 0, FineTuneImg.Width, FineTuneImg.Height + 100)
        Me.Size = New Size(rect.Width, rect.Height)
        PictureBox1.Size = FineTuneImg.Size
        PictureBox1.Image = FineTuneImg
        PictureBox1.Invalidate()
        ErodeBar.Minimum = 0
        ErodeBar.Maximum = 100
        DilateBar.Minimum = 0
        DilateBar.Maximum = 100
        DilateBar.TickFrequency = 1
        ErodeBar.TickFrequency = 1
    End Sub

    Private Sub ErodeBar_Scroll(sender As Object, e As EventArgs) Handles ErodeBar.Scroll
        ProcessIMG = New Bitmap(Erode(FineTuneImg, ErodeBar.Value).ToBitmap)
        PictureBox1.Image = ProcessIMG
        'Dim CVImage As Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte) = New Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte)(FineTuneImg)
        'Dim OCRResult As New String(ReadOCR(CVImage))
        'Main.CaptureText.Text = OCRResult
        PictureBox1.Invalidate()
    End Sub

    Private Sub Dilate_Scroll(sender As Object, e As EventArgs) Handles DilateBar.Scroll
        ProcessIMG = New Bitmap(Dilate(FineTuneImg, DilateBar.Value).ToBitmap)
        PictureBox1.Image = ProcessIMG
        'Dim CVImage As Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte) = New Emgu.CV.Image(Of Emgu.CV.Structure.Gray, Byte)(FineTuneImg)
        'Dim OCRResult As New String(ReadOCR(CVImage))
        'Main.CaptureText.Text = OCRResult
        PictureBox1.Invalidate()
    End Sub
End Class