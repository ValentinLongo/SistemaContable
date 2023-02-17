VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptListaPN 
   Caption         =   "SIGC - RptListaPN (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   15360
   _ExtentX        =   27093
   _ExtentY        =   19076
   SectionData     =   "RptListaPN.dsx":0000
End
Attribute VB_Name = "RptListaPN"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Detail_BeforePrint()
   If txtlis_codtexC1 = "0" Then
      txtlis_codtexC1.Visible = False
   Else
      txtlis_codtexC1.Visible = True
   End If
   
   If Hab1.Text = "2" Then
      Linea1.Visible = True
   Else
      Linea1.Visible = False
   End If
   
   If Hab2.Text = "2" Then
      Linea2.Visible = True
   Else
      Linea2.Visible = False
   End If
   
   On Error Resume Next
   Select Case txtaux_tip1.Text
      Case Is = "1"
         Me.ImgC1.Picture = LoadPicture(App.Path & "\bajolista.bmp")
      Case Is = "0"
         Me.ImgC1.Picture = LoadPicture(App.Path & "\neutrolista.bmp")
      Case Is = "2"
         Me.ImgC1.Picture = LoadPicture(App.Path & "\subiolista.bmp")
      Case Is = "3"
         Me.ImgC1.Picture = LoadPicture(App.Path & "\nuevolista.bmp")
   End Select
   
   Select Case txtaux_tip2.Text
      Case Is = "1"
         Me.ImgC2.Picture = LoadPicture(App.Path & "\bajolista.bmp")
      Case Is = "0"
         Me.ImgC2.Picture = LoadPicture(App.Path & "\neutrolista.bmp")
      Case Is = "2"
         Me.ImgC2.Picture = LoadPicture(App.Path & "\subiolista.bmp")
      Case Is = "3"
         Me.ImgC2.Picture = LoadPicture(App.Path & "\nuevolista.bmp")
   End Select

   If txtlis_codnumC1 = "88888888" Or txtlis_codnumC1 = "0" Then
      txtlis_codnumC1.Visible = False
   Else
      txtlis_codnumC1.Visible = True
   End If
   
   If txtaux_ctrl1 = "X" Then
      tit1.Text = txtlis_articC1
      tit1.Style = "font-size: 8pt; font-family: 'Times New Roman'; ddo-char-set: 0; font-weight: bold;"
      txtlis_articC1.Visible = False
      tit1.Visible = True
      Me.ImgC1.Visible = False
   Else
      txtlis_articC1.Style = "font-size: 7pt; font-family: 'Times New Roman'; ddo-char-set: 0;"
      txtlis_articC1.Visible = True
      tit1.Visible = False
      Me.ImgC1.Visible = True
      
      CtrlCad txtlis_articC1, 100
   End If
   
   If txtaux_ctrl2 = "X" Then
      tit2.Text = txtlis_articC2
      tit2.Style = "font-size: 8pt; font-family: 'Times New Roman'; ddo-char-set: 0; font-weight: bold;"
      txtlis_articC2.Visible = False
      tit2.Visible = True
      Me.ImgC2.Visible = False
   Else
      txtlis_articC2.Style = "font-size: 7pt; font-family: 'Times New Roman'; ddo-char-set: 0;"
      txtlis_articC2.Visible = True
      tit2.Visible = False
      Me.ImgC2.Visible = True
      
      CtrlCad txtlis_articC2, 100
   End If
   
   If CDec(txtlis_importeC1) = 0 Then
      txtlis_importeC1.Visible = False
   Else
      txtlis_importeC1.Visible = True
   End If
   
   If CDec(txtlis_aliivaC1) = 0 Then
      txtlis_aliivaC1.Visible = False
   Else
      txtlis_aliivaC1.Visible = True
   End If
   
   If txtlis_codtexC2 = "0" Then
      txtlis_codtexC2.Visible = False
   Else
      txtlis_codtexC2.Visible = True
   End If
   
   If txtlis_codnumC2 = "88888888" Or txtlis_codnumC2 = "0" Then
      txtlis_codnumC2.Visible = False
   Else
      txtlis_codnumC2.Visible = True
   End If
   
   If CDec(txtlis_importeC2) = 0 Then
      txtlis_importeC2.Visible = False
   Else
      txtlis_importeC2.Visible = True
   End If
   
   If CDec(txtlis_aliivaC2) = 0 Then
      txtlis_aliivaC2.Visible = False
   Else
      txtlis_aliivaC2.Visible = True
   End If
End Sub

Private Sub Detail_Format()
   Static RNumber As Long
   RNumber = RNumber + 1
   If RNumber = 74 Then 'si hay 74 renglones en la pagina
      'agrego un nueva pagina antes de resetear el contador
      Detail.NewPage = ddNPAfter
      RNumber = 0
   Else
      Detail.NewPage = ddNPNone 'esto apaga el NewPage
   End If
End Sub

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
   If right(Menu.Dialog1.FileName, 4) <> ".pdf" Then
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
   If right(Menu.Dialog1.FileName, 4) <> ".xls" Then
      Menu.Dialog1.FileName = Menu.Dialog1.FileName & ".xls"
   End If
   Exc.FileName = Menu.Dialog1.FileName
   Exc.Export Me.Pages
   MsgBox "Atención: La Exportación fue Exitosa.", vbInformation
   Exit Sub
fin:
   MsgBox "Atención: Ocurrió un error al intentar Exportar el archivo.", vbInformation
End Sub

Private Sub PageFooter_BeforePrint()
   PaginaN.Caption = Me.pageNumber
End Sub



