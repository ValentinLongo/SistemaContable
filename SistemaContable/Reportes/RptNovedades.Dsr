VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptNovedades 
   Caption         =   "SIGC - RptNovedades (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   15360
   _ExtentX        =   27093
   _ExtentY        =   19076
   SectionData     =   "RptNovedades.dsx":0000
End
Attribute VB_Name = "RptNovedades"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub ActiveReport_ReportStart()
   Me.Toolbar.Tools.AddEx("&PDF").Tooltip = "Exportar a PDF"
   Me.Toolbar.Tools.AddEx("&Excel").Tooltip = "Exportar a Excel"
End Sub

Private Sub ActiveReport_ToolbarClick(ByVal Tool As DDActiveReports2.DDTool)
   Select Case Tool.Caption
      Case Is = "&PDF"
         tbPDFExport
      Case Is = "&Excel"
         tbExcel
   End Select
End Sub

Private Sub tbPDFExport()
On Error GoTo fin
   Dim pdf As New ActiveReportsPDFExport.ARExportPDF
   Set pdf = New ActiveReportsPDFExport.ARExportPDF
   Menu.Dialog1.FileName = "Novedades.pdf"
   On Error Resume Next
   Menu.Dialog1.CancelError = True
   Menu.Dialog1.ShowSave
   If Err.Number = 32755 Then
      Err.Clear
      Exit Sub
   End If
   If Right(Menu.Dialog1.FileName, 4) <> ".pdf" Then
      Menu.Dialog1.FileName = Menu.Dialog1.FileName & ".pdf"
   End If
   pdf.FileName = Menu.Dialog1.FileName
   pdf.Export Me.Pages
   MsgBox "Atención: La Exportación fue Exitosa.", vbInformation
   Exit Sub
fin:
   MsgBox "Atención: Ocurrió un error al intentar Exportar el archivo.", vbInformation
End Sub

Private Sub tbExcel()
On Error GoTo fin
   Dim Exc As New ActiveReportsExcelExport.ARExportExcel
   Set Exc = New ActiveReportsExcelExport.ARExportExcel
   Menu.Dialog1.FileName = "Novedades.xls"
   On Error Resume Next
   Menu.Dialog1.CancelError = True
   Menu.Dialog1.ShowSave
   If Err.Number = 32755 Then
      Err.Clear
      Exit Sub
   End If
   If Right(Menu.Dialog1.FileName, 4) <> ".xls" Then
      Menu.Dialog1.FileName = Menu.Dialog1.FileName & ".xls"
   End If
   Exc.FileName = Menu.Dialog1.FileName
   Exc.Export Me.Pages
   MsgBox "Atención: La Exportación fue Exitosa.", vbInformation
   Exit Sub
fin:
   MsgBox "Atención: Ocurrió un error al intentar Exportar el archivo.", vbInformation
End Sub

Private Sub Detail_BeforePrint()

'   If txtlis_importeC1.Text = "0,000" Then
'      txtlis_codtexC1.Text = ""
'      txtlis_codnumC1.Text = ""
'      txtlis_articC1.Text = ""
'      txtlis_importeC1.Text = ""
'      txtlis_aliivaC1.Text = ""
'      ImgC1.Visible = False
'   End If

   Select Case txtlis_tipC1.Text
      Case Is = "1"
         Me.ImgC1.Picture = LoadPicture(App.Path & "\bajolista.bmp")
      Case Is = "0"
         Me.ImgC1.Picture = LoadPicture(App.Path & "\neutrolista.bmp")
      Case Is = "2"
         Me.ImgC1.Picture = LoadPicture(App.Path & "\subiolista.bmp")
      Case Is = "3"
         Me.ImgC1.Picture = LoadPicture(App.Path & "\nuevolista.bmp")
   End Select
   
End Sub

Private Sub PageFooter_BeforePrint()
   Image2.Picture = LoadPicture(App.Path & "\bajolista.bmp")
   Image3.Picture = LoadPicture(App.Path & "\subiolista.bmp")
   Image4.Picture = LoadPicture(App.Path & "\nuevolista.bmp")
   PaginaN.Caption = Me.pageNumber
End Sub


