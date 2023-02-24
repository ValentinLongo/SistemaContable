VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptOferta 
   Caption         =   "RptOferta (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   15360
   _ExtentX        =   27093
   _ExtentY        =   19076
   SectionData     =   "RptOferta.dsx":0000
End
Attribute VB_Name = "RptOferta"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Detail_BeforePrint()
   If Trim(txtart_codnum.Text) = "0" Then
      txtart_codnum.Text = ""
   End If
End Sub

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
   Menu.Dialog1.FileName = "Actualizaci�n.pdf"
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
   MsgBox "Atenci�n: La Exportaci�n fue Exitosa.", vbInformation
   Exit Sub
fin:
   MsgBox "Atenci�n: Ocurri� un error al intentar Exportar el archivo.", vbInformation
End Sub

Private Sub tbExcel()
On Error GoTo fin
   Dim Exc As New ActiveReportsExcelExport.ARExportExcel
   Set Exc = New ActiveReportsExcelExport.ARExportExcel
   Menu.Dialog1.Filter = "(*.xls)|*.xls|"
   Menu.Dialog1.FileName = "Actualizaci�n.xls"
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
   MsgBox "Atenci�n: La Exportaci�n fue Exitosa.", vbInformation
   Exit Sub
fin:
   MsgBox "Atenci�n: Ocurri� un error al intentar Exportar el archivo.", vbInformation
End Sub

Private Sub PageFooter_BeforePrint()
   PaginaN.Caption = "P�gina " & Me.pageNumber
End Sub

Private Sub PageHeader_Format()
   If lbl_param1.Caption = "1" Then
      Dim lW As Long, lH As Long
      lW = 6200
      lH = 2400
      With Canvas
          .Font.Size = 60
          .TextAngle = 450
          .MeasureText "ELIMINADAS", lW, lH
          .ForeColor = &HE0E0E0
          '.DrawText "Proveedores", (Me.PrintWidth - lW) / 2, (Me.Printer.PaperHeight - lH) / 2, lW, lH
          .DrawText "ELIMINADAS", 3.5 * 1440, 2.5 * 1440, 7.2 * 1440, 4 * 1440
      End With
   End If
End Sub