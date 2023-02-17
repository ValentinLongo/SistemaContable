VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptLibMov 
   Caption         =   "SIGC - RptLibMov (ActiveReport)"
   ClientHeight    =   10665
   ClientLeft      =   75
   ClientTop       =   360
   ClientWidth     =   20250
   _ExtentX        =   35719
   _ExtentY        =   18812
   SectionData     =   "RptLibMov.dsx":0000
End
Attribute VB_Name = "RptLibMov"
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
   Menu.Dialog1.FileName = "Libros de IVA.pdf"
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
   Menu.Dialog1.FileName = "Libros de IVA.xls"
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
   If txtvta_fecpro.Text = "01/01/1900" Then txtvta_fecpro.Text = ""
   If txtNeto.Text = "0,00" Then txtNeto.Text = ""
   If txtvta_exento.Text = "0,00" Then txtvta_exento.Text = ""
   If Field4.Text = "0,00" Then Field4.Text = ""
   If Field5.Text = "0,00" Then Field5.Text = ""
   If txtCond.Text = "0" Then txtCond.Text = ""
     
End Sub

Private Sub Detail_Format()
   txtNeto.OutputFormat = IIf((Len(ParCerosCant) = 0), "", "#,##0." & ParCerosCant)
   txtvta_exento.OutputFormat = IIf((Len(ParCerosCant) = 0), "", "#,##0." & ParCerosCant)
   Field4.OutputFormat = IIf((Len(ParCerosCant) = 0), "", "#,##0." & ParCerosCant)
   Field5.OutputFormat = IIf((Len(ParCerosCant) = 0), "", "#,##0." & ParCerosCant)


End Sub

Private Sub PageHeader_BeforePrint()
   Me.Pagina.Text = Format(CInt(Me.pageNumber) + CInt(Me.lbl_Page), "00000000")
   If Not Trim(Me.pagina1.Text) = "" Then
      Me.pagina1.Text = Me.pagina1.Text + CInt(Me.pageNumber)
   Else
      Me.pagina1.Visible = False
   End If
End Sub



