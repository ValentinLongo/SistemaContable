VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptListaP 
   Caption         =   "SIGC - RptListaP (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   15360
   _ExtentX        =   27093
   _ExtentY        =   19076
   SectionData     =   "RptListaP.dsx":0000
End
Attribute VB_Name = "RptListaP"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub ActiveReport_ReportStart()
   Me.Toolbar.Tools.AddEx("&PDF").Tooltip = "Exportar a PDF"
   Me.Toolbar.Tools.AddEx("&Excel").Tooltip = "Exportar a Excel"

'   Dim Fso As FileSystemObject
'   Set Fso = New FileSystemObject
'   If Fso.FileExists(App.Path & "\FondoLista.jpg") = True Then
'      Me.WatermarkAlignment = ddPACenter
'      Me.WatermarkPrintOnPages = "1-100"
'      Me.WatermarkSizeMode = ddSMStretch
'      Me.Watermark = LoadPicture(App.Path & "\FondoLista.jpg")
'   End If

   Dim FSO As New FileSystemObject
   If FSO.FileExists(App.Path & "\EncabLista.jpg") = True Then
      Image2.Visible = True
      Image2.Picture = LoadPicture(App.Path & "\EncabLista.jpg")
   Else
      Image2.Visible = False
   End If
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
   Menu.Dialog1.FileName = "Lista de Precios.pdf"
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
   Menu.Dialog1.FileName = "Lista de Precios.xls"
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
   
   If vigencia1.Text = "1" Then
      LineaC1.Visible = False
   Else
      If txtlis_importeC1.Text <> "0,000" Then
         LineaC1.Visible = True
      End If
   End If

   If vigencia2.Text = "1" Then
      LineaC2.Visible = False
   Else
      If txtlis_importeC2.Text <> "0,000" Then
         LineaC2.Visible = True
      End If
   End If

   If txtlis_importeC1.Text = "0,000" Then
      txtlis_codtexC1.Text = ""
      txtlis_codnumC1.Text = ""
      txtlis_articC1.Text = ""
      txtlis_importeC1.Text = ""
      txtlis_aliivaC1.Text = ""
      ImgC1.Visible = False
   End If

   If txtlis_importeC2.Text = "0,000" Then
      txtlis_codtexC2.Text = ""
      txtlis_codnumC2.Text = ""
      txtlis_articC2.Text = ""
      txtlis_importeC2.Text = ""
      txtlis_aliivaC2.Text = ""
      ImgC2.Visible = False
   End If
   
   If txtlis_codnumC1.Text = "0" And txtlis_importeC1.Text = "1,000" Then
      txtlis_codtexC1.Text = ""
      txtlis_codnumC1.Text = ""
      txtlis_articC1.Text = ""
      txtlis_importeC1.Text = ""
      txtlis_aliivaC1.Text = ""
      ImgC1.Visible = False
      tit1.Visible = True
   Else
      tit1.Visible = False
   End If
   
   If txtlis_codnumC2.Text = "0" And txtlis_importeC2.Text = "1,000" Then
      txtlis_codtexC2.Text = ""
      txtlis_codnumC2.Text = ""
      txtlis_articC2.Text = ""
      txtlis_importeC2.Text = ""
      txtlis_aliivaC2.Text = ""
      ImgC2.Visible = False
      tit2.Visible = True
   Else
      tit2.Visible = False
   End If
   
   On Error Resume Next
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
   
   Select Case txtlis_tipC2.Text
      Case Is = "1"
         Me.ImgC2.Picture = LoadPicture(App.Path & "\bajolista.bmp")
      Case Is = "0"
         Me.ImgC2.Picture = LoadPicture(App.Path & "\neutrolista.bmp")
      Case Is = "2"
         Me.ImgC2.Picture = LoadPicture(App.Path & "\subiolista.bmp")
      Case Is = "3"
         Me.ImgC2.Picture = LoadPicture(App.Path & "\nuevolista.bmp")
   End Select
   
   CtrlCad txtlis_articC1, 100
   CtrlCad txtlis_articC2, 100
   
   If txt_param2.Text = "0" And txtlis_codnumC1.Left <> 0 Then
      txtlis_codtexC1.Visible = False
      txtlis_articC1.Left = RptListaP.txtlis_articC1.Left - RptListaP.txtlis_codtexC1.Width
      txtlis_codnumC1.Left = 0
      txtlis_codtexC2.Visible = False
      txtlis_articC2.Left = RptListaP.txtlis_articC2.Left - RptListaP.txtlis_codtexC2.Width
      txtlis_codnumC2.Left = RptListaP.txtlis_codnumC2.Left - RptListaP.txtlis_codtexC2.Width
   End If
End Sub

Private Sub PageFooter_BeforePrint()
   PaginaN.Caption = Me.pageNumber
End Sub

