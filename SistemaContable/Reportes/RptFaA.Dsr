VERSION 5.00
Begin {9EB8768B-CDFA-44DF-8F3E-857A8405E1DB} RptFaA 
   Caption         =   "SIGC - RptFaA (ActiveReport)"
   ClientHeight    =   10815
   ClientLeft      =   0
   ClientTop       =   285
   ClientWidth     =   20400
   _ExtentX        =   35983
   _ExtentY        =   19076
   SectionData     =   "RptFaA.dsx":0000
End
Attribute VB_Name = "RptFaA"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False


Private Sub ActiveReport_ReportStart()
   Me.Toolbar.Tools.AddEx("&PDF").Tooltip = "Exportar a PDF"
   Me.Toolbar.Tools.AddEx("&Excel").Tooltip = "Exportar a Excel"
   If Len(ParCerosCant) > 0 Then
      txthis_cantidad.OutputFormat = "0." & ParCerosCant
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
   Menu.Dialog1.FileName = "Comprobante.pdf"
   Menu.Dialog1.ShowSave
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
   Menu.Dialog1.FileName = "Comprobantes.xls"
   Menu.Dialog1.ShowSave
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

Private Sub Detail_BeforePrint()
   On Error Resume Next
   
   If txthis_codtex.Text = "0" Then txthis_codtex.Text = ""
   If txthis_codnum.Text = "88888888" Then
      txthis_codnum.Text = ""
      Field18.Text = ""
   End If
   txthis_dtoCondA = IIf((txthis_dtoCondA) = "", 0, txthis_dtoCondA)
   txthis_dtoCondB = IIf((txthis_dtoCondB) = "", 0, txthis_dtoCondB)
   txthis_dtoCondC = IIf((txthis_dtoCondC) = "", 0, txthis_dtoCondC)
   txthis_dtoCondD = IIf((txthis_dtoCondD) = "", 0, txthis_dtoCondD)
   txtDtos.Text = IIf((txthis_dtoa = 0), "", Format(txthis_dtoa, "0.00")) _
   & IIf((txthis_dtob = 0), "", " " & Format(txthis_dtob, "0.00")) _
   & IIf((txthis_dtoc = 0), "", " " & Format(txthis_dtoc, "0.00")) _
   & IIf((txthis_dtod = 0), "", " " & Format(txthis_dtod, "0.00")) _
   & IIf((txthis_dtoe = 0), "", " " & Format(txthis_dtoe, "0.00")) _
   & IIf((txthis_dtof = 0), "", " " & Format(txthis_dtof, "0.00")) _
   & IIf((txthis_dtoCondA = 0), "", " " & Format(txthis_dtoCondA, "0.00")) _
   & IIf((txthis_dtoCondB = 0), "", " " & Format(txthis_dtoCondB, "0.00")) _
   & IIf((txthis_dtoCondC = 0), "", " " & Format(txthis_dtoCondC, "0.00")) _
   & IIf((txthis_dtoCondD = 0), "", " " & Format(txthis_dtoCondD, "0.00")) _
   & IIf((txthis_dtoctdo = 0), "", " " & Format(txthis_dtoctdo, "0.00"))
   
   CtrlCad txthis_articulo
   
   If CDec(txthis_preclista) = 0 Then txthis_preclista.Text = ""
   
   If CDec(Trim(txthis_cantidad.Text)) = 0 Then
      txthis_cantidad.Text = ""
      txthis_aliva.Text = ""
      txthis_punitario.Text = ""
      txthis_total.Text = ""
      txthis_preclista.Text = ""
      txtDtos.Text = ""
   End If
   
End Sub

Private Sub PageHeader_Format()
   CtrlCad txtvta_cliente, 0
   
End Sub
