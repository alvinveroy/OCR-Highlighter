Public Class Main
    Private Origin, ScreenOriginPos As Point
    Private isMouseDown As Boolean = False

    Dim mRect As Rectangle
    Dim DataPath As String

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeComponent()
        Me.DoubleBuffered = True
        Me.BackgroundImage = ScaleImage(My.Resources.Sample_Image, Me.Height, Me.Width)
        'Me.BackgroundImage = My.Resources.Sample_Image
        'Dim Openfile As New OpenFileDialog()
        'If Openfile.ShowDialog() = DialogResult.OK Then
        '    DataPath = Openfile.FileName
        'End If
    End Sub
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            Origin = New Point(e.X, e.Y)
            ScreenOriginPos = New Point(Cursor.Position)
            isMouseDown = True
            Me.Invalidate()
        End If
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            isMouseDown = False
            Dim ScreenRect As Rectangle = New Rectangle(ScreenOriginPos.X, ScreenOriginPos.Y, mRect.Width, mRect.Height)
            'ReadCharacter(CaptureSelected(ScreenRect)).Save("test.png", System.Drawing.Imaging.ImageFormat.Png)
            CaptureText.Text = ReadCharacter(CaptureSelected(ScreenRect))
            Me.Invalidate()
        End If
    End Sub
    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        Dim mousepos As Point = Cursor.Position
        If isMouseDown Then
            If e.X < Origin.X And e.Y > Origin.Y Then
                mRect = New Rectangle(e.X, Origin.Y, Math.Abs(Origin.X - e.X), Math.Abs(Origin.Y - e.Y))
            End If
            If e.X < Origin.X And e.Y < Origin.Y Then
                mRect = New Rectangle(e.X, e.Y, Math.Abs(Origin.X - e.X), Math.Abs(Origin.Y - e.Y))
            End If
            If e.X > Origin.X And e.Y > Origin.Y Then
                mRect = New Rectangle(Origin.X, Origin.Y, Math.Abs(Origin.X - e.X), Math.Abs(Origin.Y - e.Y))
            End If
            If e.X > Origin.X And e.Y < Origin.Y Then
                mRect = New Rectangle(Origin.X, e.Y, Math.Abs(Origin.X - e.X), Math.Abs(Origin.Y - e.Y))
            End If
            Me.Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Using pen As New Pen(Color.Red, 3)
            e.Graphics.DrawRectangle(pen, mRect)
        End Using
    End Sub

End Class
