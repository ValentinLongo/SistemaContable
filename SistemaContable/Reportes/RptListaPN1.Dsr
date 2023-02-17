VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptListaPN1 
   Caption         =   "SIGC - RptListaPN1 (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   20400
   WindowState     =   2  'Maximized
   _ExtentX        =   35983
   _ExtentY        =   19076
   SectionData     =   "RptListaPN1.dsx":0000
End
Attribute VB_Name = "RptListaPN1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Detail_BeforePrint()
   If Trim(txt_finan.Text) = "" Then
      txt_finan.Visible = False
   Else
      txt_finan.Visible = True
   End If
   
   If Hab1.Text = "2" Then
      Linea2.Visible = True
   Else
      Linea2.Visible = False
   End If
   
   If vigencia1.Text = "2" Then
      LineaC1.Visible = True
   Else
      LineaC1.Visible = False
   End If
   
   If txtlis_codtexC1 = "0" Then
      txtlis_codtexC1.Visible = False
   Else
      txtlis_codtexC1.Visible = True
   End If
   
   If txtlis_codnumC1 = "88888888" Or txtlis_codnumC1 = "0" Then
      txtlis_codnumC1.Visible = False
   Else
      txtlis_codnumC1.Visible = True
   End If
   
   If txtaux_ctrl1 = "X" Then
      tit1.Text = txtlis_articC1
      tit1.Style = "font-size: 7pt; font-family: 'Times New Roman'; ddo-char-set: 0; font-weight: bold;"
      txtlis_articC1.Visible = False
      tit1.Visible = True
      Me.ImgC1.Visible = False
      Line2.Visible = False
   
   Else
      Line2.Visible = True
      Me.ImgC1.Visible = True
      txtlis_articC1.Style = "font-size: 7pt; font-family: 'Times New Roman'; ddo-char-set: 0;"
      txtlis_articC1.Visible = True
      tit1.Visible = False
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
   End If
   
   If Trim(txtlis_codtexC1) = "" Then
      Line2.Visible = False
   Else
      Line2.Visible = True
   End If
   
   If CDec(Field1) = 0 Then
      Field1.Visible = False
   Else
      Field1.Visible = True
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
   
   If txtlis_articC1.Visible = True Then
      CtrlCad txtlis_articC1
   End If
   
   If Field2.Text = "0" Then
      Field2.Text = ""
   Else
      
   End If

   If txt_param2.Text = "0" And txtlis_codnumC1.left <> 0 Then
      txtlis_codtexC1.Visible = False
      txtlis_articC1.left = RptListaPN1.txtlis_articC1.left - RptListaPN1.txtlis_codtexC1.Width
      Label5.left = txtlis_articC1.left
      txtlis_codnumC1.left = 0
   End If
   
   If frm_filtrogralL.chk_renglon.Value = 0 Then RptListaPN1.Line2.Visible = False
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

Private Sub Detail_Format()
   If Trim(txt_finan.Text) = "" Then
      Detail.Height = 75
   Else
      Detail.Height = 300
   End If
   
   Static RNumber1 As Long
   RNumber1 = RNumber1 + 1

'   If txt_param1.Text <> "2" Then
      If RNumber1 > 1 Then
         If txt_salto.Text = "1" Then
            If txt_codtex2.Text = "X" Then
               'Detail.NewPage = ddNPAfter
               Detail.NewPage = ddNPBefore
               RNumber1 = 0
            Else
               Detail.NewPage = ddNPNone
            End If
         Else
            Detail.NewPage = ddNPNone
         End If
      Else
         Detail.NewPage = ddNPNone
      End If

   If Field2.Visible = False And Field3.Visible = False Then
      txtlis_articC1.Width = 3270 + (Field2.Width + Field3.Width)
   Else
      If Field2.Visible = False And Field3.Visible = True Then
         txtlis_articC1.Width = 3735
         txtlis_articC1.Width = 3735 + (Field2.Width) - 50
      Else
         txtlis_articC1.Width = 3270
      End If
   End If
   If Field2.Visible = True Then
      If Label17.Caption = "Tipo Emb." Then
         Label17.Visible = True
         Field3.Visible = True
         
         Label18.left = 7515
         Field2.left = 7515
         
         Label17.left = 6315
         Field3.left = 6315
         
         txtlis_articC1.Width = 4755
      End If
   End If
   
'   End If
   If txt_param1.Text = "1" Then Exit Sub

   Static RNumber As Long
   RNumber = RNumber + 1

   If RNumber = 74 Then 'If there are 6 records on the page
      'it will add a new page and reset the counter
      Detail.NewPage = ddNPAfter
      RNumber = 0
   Else
      Detail.NewPage = ddNPNone 'This turns off the Add New page
   End If

End Sub
