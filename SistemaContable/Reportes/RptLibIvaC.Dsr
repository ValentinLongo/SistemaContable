VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptLibIvaC 
   Caption         =   "SIGC - RptLibIvaC (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   20400
   _ExtentX        =   35983
   _ExtentY        =   19076
   SectionData     =   "RptLibIvaC.dsx":0000
End
Attribute VB_Name = "RptLibIvaC"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Fecha As String
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
   Menu.Dialog1.Filter = "(*.pdf)|*.pdf|"
   Menu.Dialog1.FileName = "Libro de IVA.pdf"
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
   Menu.Dialog1.Filter = "(*.xls)|*.xls|"
   Menu.Dialog1.FileName = "Libro de IVA.xls"
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

Private Sub Detail_Format()
   If Fecha = txtcpa_feccpbte Then
      txtcpa_feccpbte.Visible = False
   Else
      txtcpa_feccpbte.Visible = True
      Fecha = txtcpa_feccpbte
   End If
End Sub

Private Sub PageFooter_BeforePrint()
   If Field1 <> Total Then
      Texto23.Caption = "Transporte :"
      If frm_libivac.chk_impt.Value = 0 Then
         Texto23.Visible = False
         Field2.Visible = False
         Field3.Visible = False
         Field4.Visible = False
         Field6.Visible = False
         Field8.Visible = False
         Field9.Visible = False
         Field10.Visible = False
         Field13.Visible = False
         Field11.Visible = False
         'Line4.Visible = False
      Else
         Texto23.Visible = True
         Field2.Visible = True
         Field3.Visible = True
         Field4.Visible = True
         Field6.Visible = True
         Field8.Visible = True
         Field9.Visible = True
         Field10.Visible = True
         Field13.Visible = True
         Field11.Visible = True
         'Line4.Visible = True
      End If
   Else
      Texto23.Caption = "Totales :"
   End If

End Sub

Private Sub PageHeader_BeforePrint()
   Me.Pagina.Text = Format(CInt(Me.pageNumber) + CInt(Me.lbl_Page), "00000000")
   If Not Trim(Me.pagina1.Text) = "" Then
      Me.pagina1.Text = Me.pagina1.Text + CInt(Me.pageNumber)
   Else
      Me.pagina1.Visible = False
   End If
End Sub

